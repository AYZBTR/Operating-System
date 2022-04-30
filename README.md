# Operating-System
BUILDING THE SHELL 
We are building a very simple text based shell using C# (as suggested by the title). By simple, I mean very simple. We will not be implementing any scripting functionality. I might do a separate post on that, though, because I think it would be interesting to talk about. But, no, we will just be implementing a shell that will take a command (that does not have arguments), find the associated program for that command, and execute that program in a separate process.

The skeleton of this project is pretty sparse.

public class Shell
{
    private Dictionary<string, string> Aliases = new Dictionary<string, string>();
    public void Run() { }
    public int Execute(string input) { }
}
The Aliases dictionary will be used to hold commands and their corresponding programs. Adding this was a pretty arbitrary decision on my part, but I felt like having aliases. It wouldn’t be too hard to implement an alias method that allowed the user to add their own aliases.

Run is the entry point to our shell. It will start the loop up and gather user input.

public void Run()
{
    string input = null;
 
    do
    {
        Console.Write("$ ");
        input = Console.ReadLine();
        Execute(input);
    } while (input != "exit");
}
Execute is where we will fire up new processes and run our program. First, we check our dictionary of Aliases. If we cannot find the given command, we write a helpful error message and return 1, the standard integer to indicate failure. However, if we do find a matching alias, we start a new process with the alias’s corresponding program’s path. After the program finishes executing, we exit the process and return 0, the standard indication for success.

public int Execute(string input)
{
    if (Aliases.Keys.Contains(input))
    {
        var process = new Process();
        process.StartInfo = new ProcessStartInfo(Aliases[input])
        {
            UseShellExecute = false
        };
 
        process.Start();
        process.WaitForExit();
 
        return 0;
    }
 
    Console.WriteLine($"{input} not found");
    return 1;
}
That’s about all that goes in to it. It would be nice to have at least one program to try out with it, so how about we write ls.

class Program
{
    static void Main(string[] args)
    {
        var files = Directory.GetFiles(Directory.GetCurrentDirectory());
 
        foreach (var file in files)
        {
            Console.WriteLine(file);
        }
    }
}
And lastly, we need to add ls to our list of aliases.

private Dictionary<string, string> Aliases = new Dictionary<string, string>
{
    { "ls", @".\ListDirectories.exe" }
};
WRAPPING UP 
As you can see, writing a shell isn’t as complicated as many would believe. There are a lot of things we could have done to make our shell much nicer, but I’m a bit tired at the moment and just wanted to make sure I got something out this week for you all to read. I do think it would be a great exercise to try and improve this project (in the many many ways possible) and would love to see what some of you come up with.
