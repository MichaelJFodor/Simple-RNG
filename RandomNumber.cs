using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class RandomNumber
    {
        private int _number;
        private int _min = 0;
        private int _max = 999999;
        private readonly Random _random = new Random();

        public void SetMin(int min)
        {
            _min = min;
        }

        public void SetMax(int max)
        {
            _max = max;
        }

        public int GetMin()
        {
            return _min;
        }

        public int GetMax()
        {
            return _max;
        }

        public int GetRandomNumber()
        {
            _number = _random.Next(_min, _max);
            return _number;
        }

        public int[] GetMultipleRandomNumbers(int n)
        {
            int[] numbers = new int[n];

            int i = 0;           
            while(i < n)
            {
                numbers[i++] = GetRandomNumber();
            }
            return numbers;
        }
    }
}
