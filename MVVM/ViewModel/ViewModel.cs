using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MVVM.ViewModel
{
    using MVVM.Model;
    using System.Windows.Input;

    public class ViewModel : INotifyPropertyChanged
    {
        private Model model = new Model(0, 100);
        private ICommand addAmount;

        public ICommand AddAmount
        {
            get
            {
                if (addAmount == null)
                {
                    addAmount = new RelayCommand(
                        (object argument) => 
                        {
                            decimal amount = decimal.Parse((string)argument);
                            model.Add(amount);
                            OnPropertyChanged(nameof(Sum));
                        },
                        (object argument) => 
                        {
                            return IsInputCorrect((string)argument);
                        }
                        );
                }
                return addAmount;
            }
        }

        public decimal Sum
        {
            get
            {
                return model.Sum;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //alternative: (params string[] propertyName)
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public bool IsInputCorrect(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            decimal amount;
            if (!decimal.TryParse(input, out amount))
            {
                return false;
            }
            else
            {
                return model.isAmountCorrect(amount);
            }
        }
    }
}

