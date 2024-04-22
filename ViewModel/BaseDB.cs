using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ViewModel
{
    public class BaseDB
    {
        private string connectionString;
        protected SqlConnection _connection;
        protected SqlCommand _command;
        protected SqlDataReader _reader;
        protected string _tableName;
        public BaseDB(string tableName)
        {
            _tableName = tableName;
            connectionString = @"Data Source=_JAGGERNAUT_\SQLEXPRESS;Initial Catalog=MilitaryAppDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            _connection = new SqlConnection(connectionString);
            _command = new SqlCommand();
            _command.Connection = _connection;
        }
    }
}
