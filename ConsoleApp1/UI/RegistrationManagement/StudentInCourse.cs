using ConsoleApp1.BussinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.UI.RegistrationManagement
{
    internal class StudentInCourse : IPage
    {
        UI_Controller uI_Controller;
        RegistrationController registerController;

        public StudentInCourse(UI_Controller uI_Controller, RegistrationController registerController)
        {
            this.uI_Controller = uI_Controller;
            this.registerController = registerController;
        }

        public void RenderPage()
        {

        }
    }
}
