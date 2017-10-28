
using KeltonAndrea.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace KeltonAndrea.ViewModel
{
    public class TelaInicioViewModel : BaseViewModel
    {
        public TelaInicioViewModel()
        {

        }

        public async Task LoadView()
        {
            try
            {
                IsBusy = true;


                if (Application.Current.Properties.ContainsKey("user"))
                {
                    if (Application.Current.MainPage.Navigation.NavigationStack.Last().GetType() != typeof(TelaPrincipal))
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new TelaPrincipal());
                    }
                }
                else
                {
                    if (Application.Current.MainPage.Navigation.NavigationStack.Last().GetType() != typeof(LoginPage))
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                    }

                }

                IsBusy = false;
            }
            catch (Exception ex)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                   "Ops!", "Ocorreu uma ação inesperada:\n " + ex.Message + ex.StackTrace + ex.Source + ex.Data + ex.HelpLink, "OK");
            }
        }
    }
}
