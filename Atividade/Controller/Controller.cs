﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Atividade.Model;
using Atividade.Model.DAO;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;

namespace Atividade.Controller
{
    public class Controller
    {

        private static ConnectionDb connectionDb = new ConnectionDb();
        PessoaDao pessoaDao = new PessoaDao(connectionDb);
        EnderecoDao enderecoDao = new EnderecoDao(connectionDb);
        TelefoneDao telefoneDao = new TelefoneDao(connectionDb);

        private Pessoa pessoa;
        private Endereco endereco;
        private Telefone telefone;

        //Pessoa

        public bool validaNome(string nome)
        {
            return !string.IsNullOrEmpty(nome);
        }

        public bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);

        }

        public string validacaoPessoa(string nome, string cpf)
        {
            string resultado = "";

            if (!validaNome(nome))
            {
                resultado += "Nome; ";
            }

            if (!IsCpf(cpf))
            {
                resultado += "Cpf; ";
            }

            if (!string.IsNullOrEmpty(resultado))
            {
                return ("Erro no(s) campo(s):\n" + resultado);
            }

            return resultado;
        }

        public int calculaIdade(DateTime? dataNascimento)
        {
            DateTime hoje = DateTime.Now;

            if (!dataNascimento.HasValue)
            {
                return -1;
            }

            DateTime dtNascimento = dataNascimento.Value;
            int idade = hoje.Year - dtNascimento.Year;

            if (hoje.Month < dtNascimento.Month || (hoje.Month == dtNascimento.Month && hoje.Day < dtNascimento.Day))
            {
                idade--;
            }

            return idade;
        }

        public void criaPessoa(string nome, string cpf, string rg, string dtNascimento, string sexo, string profissao, string escolaridade)
        {
            pessoa = new Model.Pessoa(nome, cpf, rg, dtNascimento, sexo, profissao, escolaridade);
        }

        public string getPessoa()
        {
            if (pessoa == null)
            {
                pessoa = new Pessoa();
            }
            return pessoa.ToString();
        }


        //Endereço

        public bool validaLogradouro(string logradouro)
        {
            return !string.IsNullOrEmpty(logradouro);
        }

        public string validacaoEndereco(string logradouro)
        {

            string resultado = "";

            if (!validaLogradouro(logradouro))
            {
                resultado += "Logradouro; ";
            }

            if (!string.IsNullOrEmpty(resultado))
            {
                return ("Erro no(s) campo(s):\n" + resultado);
            }

            return resultado;
        }

        public void criaEndereco(string logradouro, string numero, string complemento, string bairro, string cidade, string estado)
        {
            Model.Endereco novoEndereco = new Model.Endereco(logradouro, numero, complemento, bairro, cidade, estado); 
            pessoa.addItemEndereco(novoEndereco);
            atualizaTablelaEndereco(pessoa.getListEndereco);
        }

        private void atualizaTablelaEndereco(List<Endereco> lista)
        {
            var paginaAtual = ((MainWindow)Application.Current.MainWindow).Content;

            if (paginaAtual is View.Endereco paginaEndereco)
            {                
                paginaEndereco.dtg_TabelaEndereco.ItemsSource = lista;
            }
        } // Verificar a parte da tabela

        public void receberDadosTabelaEndereco(string logradouro, string numero, string complemento, string bairro, string cidade, string estado)
        {
            endereco = new Endereco(logradouro, numero, complemento, bairro, cidade, estado);
        }

        //Telefone

        public bool validaTelefoneCelular(string telefoneCelular)
        {
            return !string.IsNullOrEmpty(telefoneCelular);
        }

        public string validacaoTelefone(string telefoneCelular)
        {
            string resultado = "";

            if (!validaTelefoneCelular(telefoneCelular))
            {
                resultado += "Telefone; ";
            }

            if (!string.IsNullOrEmpty(resultado))
            {
                return ("Erro no(s) campo(s):\n" + resultado);
            }

            return resultado;
        }

        public void criaTelefone(string ddd, string numeroTelefone, string operadora)
        {
            Model.Telefone novoTelefone = new Model.Telefone(ddd, numeroTelefone, operadora);            
            pessoa.addItemTelefone(novoTelefone);
            atualizaTablelaTelefone(pessoa.getListTelefone);
        }

        private void atualizaTablelaTelefone(List<Telefone> lista)
        {
            var paginaAtual = ((MainWindow)Application.Current.MainWindow).Content;

            if (paginaAtual is View.Telefone paginaTelefone)
            {
                paginaTelefone.dtg_TabelaTelefone.ItemsSource = lista;
            }
        } // Verificar a parte da tabela

        public void receberDadosTabelaTelefone(string ddd, string numeroTelefone, string operadora)
        {
            telefone = new Telefone(ddd, numeroTelefone, operadora);
        }


        //Geral

        public bool listaVazia<T>(List<T> lista)
        {
            return lista == null || lista.Count == 0;
        }

        public string verificaListaVazia()
        {
            string mensagemErro = "";

            var enderecoVazio = listaVazia(pessoa.getListEndereco);
            if (enderecoVazio)
            {
                mensagemErro += "Endereço: Lista vazia\n";
            }

            var telefoneVazio = listaVazia(pessoa.getListTelefone);
            if (telefoneVazio)
            {
                mensagemErro += "Telefone: Lista vazia\n";
            }

            return mensagemErro;
        }

        public void salvarDados()
        {
            int ultimoIdInt;

            try
            {
                pessoaDao.inserirPessoa(pessoa);
                ultimoIdInt = pessoaDao.selecionarUltimoId();
                enderecoDao.inserirEndereco(pessoa.getListEndereco, ultimoIdInt);
                telefoneDao.inserirTelefone(pessoa.getListTelefone, ultimoIdInt);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro: CPF já cadastrado", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public void removerDadosTabela()
        {

            var paginaAtual = ((MainWindow)Application.Current.MainWindow).Content;

            if (paginaAtual is View.Endereco)
            {
                pessoa.removeItemEndereco(endereco);
            }

            if (paginaAtual is View.Telefone)
            {
                pessoa.removeItemTelefone(telefone);
            }

        }

        public void transformaJson()
        {
            var meuJson = JsonConvert.SerializeObject(pessoa);
            
            MessageBox.Show(meuJson);

            //var meuObjetoJson = JsonConvert.DeserializeObject<Pessoa>(meuJson);
            //MessageBox.Show(meuObjetoJson.ToString());
        }


    }


}

