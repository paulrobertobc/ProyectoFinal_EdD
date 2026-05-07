using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_EdD
{
    //aqui debemos heredar de IDisposable para liberar recursos del sistema que va a estar usando el reproductor por naaudio,
    //es necesario llamarlo 
    public class ReproductorMP3 : IDisposable
    {
        private AudioFileReader lector;
        private WaveOutEvent salida;
        private readonly object sync = new object();

        public event EventHandler PlaybackStopped;//este evento lo ponemos para cuando haya parado una cancion

        public bool Reproduciendo => salida != null && salida.PlaybackState == PlaybackState.Playing;//estos booleanos para saber si reproduce o no
        public bool Pausado => salida != null && salida.PlaybackState == PlaybackState.Paused;

        public void Reproducir(string ruta)
        {
            lock (sync)
            {
                Detener();

                lector = new AudioFileReader(ruta);
                salida = new WaveOutEvent();
                salida.Init(lector);
                salida.PlaybackStopped += Salida_PlaybackStopped;
                salida.Play();
            }
        }

        private void Salida_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            // No continuar la reproducción con la siguiente canción si hubo un error en la reproducción
            if (e != null && e.Exception != null)
            {
                try { System.Diagnostics.Debug.WriteLine("Playback stopped with exception: " + e.Exception); } catch { }
                return;
            }

            // Solo notificar al consumidor si realmente llegó al final del stream
            lock (sync)
            {
                try
                {
                    if (lector != null && lector.Length > 0)
                    {
                        // Considerar que llegó al final si la posición está muy cerca del final
                        long remaining = lector.Length - lector.Position;
                        if (remaining > 1024) // aún queda datos -> no disparar
                        {
                            System.Diagnostics.Debug.WriteLine("Playback stopped before end; ignoring auto-advance (remaining bytes: " + remaining + ")");
                            return;
                        }
                    }
                }
                catch { }
            }

            PlaybackStopped?.Invoke(this, EventArgs.Empty);
        }

        public void Pausar()
        {
            lock (sync)
            {
                if (salida != null && salida.PlaybackState == PlaybackState.Playing)
                    salida.Pause();
            }
        }

        public void Continuar()
        {
            lock (sync)
            {
                if (salida != null && salida.PlaybackState == PlaybackState.Paused)
                    salida.Play();
            }
        }

        public void Detener()
        {
            if (salida != null)
            {
                // Evitar que el evento PlaybackStopped se dispare cuando detenemos manualmente
                salida.PlaybackStopped -= Salida_PlaybackStopped;
                try
                {
                    salida.Stop();
                }
                catch { }
                salida.Dispose();
                salida = null;
            }

            if (lector != null)
            {
                lector.Dispose();
                lector = null;
            }
        }
        public Image ObtenerCaratula(string rutaArchivo)//aqui vamos a extraer la caratula del mp3 usando taglib
        {
            try
            {
                using (var file = TagLib.File.Create(rutaArchivo))
                {
                    if (file.Tag.Pictures != null && file.Tag.Pictures.Length > 0)
                    {
                        var bin = file.Tag.Pictures[0].Data.Data;
                        using (MemoryStream ms = new MemoryStream(bin))
                        {
                            return Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        return null; // Esto por si no tiene carátula
                    }
                }
            }
            catch
            {
                return null; // Esto por si el mp3 esta corrupto o no tiene metadatos
            }
        }

        public void Dispose() => Detener();
    }
}
