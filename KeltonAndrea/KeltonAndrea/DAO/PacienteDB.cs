using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using Xamarin.Forms;
using KeltonAndrea.Control;

namespace KeltonAndrea.DAO
{
    public class PacienteDB
    {
        private SQLiteConnection _sqlconnection;

        public PacienteDB()
        {
            //Getting conection and Creating table  
            _sqlconnection = DependencyService.Get<ISQLite>().GetConnection();
            _sqlconnection.CreateTable<Paciente>();
        }

        //Get all Usuario  
        public IEnumerable<Paciente> GetPaciente()
        {
            return (from t in _sqlconnection.Table<Paciente>() select t).ToList();
        }

        //Get specific Usuario  
        public Paciente GetPaciente(int id)
        {
            return _sqlconnection.Table<Paciente>().FirstOrDefault(t => t.ID == id);
        }

        public bool GetPacienteNome(string nome)
        {
            if (_sqlconnection.Table<Paciente>().FirstOrDefault(t => t.Identificador == nome)!= null)
            {
                return true;
            }
            return false;
        }

        public Paciente GetPacienteIdentificador(string identificador)
        {
            return _sqlconnection.Table<Paciente>().FirstOrDefault(t => t.Identificador == identificador);
        }

        public Paciente GetOrgao(Paciente paciente)
        {            
            var org = paciente.Orgao;
            
            return _sqlconnection.Table<Paciente>().FirstOrDefault(t => t.Orgao == org);
        }

        public IEnumerable<Paciente> GetCompatibilidade(Paciente paciente)
        {
            var orgao = paciente.Orgao;
            var tipo = paciente.Tipo;

            return (from c in _sqlconnection.Table<Paciente>()
                    where c.Orgao.Equals(orgao)
                    && c.Tipo != tipo
                    select c).ToList();
        }


        //Delete specific usuario  
        public void DeletePaciente(int id)
        {
            _sqlconnection.Delete<Paciente>(id);
        }

        //Add new usuario to DB  
        public async System.Threading.Tasks.Task AddPacienteAsync(Paciente paciente)
        {
            if (string.IsNullOrEmpty(paciente.Identificador) || string.IsNullOrEmpty(paciente.Idade) || string.IsNullOrEmpty(paciente.Tipo))
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                  "Atenção", "Os campos 'Identificador', 'Idade' e 'Tipo' devem ser preenchidos obrigatóriamente!", "OK");
            }
            else
            {
                if (GetPacienteNome(paciente.Identificador) == false)
                {
                    _sqlconnection.Insert(paciente);
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                     "Atenção", "Paciente cadastrado com sucesso!", "OK");
                }
                else
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                  "Atenção", "O identificador de paciente já foi utilizado, escolha outro identificador", "OK");
                    paciente.Identificador = "";
                }
            }
        }
    }
}