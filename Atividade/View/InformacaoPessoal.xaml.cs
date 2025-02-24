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
    /// Interação lógica para InformacaoPessoal.xam
    /// </summary>
    public partial class InformacaoPessoal : Page
    {

        private Controller.Controller controller;
        private List<string> possiveisSexos = new List<string> { "Não Informar", "Masculino", "Feminino" };
        private List<string> possivelEscolaridade = new List<string> { "Não Informar", "Ensino Fundamental", "Ensino Médio", "Ensino Técnico", "Ensino Superior" };

        public InformacaoPessoal()
        {
            InitializeComponent();
            carregaComboBox();
            controller = new Controller.Controller();
        }

        private void dtP_DtNascimento_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            txt_Idade.Text = calculaIdade().ToString();
        }

        private void btn_proximo_Click(object sender, RoutedEventArgs e)
        { 
            string nome = txt_Nome.Text.Trim();
            string cpf = txt_Cpf.Text.Trim();
            string rg = txt_Rg.Text.Trim();
            string dtNascimento = dtP_DtNascimento.Text.Trim();
            string sexo = cb_Sexo.Text.Trim();
            string profissao = txt_Profissao.Text.Trim();
            string escolaridade = cb_Escolaridade.Text.Trim();
            string valida = controller.validacaoPessoa(nome, cpf);
            int idade = calculaIdade();

            if (!string.IsNullOrEmpty(valida))
            {
                MessageBox.Show(valida);
            }
            else
            {
                controller.criaPessoa(nome, cpf, rg, dtNascimento, idade, sexo, profissao, escolaridade);
                ((MainWindow)Application.Current.MainWindow).mudarTela("TELA2");
            }
        }

        private void carregaComboBox()
        {
            cb_Sexo.ItemsSource =  possiveisSexos;
            cb_Escolaridade.ItemsSource =  possivelEscolaridade;
        }

        private int calculaIdade()
        {

            DateTime hoje = DateTime.Now;
            
            if (!dtP_DtNascimento.SelectedDate.HasValue)
            {
                return -1;
            }

            DateTime dtNascimento = dtP_DtNascimento.SelectedDate.Value;
            int idade = hoje.Year - dtNascimento.Year;

            if (hoje.Month < dtNascimento.Month || (hoje.Month == dtNascimento.Month && hoje.Day < dtNascimento.Day))
            {
                idade--;
            }

            return idade;
        }

        private void txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
    }
}
