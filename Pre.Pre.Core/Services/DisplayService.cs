using Pre.Pe2.Cons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.Services
{
    internal class DisplayService
    {
        private UserInput userInput;

        private string whiteSpace { get; } = @"







";


        private string divider { get; } = @"
------------------------------------------------------------------------------------------------------------------------ ";

        internal DisplayService()
        {
            userInput = new UserInput();
            userInput.SetColor(ConsoleColor.Yellow);
        }

        internal void Write(string input)
        {
            Console.WriteLine(input);
        }

        internal void PageDivider()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Write($"{divider}");
            userInput.ResetColor();
        }

        internal void DisplayTitle(string title)
        {
            Console.Clear();
            Write($"{title}");
        }

        internal void WriteMenu(string[] menu)
        {
            PageDivider();
            for (int i = 0; i < menu.Count(); i++)
            {
                Console.Write(menu[i].Substring(0, 1));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(menu[i].Substring(1, 1));
                userInput.ResetColor();
                Write(menu[i].Substring(2));
            }
            PageDivider();
        }

        internal string AskQuestion(string input)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string output = userInput.ReadString($"\n{input}\n");
            userInput.ResetColor();
            return output;
        }

        internal string AskQuestionCenter(string input)
        {
            Console.Clear();
            Write(whiteSpace);
            PageDivider();
            Write(input);
            PageDivider();
            userInput.ResetColor();
            string output = userInput.ReadString("");
            PageDivider();
            return output;
        }

        internal int AskMenu(int min, int max, string input = null)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (input != null) Console.Write($"\n{input}\n");
            int output = userInput.ReadInt(min, max);
            userInput.ResetColor();
            return output;
        }

        internal int AskValue(string input)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int output = userInput.ReadInt($"\n{input}\n");
            userInput.ResetColor();
            return output;
        }

        internal int AskValueCenter(string input, int min, int max)
        {
            Console.Clear();
            Write(whiteSpace);
            PageDivider();
            Write(input);
            PageDivider();
            int output = userInput.ReadInt(min, max);
            return output;
        }

        internal void WriteCenter(string input)
        {
            Console.Clear();
            Write(whiteSpace);
            PageDivider();
            Console.WriteLine(input);
            PageDivider();
            Write("Press a key to continue...");
            Console.ReadKey();
        }
    }
}
