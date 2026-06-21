using ConsoleApp1.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.BussinessLayer.Models
{
    internal class Registration
    {
        string studentId;

        string courseCode;

        DateTime created_at;

        public Registration(string studentId, string courseCode, DateTime created_at)
        {
            this.studentId = studentId;
            this.courseCode = courseCode;
            this.created_at = created_at;
        }

        public string GetStudentId()
        {
            return studentId;
        }

        public void SetStudentId(string studentId)
        {
            this.studentId = studentId;
        }

        public string GetCourseCode()
        {
            return courseCode;
        }

        public void SetCourseCode(string courseCode)
        {
            this.courseCode = courseCode;
        }

        public DateTime GetCreatedAt()
        {
            return created_at;
        }

        public void SetCreatedAt(DateTime created_at)
        {
            this.created_at = created_at;
        }

    }
}
