using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Atividade.Model.DAO
{
    class TelefoneDao
    {

        private ConnectionDb connectionDb;

        public TelefoneDao(ConnectionDb connection)
        {
            this.connectionDb = connection;
        }

        public void inserirTelefone(ObservableCollection<Telefone> listTelefone, int id)
        {
            var conn = connectionDb.GetConnection();

            conn.Open();

            var comando = new MySqlCommand("INSERT INTO telefone (id_pessoa, ddd, numeroTelefone, operadora)" +
                "VALUES (@id_pessoa, @ddd, @numeroTelefone, @operadora)", conn);

            foreach (var telefone in listTelefone)
            {
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@id_pessoa", id);
                comando.Parameters.AddWithValue("@ddd", telefone.Ddd);
                comando.Parameters.AddWithValue("@numeroTelefone", telefone.TelefoneCelular);
                comando.Parameters.AddWithValue("@operadora", telefone.Operadora);

                comando.ExecuteNonQuery();
            }

            conn.Close();
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
