using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Model;

namespace ViewModel
{
    public class UsersDB : BaseDB
    {
        public UsersDB() : base("Users")
        {

        }
        public UsersList SelectALL()
        {
            _command.CommandText = " SELECT* from " + _tableName;
            UsersList lst = Select();
            return lst;
        }
        public User SelectByID(int id)
        {
            _command.CommandText = string.Format("SELECT * from {0}  WHERE id = {1}", _tableName, id);
            UsersList lst = Select();
            return lst.FirstOrDefault();
        }

        public UsersList Select()
        {
            UsersList list = new UsersList();
            try
            {
                _command.Connection = _connection;
                _connection.Open();
                _reader = _command.ExecuteReader(); ;
                User user;
                while (_reader.Read())
                {
                    user = new User();
                    user.Id = (int)_reader["id"];
                    user.Name = (string)_reader["firstName"].ToString();
                    user.LastName = (string)_reader["lastName"];
                    user.Birthday = (string)_reader["birthDate"];
                    user.Password = (string)_reader["password"];
                    user.IsAdmin = (bool)_reader["isAdmin"];
                    list.Add(user);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (_reader != null)
                    _reader.Close();
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }
            return list;
        }
        public void InsertUser(User user)
        {
            try
            {
                _command.Connection = _connection;
                _connection.Open();
                _command.CommandText = $"INSERT INTO {_tableName}(id,firstName,lastName,birthDate," +
                    "password, isAdmin) " + "VALUES(@id,@firstName,@lastName,@birthDate,@password,@isAdmin)";

                _command.Parameters.AddWithValue("@id", user.Id);
                _command.Parameters.AddWithValue("@firstName", user.Name);
                _command.Parameters.AddWithValue("@lastName", user.LastName);
                _command.Parameters.AddWithValue("@birthDate", user.Birthday);
                _command.Parameters.AddWithValue("@password", user.Password);
                _command.Parameters.AddWithValue("@isAdmin", user.IsAdmin);

                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

        }
    }
}

