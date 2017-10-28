using KeltonAndrea.Control;
using KeltonAndrea.DAO;
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
    public partial class BuscaView : ContentPage
    {
        private BuscaViewModel ViewModel => BindingContext as BuscaViewModel;
        public BuscaView()
        {
            InitializeComponent();
            BindingContext = new BuscaViewModel();
        }
        private void Sair(object sender, EventArgs e)
        {
            Application.Current.Properties.Clear();
            Application.Current.SavePropertiesAsync();
            if (Application.Current.MainPage.Navigation.NavigationStack.Last().GetType() != typeof(TelaInicial))
            {
                Application.Current.MainPage.Navigation.PushAsync(new TelaInicial());
            }
        }
    }
}