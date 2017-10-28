using KeltonAndrea.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KeltonAndrea.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel ViewModel => BindingContext as LoginViewModel;

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }


        private void CarregarValor(object sender, EventArgs e)
        {
            try
            {

                if (Application.Current.Properties.ContainsKey("org") &&
                    Application.Current.Properties.ContainsKey("user") &&
                    Application.Current.Properties.ContainsKey("senha"))
                {
                    Organizacao.Text = Application.Current.Properties["org"] as string;
                    Usuario.Text = Application.Current.Properties["user"] as string;
                    Senha.Text = Application.Current.Properties["senha"] as string;
                }
            }
            catch (Exception excep)
            {
                //Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                //   "Ops", "ocorreu algum erro ao carregar seus dados. Tente novamente.", excep.StackTrace, "OK");
            }
        }
    }
}