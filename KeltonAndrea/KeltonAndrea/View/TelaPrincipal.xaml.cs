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
    public partial class TelaPrincipal : ContentPage
    {
        private TelaPrincipalViewModel ViewModel => BindingContext as TelaPrincipalViewModel;
        public TelaPrincipal()
        {
            InitializeComponent();
            BindingContext = new TelaPrincipalViewModel();
        }
    }
}