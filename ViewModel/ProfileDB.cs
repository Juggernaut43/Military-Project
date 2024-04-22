using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ProfileDB : BaseDB
    {
        public ProfileDB() : base("Users")
        {

        }
        public ProfileList SelectALL()
        {
            _command.CommandText = " SELECT* from " + _tableName;
            ProfileList lst = Select();
            return lst;
        }
        public ProfileList SelectByID(int id)
        {
            _command.CommandText = string.Format("SELECT * from {0}  WHERE id = {1}", _tableName, id);
            ProfileList lst = Select();
            return lst;
        }


        public ProfileList Select()
        {
            ProfileList list = new ProfileList();
            try
            {
                _command.Connection = _connection;
                _connection.Open();
                _reader = _command.ExecuteReader(); ;
                Profile profile;
                while (_reader.Read())
                {
                    profile = new Profile();

                    int userId = (int)_reader["userId"];
                    UsersDB udb = new UsersDB();
                    profile.User = udb.SelectByID(userId);

                    profile.Dapar = (int)_reader["dapar"];
                    profile.ProfileGrade = (int)_reader["profile"];

                    int id100= (int)_reader["yom100Id"];
                    Yom100GradesDB yom100Grades = new Yom100GradesDB();
                    profile.Y100Grades = yom100Grades.SelectByID(id100);
                    list.Add(profile);
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

        public Profile GetProfileByUserId(int userId)
        {
            _command.CommandText = string.Format("SELECT * from {0}  WHERE userId = {1}", _tableName, userId);
            ProfileList lst = Select();
            return lst.FirstOrDefault();
        }
    }
}
