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
                Console.WriteLine("No users found.");
                return;
            }

            foreach (var user in userList)
            {
                Console.WriteLine($"ID: {user.Id} | Name: {user.Name}");
            }
        }
        public static void DisplayMenu(string title, Dictionary<string, (string Description, Func<Task<bool>> Action)> options)
        {
            Console.WriteLine($"\n=== {title} ===");

            foreach (var option in options)
            {
                Console.WriteLine($"{option.Key}. {option.Value.Description}");
            }
        }

        public static void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void WriteCourses(List<IEnumerable<CourseResponse>> courseList)
        {
            if (!courseList.Any())
            {
                System.Console.WriteLine($"Nije pronađen nijedan kolegij");
                return;
            }

            for (int i = 0; i < courseList.Count; i++)
            {
                var course = courseList.ElementAt(i);
                System.Console.WriteLine($"{i + 1}. Naslov: {course.Count()}\n");
            }
        }
    }
}
