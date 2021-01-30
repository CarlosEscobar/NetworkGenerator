using System.Collections.Generic;

namespace NetworkGenerator.Models
{
    public class RouterDTO
    {
        public string Type { get; set; }
        public string Quantity { get; set; }
    }

    public class GeneratorInput
    {
        public string NetworkName { get; set; }
        public List<RouterDTO> Routers { get; set; }
    }
}
