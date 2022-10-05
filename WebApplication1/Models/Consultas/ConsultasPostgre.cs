using Npgsql;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Models.Consultas
{
    public class ConsultasPostgre
    {
        public static List<AlumnoDTO> generaConsultas(NpgsqlConnection conexionGenerada)
        {
            List<AlumnoDTO> listaAlumnos = new List<AlumnoDTO>();
            try
            {

                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"proyectoEclipse\".\"alumnos\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();
                List<AlumnoDTO> lista = new List<AlumnoDTO>();
                while (resultadoConsulta.Read())
                {

                    Console.Write("{0}\t{1}\t{2}\t{3} \n",
                        resultadoConsulta[0], resultadoConsulta[1], resultadoConsulta[2], resultadoConsulta[3]);
                    lista.Add(new AlumnoDTO(Convert.ToInt32(resultadoConsulta[1]), resultadoConsulta[1].ToString(), resultadoConsulta[2].ToString(), resultadoConsulta[3].ToString()));
                }

                System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Cierre conexión y conjunto de datos");
                conexionGenerada.Close();
                resultadoConsulta.Close();

            }
            catch (Exception e)
            {

                System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Error al ejecutar consulta: " + e);
                conexionGenerada.Close();

            }

            return listaAlumnos;
        }
    }
    
}
