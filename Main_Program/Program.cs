using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OS_1
{
    class Program
    {
        private static string InitialDirectory;

        static void Main(string[] args)
        {
            InitialDirectory = Directory.GetCurrentDirectory();
            var pathway = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            Directory.SetCurrentDirectory(pathway);
            var Nshell = new Shell();
            Nshell.initialDirectory = InitialDirectory;
            Nshell.Start();
        }


    }
}
    

