using Npgsql;

namespace WebApplication1.Models.DTOs.ADTO
{
    public class ReaderAListDTO
    {
        public static List<AlumnoDTO> ReaderAListAlumnoDTO(NpgsqlDataReader resultadoConsulta)
        {
            List<AlumnoDTO> listAlumnos = new List<AlumnoDTO>();
            while (resultadoConsulta.Read())
            {
                listAlumnos.Add(new AlumnoDTO(
                    (int)Int64.Parse(resultadoConsulta[0].ToString()),
                    resultadoConsulta[1].ToString(),
                    resultadoConsulta[2].ToString(),
                    resultadoConsulta[3].ToString()
                    )
                    );

            }
            return listAlumnos;
        }

        public static List<AlumnoAsignaturaDTO> ReaderAListAlumnoAsignaturaDTO(NpgsqlDataReader resultadoConsulta)
        {
            List<AlumnoAsignaturaDTO> listAlumnos = new List<AlumnoAsignaturaDTO>();
            while (resultadoConsulta.Read())
            {
                listAlumnos.Add(new AlumnoAsignaturaDTO(
                    resultadoConsulta[0].ToString(),
                    resultadoConsulta[1].ToString(),
                    resultadoConsulta[2].ToString()
                    )
                    );

            }
            return listAlumnos;
        }




    }
}
