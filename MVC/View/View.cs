using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Model;

namespace MVC.View
{
    public class View
    {
        private Calculator _model;
        public View(Calculator model)
        {
            _model = model;
        }

        private static void DisplayText(string textToDisplay, bool isEndLine = true)
        {
            if (isEndLine)
            {
                Console.WriteLine(textToDisplay);
                return;
            }

            Console.Write(textToDisplay);
        }

        public void DisplayIntro()
        {
            DisplayText("Hello!!!!");
        }

        public void DispalyStatus()
        {
            DisplayText($"Sum = { _model.Sum}, Limit = {_model.Limit}");
        }

        public void DisplayGoodbye()
        {
            DisplayText("Goodbye.");
        }

        public void DisplayError(string error)
        {
            DisplayText(error);
        }


    }
}
