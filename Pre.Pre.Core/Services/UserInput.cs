using System;

namespace Pre.Pe2.Cons
{
    internal class UserInput
    {
        private ConsoleColor color;

        internal void SetColor(ConsoleColor color)
        {
            this.color = color;
        }

        internal ConsoleColor GetColor()
        {
            return this.color;
        }

        internal int ReadInt(string prompt, int min, int max)
        {
            DisplayPrompt(prompt);
            return ReadInt(min, max);
        }

        internal int ReadInt(int min, int max)
        {
            int value = ReadInt();
            while (value < min || value > max)
            {
                DisplayPrompt("Please enter an integer between {0} and {1} (inclusive)\n", min, max);
                value = ReadInt();
            }
            return value;
        }

        internal int ReadInt()
        {
            return this.ReadInt(">> Please choose a number:");
        }

        internal int ReadInt(string prompt)
        {
            string input = String.Empty;
            int value;
            do
            {
                DisplayPrompt(prompt); input = Console.ReadLine();
            }
            while (!int.TryParse(input, out value));
            return value;
        }

        internal string ReadString(string prompt)
        {
            DisplayPrompt(prompt);
            return Console.ReadLine();
        }

        internal bool ReadYesNo(string prompt)
        {
            ConsoleKey response;
            do
            {
                DisplayPrompt($"{ prompt } [y/n]");
                response = Console.ReadKey(false).Key;
                if (response != ConsoleKey.Enter)
                {
                    Console.WriteLine();
                }
            }
            while (response != ConsoleKey.Y && response != ConsoleKey.N);
            return (response == ConsoleKey.Y);
        }

        internal void DisplayPrompt(string prompt)
        {
            DisplayPrompt(prompt, null);
        }

        private void DisplayPrompt(string prompt, params object[] promptParams)
        {
            Console.ForegroundColor = this.color;
            Console.Write($"{prompt} ", promptParams);
        }

        internal void ResetColor()
        {
            Console.ResetColor();

            this.color = Console.ForegroundColor;
        }
    }
}