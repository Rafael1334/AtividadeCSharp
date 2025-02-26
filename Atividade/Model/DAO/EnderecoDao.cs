using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Atividade.Model.DAO
{
    class EnderecoDao
    {

        private ConnectionDb connectionDb;

        public EnderecoDao(ConnectionDb connection) 
        { 
            this.connectionDb = connection;
        }

        public void inserirEndereco(ObservableCollection<Endereco> listEndereco, int id)
        {
            var conn = connectionDb.GetConnection();

            conn.Open();

            var comando = new MySqlCommand("INSERT INTO endereco (id_pessoa, logradouro, numeroCasa, complemento, bairro, cidade, estado)" +
                "VALUES (@id_pessoa, @logradouro, @numeroCasa, @complemento, @bairro, @cidade, @estado)", conn);

            foreach (var endereco in listEndereco)
            {
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@id_pessoa", id);
                comando.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
                comando.Parameters.AddWithValue("@numeroCasa", endereco.Numero);
                comando.Parameters.AddWithValue("@complemento", endereco.Complemento);
                comando.Parameters.AddWithValue("@bairro", endereco.Bairro);
                comando.Parameters.AddWithValue("@cidade", endereco.Cidade);
                comando.Parameters.AddWithValue("@estado", endereco.Estado);

                comando.ExecuteNonQuery();
            }

            conn.Close();
        }

        public DataTable listar()
        {
            var conn = connectionDb.GetConnection();

            conn.Open();

            var cmd = new MySqlCommand("SELECT * FROM endereco WHERE id_pessoa = @id_pessoa", conn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            conn.Close();

            return dt;

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
