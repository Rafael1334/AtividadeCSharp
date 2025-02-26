using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Atividade.Model
{
    class Pessoa
    {

        private string nome;
        private string cpf;
        private string rg;
        private string dtNascimento;
        private string sexo;
        private string profissao;
        private string escolaridade;
        private ObservableCollection<Endereco> listEndereco;
        private ObservableCollection<Telefone> listTelefone;

        public Pessoa() { }

        public Pessoa(string nome, string cpf, string rg, string dtNascimento, string sexo, string profissao, string escolaridade)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.rg = rg;
            this.dtNascimento = dtNascimento;
            this.sexo = sexo;
            this.profissao = profissao;
            this.escolaridade = escolaridade;
            listEndereco = new ObservableCollection<Endereco>();
            listTelefone = new ObservableCollection<Telefone>();

        }

        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Rg { get => rg; set => rg = value; }
        public string DtNascimento { get => dtNascimento; set => dtNascimento = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string Profissao { get => profissao; set => profissao = value; }
        public string Escolaridade { get => escolaridade; set => escolaridade = value; }

        public void addItemEndereco(Endereco endereco)
        {
            listEndereco.Add(endereco);
        }

        public void removeItemEndereco(int index)
        {
            listEndereco.RemoveAt(index);
        }

        public ObservableCollection<Endereco> getListEndereco { get => listEndereco; }

        public void addItemTelefone(Telefone telefone)
        {
            listTelefone.Add(telefone);
        }

        public void removeItemTelefone(int index)
        {

            listTelefone.RemoveAt(index);
        }

        public ObservableCollection<Telefone> getListTelefone { get => listTelefone; }

        public override string ToString()
        {
            return $"Nome: {Nome}\nCPF: {Cpf} - RG: {Rg}\nData Nascimento:{DtNascimento}" +
                $"\nSexo: {Sexo}\nProfissão: {Profissao}\nEscolaridade: {Escolaridade}";
        }

    }
}
