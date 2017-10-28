using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Newtonsoft.Json.Model;
using KeltonAndrea.Control;

namespace Newtonsoft.Json.UTIL
{
    public class Session
    {
        private static Session instance;

        private Session()
        {
        }

        public static Session GetInstance()
        {
            if (instance == null)
            {
                instance = new Session()
                {
                    Usuario = new Usuario() { DadosDeAcesso = new DadosDeAcesso() },
                    ConfiguracoesDeUsuarios = new List<Usuario>()
                };
            }
            return instance;
        }

        public Usuario Usuario { get; set; }

        public List<Usuario> ConfiguracoesDeUsuarios { get; set; }
    }
}
