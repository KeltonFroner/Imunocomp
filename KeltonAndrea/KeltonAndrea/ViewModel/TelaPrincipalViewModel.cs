using KeltonAndrea.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace KeltonAndrea.ViewModel
{
    public class TelaPrincipalViewModel
    {
        public TelaPrincipalViewModel()
        {
            ToolbarSairCommand = new Command(ExecuteToolbarSairCommand);
            CadastroPaciente = new Command(DirecionaCadastroPaciente);
            ListaPaciente = new Command(DirecionaListaPaciente);
            CadastroUsuario = new Command(DirecionaCadastroUsuario);
            Busca = new Command(DirecionaBusca);
            Sobre = new Command(DirecionaSobre);            
        }

        public Command ToolbarSairCommand { get; }
        public Command CadastroPaciente { get; private set; }
        public Command ListaPaciente { get; private set; }
        public Command CadastroUsuario { get; private set; }
        public Command Busca { get; private set; }
        public Command Sobre { get; private set; }

        public async void ExecuteToolbarSairCommand()
        {
            Application.Current.Properties.Clear();
            await Application.Current.SavePropertiesAsync();
            if (Application.Current.MainPage.Navigation.NavigationStack.Last().GetType() != typeof(TelaInicial))
            {
                await Application.Current.MainPage.Navigation.PushAsync(new TelaInicial());
            }
        }
        private async void DirecionaCadastroPaciente()
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new CadastroPacienteView());
            }
            catch (System.Exception error)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                   "Error!", error.Message, "OK");
            }
        }
        private async void DirecionaListaPaciente()
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ListaPaciente());
            }
            catch (System.Exception error)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                   "Error!", error.Message, "OK");
            }
        }
        private async void DirecionaCadastroUsuario()
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new CadastroUsuarioView());
            }
            catch (System.Exception error)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                   "Error!", error.Message, "OK");
            }
        }
        private async void DirecionaBusca()
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new BuscaView());
            }
            catch (System.Exception error)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                   "Error!", error.Message, "OK");
            }
        }
        private async void DirecionaSobre()
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new SobreTabbedPage());
            }
            catch (System.Exception error)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                   "Error!", error.Message, "OK");
            }
        }
    }
}