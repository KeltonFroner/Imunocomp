
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeltonAndrea.Control
{
    public class Paciente
    {
        public int ID { get; set; }

        public string Identificador { get; set; }

        public string Tipo { get; set; }

        public string Idade { get; set; }

        public string ABO { get; set; }

        public string Orgao { get; set; }

        public string Hla_a1 { get; set; }

        public string Hla_a2 { get; set; }

        public string Hla_b1 { get; set; }

        public string Hla_b2 { get; set; }

        public string Hla_c1 { get; set; }

        public string Hla_c2 { get; set; }

        public string Hla_dq1 { get; set; }

        public string Hla_dq2 { get; set; }

        public string Hla_dp1 { get; set; }
        
        public string Hla_dp2 { get; set; }

    }
}
