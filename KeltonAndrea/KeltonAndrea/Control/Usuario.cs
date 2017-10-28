using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net.Attributes;

namespace KeltonAndrea.Control
{
    public class Usuario
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string NomeUsuario { get; set; }

        public string SenhaUsuario { get; set; }

        public string Instituicao { get; set; }
                
    }
}
