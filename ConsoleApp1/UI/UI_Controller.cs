using ConsoleApp1.BussinessLayer;
using ConsoleApp1.UI.CourseManagement;
using ConsoleApp1.UI.ManageStudent;

namespace ConsoleApp1.UI
{
    internal class UI_Controller
    {
        StudentController studentController = null;
        CourseController courseController = null;
        int state = 0;
        Dictionary<int, IPage> pageList = new Dictionary<int, IPage>();


        public UI_Controller(StudentController studentController, CourseController courseController)
        {
            this.studentController = studentController;
            this.courseController = courseController;

            pageList.Add(0, new Menu(this));
            pageList.Add(1, new StudentManagementMenu(this));
            pageList.Add(2, new CourseManagementMenu(this));
            pageList.Add(5, new StudentList(this, studentController));
            pageList.Add(6, new SearhcStudentsById(this, studentController));
            pageList.Add(7, new AddStudent(this, studentController));
            pageList.Add(8, new CourseList(this, courseController));
            pageList.Add(9, new AddCourse(this, courseController));

        }

        public void RenderCurrentPage()
        {
            pageList[state].RenderPage();
        }

        public int GetUiState()
        {
            return state;
        }

        public void ChangeUiState(int newState)
        {
            state = newState;
        }
    }
}
