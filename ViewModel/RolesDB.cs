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


        //public RolesList Select()
        //{
        //    RolesList list = new RolesList();
        //    try
        //    {
        //        _command.Connection = _connection;
        //        _connection.Open();
        //        _reader = _command.ExecuteReader(); ;
        //        Role role;
        //        while (_reader.Read())
        //        {
        //            role = new Role();
        //            role.Id = (int)_reader["id"];
        //            RequirementsDB rdb = new RequirementsDB();
        //            role.Requirements = rdb.SelectByRoleID(role.Id);
        //            role.Name = (string)_reader["command"].ToString();
        //            role.Description = (string)_reader["description"].ToString();
        //            role.MinDapar = (int)_reader["minDapar"];
        //            role.MinProfile = (int)_reader["minProfile"];
        //            list.Add(role);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        if (_reader != null)
        //            _reader.Close();
        //        if (_connection.State == System.Data.ConnectionState.Open)
        //            _connection.Close();
        //    }
        //    return list;           
        //}
        public RolesList RolesSelection(int dapar, int profile, int command, int teamWork, int attentions, int informationProcession)
        {
            _command.CommandText = $"select Roles.*, Requirements.skill,Requirements.minGrade from Roles" +
                $"right join" +
                $"(select Roles.id from Roles " +
                $"right join (select Count(Roles.id) as numberOfrequirementsMet, Roles.id as queryid " +
                $"From Roles " +
                $"left join Requirements on Requirements.roleId = Roles.id " +
                $"where Roles.minDapar <={dapar} and Roles.minProfile <={profile} and " +
                $"(Requirements.skill =1 and Requirements.minGrade<={command}) or" +
                $"(Requirements.skill =2 and Requirements.minGrade<={teamWork})or" +
                $"(Requirements.skill =3 and Requirements.minGrade<={attentions})or" +
                $"(Requirements.skill =4 and Requirements.minGrade<={informationProcession})" +
                $"GROUP BY Roles.id " +
                $"HAVING Count(Roles.id) = 4) as metIds " +
                $"on metIds.queryid = Roles.id) as ids on Roles.id = ids.id " +
                $"left join Requirements on Requirements.roleId = Roles.id ";
            RolesList lst = Select();
            return lst;
        }

        public RolesList SelectALL()
        {
            _command.CommandText = "select Roles.*, Requirements.skill, Requirements.minGrade from Roles left join Requirements on Requirements.roleId = Roles.id";
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
                Role role = new Role();
                Requirement requierment;
                int lastRoleid = -1;
                while (_reader.Read())
                {
                    int id = (int)_reader["id"];
                    if (id != lastRoleid)
                    {
                        lastRoleid = id;
                        role = new Role();
                        role.Id = id;
                        role.Name = _reader["name"].ToString();
                        role.Description = _reader["description"].ToString();
                        role.MinDapar = (int)_reader["minDapar"];
                        role.MinProfile = (int)_reader["minProfile"];
                        role.Requirements = new RequirementsList();
                        list.Add(role);
                    }

                    requierment = new Requirement();
                    requierment.RoleId = role.Id;
                    requierment.Skill = (Skills)(int)_reader["skill"];
                    requierment.MinGrade = (int)_reader["minGrade"];
                    role.Requirements.Add(requierment);
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
