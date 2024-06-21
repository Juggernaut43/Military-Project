using Model;
using System;
using System.Collections.Generic;
using System.Data;
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

        public void InsertCourse(Course course)
        {
            try
            {
                _command.Connection = _connection;
                _connection.Open();
                _command.CommandText = $"INSERT INTO {_tableName}(name,description,price,date,url) " +
                                       "VALUES(@name,@description,@price,@date,@url)";


                _command.Parameters.AddWithValue("@name", course.Name);
                _command.Parameters.AddWithValue("@description", course.Description);
                _command.Parameters.AddWithValue("@price", course.Price);
                _command.Parameters.AddWithValue("@date", course.Date);
                _command.Parameters.AddWithValue("@url", course.Url);


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
                    course.Id = Convert.ToInt32(_reader["id"]);
                    course.Name = _reader["name"].ToString();
                    course.Description = _reader["description"].ToString();
                    course.Price = Convert.ToInt32(_reader["price"].ToString());
                    course.Date = _reader["date"].ToString();
                    course.Url = _reader["url"].ToString();
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