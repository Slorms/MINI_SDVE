using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Web;

namespace SDVE.Datos
{
    internal class RegistroVotos
    {
        private static readonly string Ruta = Path.Combine(AppContext.BaseDirectory, "Datos", "votos.csv");
        public static void RegistrarVoto(string eleccion, string centro, string carrera, string grupo, string candidato, bool registrado)
        {
            string? carpeta = Path.GetDirectoryName(Ruta);
            if (carpeta != null)
                Directory.CreateDirectory(carpeta);

            bool archivoNuevo = !File.Exists(Ruta);

            using (StreamWriter archivo = new StreamWriter(Ruta, true))
            {
                // agrega los encabezados solamente la primera vez
                if (archivoNuevo)
                {
                    archivo.WriteLine("Eleccion,Centro,Carrera,Grupo,Candidato,Registrado");
                }

                archivo.WriteLine(
                    $"{Escapar(eleccion)}," +
                    $"{Escapar(centro)}," +
                    $"{Escapar(carrera)}," +
                    $"{Escapar(grupo)}," +
                    $"{Escapar(candidato)}," +
                    $"{registrado}");
            }
        }
        private static string Escapar(string texto)
        {
            // evita problemas con comas y comillas
            if (texto.Contains("\""))
                texto = texto.Replace("\"", "\"\"");

            if (texto.Contains(",") || texto.Contains("\""))
                texto = "\"" + texto + "\"";

            return texto;
        }
    }
}