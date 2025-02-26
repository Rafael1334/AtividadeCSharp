﻿using System;
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

        public Endereco(Controller.Controller controller)
        {
            this.controller = controller;
            InitializeComponent();
            preencheDadosTela();
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
                MessageBox.Show(valida, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                controller.criaEndereco(logradouro, numero, complemento, bairro, cidade, estado);
                limparTelaEndereco();
                btn_proximo.IsEnabled = true;
            }

        }

        private void btn_excluir_Click(object sender, RoutedEventArgs e)
        {
            int index = dtg_TabelaEndereco.SelectedIndex;
            controller.removerDadosTabela(index);
        }

        private void btn_proximo_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).trocarTela("TELA3");
        }

        private void btn_voltar_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).trocarTela("TELA1");
            limparTelaEndereco();
            limparTabelaEndereco();
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

        private void dtg_TabelaEndereco_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtg_TabelaEndereco.SelectedItems.Count > 0)
            {
                string dados = Convert.ToString(dtg_TabelaEndereco.SelectedItem);
                int index = dtg_TabelaEndereco.SelectedIndex;
                
                string[] recebeDados = dados.Split(';');

                txt_Logradouro.Text = recebeDados[0].Trim();
                txt_Numero.Text = recebeDados[1].Trim();
                txt_Complemento.Text = recebeDados[2].Trim();
                txt_Bairro.Text = recebeDados[3].Trim();
                txt_Cidade.Text = recebeDados[4].Trim();
                cb_Estado.SelectedItem = recebeDados[5].Trim();

                btn_excluir.IsEnabled = true;

            }
        }

        public void limparTelaEndereco()
        {
            txt_Logradouro.Text = "";
            txt_Complemento.Text = "";
            txt_Bairro.Text = "";
            txt_Cidade.Text = "";
            txt_Numero.Text = "";
            cb_Estado.SelectedIndex = 0;
        }

        public void limparTabelaEndereco()
        {
            dtg_TabelaEndereco.ItemsSource = null;
        }

    }
}
