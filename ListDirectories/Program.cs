using System;
using System.IO;

namespace ListDirectories
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(Directory.GetCurrentDirectory());
            var directories = Directory.GetDirectories(Directory.GetCurrentDirectory());
            string change = Convert.ToString(Directory.GetCurrentDirectory());
            change += '\\';
            foreach (var dir in directories)
            {
                Console.WriteLine(dir);
            };

            foreach (var file in files)
            {
                Console.WriteLine(file.Replace(change, " "));
            }
        }
    }
}
