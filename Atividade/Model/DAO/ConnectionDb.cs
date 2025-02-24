using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Atividade.Model.DAO
{
    class ConnectionDb
    {

        private string connectionString = "SERVER=localhost;DATABASE=atividade4SecGlobal;USER=root;PASSWORD=root";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

    }
}
