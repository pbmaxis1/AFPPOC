using ImpromptuNinjas.ZStd;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace ComparesAndDecompares
{
    class Program
    {

        public static void Main(string[] args)
        {
            // Create a Timer object that calls a callback method every second 
            Timer t = new Timer(TimerCallback, null, 0, 1000);

            var fileCreationInformation2 = new FileCreationInformation();
            //Assign to content byte[] i.e. documentStream          
            fileCreationInformation2.Content = System.IO.File.ReadAllBytes(@"G:\ComparesAndDecompares\MERGE_3080.AFP");

            var compressed = Compress(fileCreationInformation2.Content);
            System.IO.File.WriteAllBytes(@"G:\ComparesAndDecompares\compressed.AFP", compressed);
            Console.WriteLine("Input Length: {0}, Compressed Length: {1}", fileCreationInformation2.Content.Length, compressed.Length);

            var fileCreationInformation3 = new FileCreationInformation();
            //Assign to content byte[] i.e. documentStream
            var decompressed = Decompress(compressed);
            Console.WriteLine("Compressed Length: {0}, Decompressed Length: {1}", compressed.Length, decompressed.Length);
            System.IO.File.WriteAllBytes(@"G:\decompressed.AFP", decompressed);
        }
        private static void TimerCallback(Object o)
        {
            // Display the date/time when this method got called. 
            Console.WriteLine("In TimerCallback Compressor: " + DateTime.Now);
        }
        private static void TimerCallback1(Object o)
        {
            // Display the date/time when this method got called. 
            Console.WriteLine("In TimerCallback 1  Decompressor: " + DateTime.Now);
        }
        static byte[] Compress(byte[] input)
        {
            using var compressed = new MemoryStream();
            using var compressStream = new ZStdCompressStream(compressed);
            compressStream.Write(input, 0, input.Length);

            compressStream.Flush();
            return compressed.ToArray();

        }

        static byte[] Decompress(byte[] input)
        {
            using var compressed = new MemoryStream(input);
            using var decompressStream = new ZStdDecompressStream(compressed);

            using var output = new MemoryStream();
            var buffer = new byte[1024];
            var bytesRead = 0;

            //This while loop runs only once regardless of the length of buffer
            while ((bytesRead = decompressStream.Read(buffer, 0, buffer.Length)) > 0)
                output.Write(buffer, 0, bytesRead);

            return output.ToArray();
        }
        private static object ArraySegment<T>(object trainingData, int v1, int v2)
        {
            throw new NotImplementedException();
        }
    }
}
