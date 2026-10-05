using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SDVE.Conteo
{
    internal class ProcesadorVotos
    {
        // creamos metodo para calcular las estadisticas de la eleccion
        public Estadisticas CalcularEstadisticas(int registrados, int votantes)
        {
            // verificamos que las cantidades sean validas
            if (registrados < 0 || votantes < 0 || registrados < votantes)
            {
                throw new ArgumentException("La cantidad de registrados o votantes no es valida.");
            }

            // creamos un objeto de la clase Estadisticas
            Estadisticas datos = new Estadisticas();

            // asignamos los valores a las propiedades del objeto
            datos.Registrados = registrados;
            datos.Votantes = votantes;
            datos.Abstenciones = registrados - votantes;

            // se calcula la participacion y el abstencionismo
            if (registrados > 0)
            {
                datos.Participacion = (double)votantes / registrados * 100;
                datos.Abstencionismo = (double)datos.Abstenciones / registrados * 100;
            }
            return datos;
        }

        // creamos un metodo para agrupar las estadisticas
        public List<Estadisticas> Agrupar(List<Estadisticas> lista, string tipo)
        {
            // verificamos que la lista no sea nula
            if (lista == null)
            {
                throw new ArgumentNullException(nameof(lista));
            }

            // verificamos que el tipo de agrupacion sea valido
            if (tipo != "Grupo" && tipo != "Carrera" && tipo != "Centro")
            {
                throw new ArgumentException("El tipo de agrupacion no es valido.");
            }

            //agrupamos los datos por eleccion, centro, carrera o grupo
            var grupos = lista.GroupBy(d => new { d.Eleccion, d.Centro, Carrera = tipo == "Centro" ? "" : d.Carrera, Grupo = tipo == "Grupo" ? d.Grupo : "" });
            List<Estadisticas> resultado = new List<Estadisticas>(); // crea una lista para guardar los resultados

            // recorre cada agrupacion
            foreach (var grupo in grupos)
            {
                int registrados = 0;
                int votantes = 0;

                //suma los registros y votantes de cada grupo
                foreach (Estadisticas dato in grupo)
                {
                    registrados = checked(registrados + dato.Registrados);
                    votantes = checked(votantes + dato.Votantes);
                }

                //calcula las estadisticas con el metodo CalcularEstadisticas
                Estadisticas datos = CalcularEstadisticas(registrados, votantes);
               
                //asigna los datos de la agrupacion
                datos.Eleccion = grupo.Key.Eleccion;
                datos.Centro = grupo.Key.Centro;
                datos.Carrera = grupo.Key.Carrera;
                datos.Grupo = grupo.Key.Grupo;

                resultado.Add(datos);
            }
            return resultado;
        }

        public List<ResultadoCandidato> ContarVotos(List<ResultadoCandidato> lista)
        {
            if(lista == null)
            {
                throw new ArgumentNullException(nameof(lista));
            }
            List<ResultadoCandidato> resultados = new List<ResultadoCandidato>();

            foreach (ResultadoCandidato dato in lista)
            { 
                if (dato.Votos < 0)
                {
                    throw new ArgumentException("La cantidad de votos no puede ser negativa.");
                }

                ResultadoCandidato? encontrado = null;

                foreach (ResultadoCandidato resultado in resultados)
                {
                    if (resultado.Eleccion == dato.Eleccion && resultado.Centro == dato.Centro && resultado.Carrera == dato.Carrera 
                        && resultado.Grupo == dato.Grupo && resultado.Candidato == dato.Candidato && resultado.Registrado == dato.Registrado)
                    {
                        encontrado = resultado;
                        break;
                    }
                }

                if (encontrado == null)
                {
                    encontrado = new ResultadoCandidato();

                    encontrado.Eleccion = dato.Eleccion;
                    encontrado.Centro = dato.Centro;
                    encontrado.Carrera = dato.Carrera;
                    encontrado.Grupo = dato.Grupo;
                    encontrado.Candidato = dato.Candidato;
                    encontrado.Registrado = dato.Registrado;

                    resultados.Add(encontrado);
                }
                encontrado.Votos = checked(encontrado.Votos + dato.Votos);
            }
            return resultados;
        }

        public List<ResultadoCandidato> AgruparVotos(List<ResultadoCandidato> lista, string tipo)
        {
            if (lista == null)
            {
                throw new ArgumentNullException(nameof(lista));
            }

            if (tipo != "Grupo" && tipo != "Carrera" && tipo != "Centro")
            {
                throw new ArgumentException("El tipo de agrupacion no es valido.");
            }

            List<ResultadoCandidato> datos = new List<ResultadoCandidato>();

            foreach (ResultadoCandidato dato in lista)
            {
                ResultadoCandidato nuevo = new ResultadoCandidato();

                nuevo.Eleccion = dato.Eleccion;
                nuevo.Centro = dato.Centro;
                nuevo.Carrera = tipo == "Centro" ? "" : dato.Carrera;
                nuevo.Grupo = tipo == "Grupo" ? dato.Grupo : "";
                nuevo.Candidato = dato.Candidato;
                nuevo.Registrado = dato.Registrado;
                nuevo.Votos = dato.Votos;

                datos.Add(nuevo);
            }
            return ContarVotos(datos);
        }

        public double CalcularPorcentaje(int votos, int totalVotos)
        {
            if (votos < 0 || totalVotos < 0 || votos > totalVotos)
            {
                throw new ArgumentException("La cantidad de votos o el total de votos no es valida.");
            }
            
            if (totalVotos == 0)
            {
                return 0;
            }

            double porcentaje = (double)votos / totalVotos * 100;

            return Math.Round(porcentaje, 2);
        }

        public int ContarNoRegistrados(List<ResultadoCandidato> lista)
        {
            if (lista == null)
            {
                throw new ArgumentNullException(nameof(lista));
            }
            int total = 0;
            foreach (ResultadoCandidato dato in lista)
            {
                if (dato.Votos < 0)
                {
                    throw new ArgumentException("La cantidad de votos no puede ser negativa.");
                }

                if (!dato.Registrado)
                {
                    total = checked(total + dato.Votos);
                }
            }
            return total;
        }
    }
}