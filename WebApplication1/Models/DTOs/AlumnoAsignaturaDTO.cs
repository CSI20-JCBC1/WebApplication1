namespace WebApplication1.Models.DTOs
{
    public class AlumnoAsignaturaDTO
    {
        public string? nombre { get; private set; }
        public string? apellidos { get; private set; }
        public string? nombreAs { get; private set; }

        //Constructor AlumnoDTO completo
        public AlumnoAsignaturaDTO(string Nombre, string Apellidos, string NombreAs)
        {
            nombre = Nombre;
            apellidos=Apellidos;
            nombreAs = NombreAs;
     
        }
    }
}
