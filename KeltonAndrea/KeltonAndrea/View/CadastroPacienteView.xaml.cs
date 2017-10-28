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
    public partial class CadastroPacienteView : ContentPage
    {
        
        public CadastroPacienteView()
        {
            InitializeComponent();
            Paciente pac = new Paciente();
            
            

            var LabelIdentificacao = new FontAwesomeLabel { Text = '\uf2c2'.ToString(), HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.FromHex("#339966"),FontSize=(50) };
            var LabelTitulo = new Label { Text = "Cadastro de Paciente", HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.FromHex("#339966"), FontSize = (20) };
            var StackTitulo = new StackLayout { Children = { LabelIdentificacao, LabelTitulo } };

            #region DadosIdentificacao
            var EntryIdentificador = new Entry { Placeholder = "Identificador" };
            var LabelIdadeDoador = new Entry { Placeholder = "Idade do paciente", Keyboard = Keyboard.Numeric };
            
            EntryIdentificador.TextChanged += (sender, args) =>
            {
                pac.Identificador = EntryIdentificador.Text;                
            };

            LabelIdadeDoador.TextChanged += (sender, args) =>
            {
                pac.Idade = LabelIdadeDoador.Text;
            };

            var stackIdentificacao = new StackLayout { Children = { EntryIdentificador, LabelIdadeDoador } };

            var FrameDadosPessoais = new Frame
            {
                OutlineColor = Color.Gray,
                Margin = new Thickness(10, 5, 10, 0),
                Content = stackIdentificacao
            };
            #endregion

            #region TipoPaciente
                                    
            var TipoPaciente = new List<String>();
            TipoPaciente.Add("Doador");
            TipoPaciente.Add("Receptor");
            
            var pickerTipoPaciente = new Picker { Title = "Doador / Receptor" };
            pickerTipoPaciente.ItemsSource = TipoPaciente;
                      
            var stackTipo = new StackLayout
            {
                Children = { pickerTipoPaciente }
            };

            var FrameTipo = new Frame { OutlineColor = Color.Gray, Margin = new Thickness(10, 5, 10, 0), Content = stackTipo };

            pickerTipoPaciente.SelectedIndexChanged += (sender, args) =>
            {
                if (pickerTipoPaciente.SelectedIndex != -1)
                {
                    pac.Tipo = pickerTipoPaciente.Items[pickerTipoPaciente.SelectedIndex];
                }
            };

            
            #endregion


            #region HLA-A
            var LabelHLAI = new Label { Text = "HLA-A" };
            var lista_HLA_I_A = new List<String>();

            lista_HLA_I_A.Add("A*01:01:01:01");
            lista_HLA_I_A.Add("A*01:01:01:02N");
            lista_HLA_I_A.Add("A*01:01:01:03");
            lista_HLA_I_A.Add("A*01:01:01:04");
            lista_HLA_I_A.Add("A*01:01:01:05");
            lista_HLA_I_A.Add("A*01:01:01:06");
            lista_HLA_I_A.Add("A*01:01:01:07");
            lista_HLA_I_A.Add("A*01:01:01:08");
            lista_HLA_I_A.Add("A*01:01:01:09");
            lista_HLA_I_A.Add("A*01:01:01:10");


            var picker_HLA_I_A_alelo1 = new Picker { Title = "Alelo 1" };
            picker_HLA_I_A_alelo1.ItemsSource = lista_HLA_I_A;

            var picker_HLA_I_A_3_alelo2 = new Picker { Title = "Alelo 2" };
            picker_HLA_I_A_3_alelo2.ItemsSource = lista_HLA_I_A;


            var stackAlelosA = new StackLayout
            {
                Children = { LabelHLAI, picker_HLA_I_A_alelo1, picker_HLA_I_A_3_alelo2 }
            };


            var FramePkr = new Frame { OutlineColor = Color.Gray, Margin = new Thickness(10, 5, 10, 0), Content = stackAlelosA };

            picker_HLA_I_A_alelo1.SelectedIndexChanged += (sender, args) =>
            {
                if (picker_HLA_I_A_alelo1.SelectedIndex != -1)
                {
                    pac.Hla_a1 = picker_HLA_I_A_alelo1.Items[picker_HLA_I_A_alelo1.SelectedIndex];

                }
            };

            picker_HLA_I_A_3_alelo2.SelectedIndexChanged += (sender, args) =>
            {
                if (picker_HLA_I_A_3_alelo2.SelectedIndex != -1)
                {                 
                    pac.Hla_a2 = picker_HLA_I_A_3_alelo2.Items[picker_HLA_I_A_3_alelo2.SelectedIndex];
                }
            };
            #endregion

            #region HLA-B
            var LabelHLBI = new Label { Text = "HLA-B" };
            var lista_HLA_I_B = new List<String>();

            lista_HLA_I_B.Add("B*07:02:01:01");
            lista_HLA_I_B.Add("B*07:02:01:02");
            lista_HLA_I_B.Add("B*07:02:01:03");
            lista_HLA_I_B.Add("B*07:02:01:04");
            lista_HLA_I_B.Add("B*07:02:01:05");
            lista_HLA_I_B.Add("B*07:02:01:06");
            lista_HLA_I_B.Add("B*07:02:01:07");
            lista_HLA_I_B.Add("B*07:02:02");
            lista_HLA_I_B.Add("B*07:02:03");
            lista_HLA_I_B.Add("B*07:02:04");


            var picker_HLA_I_B_alelo1 = new Picker { Title = "Alelo 1" };
            picker_HLA_I_B_alelo1.ItemsSource = lista_HLA_I_B;

            var picker_HLA_I_B_3_alelo2 = new Picker { Title = "Alelo 2" };
            picker_HLA_I_B_3_alelo2.ItemsSource = lista_HLA_I_B;


            var stackAlelosB = new StackLayout
            {

                Children = { picker_HLA_I_B_alelo1, picker_HLA_I_B_3_alelo2 }
            };

            var stackHLA_I_B = new StackLayout { Children = { LabelHLBI, stackAlelosB } };
            var FramePkrB = new Frame { OutlineColor = Color.Gray, Margin = new Thickness(10, 5, 10, 0), Content = stackHLA_I_B };

            picker_HLA_I_B_alelo1.SelectedIndexChanged += (sender, args) =>
            {
                if (picker_HLA_I_B_alelo1.SelectedIndex != -1)
                {
                    pac.Hla_b1 = picker_HLA_I_B_alelo1.Items[picker_HLA_I_B_alelo1.SelectedIndex];
                }
            };

            picker_HLA_I_B_3_alelo2.SelectedIndexChanged += (sender, args) =>
            {
                if (picker_HLA_I_B_3_alelo2.SelectedIndex != -1)
                {
                    pac.Hla_b2 = picker_HLA_I_B_3_alelo2.Items[picker_HLA_I_B_3_alelo2.SelectedIndex];
                }
            };

            #endregion

            #region HLA-C
            var LabelHLCI = new Label { Text = "HLA-C" };
            var lista_HLA_I_C = new List<String>();

            lista_HLA_I_C.Add("C*01:02:01:01");
            lista_HLA_I_C.Add("C*01:02:01:02");
            lista_HLA_I_C.Add("C*01:02:01:03");
            lista_HLA_I_C.Add("C*01:02:01:04");
            lista_HLA_I_C.Add("C*01:02:01:05");
            lista_HLA_I_C.Add("C*01:02:02");
            lista_HLA_I_C.Add("C*01:02:03");
            lista_HLA_I_C.Add("C*01:02:04");
            lista_HLA_I_C.Add("C*01:02:05");
            lista_HLA_I_C.Add("C*01:02:06");


            var picker_HLA_I_C_alelo1 = new Picker { Title = "Alelo 1" };
            picker_HLA_I_C_alelo1.ItemsSource = lista_HLA_I_C;

            var picker_HLA_I_C_3_alelo2 = new Picker { Title = "Alelo 2" };
            picker_HLA_I_C_3_alelo2.ItemsSource = lista_HLA_I_C;


            var stackAlelosC = new StackLayout
            {
                
                Children = { picker_HLA_I_C_alelo1, picker_HLA_I_C_3_alelo2 }
            };

            var stackHLA_I_C = new StackLayout { Children = { LabelHLCI, stackAlelosC } };
            var FramePkrC = new Frame { OutlineColor = Color.Gray, Margin = new Thickness(10, 5, 10, 0), Content = stackHLA_I_C };

            picker_HLA_I_C_alelo1.SelectedIndexChanged += (sender, args) =>
            {
                if (picker_HLA_I_C_alelo1.SelectedIndex != -1)
                {
                    pac.Hla_c1 = picker_HLA_I_C_alelo1.Items[picker_HLA_I_C_alelo1.SelectedIndex];
                }
            };

            picker_HLA_I_C_3_alelo2.SelectedIndexChanged += (sender, args) =>
            {
                if (picker_HLA_I_C_3_alelo2.SelectedIndex != -1)
                {
                    pac.Hla_c2 = picker_HLA_I_C_3_alelo2.Items[picker_HLA_I_C_3_alelo2.SelectedIndex];
                }
            };
            #endregion
                       
            #region HLA-DQ
            var LabelHLDQ = new Label { Text = "HLA-DQ" };
            var lista_HLA_II_DQ = new List<String>();

            lista_HLA_II_DQ.Add("DQA1*01:01:01:01");
            lista_HLA_II_DQ.Add("DQA1*01:01:01:02");
            lista_HLA_II_DQ.Add("DQA1*01:01:01:03");
            lista_HLA_II_DQ.Add("DQA1*01:01:01:04");
            lista_HLA_II_DQ.Add("DQA1*01:01:01:05");
            lista_HLA_II_DQ.Add("DQA1*01:01:02");
            lista_HLA_II_DQ.Add("DQA1*01:01:03");
            lista_HLA_II_DQ.Add("DQA1*01:02:01:01");
            lista_HLA_II_DQ.Add("DQA1*01:02:01:02");
            lista_HLA_II_DQ.Add("DQA1*01:02:01:03");


            var picker_HLA_II_DQ_alelo1 = new Picker { Title = "Alelo 1" };
            picker_HLA_II_DQ_alelo1.ItemsSource = lista_HLA_II_DQ;

            var picker_HLA_II_DQ_3_alelo2 = new Picker { Title = "Alelo 2" };
            picker_HLA_II_DQ_3_alelo2.ItemsSource = lista_HLA_II_DQ;


            var stackAlelosDQ = new StackLayout
            {
               
                Children = { picker_HLA_II_DQ_alelo1, picker_HLA_II_DQ_3_alelo2 }
            };

            var stackHLA_II_DQ = new StackLayout { Children = { LabelHLDQ, stackAlelosDQ } };
            var FramePkrDQ = new Frame { OutlineColor = Color.Gray, Margin = new Thickness(10, 5, 10, 0), Content = stackHLA_II_DQ };

            
            picker_HLA_II_DQ_alelo1.SelectedIndexChanged += (sender, args) =>
            {
                if (picker_HLA_II_DQ_alelo1.SelectedIndex != -1)
                {
                    pac.Hla_dq1 = picker_HLA_II_DQ_alelo1.Items[picker_HLA_II_DQ_alelo1.SelectedIndex];
                }
            };
            picker_HLA_II_DQ_3_alelo2.SelectedIndexChanged += (sender, args) =>
            {
                if (picker_HLA_II_DQ_3_alelo2.SelectedIndex != -1)
                {
                    pac.Hla_dq2 = picker_HLA_II_DQ_3_alelo2.Items[picker_HLA_II_DQ_3_alelo2.SelectedIndex];
                }
            };
                       


            #endregion

            #region HLA-DP
            var LabelHLDP = new Label { Text = "HLA-DP" };
            var lista_HLA_II_DP = new List<String>();

            lista_HLA_II_DP.Add("DPA1*01:03:01:01");
            lista_HLA_II_DP.Add("DPA1*01:03:01:02");
            lista_HLA_II_DP.Add("DPA1*01:03:01:03");
            lista_HLA_II_DP.Add("DPA1*01:03:01:04");
            lista_HLA_II_DP.Add("DPA1*01:03:01:05");
            lista_HLA_II_DP.Add("DPA1*01:03:01:06");
            lista_HLA_II_DP.Add("DPA1*01:03:01:07");
            lista_HLA_II_DP.Add("DPA1*01:03:01:08");
            lista_HLA_II_DP.Add("DPA1*01:03:02");
            lista_HLA_II_DP.Add("DPA1*01:03:03");


            var picker_HLA_II_DP_alelo1 = new Picker { Title = "Alelo 1" };
            picker_HLA_II_DP_alelo1.ItemsSource = lista_HLA_II_DP;

            var picker_HLA_II_DP_3_alelo2 = new Picker { Title = "Alelo 2" };
            picker_HLA_II_DP_3_alelo2.ItemsSource = lista_HLA_II_DP;


            var stackAlelosDP = new StackLayout
            {
               
                Children = { picker_HLA_II_DP_alelo1, picker_HLA_II_DP_3_alelo2 }
            };

            var stackHLA_II_DP = new StackLayout { Children = { LabelHLDP, stackAlelosDP } };
            var FramePkrDP = new Frame { OutlineColor = Color.Gray, Margin = new Thickness(10, 5, 10, 10), Content = stackHLA_II_DP };
            
            picker_HLA_II_DP_alelo1.SelectedIndexChanged += (sender, args) =>
            {
                if (picker_HLA_II_DP_alelo1.SelectedIndex != -1)
                {
                    pac.Hla_dp1 = picker_HLA_II_DP_alelo1.Items[picker_HLA_II_DP_alelo1.SelectedIndex];
                }
            };
            picker_HLA_II_DP_3_alelo2.SelectedIndexChanged += (sender, args) =>
            {
                if (picker_HLA_II_DP_3_alelo2.SelectedIndex != -1)
                {
                    pac.Hla_dp2 = picker_HLA_II_DP_3_alelo2.Items[picker_HLA_II_DP_3_alelo2.SelectedIndex];                    

                }
            };

            
            #endregion

            #region OrgaoMedula

            var listOrgaoMedula = new List<String>();

            listOrgaoMedula.Add("Medula");
            listOrgaoMedula.Add("Coração");
            listOrgaoMedula.Add("Rim");
            listOrgaoMedula.Add("Figado");
                        
            var pickerOrgaoMedula = new Picker { Title = "Orgao / Medula" };
            pickerOrgaoMedula.ItemsSource = listOrgaoMedula;
           

            var FrameOrgaoMedula = new Frame { OutlineColor = Color.Gray, Margin = new Thickness(10, 5, 10, 10), Content = pickerOrgaoMedula };

            pickerOrgaoMedula.SelectedIndexChanged += (sender, args) =>
            {
                if (pickerOrgaoMedula.SelectedIndex != -1 )
                {
                    pac.Orgao = pickerOrgaoMedula.Items[pickerOrgaoMedula.SelectedIndex];
                }

            };
            #endregion

            #region TipoSanguineo
            var TipoSanguineo = new List<String>();
            TipoSanguineo.Add("A");
            TipoSanguineo.Add("B");
            TipoSanguineo.Add("AB");
            TipoSanguineo.Add("O");
            
            var pickerABOPaciente = new Picker { Title = "ABO" };
            pickerABOPaciente.ItemsSource = TipoSanguineo;

            var FrameABO = new Frame
            {
                OutlineColor = Color.Gray,
                Margin = new Thickness(10, 5, 10, 0),
                Content = pickerABOPaciente
            };

            pickerABOPaciente.SelectedIndexChanged += (sender, args) =>
            {
                if (pickerABOPaciente.SelectedIndex != -1)
                {
                    pac.ABO = pickerABOPaciente.Items[pickerABOPaciente.SelectedIndex];                    
                }
            };
            #endregion



            PacienteDB pacienteDB = new PacienteDB();

            Button button = new Button
            {
                Text = "Salvar",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                Margin = 10,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Command = new Command(() =>  pacienteDB.AddPacienteAsync(pac))
            };

            var St = new StackLayout { Margin = 5, Children = { StackTitulo, LabelIdentificacao, FrameDadosPessoais, FrameTipo, FrameOrgaoMedula, FrameABO, FramePkr, FramePkrB, FramePkrC, FramePkrDQ,  FramePkrDP, button } };
            


            Content = new ScrollView
            {
                Content = St
            };
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