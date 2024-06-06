using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class RolesDB : BaseDB
    {
        public RolesDB() : base("Roles")
        {
            

        }


        public RolesList SelectAll()
        {
            _command.CommandText = string.Format("SELECT * from {0}", _tableName);
            RolesList lst = Select();
            return lst;
        }


        public RolesList Select()
        {
            RolesList list = new RolesList();
            try
            {
                _command.Connection = _connection;
                _connection.Open();
                _reader = _command.ExecuteReader(); ;
                Role role;
                while (_reader.Read())
                {
                    role = new Role();
                    role.Id = (int)_reader["id"];
                    RequirementsDB rdb = new RequirementsDB();
                    role.Requirements = rdb.SelectByRoleID(role.Id);
                    role.Name = (string)_reader["command"].ToString();
                    role.Description = (string)_reader["description"].ToString();
                    role.MinDapar = (int)_reader["minDapar"];
                    role.MinProfile = (int)_reader["minProfile"];
                    list.Add(role);
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
        public RolesList RolesSelection(int dapar, int profile, int command, int teamWork, int attentions, int informationProcession)
        {
            _command.CommandText = $"SELECT * from {_tableName} where minDapar > {dapar} and minProfile> {profile}";
            RolesList lst = Select();
            return lst;
        }
    }
}
