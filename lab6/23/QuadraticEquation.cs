using System;

namespace lab6._23
{
    public class QuadraticEquation
    {
        private double coefficientA;
        private double coefficientB;
        private double coefficientC;

        public double CoefficientA
        {
            get { return coefficientA; }
            set { coefficientA = value; }
        }

        public double CoefficientB
        {
            get { return coefficientB; }
            set { coefficientB = value; }
        }

        public double CoefficientC
        {
            get { return coefficientC; }
            set { coefficientC = value; }
        }

        public QuadraticEquation()
        {
            coefficientA = 1.0;
            coefficientB = 0.0;
            coefficientC = 0.0;
        }

        public QuadraticEquation(double a, double b, double c)
        {
            coefficientA = a;
            coefficientB = b;
            coefficientC = c;
        }

        public QuadraticEquation(QuadraticEquation other)
        {
            coefficientA = other.coefficientA;
            coefficientB = other.coefficientB;
            coefficientC = other.coefficientC;
        }

        public double CalculateDiscriminant()
        {
            return coefficientB * coefficientB - 4 * coefficientA * coefficientC;
        }

        public double[] Solve()
        {
            if (coefficientA == 0)
            {
                throw new InvalidOperationException(
                    "Коэффициент a не может быть равен нулю — это не квадратное уравнение.");
            }

            double discriminant = CalculateDiscriminant();

            if (discriminant < 0)
            {
                return new double[0];
            }

            if (discriminant == 0)
            {
                double root = -coefficientB / (2 * coefficientA);
                return new double[] { root };
            }

            double sqrtD = Math.Sqrt(discriminant);
            double denominator = 2 * coefficientA;
            double root1 = (-coefficientB + sqrtD) / denominator;
            double root2 = (-coefficientB - sqrtD) / denominator;

            return new double[] { root1, root2 };
        }

        public override string ToString()
        {
            string equation = $"{coefficientA}x^2";

            if (coefficientB >= 0)
            {
                equation += $" + {coefficientB}x";
            }
            else
            {
                equation += $" - {Math.Abs(coefficientB)}x";
            }

            if (coefficientC >= 0)
            {
                equation += $" + {coefficientC}";
            }
            else
            {
                equation += $" - {Math.Abs(coefficientC)}";
            }

            equation += " = 0";
            return equation;
        }



        public static QuadraticEquation operator ++(QuadraticEquation eq)
        {
            return new QuadraticEquation(
                eq.coefficientA + 1,
                eq.coefficientB + 1,
                eq.coefficientC + 1);
        }

        public static QuadraticEquation operator --(QuadraticEquation eq)
        {
            return new QuadraticEquation(
                eq.coefficientA - 1,
                eq.coefficientB - 1,
                eq.coefficientC - 1);
        }

        public static implicit operator double(QuadraticEquation eq)
        {
            return eq.CalculateDiscriminant();
        }

        public static explicit operator bool(QuadraticEquation eq)
        {
            if (eq.coefficientA == 0)
            {
                return false;
            }

            return eq.CalculateDiscriminant() >= 0;
        }

        public static bool operator ==(QuadraticEquation eq1, QuadraticEquation eq2)
        {
            if (ReferenceEquals(eq1, null) && ReferenceEquals(eq2, null))
            {
                return true;
            }

            if (ReferenceEquals(eq1, null) || ReferenceEquals(eq2, null))
            {
                return false;
            }

            return eq1.coefficientA == eq2.coefficientA &&
                   eq1.coefficientB == eq2.coefficientB &&
                   eq1.coefficientC == eq2.coefficientC;
        }

        public static bool operator !=(QuadraticEquation eq1, QuadraticEquation eq2)
        {
            return !(eq1 == eq2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            QuadraticEquation other = (QuadraticEquation)obj;
            return coefficientA == other.coefficientA &&
                   coefficientB == other.coefficientB &&
                   coefficientC == other.coefficientC;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + coefficientA.GetHashCode();
            hash = hash * 31 + coefficientB.GetHashCode();
            hash = hash * 31 + coefficientC.GetHashCode();
            return hash;
        }
    }
}
