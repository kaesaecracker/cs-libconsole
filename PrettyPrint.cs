using System;
using System.Xml;

namespace LibConsole
{
    public static class PrettyPrint
    {
        private static int _targetWidth = 80;

        public static int TargetWidth
        {
            get => _targetWidth;
            // ensure that it is even
            set => _targetWidth = value % 2 == 0 ? value : value - 1;
        }

        public static void Print(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;

            int textIndex = 0;
            while (textIndex < text.Length)
            {
                int i = 0;
                while (textIndex < text.Length && i < TargetWidth)
                {
                    Console.Write(text[textIndex]);

                    i++;
                    textIndex++;
                }

                if (textIndex < text.Length) Console.Write(Environment.NewLine);
            }

            Console.ResetColor();
        }

        public static void PrintLn() => Console.WriteLine();

        public static void PrintLn(string text, ConsoleColor color = ConsoleColor.White)
        {
            Print(text, color);
            PrintLn();
        }

        public enum HeadingLevel
        {
            H1,
            H2,
            H3,
            H4
        }

        public static void PrintHeading(string text, HeadingLevel level = HeadingLevel.H1)
        {
            char decoLeft, decoRight;
            switch (level)
            {
                case HeadingLevel.H1:
                    decoLeft = '▷';
                    decoRight = '◁';
                    break;
                case HeadingLevel.H2:
                    decoLeft = '▹';
                    decoRight = '◃';
                    break;
                case HeadingLevel.H3:
                    decoLeft = '◦';
                    decoRight = decoLeft;
                    break;
                case HeadingLevel.H4:
                    decoLeft = ' ';
                    decoRight = decoLeft;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level,
                        "Unknown heading level");
            }

            PrintLn();
            PrintLn(Decorate(text, decoLeft, decoRight), ConsoleColor.DarkGreen);
        }

        public static void PrintList(params string[] items)
        {
            foreach (string item in items)
            {
                PrintLn($"- {item}");
            }
        }

        private static string Decorate(string original, char leftDeco, char rightDeco)
        {
            const int spacesPerSide = 2;
            const char space = ' ';
            string fillBetween = new string(space, spacesPerSide);

            int spaceToFill = TargetWidth - (original.Length + 2 * spacesPerSide);
            int lengthPerSide = (spaceToFill / 2);

            int leftLength = spaceToFill.IsEven() ? lengthPerSide : lengthPerSide - 1;
            int rightLength = spaceToFill.IsEven() ? lengthPerSide : lengthPerSide + 2;

            string leftFill = string.Empty;
            string rightFill = string.Empty;
            for (int i = 0; i < Max(leftLength, rightLength); i++)
            {
                if (i < rightLength) rightFill = (i.IsEven() ? rightDeco : space) + rightFill;
                if (i < leftLength) leftFill += i.IsEven() ? leftDeco : space;
            }

            return $"{leftFill}{fillBetween}{original}{fillBetween}{rightFill}";
        }

        public static bool IsWhitespace(this string s) => string.IsNullOrWhiteSpace(s);

        private static int Max(int a, int b) => a > b ? a : b;

        private static bool IsEven(this int num)
        {
            return num % 2 == 0;
        }
    }
}