using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class MultipleRandom : Page
    {
        private RandomNumber rn = new RandomNumber();
        private int _minInput;
        private int _maxInput;

        public MultipleRandom()
        {
            InitializeComponent();
            _minInput = rn.GetMin();
            _maxInput = rn.GetMax();
        }

        private bool VerifyUserInput(string userMinInput, string userMaxInput)
        {
            // Check Type of min input
            if (CheckValidType(userMinInput))
            {
                _minInput = Convert.ToInt32(userMinInput);
                rn.SetMin(_minInput);
            }
            else
            {
                return false;
            }

            // Check Type for max input
            if (CheckValidType(userMaxInput))
            {
                _maxInput = Convert.ToInt32(userMaxInput);
                rn.SetMax(_maxInput);
            }
            else
            {
                return false;
            }
            
            // Check bounds are valid (min < max)
            if (!CheckValidBounds(_minInput, _maxInput))
            {
                return false;
            }

            return true;
        }

        private bool CheckValidBounds(int a, int b)
        {
            if(a >= b)
            {
                MessageBox.Show($"Bound Error=> MIN value must be less than MAX value\nUser provided: {a} >= {b}");
                return false;
            }
            return true;
        }

        private bool CheckValidType(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return false;
            }

            int num = Convert.ToInt32(s);

            return true;
        }

        private void SubmitData(object sender, RoutedEventArgs e)
        {
            string userMinInput = Box1.Text;
            string userMaxInput = Box2.Text;

            if(!VerifyUserInput(userMinInput, userMaxInput))
            {
                return;
            }

            int numbersWanted = Convert.ToInt32(numberOfRandoms.Value);

            ResultBlock.Text = "";
            int[] numbers = new int[numbersWanted];
            numbers = rn.GetMultipleRandomNumbers(numbersWanted);

            int i = 0;
            while(i < numbersWanted)
            {
                ResultBlock.Text += numbers[i];
                if(i + 1 != numbersWanted)
                {
                    ResultBlock.Text += ", ";
                }
                i++;
            }
            
        }

        
    }
}
