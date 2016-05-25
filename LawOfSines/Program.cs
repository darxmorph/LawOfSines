using System;

namespace LawOfSines
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please note the unit used for angles is Degrees");
            Console.WriteLine("");
            Console.WriteLine("Angle A:");
            float angleA = float.Parse(Console.ReadLine());
            Console.WriteLine("Angle B:");
            float angleB = float.Parse(Console.ReadLine());
            Console.WriteLine("Angle C:");
            float angleC = float.Parse(Console.ReadLine());
            Console.WriteLine("Side A:");
            float sideA = float.Parse(Console.ReadLine());
            Console.WriteLine("Side B:");
            float sideB = float.Parse(Console.ReadLine());
            Console.WriteLine("Side C:");
            float sideC = float.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Result: ");
            IlluminatiTriangle tr = LawOfSines(toRadians(angleA), toRadians(angleB), toRadians(angleC), sideA, sideB, sideC);

            if (tr == null) {
                Console.WriteLine("ERROR: maybe you're missing data?");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Angle A: " + toDegrees(tr.angleA).ToString());
            Console.WriteLine("Angle B: " + toDegrees(tr.angleB).ToString());
            Console.WriteLine("Angle C: " + toDegrees(tr.angleC).ToString());
            Console.WriteLine("Side A: " + tr.sideA.ToString());
            Console.WriteLine("Side B: " + tr.sideB.ToString());
            Console.WriteLine("Side C: " + tr.sideC.ToString());

            Console.ReadLine();
        }

        static IlluminatiTriangle LawOfSines(double angleA, double angleB, double angleC, double sideA, double sideB, double sideC) {
            bool haveAngleA = (angleA != 0);
            bool haveAngleB = (angleB != 0);
            bool haveAngleC = (angleC != 0);
            bool haveSideA = (sideA != 0);
            bool haveSideB = (sideB != 0);
            bool haveSideC = (sideC != 0);
            bool haveAll = haveAngleA && haveAngleB && haveAngleC && haveSideA && haveSideB && haveSideC;
            bool canSolveMore = ((haveAngleA && !haveSideA) || (haveSideA && !haveAngleA)
                || (haveAngleB && !haveSideB) || (haveSideB && !haveAngleB)
                || (haveAngleC && !haveAngleC) || (haveSideC && !haveAngleC));

            // at least: 1*(sideX + AngleX) + 1 side/angle
            bool meetsRequirements = (((haveAngleA && haveSideA) && (haveAngleB || haveSideB || haveAngleC || haveSideC))
                || ((haveAngleB && haveSideB) && (haveAngleA || haveSideA || haveAngleC || haveSideC))
                || ((haveAngleC && haveSideC) && (haveAngleA || haveSideA || haveAngleB || haveSideB)));

            if (meetsRequirements) {
                // REAL MATH LOL
                while (canSolveMore)
                {
                    if (haveAngleA && haveSideA)
                    {
                        if (haveAngleB && !haveSideB)
                        {
                            // a/sinA = b/sinB
                            // b=(a*sinB)/sinA
                            sideB = (sideA * Math.Sin(angleB)) / Math.Sin(angleA);
                        }

                        if (haveAngleC && !haveSideC)
                        {
                            sideC = (sideA * Math.Sin(angleC)) / Math.Sin(angleA);
                        }

                        if (haveSideB && !haveAngleB)
                        {
                            // sinB = (sinA*b)/a
                            angleB = Math.Asin((Math.Sin(angleA) * sideB) / sideA);
                        }

                        if (haveSideC && !haveAngleC)
                        {
                            angleC = Math.Asin((Math.Sin(angleA) * sideC) / sideA);
                        }
                    }
                    if (haveAngleB && haveSideB)
                    {
                        if (haveAngleA && !haveSideA)
                        {
                            sideA = (sideB * Math.Sin(angleA)) / Math.Sin(angleB);
                        }

                        if (haveAngleC && !haveSideC)
                        {
                            sideC = (sideB * Math.Sin(angleC)) / Math.Sin(angleB);
                        }

                        if (haveSideA && !haveAngleA)
                        {
                            angleA = Math.Asin((Math.Sin(angleB) * sideA) / sideB);
                        }

                        if (haveSideC && !haveAngleC)
                        {
                            angleC = Math.Asin((Math.Sin(angleB) * sideC) / sideB);
                        }
                    }
                    if (haveAngleC && haveSideC)
                    {
                        if (haveAngleA && !haveSideA)
                        {
                            sideA = (sideC * Math.Sin(angleA)) / Math.Sin(angleC);
                        }

                        if (haveAngleB && !haveSideB)
                        {
                            sideB = (sideC * Math.Sin(angleB)) / Math.Sin(angleC);
                        }

                        if (haveSideA && !haveAngleA)
                        {
                            angleA = Math.Asin((Math.Sin(angleC) * sideA) / sideC);
                        }

                        if (haveSideB && !haveAngleB)
                        {
                            angleB = Math.Asin((Math.Sin(angleC) * sideB) / sideC);
                        }
                    }

                    // Last angle

                    haveAngleA = (angleA != 0);
                    haveAngleB = (angleB != 0);
                    haveAngleC = (angleC != 0);
                    haveSideA = (sideA != 0);
                    haveSideB = (sideB != 0);
                    haveSideC = (sideC != 0);

                    if (haveAngleA && haveAngleB && !haveAngleC)
                    {
                        angleC = Math.PI - angleA - angleB;
                    }

                    if (haveAngleA && !haveAngleB && haveAngleC)
                    {
                        angleB = Math.PI - angleA - angleC;
                    }

                    if (!haveAngleA && haveAngleB && haveAngleC)
                    {
                        angleA = Math.PI - angleB - angleC;
                    }

                    haveAngleA = (angleA != 0);
                    haveAngleB = (angleB != 0);
                    haveAngleC = (angleC != 0);
                    haveSideA = (sideA != 0);
                    haveSideB = (sideB != 0);
                    haveSideC = (sideC != 0);

                    haveAll = haveAngleA && haveAngleB && haveAngleC && haveSideA && haveSideB && haveSideC;
                    canSolveMore = ((haveAngleA && !haveSideA) || (haveSideA && !haveAngleA)
                        || (haveAngleB && !haveSideB) || (haveSideB && !haveAngleB)
                        || (haveAngleC && !haveSideC) || (haveSideC && !haveAngleC));
                }

                return new IlluminatiTriangle(angleA, angleB, angleC, sideA, sideB, sideC);
            }

            return null;
        }

        static double toRadians(double angledeg) {
            return (Math.PI / 180.0) * angledeg;
        }

        static double toDegrees(double anglerad)
        {
            return anglerad * (180.0 / Math.PI);
        }
    }
}
