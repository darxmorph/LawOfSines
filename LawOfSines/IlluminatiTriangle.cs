using System;

namespace LawOfSines
{
    public class IlluminatiTriangle
    {
        public double angleA { get; set; }
        public double angleB { get; set; }
        public double angleC { get; set; }

        public double sideA { get; set; }
        public double sideB { get; set; }
        public double sideC { get; set; }

        public IlluminatiTriangle(double angleA, double angleB, double angleC, double sideA, double sideB, double sideC)
        {
            this.angleA = angleA;
            this.angleB = angleB;
            this.angleC = angleC;
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }
    }
}
