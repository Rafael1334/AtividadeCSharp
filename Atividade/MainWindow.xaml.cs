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
using Atividade.View;

namespace Atividade
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Controller.Controller controller;
        public const string telaInformacaoPessoal = "TELA1";
        public const string telaEndereco= "TELA2";
        public const string telaTelefone= "TELA3";

        public MainWindow()
        {
            InitializeComponent();

            controller = new Controller.Controller();

            mudarTela(telaInformacaoPessoal);
        }

        public void mudarTela(string nomePagina)
        {
            switch(nomePagina)
            { 
                case telaInformacaoPessoal:
                    controller.trocarTela(telaInformacaoPessoal);
                    break;
                case telaEndereco:
                    controller.trocarTela(telaEndereco);
                    break;
                case telaTelefone:
                    controller.trocarTela(telaTelefone);
                    break;
            }
        }

    }
}