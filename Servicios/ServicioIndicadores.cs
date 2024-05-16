using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioIndicadores
    {
        public Entidades.Indicadores GetListadoUF()
        {
            string apiUrl = "http://localhost:12024/api/Datos/GetIndicadores/uf";

            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");

            var indicadores = JsonConvert.DeserializeObject<Entidades.Indicadores>(webClient.DownloadString(apiUrl));

            return indicadores;
        }
    }
}
