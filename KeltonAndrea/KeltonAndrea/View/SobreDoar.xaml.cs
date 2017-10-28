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
    public partial class SobreDoar : ContentPage
    {
        public SobreDoar()
        {
            InitializeComponent();

            Label header = new Label
            {
                Text = "Saiba como doar",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            Label text = new Label
            {
                Text = "Dedicamos uma seção de nosso aplicativo para redirecionar o visitante ao site do Inca no qual o usuário pode obter maiores informações sobre doação de orgãos.",                
                HorizontalOptions = LayoutOptions.Center
                
            };
            WebView webView = new WebView
            {
                Source = new UrlWebViewSource
                {
                    Url = "http://redome.inca.gov.br/doador/como-se-tornar-um-doador/",
                },
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    text,
                    webView
                }
            };
        }
    }
}