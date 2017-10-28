using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using KeltonAndrea.Control;
using KeltonAndrea.Model;

namespace KeltonAndrea.ViewModel
{
   public class CadastroPacienteViewModel : BaseViewModel
    {

        private StackLayout _myStackLayout;

        public StackLayout MyStackLayout
        {
            get { return _myStackLayout; }
            set { SetProperty(ref _myStackLayout, value); }
        }

        public CadastroPacienteViewModel()
        {
            MyStackLayout = new StackLayout();
        }


        public async Task LoadView()
        {

            try
            {
                IsBusy = true;

                var Content = new ContentPage();



                #region HLA-A
                var LabelHLAI = new Label { Text = "HLA-A" };
                var lista_HLA_I_A = new List<HLA_I>();
                for (var i = 0; i < 10; i++) { lista_HLA_I_A.Add(new HLA_I { Descricao = $"{i + 1}" }); }

                var picker_HLA_I_A_alelo1 = new Picker { Title = "Alelo 1" };
                picker_HLA_I_A_alelo1.ItemsSource = lista_HLA_I_A;

                var picker_HLA_I_A_3_alelo2 = new Picker { Title = "Alelo 2" };
                picker_HLA_I_A_3_alelo2.ItemsSource = lista_HLA_I_A;


                var stackAlelosA = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = { picker_HLA_I_A_alelo1, picker_HLA_I_A_3_alelo2 }
                };

                var stackHLA_I_A = new StackLayout { Children = { LabelHLAI, stackAlelosA } };
                var FramePkr = new Frame { OutlineColor = Color.Gray, Margin = new Thickness(10, 5, 10, 0), Content = stackHLA_I_A };
                #endregion

                var LabelIdentificacao = new FontAwesomeLabel { Text = '\uf2c2'.ToString(), HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.FromHex("#339966"), };
                var LabelTitulo = new Label { Text = "Cadastro de Paciente", HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.FromHex("#339966"), };
                var StackTitulo = new StackLayout { Children = { LabelIdentificacao, LabelTitulo } };

                var EntryIdentificador = new Entry { Placeholder = "Identificador" };
                var TipoPaciente = new List<string>();
                TipoPaciente.Add("Doador");
                TipoPaciente.Add("Receptor");
                var pickerTipoPaciente = new Picker { Title = "Tipo de Paciente" };
                pickerTipoPaciente.ItemsSource = TipoPaciente;

                var EntryTipoPaciente = new Entry { Placeholder = "Tipo" };
                var LabelIdadeDoador = new Entry { Placeholder = "Idade do doador", Keyboard = Keyboard.Numeric };
                var stackIdentificacao = new StackLayout { Children = { EntryIdentificador, pickerTipoPaciente, LabelIdadeDoador } };

                var FrameDadosPessoais = new Frame
                {
                    OutlineColor = Color.Gray,
                    Margin = new Thickness(10, 5, 10, 0),
                    Content = stackIdentificacao
                };

                var TipoSanguineo = new List<String>();
                TipoSanguineo.Add("abo.Descricao");
                var pickerABOPaciente = new Picker { Title = "ABO" };
                pickerABOPaciente.ItemsSource = TipoSanguineo;

                var FrameABO = new Frame
                {
                    OutlineColor = Color.Gray,
                    Margin = new Thickness(10, 5, 10, 0),
                    Content = pickerABOPaciente
                };

                MyStackLayout.Children.Add(StackTitulo);
                MyStackLayout.Children.Add(LabelIdentificacao);
                MyStackLayout.Children.Add(FrameDadosPessoais);
                MyStackLayout.Children.Add(FrameABO);
                MyStackLayout.Children.Add(FramePkr);



            }
            catch (System.Exception)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Ops", "Erro no cadastro de doador. Tente novamente.", "OK");
            }

        }
    }
}
