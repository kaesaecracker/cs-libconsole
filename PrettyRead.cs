using System;

namespace LibConsole
{
    public static class PrettyRead
    {
        public static string ReadLn(string message)
        {
            PrettyPrint.Print(message + ": ");
            string input = Console.ReadLine();
            return input == null ? string.Empty : input.Trim();
        }
        
        public static string ReadLn() => ReadLn("");

        public static void FlushIn()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
    }
}