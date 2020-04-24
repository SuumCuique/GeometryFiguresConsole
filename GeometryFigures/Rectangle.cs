using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryFigures
{
    /// <summary>
    /// Class for rectangle type figures
    /// </summary>
    [Serializable]
    public class Rectangle : Figure
    {
        public double SideA;
        public double SideB;
        protected override double Area { get; set; }
        public Rectangle() { }
        public Rectangle(double a, double b)
        {
            SideA = a;
            SideB = b;
        }

        public override void CalculateArea()
        {
            if (SideA <= 0) throw new ArgumentException(String.Format("{0} cannot be less than/equal to 0", SideA), "A");
            else if (SideB <= 0) throw new ArgumentException(String.Format("{0} cannot be less than/equal to 0", SideB), "B");
            else Area = SideA * SideB;
        }
    }
}