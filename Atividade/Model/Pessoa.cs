using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade.Model
{
    class Pessoa
    {

        private string nome;
        private string cpf;
        private string rg;
        private string dtNascimento;
        private int idade;
        private string sexo;
        private string profissao;
        private string escolaridade;
        private List<Endereco> listEndereco;
        private List<Telefone> listTelefone;

        public Pessoa()
        {

        }

        public Pessoa(string nome, string cpf, string rg, string dtNascimento, int idade,string sexo, string profissao, string escolaridade)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.rg = rg;
            this.dtNascimento = dtNascimento;
            this.idade = idade;
            this.sexo = sexo;
            this.profissao = profissao;
            this.escolaridade = escolaridade;
            this.listEndereco = new List<Endereco>();
            this.listTelefone = new List<Telefone>();
        }

        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Rg { get => rg; set => rg = value; }
        public string DtNascimento { get => dtNascimento; set => dtNascimento = value; }
        public int Idade { get => idade; set => idade = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string Profissao { get => profissao; set => profissao = value; }
        public string Escolaridade { get => escolaridade; set => escolaridade = value; }

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

        /*public bool validaRg(string rg)
        {
            return !string.IsNullOrEmpty(rg);
        }

        public bool validaDataNascimento(string dtNascimento)
        {
            return !string.IsNullOrEmpty(dtNascimento);
        }

        public bool validaSexo(string sexo)
        {
            return !string.IsNullOrEmpty(sexo);
        }

        public bool validaProfissao(string profissao)
        {
            return !string.IsNullOrEmpty(profissao);
        }

        public bool validaEscolaridade(string escolaridade)
        {
            return !string.IsNullOrEmpty(escolaridade);
        }*/

    }
}
