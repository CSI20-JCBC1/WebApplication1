using Npgsql;
using WebApplication1.Models.DTOs;
using System.Data;

namespace WebApplication1.Models.Consultas
{
    public class ConsultasPostgreSQL
    {
        public static List<AlumnoDTO> ConsultaSelectPostgreSQL(NpgsqlConnection conexionGenerada)
        {
            List<AlumnoDTO> listAlumnos = new List<AlumnoDTO>();
            try
            {
                //Se define y ejecuta la consulta Select
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"proyectoEclipse\".\"alumnos\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                //Paso de DataReader a lista de alumnoDTO
                listAlumnos = DTOs.ADTO.ReaderAListDTO.ReaderAListAlumnoDTO(resultadoConsulta);
                int cont = listAlumnos.Count();
                System.Console.WriteLine("[INFORMACIÓN-ConsultasPostgreSQL-ConsultaSelectPostgreSQL] Lista compuesta por: " + cont + " alumnos");

                System.Console.WriteLine("[INFORMACIÓN-ConsultasPostgreSQL-ConsultaSelectPostgreSQL] Cierreconjunto de datos");
                
                resultadoConsulta.Close();

            }
            catch (Exception e)
            {

                System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Error al ejecutar consulta: " + e);
                conexionGenerada.Close();

            }
            return listAlumnos;
        }

        public static List<AlumnoAsignaturaDTO> ConsultaSelectPostgreSQL2(NpgsqlConnection conexionGenerada)
        {
            List<AlumnoAsignaturaDTO> listAlumnoAsignatura = new List<AlumnoAsignaturaDTO>();
            try
            {
                //Se define y ejecuta la consulta Select
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT al.nombre, al.apellidos,asi.nombre FROM \"proyectoEclipse\".\"alumnos\" al INNER JOIN \"proyectoEclipse\".rel_alumn_asig r ON al.id_alumno = r.id_alumno\r\n    INNER JOIN \"proyectoEclipse\".asignaturas asi ON r.id_asignatura = asi.id_asignatura", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                //Paso de DataReader a lista de alumnoDTO
                listAlumnoAsignatura = DTOs.ADTO.ReaderAListDTO.ReaderAListAlumnoAsignaturaDTO(resultadoConsulta);
                int cont = listAlumnoAsignatura.Count();
                System.Console.WriteLine("[INFORMACIÓN-ConsultasPostgreSQL-ConsultaSelectPostgreSQL] Lista compuesta por: " + cont + " alumnos con asignaturas");

                System.Console.WriteLine("[INFORMACIÓN-ConsultasPostgreSQL-ConsultaSelectPostgreSQL] Cierre conjunto de datos");
                
                resultadoConsulta.Close();

            }
            catch (Exception e)
            {

                System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Error al ejecutar consulta: " + e);
                conexionGenerada.Close();

            }
            return listAlumnoAsignatura;
        }



    }

}
