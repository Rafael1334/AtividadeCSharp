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

        public void inserirPessoa(string nome, string cpf, string rg, string dataNascimento, string sexo, string profissao, string escolaridade)
        {
            var conn = connectionDb.GetConnection();

            conn.Open();

            var comando = new MySqlCommand("INSERT INTO pessoa (nome, cpf, rg, dataNascimento, sexo, profissao, escolaridade) " +
                "VALUES (@nome, @cpf, @rg, @dataNascimento, @sexo, @profissao, @escolaridade)", conn);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@cpf", cpf);
            comando.Parameters.AddWithValue("@rg", rg);
            comando.Parameters.AddWithValue("@dataNascimento", dataNascimento);
            comando.Parameters.AddWithValue("@sexo", sexo);
            comando.Parameters.AddWithValue("@profissao", profissao);
            comando.Parameters.AddWithValue("@escolaridade", escolaridade);
            comando.ExecuteNonQuery();

            conn.Close();
        }

    }
}
