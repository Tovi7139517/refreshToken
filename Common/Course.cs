using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Course
    {
        public int courses_id { get; set; }
        public string courses_name { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        
        public int Price { get; set; }
        //public List<Recommendation> Recommendations { get; set; }
        public int numberOfViewers  { get; set; }
        //public Timer Length { get; set;}
        //public DateTime create_at { get; set; }
        //public DateTime update_at { get; set; }


        //public Course MapCourse(SqlDataReader _reader)
        //{
        //    if (reader.Read())
        //    {
        //        Course course = new Course();

        //        course.courses_id = Convert.ToInt32(reader["courses_id"]);
        //        course.courses_name = reader["courses_name"].ToString();
        //        course.title = reader["title"].ToString();
        //        course.description = reader["description"].ToString();
        //        course.Price = Convert.ToInt32(reader["Price"]);
        //        //Recommendations = new List<Recommendation>();

        //        return course;
        //    }
        //    return null;
        //}



    }
}
