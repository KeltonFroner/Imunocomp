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
    public partial class CadastroUsuarioView : ContentPage
    {
        public UsuarioDB _usuariodb;
        public Usuario usuario;
        public CadastroUsuarioView()
        {
            InitializeComponent();
        }

        public void adddata(object s, EventArgs args)
        {
            usuario = new Usuario();
            _usuariodb = new UsuarioDB();
            usuario.NomeUsuario = NomeUsuario.Text;
            usuario.Instituicao = Instituicao.Text;
            usuario.SenhaUsuario = SenhaUsuario.Text;
            if (string.IsNullOrEmpty(usuario.NomeUsuario) || string.IsNullOrEmpty(usuario.Instituicao) || string.IsNullOrEmpty(usuario.SenhaUsuario))
            {
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                             "Atenção", "Todos os campos devem ser preenchidos!", "OK");
            }
            else
            {
                if (!_usuariodb.GetUsuarioNome(usuario.NomeUsuario))
                {
                    _usuariodb.AddUsuario(usuario);
                    Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                          "Atenção", "Usuario registrado com sucesso", "OK");
                    NomeUsuario.Text = "";
                    Instituicao.Text = "";
                    SenhaUsuario.Text = "";

                }
                else
                {
                    Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                          "Atenção", "O nome de usuario já existe, por favor escolha outro nome", "OK");
                    NomeUsuario.Text = "";
                    Instituicao.IsEnabled = false;
                    SenhaUsuario.IsEnabled = false;
                    NomeUsuario.IsEnabled = true;
                    NomeUsuario.Focus();
                }
            }
        }

        public void Showdata(object sender, EventArgs args)
        {
            Application.Current.MainPage.Navigation.PushAsync(new ListaUsuariosView());
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

