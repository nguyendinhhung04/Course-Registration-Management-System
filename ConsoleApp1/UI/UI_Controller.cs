using ConsoleApp1.BussinessLayer;
using ConsoleApp1.UI.CourseManagement;
using ConsoleApp1.UI.ManageStudent;
using ConsoleApp1.UI.RegistrationManagement;

namespace ConsoleApp1.UI
{
    internal class UI_Controller
    {
        StudentController studentController = null;
        CourseController courseController = null;
        RegistrationController registerController = null;
        int state = 0;
        Dictionary<int, IPage> pageList = new Dictionary<int, IPage>();


        public UI_Controller(StudentController studentController, CourseController courseController, RegistrationController registerController)
        {
            this.studentController = studentController;
            this.courseController = courseController;
            this.registerController = registerController;

            pageList.Add(0, new Menu(this));
            pageList.Add(1, new StudentManagementMenu(this));
            pageList.Add(2, new CourseManagementMenu(this));
            pageList.Add(3, new RegistrationManagementMenu(this));
            pageList.Add(5, new StudentList(this, studentController));
            pageList.Add(6, new SearhcStudentsById(this, studentController));
            pageList.Add(7, new AddStudent(this, studentController));
            pageList.Add(8, new CourseList(this, courseController));
            pageList.Add(9, new AddCourse(this, courseController));
            pageList.Add(10, new StudentRegister(this, registerController));
            pageList.Add(11, new StudentInCourse(this, registerController, courseController, studentController));

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
