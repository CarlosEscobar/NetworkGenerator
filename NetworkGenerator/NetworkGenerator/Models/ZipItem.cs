using System.IO;

namespace NetworkGenerator.Models
{
    public class ZipItem
    {
        public string Name { get; set; }
        public Stream Content { get; set; }
        public ZipItem(string Name, Stream Content)
        {
            this.Name = Name;
            this.Content = Content;
        }
    }
}
