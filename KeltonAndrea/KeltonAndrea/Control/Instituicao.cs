using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeltonAndrea.Control
{
    public class Instituicao
    {
        public int ID { get; set; }

        public string Nome { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public Usuario usuario { get; set; }
    }
}
