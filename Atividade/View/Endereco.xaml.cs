using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Atividade.View
{
    /// <summary>
    /// Interação lógica para Endereco.xam
    /// </summary>
    public partial class Endereco : Page
    {

        Controller.Controller controller;
        private List<string> estadosBrasil = new List<string> {
            "-", "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA",
            "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN",
            "RS", "RO", "RR", "SC", "SP", "SE", "TO" };

        private List<string> colunasTabela = new List<string> { "Logradouro", "Número", "Complemento", "Bairro", "Cidade", "Estado" };

        public Endereco()
        {
            InitializeComponent();
            preencheDadosTela();
            controller = new Controller.Controller();
        }

        private void btn_adicionarEndereco_Click(object sender, RoutedEventArgs e)
        {
            string logradouro = txt_Logradouro.Text.Trim();
            string numero = txt_Numero.Text.Trim();
            string complemento = txt_Complemento.Text.Trim();
            string bairro = txt_Bairro.Text.Trim();
            string cidade = txt_Cidade.Text.Trim();
            string estado = cb_Estado.Text.Trim();
            string valida = controller.validacaoEndereco(logradouro);

            if (!string.IsNullOrEmpty(valida))
            {
                MessageBox.Show(valida);
            }
            else
            {
                insereDadosTabela();
                btn_proximo.IsEnabled = true;
            }

        }

        private void btn_excluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_proximo_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).mudarTela("TELA3");
        }

        private void btn_voltar_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).mudarTela("TELA1");
        }

        private void txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void preencheDadosTela()
        {
            cb_Estado.ItemsSource = estadosBrasil;
        }
    
        private void insereDadosTabela()
        {

        }

        
    }
}
