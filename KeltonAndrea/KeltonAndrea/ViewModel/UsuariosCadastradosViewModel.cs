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
   public  class UsuariosCadastradosViewModel : BaseViewModel
    {
        public UsuariosCadastradosViewModel()
        {
            UsuariosCadastrados = new ObservableCollection<Usuario>();
            CadastrarCommand = new Command(DirecionaCadastroUsuario);
            //ToolbarSairCommand = new Command(ExecuteToolbarSairCommand);
        }


        //public Command ToolbarSairCommand { get; }
        public ObservableCollection<Usuario> UsuariosCadastrados { get; set; }
        public Command CadastrarCommand { get; }

        public UsuarioDB _database;

        public async Task CarregarUsuarios()
        {
            try
            {
                IsBusy = true;
                UsuarioDB us = new UsuarioDB();
                _database = new UsuarioDB();
                var usuarios = _database.GetUsuario();
                                
                foreach (var item in usuarios)
                {
                    UsuariosCadastrados.Add(item);
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

        private async void DirecionaCadastroUsuario()
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new TelaPrincipal());
            }
            catch (System.Exception error)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                   "Error!", error.Message, "OK");
            }
        }
    }
}
