using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathoffile = args[0];
            StreamReader sr = new StreamReader(pathoffile);
            int counter = 0;
            string delim = " ,.";
            List<string> fields = new List<string>();
            string line = null;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                counter++;
                fields.AddRange(line.Split(delim.ToCharArray()));
            }
            sr.Close();
            Console.WriteLine("The word count is {0}", fields.Count);
            Console.WriteLine("The Line count is {0}", counter);
        }
    }
}
           
        



