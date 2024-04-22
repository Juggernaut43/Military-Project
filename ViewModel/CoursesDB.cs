using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ViewModel
{

    public class CoursesDB : BaseDB
    {
        public CoursesDB() : base("Courses")
        {
        }
        public CoursesList SelectALL()
        {
            _command.CommandText = " SELECT * from " + _tableName;
            CoursesList lst = Select();
            return lst;
        }
        public CoursesList SelectByID(int id)
        {
            _command.CommandText = string.Format(" SELECT * from {0} WHERE id = {1}", _tableName, id);
            CoursesList lst = Select();
            return lst;
        }
        public CoursesList SelectByName(string name)
        {
            _command.CommandText = string.Format(" SELECT * from {0} WHERE name = {1}", _tableName);
            CoursesList lst = Select();
            return lst;
        }


        public CoursesList Select()
        {
            CoursesList list = new CoursesList();
            try
            {
                _command.Connection = _connection;
                _connection.Open();
                _reader = _command.ExecuteReader(); ;
                Course course;
                while (_reader.Read())
                {
                    course = new Course();
                    course.Id = Convert.ToInt32(_reader["Id"]);
                    course.Name = _reader["name"].ToString();
                    course.Description = _reader["descriptions"].ToString();
                    course.Price = Convert.ToInt32(_reader["price"].ToString());
                    course.Date = Convert.ToDateTime(_reader["date"].ToString());
                    list.Add(course);
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