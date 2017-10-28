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
    public class PacientesCadastradosViewModel : BaseViewModel
    {
        public PacientesCadastradosViewModel()
        {
            PacientesCadastrados = new ObservableCollection<Paciente>();
            CadastrarCommand = new Command(AdicionarOutraConta);
        }
        public ObservableCollection<Paciente> PacientesCadastrados { get; set; }
        public Command CadastrarCommand { get; }

        public PacienteDB _database;

        public async Task CarregarUsuarios()
        {
            try
            {
                IsBusy = true;
                PacienteDB us = new PacienteDB();
                _database = new PacienteDB();
                var pacientes = _database.GetPaciente();

                foreach (var item in pacientes)
                {
                    PacientesCadastrados.Add(item);
                }                
            }
            catch (Exception error)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                      "Error!", error.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var contato = e.SelectedItem as Usuario;
            await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Item Selecionado (SelectedItem) ", contato.NomeUsuario, "Ok");
        }

        private async void AdicionarOutraConta()
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
    }
}
