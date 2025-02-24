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
    /// Interação lógica para Telefone.xam
    /// </summary>
    public partial class Telefone : Page
    {

        Controller.Controller controller;
        List<Telefone> novoTelefone;


        public Telefone()
        {
            InitializeComponent();
            controller = new Controller.Controller();
            novoTelefone = new List<Telefone>();
        }

        private void btn_salvar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_voltar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_excluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_adicionarTelefone_Click(object sender, RoutedEventArgs e)
        {
            string ddd = txt_DDD.Text.Trim();
            string numero = txt_NumeroTelefone.Text.Trim();
            string operadora = txt_Operadora.Text.Trim();
            string valida = controller.validacaoEndereco(numero);

            if (!string.IsNullOrEmpty(valida))
            {
                MessageBox.Show(valida);
            }
            else
            {
                controller.criaTelefone(ddd, numero, operadora);
                //novoTelefone = controller.telefones;
                insereDadosTabela();
                btn_salvar.IsEnabled = true;
            }

        }

        private void insereDadosTabela()
        {

        }


        private void txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
    }
}
