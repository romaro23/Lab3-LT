// See https://aka.ms/new-console-template for more information
using System;
using System.Text.RegularExpressions;


class Program
{
    static void Main(string[] args)
    {
        while(true)
        {
            Console.WriteLine("Read from a console - 1, from a file - 2");
            int answer;
            while (!int.TryParse(Console.ReadLine(), out answer)) {
                Console.WriteLine("Wrong. Try again.");
            }
            string input;
            string[] words = new string[50];
            switch (answer)
            {
                case 1:
                    input = Console.ReadLine();
                    words = input.Split(' ');
                    break;
                case 2:
                    string[] lines = File.ReadAllLines("C:\\Users\\Romaro\\source\\repos\\C#\\LT\\Lab3\\Lab3\\Words.txt");
                    foreach (string line in lines)
                    {
                        words = line.Split(' ');
                        break;
                    }
                    break;
            }
            foreach (string word in words)
            {
                if (IsMatch(word))
                {
                    Console.WriteLine($"{word} - Match");
                }
                else
                {
                    Console.WriteLine($"{word} - Not match");
                }
            }
        }
        
    }

    static bool IsMatch(string word)
    {
        Regex regex = new Regex(@"^(bc|cbc|bc(acbc)*|cbc(acbc)*|b(bb)*c|cb(bb)*c|bcab(bb)*c|cbcab(bb)*c|bc(a(bb)*cbc)*|cbc(a(bb)*cbc)*)$");
        return regex.IsMatch(word);
    }
}
