using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryFigures
{
    /// <summary>
    /// Class for triangle type figures
    /// </summary>
    [Serializable]
    public class Triangle : Figure
    {
        public double SideA;
        public double SideB;
        public double SideC;
        protected override double Area { get; set; }
        public Triangle() { }
        public Triangle(double a, double b, double c)
        {
            SideA = a;
            SideB = b;
            SideC = c;
        }

        public override void CalculateArea()
        {
            double Perimetr = SideA + SideB + SideC;
            if (SideA <= 0) throw new ArgumentException(String.Format("{0} cannot be less than/equal to 0", SideA), "A");
            else if (SideB <= 0) throw new ArgumentException(String.Format("{0} cannot be less than/equal to 0", SideB), "B");
            else if (SideC <= 0) throw new ArgumentException(String.Format("{0} cannot be less than/equal to 0", SideC), "C");
            else Area = Math.Sqrt(Perimetr * (Perimetr - SideA) * (Perimetr - SideB) * (Perimetr - SideC));
        }
    }
}
