using KeltonAndrea.Control;
using KeltonAndrea.DAO;
using KeltonAndrea.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KeltonAndrea.ViewModel
{
    public class Compatibilidade
    {
        public Compatibilidade()
        {
            PacientesCadastrados = new ObservableCollection<Paciente>();
            ToolbarSairCommand = new Command(ExecuteToolbarSairCommand);
            ToolbarVoltarCommand = new Command(ExecuteToolbarVoltarCommand);
            OutraBusca = new Command(RealizarOutraBusca);
        }

        public Command OutraBusca { get; }
        public Command ToolbarSairCommand { get; }
        public Command ToolbarVoltarCommand { get; }
        public ObservableCollection<Paciente> PacientesCadastrados { get; set; }

        public PacienteDB _database;
        public Paciente resultadoPaciente { get; set; }


        public async Task CompatibilidadeImunologica()
        {

            try
            {
                PacienteDB usPac = new PacienteDB();
                _database = new PacienteDB();
                var Identificador = Application.Current.Properties["Identificador"] as string;
                

                Application.Current.Properties["Identificador"] = "";
                resultadoPaciente = _database.GetPacienteIdentificador(Identificador);
                if (_database.GetPacienteNome(Identificador))
                {
                    var pacientes = _database.GetCompatibilidade(resultadoPaciente);
                    if (pacientes == null)
                    {
                        await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Ops", "Não existe paciente compatível.", "OK");
                        await Application.Current.MainPage.Navigation.PushAsync(new BuscaView());
                    }
                    else
                    {
                        foreach (var item in pacientes)
                        {
                            PacientesCadastrados.Add(item);
                        }
                    }
                }
                //if (resultadoPaciente == null)
                //{
                    //await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Ops", "Não existe paciente cadastrado com esse identificador.", "OK");
                //    await Application.Current.MainPage.Navigation.PushAsync(new TelaPrincipal());
                //}
                else
                {
                    if (string.IsNullOrEmpty(Identificador.ToString()))
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new TelaPrincipal());
                    }
                }
            }
            catch (System.Exception)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Ops", "No algoritmo de compatibilidade.", "OK");
            }
        }


        public async void ExecuteToolbarSairCommand()
        {

            await Application.Current.SavePropertiesAsync();
            if (Application.Current.MainPage.Navigation.NavigationStack.Last().GetType() != typeof(TelaInicial))
            {
                await Application.Current.MainPage.Navigation.PushAsync(new TelaInicial());
            }
        }
        public async void ExecuteToolbarVoltarCommand()
        {
            await Application.Current.SavePropertiesAsync();
            if (Application.Current.MainPage.Navigation.NavigationStack.Last().GetType() != typeof(TelaPrincipal))
            {
                await Application.Current.MainPage.Navigation.PushAsync(new TelaPrincipal());
            }
        }
        private async void RealizarOutraBusca()
        {
            try
            {
                //await Application.Current.SavePropertiesAsync();
                if (Application.Current.MainPage.Navigation.NavigationStack.Last().GetType() != typeof(BuscaView))
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new BuscaView());
                }

            }
            catch (System.Exception error)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                   "Error!", error.Message, "OK");
            }
        }
    }
}