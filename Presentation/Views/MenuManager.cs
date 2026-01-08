using Application.Common;
using Presentation.Actions;
using Presentation.Helpers;

namespace Presentation.Views
{
    public class MenuManager
    {
        private readonly UserActions _userActions;
        private readonly CourseActions _courseActions;
        public MenuManager(UserActions userActions, CourseActions courseActions)
        {
            _userActions = userActions;
            _courseActions = courseActions;
        }

        public async Task RunAsync()
        {
            bool exitRequested = false;
            var mainMenuOptions = MenuOptions.CreateMainMenuOptions(this);
            while (!exitRequested)
            {
                Writer.DisplayMenu("MOODLE - MAIN MENU", mainMenuOptions);
                var choice = Reader.ReadMenuChoice();
                if (mainMenuOptions.ContainsKey(choice))
                {
                    exitRequested = await mainMenuOptions[choice].Action();
                }
                else
                {
                    Writer.WriteMessage("Neispravan unos. Pokušajte ponovo.");
                }
            }
        }

        public async Task HandleLoginUserAsync()
        {
            Console.Clear();
            Console.Write("Email: ");
            var email = Console.ReadLine()!;

            Console.Write("Lozinka: ");
            var password = Console.ReadLine()!;

            var user = await _userActions.LoginUserAsync(email, password);

            if (user == null)
            {
                Console.WriteLine("Logiranje korisnika neuspješno. Pritisnite bilo koju tipku.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Dobrodošao, {user.Email}");
                await ShowUserMenu(user);
            }              

        }

        public async Task HandleRegisterUserAsync()
        {
            Console.Clear();
            Console.Write("Email: ");
            var email = Console.ReadLine()!;

            Console.Write("Password: ");
            var password = Console.ReadLine()!;

            Console.Write("Confirm password: ");
            var confirm = Console.ReadLine()!;

            var captcha = _userActions.GenerateCaptcha();
            Console.WriteLine($"Captcha: {captcha}");
            Console.Write("Repeat captcha: ");
            var captchaInput = Console.ReadLine()!;

            var user = await _userActions.RegisterUserAsync(
                email, password, confirm, captcha, captchaInput);

            if (user == null)
            {
                Console.WriteLine("Registracija nije uspješna. Pritisnite bilo koju tipku.");
                Console.ReadKey();
            }
        }

        public async Task ShowUserMenu(UserResponse user)
        {
            Console.Clear();
            bool exitRequested = false;

            while (!exitRequested)
            {
                Dictionary<string, (string Description, Func<Task<bool>> Action)> userMenuOptions;

                switch(user.Role)
                {
                    case Domain.Enums.Role.Student:
                        userMenuOptions = MenuOptions.CreateStudentMenuOptions(this, user);
                        break;

                    default:
                        Console.WriteLine("Nepoznata rola");
                        return;
                }

                Writer.DisplayMenu("KORISNICKI MENI", userMenuOptions);

                var choice = Reader.ReadMenuChoice();

                if (userMenuOptions.ContainsKey(choice))
                {
                    exitRequested = await userMenuOptions[choice].Action();
                }
                else
                {
                    Writer.WriteMessage("Neispravan unos.");
                    await Task.Delay(1000);
                }
            }
        }

        public async Task<bool> ShowMyCoursesAsync(UserResponse user)
        {
            Console.Clear();
            Console.WriteLine("Prikaz vaših kolegija:");

            var courses = await _courseActions.GetStudentCoursesAsync(user.Id);

            if (!courses.Any())
            {
                Console.WriteLine("Nemate upisanih kolegija.");
            }
            else
            {
                int index = 1;
                foreach (var course in courses)
                {
                    Console.WriteLine($"{index}. {course.Name}");
                    index++;
                }
            }

            Console.WriteLine("Pritisnite bilo koju tipku za povratak.");
            Console.ReadKey();

            return false;
        }

        public async Task<bool> PrivateChatAsync(UserResponse user)
        {
            Console.Clear();
            bool exitRequested = false;

            while (!exitRequested)
            {
                Dictionary<string, (string Description, Func<Task<bool>> Action)> privateMessagesOptions;

                privateMessagesOptions = MenuOptions.CreatePrivateMessagesMenu(this, user);
                Writer.DisplayMenu("PRIVATNE PORUKE", privateMessagesOptions);

                var choice = Reader.ReadMenuChoice();

                if (privateMessagesOptions.ContainsKey(choice))
                {
                    exitRequested = await privateMessagesOptions[choice].Action();
                }
                else
                {
                    Writer.WriteMessage("Neispravan unos.");
                    await Task.Delay(1000);
                }
            }

            return false;
        }

        internal async Task<bool> SeeConversation(UserResponse user)
        {
            throw new NotImplementedException();
        }

        internal async Task<bool> SeeChats(UserResponse user)
        {
            throw new NotImplementedException();
        }
    }
}
