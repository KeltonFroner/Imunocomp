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
    public partial class TelaInicial : ContentPage
    {
        private TelaInicioViewModel ViewModel => BindingContext as TelaInicioViewModel;
        public TelaInicial()
        {
            InitializeComponent();
            BindingContext = new TelaInicioViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.LoadView();
        }
    }
}