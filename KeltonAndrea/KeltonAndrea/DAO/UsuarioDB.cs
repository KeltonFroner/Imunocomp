using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using Xamarin.Forms;
using KeltonAndrea.Control;

namespace KeltonAndrea.DAO
{
    public class UsuarioDB
    {
        private SQLiteConnection _sqlconnection;

        public UsuarioDB()
        {
            //Getting conection and Creating table  
            _sqlconnection = DependencyService.Get<ISQLite>().GetConnection();
            _sqlconnection.CreateTable<Usuario>();
        }

        //Get all Usuario  
        public IEnumerable<Usuario> GetUsuario()
        {
            return (from t in _sqlconnection.Table<Usuario>() select t).ToList();
        }

        //Get specific Usuario  
        public Usuario GetUsuario(int id)
        {
            return _sqlconnection.Table<Usuario>().FirstOrDefault(t => t.ID == id);
        }


        //Pegar Usuario especifico pelo nome 
        public bool GetUsuarioNome(string nome)
        {
            if ((_sqlconnection.Table<Usuario>().FirstOrDefault(t => t.NomeUsuario == nome)) == null)
            {
                return false;
            }

            return true;
        }

        public bool GetDadosAcesso(Usuario usuario)
        {
            bool teste = false;
            var user = usuario.NomeUsuario;
            var org = usuario.Instituicao;
            var pass = usuario.SenhaUsuario;
            var query = from c in _sqlconnection.Table<Usuario>()
                            where c.NomeUsuario.Equals(user)
                            && c.Instituicao.Equals(org)
                            && c.SenhaUsuario.Equals(pass)
                            select c;

            return query.Count().Equals(0) ? false : true;           
        }
       

        //Delete specific usuario  
        public void DeleteUsuario(int id)
        {
            _sqlconnection.Delete<Usuario>(id);
        }

        //Add new usuario to DB  
        public void AddUsuario(Usuario usuario)
        {
            _sqlconnection.Insert(usuario);
        }
    }
}