using Npgsql;

namespace WebApplication1.Models.Conexiones
{
    
        public class ConexionPostgreSQL
        {
            //MÉTODOS
            public NpgsqlConnection GeneraConexion(string host, string port,
                string db, string user, string pass)
            {
                System.Console.WriteLine("[INFORMACIÓN-GeneraPostgreSQL-GeneraConexion] Entra en GeneraConexion");

                //Se crea una nueva conexión y la cadena con los datos de conexión.
                NpgsqlConnection conexion = new NpgsqlConnection();
                var datosConexion = "Server=" + host + "; Port=" + port + "; User Id=" + user + "; Password=" + pass + "; Database=" + db;
                //var datosConexion = "Server=localhost; Port=5432; User Id=postgres; Password=pr0f3s0r; Database=EjemploInicial";
                System.Console.WriteLine(datosConexion);
                var estado = "";
                if (!string.IsNullOrWhiteSpace(datosConexion))
                {
                    try
                    {
                        conexion = new NpgsqlConnection(datosConexion);
                        conexion.Open();
                        //Se obtiene el estado de conexión para informarlo por consola
                        estado = conexion.State.ToString();
                        System.Console.WriteLine("[INFORMACIÓN-ConexionPostgreSQL-GeneraConexion] Estado conexión: " + estado);
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine("[ERROR-ConexionPostgreSQL-GeneraConexion] Error al crear conexión:" + e);
                        conexion.Close();
                    }
                }

                return conexion;

            }
        }

    
}
