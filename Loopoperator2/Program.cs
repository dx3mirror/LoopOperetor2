using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Loopoperator2
{
    internal class Program
    {
        public abstract class NumberOperatorBase
        {
            protected readonly int Number;

            protected NumberOperatorBase(int number)
            {
                Number = number;
            }

            public abstract int RunOperation();
        }

        public class SumLastDigitsStrategy : NumberOperatorBase
        {
            private readonly int _m;

            public SumLastDigitsStrategy(int number, int m) : base(number)
            {
                _m = m;
            }

            public override int RunOperation()
            {
                if (Number.ToString().Length < _m)
                    throw new Exception("m must be less than number of digits in a number");

               
                var numberAsString = Number.ToString();
                var mLastDigits = numberAsString.Substring(numberAsString.Length - _m);
                var sum = mLastDigits.Sum(c => int.Parse(c.ToString()));

                return sum;

            }
        }

        public static void Start()
        {
            var strategy = new SumLastDigitsStrategy(123456, 3);
            var sum = strategy.RunOperation();
        }
        static void Main(string[] args) => Start();
    }
}
