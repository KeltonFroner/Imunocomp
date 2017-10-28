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
    public partial class ListaUsuariosView : ContentPage
    {
        private UsuariosCadastradosViewModel ViewModel => BindingContext as UsuariosCadastradosViewModel;
        public ListaUsuariosView()
        {
            InitializeComponent();
            BindingContext = new UsuariosCadastradosViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel != null)
                await ViewModel.CarregarUsuarios();
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