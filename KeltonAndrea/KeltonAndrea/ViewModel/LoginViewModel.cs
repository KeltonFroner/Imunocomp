using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using KeltonAndrea.View;
using KeltonAndrea.DAO;
using KeltonAndrea.Control;

namespace KeltonAndrea.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            LoginCommand = new Command(ExecuteLoginCommand);
            //SalvarDadosAcessoCommand = new Command(SalvarValor_OnClick);
            //ConfigurarCamposCommand = new Command(ConfigurarCampos);
        }


        private string _organizacaoUsuario;
        public string OrganizacaoUsuario
        {
            get { return _organizacaoUsuario; }
            set { SetProperty(ref _organizacaoUsuario, value); LoginCommand.ChangeCanExecute(); }
        }

        private string _Nomeusuario;
        public string NomeUsuario
        {
            get { return _Nomeusuario; }
            set { SetProperty(ref _Nomeusuario, value); LoginCommand.ChangeCanExecute(); }
        }

        private string _senhaUsuario;
        public string SenhaUsuario
        {
            get { return _senhaUsuario; }
            set { SetProperty(ref _senhaUsuario, value); LoginCommand.ChangeCanExecute(); }
        }

        private string _servidor;
        public string Servidor
        {
            get { return _servidor; }
            set { SetProperty(ref _servidor, value); LoginCommand.ChangeCanExecute(); }
        }


        public Command LoginCommand { get; }
        public Command SalvarDadosAcessoCommand { get; private set; }
        public Command ConfigurarCamposCommand { get; private set; }



        private async void ExecuteLoginCommand()
        {
            Exception error = null;

            try
            {
                UsuarioDB usbanco = new UsuarioDB();
                Usuario usModel = new Usuario();
                usModel.NomeUsuario = NomeUsuario;
                usModel.Instituicao = OrganizacaoUsuario;
                usModel.SenhaUsuario = SenhaUsuario;
                bool validacao = false;

                if (string.IsNullOrWhiteSpace(OrganizacaoUsuario) || string.IsNullOrWhiteSpace(NomeUsuario) || string.IsNullOrWhiteSpace(SenhaUsuario))
                {
                    validacao = false;
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                 "Atenção", "Por favor, insira todos os dados para continuar", "OK");
                    
                }
                else
                {
                    if (validacao == false && NomeUsuario == "Andrea" || NomeUsuario == "Kelton" && SenhaUsuario == "ufcspa")
                    {
                        validacao = true;
                        await Application.Current.MainPage.Navigation.PushAsync(new TelaPrincipal());
                        SalvarValor_OnClick();
                        
                    }
                    
                    if (validacao == false && usbanco.GetDadosAcesso(usModel) == true)
                    {
                        validacao = true;
                        await Application.Current.MainPage.Navigation.PushAsync(new TelaPrincipal());
                        SalvarValor_OnClick();
                        
                    }
                    
                    if(validacao == false)
                    {
                        await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                 "Atenção", "Dados incorretos, por favor tente novamente", "OK");
                        NomeUsuario = "";
                        OrganizacaoUsuario = "";
                        SenhaUsuario = "";   
                    }
                }
            }
            catch (System.Exception)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Ops", "Erro nos dados de acesso. Tente novamente.", "OK");
            }

            if (error != null)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                   "Error!", error.Message, "OK");
            }
        }

        public async void SalvarValor_OnClick()
        {
            try
            {
                Application.Current.Properties["org"] = OrganizacaoUsuario;
                Application.Current.Properties["user"] = NomeUsuario;
                Application.Current.Properties["senha"] = SenhaUsuario;
               
                await Application.Current.SavePropertiesAsync();
            }
            catch (Exception exep)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                   "Ops", "ocorreu algum erro ao gravar seus dados. Tente novamente.", exep.StackTrace, "OK");
            }
        }
    }
}
