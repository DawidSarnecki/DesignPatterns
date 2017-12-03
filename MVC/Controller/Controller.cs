using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Controller
{
    using Model;
    using View;
    public class Controller
    {
        private Calculator _model;
        private View _view;

        public Controller(decimal limit)
        {
            _model = new Calculator(limit, 0);
            _view = new View();
            _model.SumChanged += _view.DispalyStatus;
        }

        public void Run()
        {
            _view.DisplayIntro();
            bool exit = false;

            // main loop
            do
            {
                //now we don't need this method, now status is displayed automatically using event
                //_view.DispalyStatus();
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    exit = true;
                    continue;
                }

                decimal amount = 0; 
                try
                {
                    amount = decimal.Parse(input);
                    _model.Add(amount);
                }
                catch(Exception e)
                {
                    _view.DisplayError("Error: " + e.Message);
                }

            } while(!exit);

                _view.DisplayGoodbye();
        }
    }
}
