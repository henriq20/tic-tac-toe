using System;

namespace TicTacToe.Demo.ConsoleApp
{
    public class Output
    {
        public static void Write(object value)
        {
            Console.Write(value);
        }

        public static void Write(object value, ConsoleColor? foreground = null)
        {
            Console.ForegroundColor = foreground != null ? foreground.Value : Console.ForegroundColor;
            Console.Write(value);
            Console.ResetColor();
        }

        public static void Write(object value, ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            Console.ForegroundColor = foreground != null ? foreground.Value : Console.ForegroundColor;
            Console.BackgroundColor = background != null ? background.Value : Console.BackgroundColor;
            Console.Write(value);
            Console.ResetColor();
        }

        public static void WriteLine()
        {
            Console.WriteLine();
        }

        public static void WriteLine(object value)
        {
            Console.WriteLine(value);
        }

        public static void WriteLine(object value, ConsoleColor? foreground = null)
        {
            Write(value, foreground);
            Console.WriteLine();
        }

        public static void WriteLine(object value, ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            Write(value, foreground, background);
            Console.WriteLine();
        }

        public static void DisplayError(object value)
        {
            Write(value, ConsoleColor.Red);
            Console.ReadLine();
        }
    }
}