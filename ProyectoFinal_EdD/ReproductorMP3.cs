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

        public event EventHandler PlaybackStopped;

        public bool Reproduciendo => salida != null && salida.PlaybackState == PlaybackState.Playing;
        public bool Pausado => salida != null && salida.PlaybackState == PlaybackState.Paused;

        public TimeSpan Posicion => lector?.CurrentTime ?? TimeSpan.Zero;
        public TimeSpan Duracion => lector?.TotalTime ?? TimeSpan.Zero;

        public void Reproducir(string ruta)
        {
            Detener();

            lector = new AudioFileReader(ruta);
            salida = new WaveOutEvent();
            salida.Init(lector);
            salida.PlaybackStopped += Salida_PlaybackStopped;
            salida.Play();
        }

        private void Salida_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            PlaybackStopped?.Invoke(this, EventArgs.Empty);
        }

        public void Pausar()
        {
            if (salida != null && salida.PlaybackState == PlaybackState.Playing)
                salida.Pause();
        }

        public void Continuar()
        {
            if (salida != null && salida.PlaybackState == PlaybackState.Paused)
                salida.Play();
        }

        public void Detener()
        {
            if (salida != null)
            {
                salida.Stop();
                salida.PlaybackStopped -= Salida_PlaybackStopped;
                salida.Dispose();
                salida = null;
            }

            if (lector != null)
            {
                lector.Dispose();
                lector = null;
            }
        }
        public Image ObtenerCaratula(string rutaArchivo)
        {
            try
            {
                var file = TagLib.File.Create(rutaArchivo);

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
                    return null; // No tiene carátula
                }
            }
            catch
            {
                return null; // Archivo corrupto o sin metadatos
            }
        }

        public void Dispose() => Detener();
    }
}
