using ConsoleApp1.BussinessLayer.Models;
using ConsoleApp1.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1.BussinessLayer
{
    internal class RegistrationController
    {

        Data data = null;

        public RegistrationController(Data data)
        {
            this.data = data;
        }

        public string NewRegistration(string studentId, string courseCode)
        {
            Course existedCourse = data.courseList.FirstOrDefault(c => c.GetCourseCode() == courseCode);
            if (!data.studentList.ContainsKey(studentId))
            {
                throw new ArgumentException("No student existed");
            }
            if (existedCourse == null)
            {
                throw new ArgumentException("No course existed");
            }

            if(data.registrationList.FindAll(r => r.GetStudentId() == studentId).Exists(r => r.GetCourseCode() == courseCode))
            {
                throw new Exception("Student has already registered course");
            }

            List<Registration> temp = data.registrationList.FindAll(r => r.GetCourseCode() == courseCode);
            if(temp.Count() >= existedCourse.GetCapacity())
            {
                throw new Exception("No more slot in class");
            }

            data.registrationList.Add(new Registration(studentId, courseCode, DateTime.Now));

            return "Success";
        }

        public Dictionary<Course, List<Student>> GetRegistration()
        {
            Dictionary<Course, List<Student>> dict = new Dictionary<Course, List<Student>>();
            IEnumerable<IGrouping<string, Registration>> groupData = data.registrationList.GroupBy(r => r.GetCourseCode());

            foreach (IGrouping<string, Registration> group in groupData)
            {
                Course course = data.courseList.FirstOrDefault(c => c.GetCourseCode() == group.Key);
                List<Student> studentListInCourse = new List<Student>();
                foreach (Registration s in group)
                {
                    studentListInCourse.Add(data.studentList[s.GetStudentId()]);
                }
                dict[course] = studentListInCourse;
            }

            return dict;
        }
    }
}
