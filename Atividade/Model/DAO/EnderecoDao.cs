using System;
using System.Collections.Generic;
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

        public void inserirEndereco()
        {

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

    }
}
