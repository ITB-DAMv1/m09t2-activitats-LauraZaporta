using System.Diagnostics;
using System.IO;

public class Program()
{
    public static void Main()
    {
        const string MenuInfo = "\n EXERCISES MENU" +
            "\n ------------- \n" +
            "\n [1] - See README.md" +
            "\n [2] - ExTwo() - Processes informaation" +
            "\n [0] - Exit";
        const string MenuChoose = "\n Choose an option: ";

        bool exit = false;
        string menuOption = string.Empty;

        while (!exit) {

            Console.WriteLine(MenuInfo);
            Console.Write(MenuChoose);
            menuOption = Console.ReadLine();

            switch (menuOption)
            {
                case "2":
                    ExTwo();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("\n Not valid option! Choose another one");
                    break;
            } 
        }
    }

    private static void ExTwo()
    {
        const string Path = @"../../../files/processes.txt";
        File.WriteAllText(Path, String.Empty);

        Process[] allProcs = Process.GetProcesses();
        Console.WriteLine("\n PROCESSES: \n ----------");

        using (StreamWriter sw = new StreamWriter(Path))
        {
            foreach (Process process in allProcs)
            {
                Console.WriteLine($"\n Name: {process.ProcessName} \n PID: {process.Id}\n");
                sw.WriteLine($"Name: {process.ProcessName} ----- PID: {process.Id}");
            }
        }
    }
}