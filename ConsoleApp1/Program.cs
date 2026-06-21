using ConsoleApp1.BussinessLayer;
using ConsoleApp1.UI;

public class Program
{
    public static void Main()
    {
        //Init 
        Data data = new Data();
        StudentController studentController = new StudentController(data);
        CourseController courseController = new CourseController(data);
        RegistrationController registrationController = new RegistrationController(data);
        UI_Controller ui_controller = new UI_Controller(studentController, courseController, registrationController);

        while (ui_controller.GetUiState() > -1)
        {
            //Render the current UI 
            ui_controller.RenderCurrentPage();
        }
    }


}