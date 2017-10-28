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
    public partial class SobreTabbedPage : TabbedPage
    {
        public SobreTabbedPage()
        {
            BarBackgroundColor = Color.FromHex("#53c68c");
            this.Title = "Sobre";
            this.Children.Add(new Sobre() { Title = "Aplicativo" });
            this.Children.Add(new SobreImunologia() { Title = "Imunologia" });
            this.Children.Add(new SobreDoar() { Title = "Doe"  });
        }
    }
}