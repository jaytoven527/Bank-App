using Bank;

public class BankApp
{   
   private static void GreetUser ()
   {
       Console.WriteLine($"{Environment.NewLine}Welcome, visitor!");
       Console.WriteLine($"{Environment.NewLine}First things first, what is your name?");
       string? name = Console.ReadLine();

       PresentMenuOptions(name);
   }

   private static void PresentMenuOptions (string? name)
   {
       Console.WriteLine($"{Environment.NewLine}Hello {name}, this is the main menu.");
       Console.Write($"{Environment.NewLine}Here are your options: ");
       string options = $"{Environment.NewLine}Create account   |   Make deposit    |   Make withdrawal  |  Account History";
       Console.WriteLine(options);
       Console.WriteLine($"{Environment.NewLine}What would you like to do (Type in one of the menu options): ");
       string? UserChoice = Console.ReadLine();

       RespondToInputValue(UserChoice);
   }

   private static void RespondToInputValue (string? choice) 
   {
       if (string.IsNullOrWhiteSpace(choice))
       {
           Console.WriteLine("Please enter one of the following options");
           string? Retry = Console.ReadLine();
           RespondToInputValue(Retry);
       }

        string Choice = choice.ToLower().Trim();

        if(Choice == "create account")
        {
            Console.WriteLine($"{Environment.NewLine}Test successful.");
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }
        else if (Choice == "make deposit")
        {
            Console.WriteLine($"{Environment.NewLine}Test successful.");
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }
        else if (Choice == "make withdrawal")
        {
            Console.WriteLine($"{Environment.NewLine}Test successful.");
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }
        else if (Choice == "account history")
        {
            Console.WriteLine($"{Environment.NewLine}Test successful.");
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }
        else 
        {
            string InvalidValue = $"{Environment.NewLine}Invalid value. Please type in one of the menu options: ";
            Console.WriteLine(InvalidValue);
            string? Retry = Console.ReadLine();
            
            RespondToInputValue(Retry);
        }
   }
    



    static void Main ()
    {
       GreetUser();

    }
}







