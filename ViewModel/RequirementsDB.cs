using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    internal class RequirementsDB : BaseDB
    {

        public RequirementsDB() : base("Requirements")
        {

        }

        public RequirementsList SelectALL()
        {
            _command.CommandText = " SELECT* from " + _tableName;
            RequirementsList lst = Select();
            return lst;
        }

        public RequirementsList SelectByRoleID(int id)
        {
            _command.CommandText = string.Format("SELECT * from {0}  WHERE roleId = {1}", _tableName, id);
            RequirementsList lst = Select();
            return lst;
        }

        public RequirementsList Select()
        {
            RequirementsList list = new RequirementsList();
            try
            {
                _command.Connection = _connection;
                _connection.Open();
                _reader = _command.ExecuteReader(); ;
                Requirement requirement;
                while (_reader.Read())
                {
                    requirement = new Requirement();
                    requirement.RoleId = (int)_reader["roleId"];
                    requirement.Skill = (Skills)_reader["skills"];
                    requirement.MinGrade = (int)_reader["minGrade"];
                    list.Add(requirement);
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
    }
}
