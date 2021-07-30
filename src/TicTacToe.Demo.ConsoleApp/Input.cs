using System;

namespace TicTacToe.Demo.ConsoleApp
{
    public static class Input
    {
        public static string Ask(object value)
        {
            Console.Write(value);
            return Console.ReadLine();
        }

        public static string Ask(object value, ConsoleColor foreground)
        {
            Output.Write(value);

            Console.ForegroundColor = foreground;
            string output = Console.ReadLine();
            Console.ResetColor();

            return output;
        }

        public static string Ask(object value, ConsoleColor foreground, ConsoleColor background)
        {
            Output.Write(value);
            
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            string output = Console.ReadLine();
            Console.ResetColor();

            return output;
        }

        public static string AskUntil(Func<string, bool> condition, object value)
        {
            string output;

            do
            {
                output = Ask(value);
            }
            while (!condition(output));

            return output;
        }

        public static string AskUntil(Func<string, bool> condition, object value, ConsoleColor foreground)
        {
            string output;

            do
            {
                output = Ask(value, foreground);
            }
            while (!condition(output));

            return output;
        }

        public static string AskUntil(Func<string, bool> condition, object value, ConsoleColor foreground, ConsoleColor background)
        {
            string output;

            do
            {
                output = Ask(value, foreground, background);
            }
            while (!condition(output));

            return output;
        }

        public static T Convert<T>(this string output, Func<string, T> convert)
        {
            return convert(output);
        }
    }
}