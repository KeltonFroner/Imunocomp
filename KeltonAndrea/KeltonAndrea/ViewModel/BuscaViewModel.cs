using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeltonAndrea.View;
using KeltonAndrea.DAO;
using KeltonAndrea.Control;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace KeltonAndrea.ViewModel
{
    public class BuscaViewModel : BaseViewModel
    {

        public BuscaViewModel()
        {
            BuscarCommand = new Command(ExecuteBuscarCommand);
            ToolbarSairCommand = new Command(ExecuteToolbarSairCommand);
        }

        private string _identificador;
        public string Identificador
        {
            get { return _identificador; }
            set { SetProperty(ref _identificador, value); BuscarCommand.ChangeCanExecute(); }
        }

        public Command ToolbarSairCommand { get; }
        public Command BuscarCommand { get; }

        public PacienteDB _database { get; }

        public async void ExecuteBuscarCommand()
        {
            PacienteDB _database = new PacienteDB();

            try
            {
                if (string.IsNullOrWhiteSpace(Identificador))
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                 "Atenção", "Por favor, insira o identificador do paciente", "OK");
                }
                else
                {
                    if (_database.GetPacienteNome(_identificador))
                    {
                        Application.Current.Properties["Identificador"] = Identificador;
                        await Application.Current.SavePropertiesAsync();
                        await Application.Current.MainPage.Navigation.PushAsync(new ResultadoView());
                        Identificador = "";
                    }
                    else
                    {
                        await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                 "Atenção", "Identificador não encontrado", "OK");
                    }
                    
                }
            }
            catch (System.Exception)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Ops", "Erro nos dados de acesso. Tente novamente.", "OK");
            }
        }


        public async void ExecuteToolbarSairCommand()
        {
            Application.Current.Properties.Clear();
            await Application.Current.SavePropertiesAsync();
            if (Application.Current.MainPage.Navigation.NavigationStack.Last().GetType() != typeof(TelaInicial))
            {
                await Application.Current.MainPage.Navigation.PushAsync(new TelaInicial());
            }
        }
    }
}