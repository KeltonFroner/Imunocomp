using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeltonAndrea.Control
{
    public class DadosDeAcesso
    {
        [JsonProperty("access_token")]
        public string Token { get; set; }

        [JsonProperty("bearer")]
        public string Tipo { get; set; }

        [JsonProperty("expires_in")]
        public double Expiracao { get; set; }
    }
}

