namespace Presentation.Helpers
{
    public static class Reader
    {
        public static string ReadLine()
        {
            return Console.ReadLine() ?? "";
        }

        public static string ReadInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? "";
        }

        public static int? ReadInt(string prompt)
        {
            System.Console.Write(prompt);
            var input = Console.ReadLine();

            if (int.TryParse(input, out int result))
            {
                return result;
            }

            return null;
        }

        public static string ReadMenuChoice(string prompt = "Izaberi opciju: ")
        {
            System.Console.Write(prompt);
            return System.Console.ReadLine() ?? "";
        }
    }
}
