using System;

namespace NetworkGenerator.Generators
{
    public static class CoordinatesGenerator
    {
        private static int XOrigin = 600;
        private static int YOrigin = 600;
        private static int Radius = 400;
        private static int CoordinatesCorrelative = 0;
        private static int NumberOfSwitches;

        public static void SetNumberOfSwitches(int numberOfSwitches)
        {
            NumberOfSwitches = numberOfSwitches;
        }

        public static Tuple<double, double> GenerateCoordinate()
        {
            double stepAngle = (2 * Math.PI) / NumberOfSwitches;
            double currentAngle = stepAngle * (CoordinatesCorrelative++);
            return new Tuple<double, double>(XOrigin + (Radius*Math.Cos(currentAngle)), YOrigin + (Radius * Math.Sin(currentAngle)));
        }

        public static void ResetCorrelative()
        {
            CoordinatesCorrelative = 0;
        }
    }
}
