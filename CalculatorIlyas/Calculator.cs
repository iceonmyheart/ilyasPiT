using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorIlyas
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Substract(int a, int b) 
        {
            return a - b;
        }
        public int Multuply(int a, int b)
        {
            return a* b;    
        }
        public double Divide(int a, int b)
        {
            if (b== 0)
                throw new DivideByZeroException("Деление на ноль невозможно.");
            return (double)a/b;
        }
    }
}
