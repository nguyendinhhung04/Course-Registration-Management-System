using ConsoleApp1.BussinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.BussinessLayer
{
    internal class CourseController
    {
        Data data = null;

        public CourseController(Data data)
        {
            this.data = data;
        }

        public List<Course> GetCourses()
        {
            return data.courseList;
        }

        public string ValidateNewCourse(string courseName, string courseCode, int capacity, float fee)
        {
            if( data.courseList.Exists(c => c.GetCourseName() == courseName) ) 
            {
                return "Course Name has already exsisted";
            }

            if (data.courseList.Exists(c => c.GetCourseCode() == courseCode))
            {
                return "Course Code has already exsisted";
            }
            if(capacity<= 0) 
            {
                return "Capacity is not allowed <= 0";
            }
            if (fee < 0)
            {
                return "Capacity is not allowed < 0";
            }

            return "Valid";
        }

        public string AddCourse( string courseName, string courseCode, int capacity, float fee) 
        {
            string result = ValidateNewCourse(courseName, courseCode, capacity, fee);
            if ( ! (result == "Valid") )
            {
                throw new Exception(result);
            }

            try
            {
                Course newCourse = new Course(courseName, courseCode, capacity, fee);
                data.courseList.Add(newCourse);

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }


            return "Course Saved";
        }
    }
}
