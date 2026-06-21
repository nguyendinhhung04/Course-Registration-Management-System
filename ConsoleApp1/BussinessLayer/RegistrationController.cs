using ConsoleApp1.BussinessLayer.Models;
using ConsoleApp1.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
            Student existedStudent = data.studentList.FirstOrDefault(s => s.GetStudentID() == studentId);
            Course existedCourse = data.courseList.FirstOrDefault(c => c.GetCourseCode() == courseCode);
            if (existedStudent==null)
            {
                throw new ArgumentException("No student existed");
            }
            if (existedCourse == null)
            {
                throw new ArgumentException("No course existed");
            }

            if(!data.registrationList.FindAll(r => r.GetStudentId() == studentId).Exists(r => r.GetCourseCode() == courseCode))
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
    }
}
