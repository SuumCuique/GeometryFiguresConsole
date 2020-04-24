using System.Xml.Serialization;

namespace GeometryFigures {
    /// <summary>
    /// Abstract class for all figures
    /// </summary>
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Triangle))]
    [XmlInclude(typeof(Rectangle))]
    public abstract class Figure {
        /// <summary>
        /// Area of figure
        /// </summary>
        public abstract double Area { get; set; }
        /// <summary>
        /// Calculate area of figure
        /// </summary>
        public abstract void CalculateArea();
        /// <summary>
        /// return calculated area of figure
        /// </summary>
        /// <returns></returns>
        public double ReturnArea() {
            CalculateArea();
            return Area;
        }
    }
}