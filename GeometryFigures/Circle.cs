using System;

namespace GeometryFigures {
    /// <summary>
    /// Class for circle type figures
    /// </summary>
    [Serializable]
    public class Circle : Figure {
        double Radius;
        public override double Area { get; set; }
        public Circle() { }
        public Circle(double radius) {
            Radius = radius;
        }

        public override void CalculateArea() {
            if(Radius <= 0)
                throw new ArgumentException(String.Format("{0} cannot be less than/equal to 0", Radius), "Radius");
            else
                Area = Math.PI * Radius * Radius;
        }
    }
}
