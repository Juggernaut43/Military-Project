using Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    internal class Yom100GradesDB : BaseDB
    {
        public Yom100GradesDB() : base("Yom100Grades")
        {

        }
    
        public Yom100Grades SelectByID(int id)
        {
            _command.CommandText = string.Format("SELECT * from {0}  WHERE id = {1}", _tableName, id);
            Yom100GradesList lst = Select();
            return lst.FirstOrDefault();
        }


        public Yom100GradesList Select()
        {
            Yom100GradesList list = new Yom100GradesList();
            try
            {
                _command.Connection = _connection;
                _connection.Open();
                _reader = _command.ExecuteReader(); ;
                Yom100Grades yom100Grades;
                while (_reader.Read())
                {
                    yom100Grades = new Yom100Grades();
                    yom100Grades.Id = (int)_reader["id"];
                    yom100Grades.Command = (int)_reader["command"];
                    yom100Grades.Teamwork = (int)_reader["teamwork"];
                    yom100Grades.Attention = (int)_reader["attention"];
                    yom100Grades.InformationProcession = (int)_reader["informationProcession"];  
                    list.Add(yom100Grades);
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

