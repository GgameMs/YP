using System;

namespace lab6_1
{
    public class ThreeIntegers
    {
        private int firstField;
        private int secondField;
        private int thirdField;

        public int FirstField
        {
            get { return firstField; }
            set { firstField = value; }
        }

        public int SecondField
        {
            get { return secondField; }
            set { secondField = value; }
        }

        public int ThirdField
        {
            get { return thirdField; }
            set { thirdField = value; }
        }

        public ThreeIntegers()
        {
            firstField = 0;
            secondField = 0;
            thirdField = 0;
        }

        public ThreeIntegers(int first, int second, int third)
        {
            firstField = first;
            secondField = second;
            thirdField = third;
        }

        public ThreeIntegers(ThreeIntegers other)
        {
            firstField = other.firstField;
            secondField = other.secondField;
            thirdField = other.thirdField;
        }

        public int GetMinLastDigit()
        {
            int lastDigit1 = Math.Abs(firstField) % 10;
            int lastDigit2 = Math.Abs(secondField) % 10;
            int lastDigit3 = Math.Abs(thirdField) % 10;

            int minDigit = lastDigit1;

            if (lastDigit2 < minDigit)
            {
                minDigit = lastDigit2;
            }

            if (lastDigit3 < minDigit)
            {
                minDigit = lastDigit3;
            }

            return minDigit;
        }

        public override string ToString()
        {
            return $"ThreeIntegers: FirstField = {firstField}, " +
                   $"SecondField = {secondField}, ThirdField = {thirdField}";
        }
    }
}
