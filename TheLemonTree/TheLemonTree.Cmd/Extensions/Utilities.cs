using System;
using System.Collections.Generic;
using System.Text;

namespace TheLemonTree.Cmd.Extensions
{
    public static class Utilities
    {
        public static int AskUserForInt(string question = "", int min = int.MinValue, int max = int.MaxValue)
        {
            string input;
            int selection;
            do
            {
                input = AskUser(question);
            } while (!int.TryParse(input, out selection) || selection < min || selection > max);

            return selection;
        }
        public static string AskUser(string question)
        {
            string input;

            Console.Write($"{question}\n> ");
            input = Console.ReadLine();
            Console.WriteLine("\n");
            return input;
        }
        public static void TellUser(string statement)
        {
            Console.WriteLine(statement + "\n\n");
            Console.Write("  -- Press a key to continue --");
            Console.ReadKey();
        }
    }
}
