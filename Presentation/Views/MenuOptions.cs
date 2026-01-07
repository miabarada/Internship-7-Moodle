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
        
        public static Dictionary<string, (string Description, Func<Task<bool>> Action)> CreateMainMenuOptions(MainMenu mainMenu) 
        { 
            return new MenuOptions()
                .AddOption("1", "Logiraj se", async () => { await mainMenu.HandleLoginUserAsync(); Console.Clear(); return false; })
                .AddOption("2", "Izađi", async () => { Console.WriteLine("Izlaz iz aplikacije..."); return true; })
                .Build(); 
        } 
    }
}
