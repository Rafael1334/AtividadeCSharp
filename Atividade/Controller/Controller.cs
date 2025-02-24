using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Atividade.Model;
using Atividade.Model.DAO;

namespace Atividade.Controller
{
    class Controller
    {

        private static ConnectionDb connectionDb = new ConnectionDb();
        PessoaDao pessoaDao = new PessoaDao(connectionDb);

        private Model.Pessoa pessoa = new Model.Pessoa();

        private Model.Endereco endereco = new Model.Endereco();
        private List<Endereco> listEndereco = new List<Endereco>();

        private Model.Telefone telefone = new Model.Telefone();

        public void criaPessoa(string nome, string cpf, string rg, string dtNascimento, int idade ,string sexo, string profissao, string escolaridade)
        {
            Model.Pessoa novaPessoa = new Model.Pessoa(nome, cpf, rg, dtNascimento, idade, sexo, profissao, escolaridade);
            MessageBox.Show(novaPessoa.ToString(), "Informações do Usuário", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void criaEndereco(string logradouro, string numero, string complemento, string bairro, string cidade, string estado )
        {
            Model.Endereco novoEndereco = new Model.Endereco(logradouro, numero, complemento, bairro, cidade, estado);
            listEndereco.Add(novoEndereco);

            string mensagem = string.Join("\n", listEndereco);
            MessageBox.Show(mensagem, "Endereços Cadastrados", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void criaTelefone(string ddd, string numeroTelefone, string operadora)
        {
            Model.Telefone novoTelefone = new Model.Telefone(ddd, numeroTelefone, operadora);
            
        }

        public void trocarTela(string nomePagina)
        {
            switch (nomePagina)
            {
                case "TELA1":
                    ((MainWindow)Application.Current.MainWindow).Content = new View.InformacaoPessoal();
                    break;
                case "TELA2":
                    ((MainWindow)Application.Current.MainWindow).Content = new View.Endereco();
                    break;
                case "TELA3":
                    ((MainWindow)Application.Current.MainWindow).Content = new View.Telefone();
                    break;
            }
        }

        public string validacaoPessoa(string nome, string cpf)
        {
            string resultado = "";

            if (!pessoa.validaNome(nome))
            {
                resultado += "Nome; ";
            }

            if (!pessoa.IsCpf(cpf))
            {
                resultado += "Cpf; ";
            }

            /*if (!pessoa.validaRg(rg))
            {
                resultado += "Rg; ";
            }

            if (!pessoa.validaDataNascimento(dtNascimento))
            {
                resultado += "Data de nascimento; ";
            }

            if (!pessoa.validaSexo(sexo))
            {
                resultado += "Sexo; ";
            }

            if (!pessoa.validaProfissao(profissao))
            {
                resultado += "Profissão; ";
            }

            if (!pessoa.validaEscolaridade(escolaridade))
            {
                resultado += "Escolaridade; ";
            }*/

            if (!string.IsNullOrEmpty(resultado))
            {
                return ("Erro no(s) campo(s):\n" + resultado);
            }

            return resultado;
        }

        public string validacaoEndereco(string logradouro)
        {

            string resultado = "";

            if (!endereco.validaLogradouro(logradouro))
            {
                resultado += "Logradouro; ";
            }

            if (!string.IsNullOrEmpty(resultado))
            {
                return ("Erro no(s) campo(s):\n" + resultado);
            }

            return resultado;
        }

        public string validacaoTelefone(string telefoneCelular)
        {
            string resultado = "";

            if (!telefone.validaTelefoneCelular(telefoneCelular))
            {
                resultado += "Telefone; ";
            }

            if (!string.IsNullOrEmpty(resultado))
            {
                return ("Erro no(s) campo(s):\n" + resultado);
            }

            return resultado;
        }

    }


}

