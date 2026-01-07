using Presentation.Actions;
using Presentation.Helpers;

namespace Presentation.Views
{
    public class MainMenu 
    { 
        private readonly UserActions _userActions; 
        public MainMenu(UserActions userActions) 
        { 
            _userActions = userActions; 
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
        } 
    }
}
