using System;
using Xamarin.Forms;
using KeltonAndrea.View;
using KeltonAndrea.Model;
using System.Threading.Tasks;
using KeltonAndrea.Control;

namespace KeltonAndrea.ViewModel
{
    public class CadastroUsuarioViewModel : BaseViewModel
    {
        public CadastroUsuarioViewModel()
        {
            MyStackLayout = new StackLayout();
            SalvarCommand = new Command(ExecuteSalvarCommand);
        }


        private Entry _entryOrganizacaoUsuario;
        public Entry entryOrganizacaoUsuario
        {
            get { return _entryOrganizacaoUsuario; }
            set { SetProperty(ref _entryOrganizacaoUsuario, value); SalvarCommand.ChangeCanExecute(); }
        }

        private Entry _entryNomeUsuario;
        public Entry entryNomeUsuario
        {
            get { return _entryNomeUsuario; }
            set { SetProperty(ref _entryNomeUsuario, value); SalvarCommand.ChangeCanExecute(); }
        }

        private Entry _entrySenhaUsuario;
        public Entry entrySenhaUsuario
        {
            get { return _entrySenhaUsuario; }
            set { SetProperty(ref _entrySenhaUsuario, value); SalvarCommand.ChangeCanExecute(); }
        }

        private Entry _entryPermissaoUsuario;
        public Entry entryPermissaoUsuario
        {
            get { return _entryPermissaoUsuario; }
            set { SetProperty(ref _entryPermissaoUsuario, value); SalvarCommand.ChangeCanExecute(); }
        }

        private StackLayout _myStackLayout;

        public StackLayout MyStackLayout
        {
            get { return _myStackLayout; }
            set { SetProperty(ref _myStackLayout, value); }
        }

        public async Task LoadView()
        {

            try
            {
                IsBusy = true;

                var Content = new ContentPage();

                var LabelIdentificacao = new FontAwesomeLabel { Text = '\uf2c2'.ToString(), HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.FromHex("#339966"), };
                var LabelTitulo = new Label { Text = "Cadastro de Usuario", HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.FromHex("#339966"), };
                var stackTitulo = new StackLayout { Children = { LabelIdentificacao, LabelTitulo } };

                var LabelNomeUsuario = new FontAwesomeLabel { Text = Icon.FAUser.ToString(), HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.FromHex("#339966"), };
                entryNomeUsuario = new Entry { Placeholder = "Nome de usuário TESTE FINAL PARA DESENCARGO DE CONSCIÊNCIA" };
                var stackNomeUsuario = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { LabelNomeUsuario, entryNomeUsuario } };

                var LabelSenhaUsuario = new FontAwesomeLabel { Text = Icon.FAPassword.ToString(), HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.FromHex("#339966"), };
                entrySenhaUsuario = new Entry { Placeholder = "Senha de usuário " };
                var stackSenhaUsuario = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { LabelSenhaUsuario, entrySenhaUsuario } };

                var LabelOrganizacaoUsuario = new FontAwesomeLabel { Text = Icon.FAInstitute.ToString(), HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.FromHex("#339966"), };
                entryOrganizacaoUsuario = new Entry { Placeholder = "Organizacao de usuário " };
                var stackOrganizacaoUsuario = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { LabelOrganizacaoUsuario, entryOrganizacaoUsuario } };

                var labelPermissaoUsuario = new FontAwesomeLabel { Text = Icon.FAGear.ToString(), HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.FromHex("#339966"), };
                entryPermissaoUsuario = new Entry { Placeholder = "Permissao de usuário ", Keyboard = Keyboard.Numeric };
                var stackPermissaoUsuario = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { labelPermissaoUsuario, entryPermissaoUsuario } };

                var ButtonSave = new Button { Text = "salvar", BackgroundColor = Color.FromHex("#339966"), TextColor = Color.White, Command = SalvarCommand };
                var stackBody = new StackLayout { Margin = 10, Children = { stackTitulo, stackNomeUsuario, stackSenhaUsuario, stackOrganizacaoUsuario, stackPermissaoUsuario, ButtonSave } };

                MyStackLayout.Children.Add(stackBody);

            }
            catch (System.Exception)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Ops", "Erro no cadastro de doador. Tente novamente.", "OK");
            }

        }

        public Command SalvarCommand { get; private set; }

        private async void ExecuteSalvarCommand()
        {
            Exception error = null;

            try
            {

                if (string.IsNullOrWhiteSpace(entryOrganizacaoUsuario.Text) || string.IsNullOrWhiteSpace(entryNomeUsuario.Text) || string.IsNullOrWhiteSpace(entrySenhaUsuario.Text) || string.IsNullOrWhiteSpace(entryPermissaoUsuario.Text))
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                 "Atenção", "Por favor, insira todos os dados para continuar", "OK");
                }

                else
                {
                    Usuario user = new Usuario();
                    user.NomeUsuario = entryNomeUsuario.Text;
                    //user.OrganizacaoUsuario. = entryOrganizacaoUsuario.Text;
                    user.SenhaUsuario = entrySenhaUsuario.Text;
                    user.PermissaoUsuario = int.Parse(entryPermissaoUsuario.Text);


                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                "Atenção", "Cadastrado com sucesso", "OK");
                }

            }
            catch (System.Exception)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Ops", "Erro cadastro de Usuario. Tente novamente.", "OK");
            }

            if (error != null)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                   "Error!", error.Message, "OK");
            }
        }


    }
}

