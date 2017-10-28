using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeltonAndrea.Control
{
    public class HLA_I
    {

        public int ID { get; set; }

        public string Descricao { get; set; }
        public string Subtipo { get; set; }

        public override string ToString()
        {
            return string.Format("[Person: ID={0}, Descricao={1}, Subtipo={2} ]", ID, Descricao, Subtipo);
        }
    }
}

