using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Atividade.Model.DAO
{
    class PessoaDao
    {

        private ConnectionDb connectionDb;

        public PessoaDao(ConnectionDb connection)
        {
            this.connectionDb = connection;
        }

        public void inserirPessoa(Pessoa pessoa)
        {
            var conn = connectionDb.GetConnection();

            conn.Open();
           

            var comando = new MySqlCommand("INSERT INTO pessoa (nome, cpf, rg, dataNascimento, sexo, profissao, escolaridade) " +
                "VALUES (@nome, @cpf, @rg, @dataNascimento, @sexo, @profissao, @escolaridade)", conn);
            comando.Parameters.AddWithValue("@nome", pessoa.Nome);
            comando.Parameters.AddWithValue("@cpf", pessoa.Cpf);
            comando.Parameters.AddWithValue("@rg", pessoa.Rg);
            comando.Parameters.AddWithValue("@dataNascimento", pessoa.DtNascimento);
            comando.Parameters.AddWithValue("@sexo", pessoa.Sexo);
            comando.Parameters.AddWithValue("@profissao", pessoa.Profissao);
            comando.Parameters.AddWithValue("@escolaridade", pessoa.Escolaridade);
            comando.ExecuteNonQuery();
            
            conn.Close();
        }

        public int selecionarUltimoId()
        {
            int ultimoID;
            var conn = connectionDb.GetConnection();
            conn.Open();

            var comando = new MySqlCommand("SELECT LAST_INSERT_ID()", conn);
            comando.ExecuteNonQuery();
            ultimoID = Convert.ToInt32(comando.ExecuteScalar());

            conn.Close();

            return ultimoID;
        }

        public void listaPessoa()
        {
            var conn = connectionDb.GetConnection();
            conn.Open();

            var comando = new MySqlCommand("SELECT * FROM pessoa");
            comando.ExecuteNonQuery();

            conn.Close();
        }

    }
}
