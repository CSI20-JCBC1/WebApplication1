using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Diagnostics;
using WebApplication1.Models;
using static WebApplication1.Util.VariableConexionPostgreSQL;
using WebApplication1.Models.Conexiones;
using WebApplication1.Models.DTOs;
using WebApplication1.Models.Consultas;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(ConexionPostgreSQL conexionPostgreSQL)
        {
            // Profesor

            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Entra en Index");

            //CONSTANTES
            const string HOST = VariablesConexionPostgreSQL.HOST;
            const string PORT = VariablesConexionPostgreSQL.PORT;
            const string USER = VariablesConexionPostgreSQL.USER;
            const string PASS = VariablesConexionPostgreSQL.PASS;
            const string DB = VariablesConexionPostgreSQL.DB;

            //Se genera una conexión a PostgreSQL y validamos que esté abierta fuera del método
            var estadoGenerada = "";
            NpgsqlConnection conexionGenerada = new NpgsqlConnection();
            List<AlumnoDTO> listAlumnoDTO = new List<AlumnoDTO>();

            //NpgsqlCommand consulta = new NpgsqlCommand();
            conexionGenerada = conexionPostgreSQL.GeneraConexion(HOST, PORT, DB, USER, PASS);
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Estado conexión generada: " + estadoGenerada);

            //Se realiza la consulta y se guarda una lista de alumnosDTO
            listAlumnoDTO = ConsultasPostgreSQL.ConsultaSelectPostgreSQL(conexionGenerada);
            int cont = listAlumnoDTO.Count();
            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Lista compuesta por: " + cont + " alumnos");
            foreach (AlumnoDTO alumno in listAlumnoDTO)
                System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Lista alumnos: {0} {1} {2} {3}", alumno.id_alumno,
                 alumno.nombre, alumno.apellidos, alumno.email);
            

            List<AlumnoAsignaturaDTO> listAlumnoAsignaturaDTO = new List<AlumnoAsignaturaDTO>();
            listAlumnoAsignaturaDTO = ConsultasPostgreSQL.ConsultaSelectPostgreSQL2(conexionGenerada);
            int cont2 = listAlumnoAsignaturaDTO.Count();
            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Lista compuesta por: " + cont2 + " alumnosAsignaturas");
            
            foreach(AlumnoAsignaturaDTO alumnoAs in listAlumnoAsignaturaDTO) { 
            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Lista alumnos y asignatura: {0} {1} {2}", alumnoAs.nombre,
                alumnoAs.apellidos, alumnoAs.nombreAs);
            }

            conexionGenerada.Close();
            

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}