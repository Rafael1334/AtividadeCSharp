using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Atividade.Model;
using Atividade.View;

namespace Atividade
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Controller.Controller controller;
        private Page pageInformacaoPessoa;
        private Page pageEndereco;
        private Page pageTelefone;

        public MainWindow()
        {
            controller = new Controller.Controller();
            pageInformacaoPessoa = new View.InformacaoPessoal(controller);
            pageEndereco = new View.Endereco(controller);
            pageTelefone = new View.Telefone(controller);

            InitializeComponent();
            ((MainWindow)Application.Current.MainWindow).Content = pageInformacaoPessoa;

        }

        public void trocarTela(string nomePagina)
        {
            switch (nomePagina)
            {
                case "TELA1":
                    ((MainWindow)Application.Current.MainWindow).Content = pageInformacaoPessoa;
                    break;
                case "TELA2":
                    ((MainWindow)Application.Current.MainWindow).Content = pageEndereco;
                    break;
                case "TELA3":
                    ((MainWindow)Application.Current.MainWindow).Content = pageTelefone;
                    break;
            }
        }

    }
}