using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Diagnostics;
using WebApplication1.Models;
using static WebApplication1.Util.VariableConexionPostgreSQL;
using WebApplication1.Models.Conexiones;

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
            NpgsqlCommand consulta = new NpgsqlCommand();
            conexionGenerada = conexionPostgreSQL.GeneraConexion(HOST, PORT, DB, USER, PASS);
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Estado conexión generada: " + estadoGenerada);

            //Se define la consulta a realizar y se guarda el resultado
            try
            {

                consulta = new NpgsqlCommand("SELECT * FROM \"proyectoEclipse\".\"alumnos\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();
                while (resultadoConsulta.Read())
                {

                    Console.Write("{0}\t{1}\t{2}\t{3} \n",
                        resultadoConsulta[0], resultadoConsulta[1], resultadoConsulta[2], resultadoConsulta[3]);

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