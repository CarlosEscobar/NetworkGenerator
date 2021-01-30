using Microsoft.AspNetCore.Mvc;
using NetworkGenerator.Models;
using NetworkGenerator.FileUtilities;

namespace NetworkGenerator.Controllers
{
    [ApiController]
    [Route("network/generator")]
    public class NetworkGeneratorController : ControllerBase
    {
        [HttpPost]
        public IActionResult GenerateNetworks(GeneratorInput inputModel)
        {
            return File(Zipper.Zip(Generator.GeneratePkts(inputModel)), "application/octet-stream");
        }
    }
}
