using System;
using System.Diagnostics;
using System.IO;

namespace NetworkGenerator.FileUtilities
{
    public static class XmlConverter
    {
        public static void ConvertXmlToPkt(string xmlFilePath, string pktFilePath)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = Constants.PythonExePath;
            start.Arguments = string.Format("{0} -e {1} {2}", Constants.PythonConverterPath, xmlFilePath, pktFilePath);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                }
            }
        }
    }
}
