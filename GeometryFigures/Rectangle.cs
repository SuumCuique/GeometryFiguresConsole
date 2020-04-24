using System;

namespace GeometryFigures {
    /// <summary>
    /// Class for rectangle type figures
    /// </summary>
    [Serializable]
    public class Rectangle : Figure {
        double SideA;
        double SideB;
        public override double Area { get; set; }
        public Rectangle() { }
        public Rectangle(double a, double b) {
            SideA = a;
            SideB = b;
        }

        public override void CalculateArea() {
            if(SideA <= 0)
                throw new ArgumentException(String.Format("{0} cannot be less than/equal to 0", SideA), "A");
            else if(SideB <= 0)
                throw new ArgumentException(String.Format("{0} cannot be less than/equal to 0", SideB), "B");
            else
                Area = SideA * SideB;
        }
    }
}