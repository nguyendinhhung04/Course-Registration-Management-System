using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.DataAccessLayer.Models
{
    class Student
    {
        string student_fullname { get; set; }
        string student_ID { get; set; }
        DateOnly student_dob { get; set; }

        public String GetStudentFullname()
        {
            return student_fullname;
        }

        public void SetStudentFullname(string name)
        {
            student_fullname = name;
        }

        public String GetStudentID()
        {
            return student_ID;
        }
        public DateOnly GetStudentDOB()
        {
            return student_dob;
        }

        public void SetStudentDOB(DateOnly dob)
        {
            student_dob = dob;
        }

        public void SetStudentID(String studentID)
        {
            student_ID = studentID;
        }

        public Student()
        {

        }

        public Student(string studentID, string studentFullName, DateOnly studentDOB)
        {
            student_ID = studentID;
            student_fullname = studentFullName;
            student_dob = studentDOB;
        }


    }
}