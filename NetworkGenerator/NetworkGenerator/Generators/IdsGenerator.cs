namespace NetworkGenerator.Generators
{
    public static class IdsGenerator
    {
        private static int Correlative = 0;

        public static int GenerateId()
        {
            return Correlative++;
        }

        public static void ResetCorrelative()
        {
            Correlative = 0;
        }
    }
}
