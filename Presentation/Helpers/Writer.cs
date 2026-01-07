using Application.Common;

namespace Presentation.Helpers
{
    public static class Writer
    {
        public static void WriteUsers(IEnumerable<UserResponse> users)
        {
            var userList = users.ToList();

            if (!userList.Any())
            {
                System.Console.WriteLine("No users found.");
                return;
            }

            foreach (var user in userList)
            {
                System.Console.WriteLine($"ID: {user.Id} | Name: {user.Name}");
            }
        }
        public static void DisplayMenu(string title, Dictionary<string, (string Description, Func<Task<bool>> Action)> options)
        {
            System.Console.WriteLine($"\n=== {title} ===");

            foreach (var option in options)
            {
                System.Console.WriteLine($"{option.Key}. {option.Value.Description}");
            }
        }

        public static void WriteMessage(string message)
        {
            System.Console.WriteLine(message);
        }

        public static void WaitForKey()
        {
            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey();
        }
    }
}
