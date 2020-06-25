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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class SingleRandom : Page
    {
        private RandomNumber rn = new RandomNumber();
        private int _minInput;
        private int _maxInput;

        public SingleRandom()
        {
            InitializeComponent();
            _minInput = rn.GetMin();
            _maxInput = rn.GetMax();
        }

        private void SubmitData(object sender, RoutedEventArgs e)
        {
            string userMinInput = Box1.Text;
            string userMaxInput = Box2.Text;
           
            if (!String.IsNullOrEmpty(userMinInput))
            {
                _minInput = Convert.ToInt32(userMinInput);
                rn.SetMin(_minInput);
            }
            if (!String.IsNullOrEmpty(userMaxInput))
            {
                _maxInput = Convert.ToInt32(userMaxInput);
                rn.SetMax(_maxInput);
            }

            if (_maxInput <= _minInput)
            {
                MessageBox.Show("Minimum bound must be smaller than Maximum bound!");
                return;
            }
            ResultBlock.Text =  Convert.ToString(rn.GetRandomNumber());
        }
    }
}
