using ConsoleApp1.DataAccessLayer.Models;
using ConsoleApp1.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1.BussinessLayer
{
    internal class StudentController
    {
        Data data = null;

        public StudentController(Data data)
        {
            this.data = data;
        }

        public List<Student> GetStudents()
        {
            if(data==null)
            {
                throw new Exception("No Data");
            }
            return data.studentList;
        }

        public List<Student> GetStudentsById(string id)
        {
            return data.studentList.FindAll(s => s.GetStudentID() == id); ;
        }

        public string ValidateNewStudent(string ID, string name, DateOnly dob)
        {
            
            if (!String.IsNullOrEmpty(ID))
            {
                if (data.studentList.Exists(s => s.GetStudentID() == ID))
                {
                    return "Existed ID";
                }
            }
            if (string.IsNullOrWhiteSpace(ID) ||
                !Regex.IsMatch(ID, @"^S\d+$"))
            {
                return "Invalid ID";
            }
            if (data.studentList.FindAll(s => s.GetStudentFullname() == name).Exists(s => s.GetStudentDOB() == dob))
            {
                return "Student Existed";
            }

            return "Success";
        }

        public string AddStudent(string ID, string name, DateOnly dob)
        {
            if (string.IsNullOrEmpty(name) || dob == null)
            {
                throw new ArgumentNullException("Name or DOB is not allowed null value");
            }

            string result = (ValidateNewStudent(ID, name, dob));
            if (!  (result == "Success") )
            {
                throw new Exception(result);
            }

            try
            {
                Student newStudent = new Student();
                if (string.IsNullOrEmpty(ID))
                {
                    newStudent.SetStudentID("S" + (data.studentList.Count() + 1));
                }
                newStudent.SetStudentFullname(name);
                newStudent.SetStudentDOB(dob);
                data.studentList.Add(newStudent);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }


            return "Student saved";
        }
    }
}
