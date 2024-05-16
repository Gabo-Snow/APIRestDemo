using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIRestDemo.Controllers
{
    public class DatosController : ApiController
    {
        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}


        public IHttpActionResult Get()
        {
            string apiUrl = "https://www.feriadosapp.com/api/holidays.json";

            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");

            //var feriados = webClient.DownloadString(apiUrl);
            var feriados = JsonConvert.DeserializeObject<Models.Feriados>(webClient.DownloadString(apiUrl));

            return Ok(feriados);
        }

        public IHttpActionResult GetFarmacias(int id)
        {
            string apiUrl = "https://farmanet.minsal.cl/maps/index.php/ws/getLocalesTurnos";

            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");

            var farmacias = webClient.DownloadString(apiUrl);

            return Ok(farmacias);
        }

        [Route("api/Datos/GetIndicadores/{tipoIndicador}")]
        public IHttpActionResult GetIndicadores(string tipoIndicador)
        {
            string apiUrl = "https://mindicador.cl/api";

            if (tipoIndicador.ToLower().Equals("uf"))
            {
                apiUrl = $"https://mindicador.cl/api/{tipoIndicador.ToLower()}";
            }

            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");

            var indicadores = JsonConvert.DeserializeObject<Models.Indicadores>(webClient.DownloadString(apiUrl));

            return Ok(indicadores); 
        }
       
    }
}