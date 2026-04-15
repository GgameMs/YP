using System;

namespace lab6_1
{
    public class RGBColor : ThreeIntegers
    {
        public RGBColor()
            : base(0, 0, 0)
        {
        }

        public RGBColor(int red, int green, int blue)
            : base(_ClampChannel(red), _ClampChannel(green), _ClampChannel(blue))
        {
        }

        public RGBColor(RGBColor other)
            : base(other.FirstField, other.SecondField, other.ThirdField)
        {
        }

        private static int _ClampChannel(int value)
        {
            if (value < 0)
            {
                return 0;
            }

            if (value > 255)
            {
                return 255;
            }

            return value;
        }

        public bool IsGrayscale()
        {
            return FirstField == SecondField && SecondField == ThirdField;
        }

        public RGBColor InvertColor()
        {
            int invertedRed = 255 - FirstField;
            int invertedGreen = 255 - SecondField;
            int invertedBlue = 255 - ThirdField;

            return new RGBColor(invertedRed, invertedGreen, invertedBlue);
        }

        public string ToHexString()
        {
            return $"#{FirstField:X2}{SecondField:X2}{ThirdField:X2}";
        }

        public override string ToString()
        {
            return $"RGBColor({ToHexString()}): " +
                   $"R = {FirstField}, G = {SecondField}, B = {ThirdField}";
        }
    }
}
