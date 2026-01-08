using Application.Common;

namespace Presentation.Views
{
    public class MenuOptions 
    { 
        private readonly Dictionary<string, (string Description, Func<Task<bool>> Action)> _options; 
        public MenuOptions() 
        { 
            _options = []; 
        } 
        
        public MenuOptions AddOption(string key, string description, Func<Task<bool>> action) 
        { 
            _options.Add(key, (description, action)); 
            return this; 
        } 
        
        public Dictionary<string, (string Description, Func<Task<bool>> Action)> Build() 
        { 
            return _options; 
        } 
        
        public static Dictionary<string, (string Description, Func<Task<bool>> Action)> CreateMainMenuOptions(MenuManager mainMenu) 
        { 
            return new MenuOptions()
                .AddOption("1", "Logiraj se", async () => { await mainMenu.HandleLoginUserAsync(); Console.Clear(); return false; })
                .AddOption("2", "Registriraj se", async () => { await mainMenu.HandleRegisterUserAsync(); Console.Clear(); return false; })
                .AddOption("3", "Izađi", async () => { Console.WriteLine("Izlaz iz aplikacije..."); return true; })
                .Build(); 
        }

        public static Dictionary<string, (string Description, Func<Task<bool>> Action)> CreateStudentMenuOptions(MenuManager menu, UserResponse user)
        {
            return new MenuOptions()
                .AddOption("1", "Moji kolegiji", async () => await menu.ShowMyCoursesAsync(user))
                .AddOption("2", "Privatni chat", async () => await menu.PrivateChatAsync(user))
                .AddOption("3", "Odjava", async () => true)
                .Build();
        }

        public static Dictionary<string, (string Description, Func<Task<bool>> Action)> CreatePrivateMessagesMenu(MenuManager menu, UserResponse user)
        {
            return new MenuOptions()
                .AddOption("1", "Pošalji poruku", async () => await menu.SeeConversation(user))
                .AddOption("2", "Pregledaj razgovore", async () => await menu.SeeChats(user))
                .AddOption("3", "Natrag", async () => true)
                .Build();
        }
    }
}
