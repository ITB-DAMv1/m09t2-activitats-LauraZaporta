using System.Diagnostics;
using System.IO;
using System.Net.Sockets;

public class Program()
{
    // Carrera de camells
    private static object locker = new object();
    private static int winner = 0;

    // Programa principal
    public static void Main()
    {
        const string MenuInfo = "\n EXERCISES MENU" +
            "\n ------------- \n" +
            "\n [1] - See README.md" +
            "\n [2] - ExTwo() - Processes informaation" +
            "\n [3] - ExThree() - BrowserProcesses" +
            "\n [4] - See README.md" +
            "\n [5] - ExFive() - Five threads" +
            "\n [6] - CamelRun() - Random run between 5 threads" +
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
                case "3":
                    ExThree("chrome");
                    break;
                case "5":
                    ExFive();
                    break;
                case "6":
                    CamelRun();
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
    private static void ExThree(string browser)
    {
        Process[] browserProcesses = Process.GetProcessesByName(browser);
        if (browserProcesses.Length == 0)
        {
            Console.WriteLine("\n The browser is not working at the moment");
        }
        else
        {
            Console.WriteLine("\n BROWSER {0}\n --------------", browser);
            foreach (Process proc in browserProcesses)
            {
                Console.WriteLine($"\n PID: {proc.Id}" +
                    $"\n Horaa d'inici: {proc.StartTime}" +
                    $"\n Prioritat: {proc.BasePriority}");
            }
        }
    }
    private static void ExFive()
    {
        const string threadInfo = "Hola! Soc el fil número {0}";

        Thread one = new Thread(() =>
        {
            Thread.Sleep(400);
            Console.WriteLine(threadInfo, 1);
        });
        Thread two = new Thread(() =>
        {
            Thread.Sleep(300);
            Console.WriteLine(threadInfo, 2);
        });
        Thread three = new Thread(() =>
        {
            Thread.Sleep(200);
            Console.WriteLine(threadInfo, 3);
        });
        Thread four = new Thread(() =>
        {
            Thread.Sleep(100);
            Console.WriteLine(threadInfo, 4);
        });
        Thread five = new Thread(() =>
        {
            Thread.Sleep(0);
            Console.WriteLine(threadInfo, 5);
        });

        one.Start();
        two.Start();
        three.Start();
        four.Start();
        five.Start();

        one.Join();
        two.Join();
        three.Join();
        four.Join();
        five.Join();
    }
    private static void CamelRun()
    {
        object locker = new object();

        Thread camelOne = GenerateCamelThread(1, 100, 500);
        Thread camelTwo = GenerateCamelThread(2, 50, 600);
        Thread camelThree = GenerateCamelThread(3, 200, 300);
        Thread camelFour = GenerateCamelThread(4, 150, 400);
        Thread camelFive = GenerateCamelThread(5, 180, 650);

        camelOne.Start();
        camelTwo.Start();
        camelThree.Start();
        camelFour.Start();
        camelFive.Start();

        camelOne.Join();
        camelTwo.Join();
        camelThree.Join();
        camelFour.Join();
        camelFive.Join();

        Console.WriteLine($"\n Camel {winner} is the winner of the race!");
    }
    private static Thread GenerateCamelThread(int camelNum, int min, int max)
    {
        Random r = new Random();
        int rest = r.Next(min, max);

        Thread camel = new Thread(() =>
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine($"Camel {camelNum} has reached {i}!");

                if (i == 100)
                {
                    lock (locker)
                    {
                        if (winner == 0)
                        {
                            winner = camelNum;
                            Console.WriteLine($"Camel {camelNum} has crossed the finish line!");
                        }
                    }
                }

                Thread.Sleep(rest);
            }
        });
        return camel;
    }
}