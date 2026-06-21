using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.BussinessLayer.Models
{
    public class Course
    {
        string courseName;
        string courseCode;
        int capacity;
        float fee;

        public Course() { }

        public Course(string courseName,string courseCode, int capacity, float fee) 
        {
            this.courseName = courseName;
            this.courseCode = courseCode;
            this.capacity = capacity;
            this.fee = fee;
        }

        public string GetCourseName()
        {
            return courseName;
        }

        public void SetCourseName(string courseName)
        {
            this.courseName = courseName;
        }

        public string GetCourseCode()
        {
            return courseCode;
        }

        public void SetCourseCode(string courseCode)
        {
            this.courseCode = courseCode;
        }

        public int GetCapacity()
        {
            return capacity;
        }

        public void SetCapacity(int capacity)
        {
            this.capacity = capacity;
        }

        public float GetFee()
        {
            return fee;
        }

        public void SetFee(float fee)
        {
            this.fee = fee;
        }

    }
}
