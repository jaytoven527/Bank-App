using Bank;
public class GiftCardAcct : BankAccount
{   
    private readonly decimal _monthlyDeposits = 0m;
    public GiftCardAcct (decimal initAmount, string name, string AcctName, decimal monthlyDeposits = 0) : base(initAmount, name) 
    {
        Greeting(name, AcctName);
        _monthlyDeposits = monthlyDeposits;
        
    }
     

    public override void Greeting (string name, string AcctName) 
    {
        Console.WriteLine($"{Environment.NewLine}Congratulations, {name}!");
        Console.Write($"Your new {AcctName} Account has been created!");
    }

    
    public override void PerformMonthEndTransaction () 
    {
         if (_monthlyDeposits != 0)
        {
            deposit(_monthlyDeposits, DateTime.Now, "Apply monthly fee");
        }
    }
}