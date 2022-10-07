namespace WebApplication1.Models.DTOs
{
    public class AlumnoDTO
    {
        public int id_alumno { get; private set; }
        //Al añadir al tipo el símbolo ? se admite null en el campo al salir del constructor.
        public string? nombre { get; private set; }
        public string? apellidos { get; private set; }
        public string? email { get; private set; }

        //Constructor AlumnoDTO completo
        public AlumnoDTO(int Id, string Nombre, string Apellidos, string Email)
        {
            id_alumno = Id;
            nombre = Nombre;
            apellidos = Apellidos;
            email = Email;
        }

    }
}
