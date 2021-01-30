using NetworkGenerator.Generators;
using System;

namespace NetworkGenerator.Models
{
    public class Router
    {
        public int Id { get; }
        public string Name { get; }

        public string X { get; }
        public string Y { get; }
        public string XCoordinate { get; }
        public string YCoordinate { get; }

        public string BuildInAddr { get; }
        public string Port1MacAddress { get; }
        public string Port1IpV6DefaultLink { get; }
        public string Port2MacAddress { get; }
        public string Port2IpV6DefaultLink { get; }

        public Router(string xCoordinate, string yCoordinate)
        {
            Id = IdsGenerator.GenerateId();
            Name = "Router_" + Id;
            
            X = "0";
            Y = "0";
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;

            BuildInAddr = AddressesGenerator.GenerateBuildInAddr();
            Port1MacAddress = AddressesGenerator.GenerateMacAddress();
            Port1IpV6DefaultLink = AddressesGenerator.GenerateIpV6Address();
            Port2MacAddress = AddressesGenerator.GenerateMacAddress();
            Port2IpV6DefaultLink = AddressesGenerator.GenerateIpV6Address();
        }
    }

    public class Switch
    {
        public int Id { get; }
        public string Name { get; }

        public string X { get; }
        public string Y { get; }
        public string XCoordinate { get; }
        public string YCoordinate { get; }

        public string BuildInAddr { get; }
        public string Port1MacAddress { get; }
        public string Port2MacAddress { get; }
        public string Port3MacAddress { get; }
        public string Port4MacAddress { get; }
        public string Port5MacAddress { get; }
        public string Port6MacAddress { get; }
        public string Port7MacAddress { get; }
        public string Port8MacAddress { get; }
        public string Port9MacAddress { get; }
        public string Port10MacAddress { get; }
        public string Port11MacAddress { get; }
        public string Port12MacAddress { get; }
        public string Port13MacAddress { get; }
        public string Port14MacAddress { get; }
        public string Port15MacAddress { get; }
        public string Port16MacAddress { get; }
        public string Port17MacAddress { get; }
        public string Port18MacAddress { get; }
        public string Port19MacAddress { get; }
        public string Port20MacAddress { get; }
        public string Port21MacAddress { get; }
        public string Port22MacAddress { get; }
        public string Port23MacAddress { get; }
        public string Port24MacAddress { get; }

        public Switch(string name, string xCoordinate, string yCoordinate)
        {
            Id = IdsGenerator.GenerateId();
            Name = name;

            X = "0";
            Y = "0";
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;

            BuildInAddr = AddressesGenerator.GenerateBuildInAddr();
            Port1MacAddress = AddressesGenerator.GenerateMacAddress();
            Port2MacAddress = AddressesGenerator.GenerateMacAddress();
            Port3MacAddress = AddressesGenerator.GenerateMacAddress();
            Port4MacAddress = AddressesGenerator.GenerateMacAddress();
            Port5MacAddress = AddressesGenerator.GenerateMacAddress();
            Port6MacAddress = AddressesGenerator.GenerateMacAddress();
            Port7MacAddress = AddressesGenerator.GenerateMacAddress();
            Port8MacAddress = AddressesGenerator.GenerateMacAddress();
            Port9MacAddress = AddressesGenerator.GenerateMacAddress();
            Port10MacAddress = AddressesGenerator.GenerateMacAddress();
            Port11MacAddress = AddressesGenerator.GenerateMacAddress();
            Port12MacAddress = AddressesGenerator.GenerateMacAddress();
            Port13MacAddress = AddressesGenerator.GenerateMacAddress();
            Port14MacAddress = AddressesGenerator.GenerateMacAddress();
            Port15MacAddress = AddressesGenerator.GenerateMacAddress();
            Port16MacAddress = AddressesGenerator.GenerateMacAddress();
            Port17MacAddress = AddressesGenerator.GenerateMacAddress();
            Port18MacAddress = AddressesGenerator.GenerateMacAddress();
            Port19MacAddress = AddressesGenerator.GenerateMacAddress();
            Port20MacAddress = AddressesGenerator.GenerateMacAddress();
            Port21MacAddress = AddressesGenerator.GenerateMacAddress();
            Port22MacAddress = AddressesGenerator.GenerateMacAddress();
            Port23MacAddress = AddressesGenerator.GenerateMacAddress();
            Port24MacAddress = AddressesGenerator.GenerateMacAddress();
        }
    }

    public class NetworkNode
    {
        public int Correlative { get; set; }
        public Router Router { get; set; }
        public Switch Switch1 { get; set; }
        public Switch Switch2 { get; set; }

        private int PortSwitch { get; set; }
        private int PortCounter { get; set; }

        public NetworkNode()
        {
            Tuple<double, double> switch1Coordinates = CoordinatesGenerator.GenerateCoordinate();
            Tuple<double, double> switch2Coordinates = CoordinatesGenerator.GenerateCoordinate();
            Tuple<double, double> routerCoordinates = new Tuple<double, double>( (switch1Coordinates.Item1 + switch2Coordinates.Item1)/2, 
                                                                                 (switch1Coordinates.Item2 + switch2Coordinates.Item2)/2 );

            Router = new Router(Math.Round(routerCoordinates.Item1).ToString(),
                                Math.Round(routerCoordinates.Item2).ToString());

            Switch1 = new Switch(Router.Name + "_Switch1", 
                                 Math.Round(switch1Coordinates.Item1).ToString(),
                                 Math.Round(switch1Coordinates.Item2).ToString());

            Switch2 = new Switch(Router.Name + "_Switch2",
                                 Math.Round(switch2Coordinates.Item1).ToString(),
                                 Math.Round(switch2Coordinates.Item2).ToString());

            PortSwitch = 1;
            PortCounter = 2;
        }

        public Tuple<string,string> GetAvailablePort()
        {
            string switchId;
            if(PortSwitch == 1)
            {
                switchId = Switch1.Id.ToString();
            }
            else
            {
                switchId = Switch2.Id.ToString();
            }

            string fastEthernet = "FastEthernet0/" + (PortCounter++).ToString();

            if(PortCounter == 25)
            {
                PortSwitch = 2;
                PortCounter = 2;
            }

            return new Tuple<string,string>(switchId, fastEthernet);
        }
    }
}
