namespace NetworkGenerator.Generators
{
    public static class AddressesGenerator
    {
        private static int MacAddressCorrelative = 0;
        private static int BuildInAddrCorrelative = 0;
        private static int IpV6Correlative = 0;

        public static string GenerateMacAddress()
        {
            return "0CA1.0CA1." + (MacAddressCorrelative++).ToString("X4");
        }

        public static string GenerateBuildInAddr()
        {
            return "0CA1.0CA1." + (BuildInAddrCorrelative++).ToString("X4");
        }

        public static string GenerateIpV6Address()
        {
            return "0CA1::CA1:0CA1:0CA1:" + (IpV6Correlative++).ToString("X4");
        }

        public static void ResetCorrelatives()
        {
            MacAddressCorrelative = 0;
            BuildInAddrCorrelative = 0;
            IpV6Correlative = 0;
        }
    }
}
