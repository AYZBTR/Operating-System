using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OS_1
{
    class Shell
    {
        public string initialDirectory;

        private Dictionary<string, string> Aliases = new Dictionary<string, string>
        {
            {"ls" , @"\ListDirectories.exe"},
            {"pwd" , @"\PrintDirectory.exe" },
            {"wc" , @"\WordCount.exe" }

        };

        public void Start() 
        {


            string value = null;
            do
            {
                Console.Write("AYZBTR-$ ");
                value = Console.ReadLine();
                if (value.StartsWith("cd"))
                {
                    string separate = value.Remove(0, 3);
                    ChngPath(separate);
                }
                else if (value.StartsWith("wc"))
                {
                    string File = value.Remove(0, 3);
                    string order = value.Substring(0, 2);
                   
                    var process = new Process();
                   
                    process.StartInfo = new ProcessStartInfo(initialDirectory + Aliases[order]);
                    process.StartInfo.Arguments = Directory.GetCurrentDirectory()
                        + "\\" + File;
                    process.Start();
                    process.WaitForExit(); 
                }
                else 
                {
                    Execute(value);
                }

            } while (value != "exit");
        }



        public int Execute(string input)
        {
            if (Aliases.Keys.Contains(input))
            {
                var process = new Process();

                process.StartInfo = new ProcessStartInfo(initialDirectory + Aliases[input])
                {
                    UseShellExecute = false,
                    WorkingDirectory = Directory.GetCurrentDirectory()
                };

                process.Start();
                process.WaitForExit();

                return 0;
            }
            Console.WriteLine($"{input} not found");
            return 1;
        }


        public void ChngPath(string pathway)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            string newpath = currentDirectory + "\\" + pathway;
                    if (Directory.Exists(newpath))
                    {
                         Directory.SetCurrentDirectory(newpath);
                    }


            else
            {
                if (Directory.Exists(pathway))
                    Directory.SetCurrentDirectory(pathway);
                else
                    Console.WriteLine($"Directory {0} doesn't exist", newpath);

            }

        }
    }
}
