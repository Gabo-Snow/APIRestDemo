using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCConsumeAPI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string apiUrl = "http://localhost:12024/api/Datos/GetIndicadores/uf";

            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");

            var indicadores = JsonConvert.DeserializeObject<Models.IndicadoresModel>(webClient.DownloadString(apiUrl));

            return View(indicadores.serie);
        }

        public ActionResult GetIndicadores()
        {
            Servicios.ServicioIndicadores servicioIndicadores = new Servicios.ServicioIndicadores();
            var indicadores = servicioIndicadores.GetListadoUF();


            return View(indicadores.serie);
        }
    }
}