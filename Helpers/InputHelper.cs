namespace cmpp_assignment2_csharp.Helpers
{
    public static class InputHelper
    {
        public static string ReadString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input.Trim();

                Console.WriteLine("Invalid input. Please try again.");
            }
        }

        public static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);

                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;

                Console.WriteLine("Invalid number. Please enter an integer.");
            }
        }

        public static int ReadInt(string prompt, int min)
        {
            while (true)
            {
                int value = ReadInt(prompt);

                if (value >= min)
                    return value;

                Console.WriteLine($"Value must be >= {min}");
            }
        }

        public static double ReadDouble(string prompt, double min, double max)
        {
            while (true)
            {
                Console.Write(prompt);

                if (double.TryParse(Console.ReadLine(), out double value) &&
                    value >= min && value <= max)
                    return value;

                Console.WriteLine($"Invalid GPA. Enter value between {min} and {max}");
            }
        }
    }
}