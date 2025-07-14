using Bank;
public class InterestEarningAcct : BankAccount
{
    public InterestEarningAcct (decimal initAmount, string name, string AcctName) : base(initAmount, name)
    {
        interestBalance = initAmount;
        Greeting(name, AcctName);
    }

    public decimal interestBalance {get;}

    public override void Greeting (string name, string AcctName) 
    {
        Console.WriteLine($"{Environment.NewLine}Congratulations, {name}!");
        Console.Write($"Your new {AcctName} Account has been created!");
    }
    public override void PerformMonthEndTransaction () 
    {
         if (interestBalance > 0)
        {
            decimal interest = interestBalance * 0.02m;
            deposit(interest, DateTime.Now, "Apply monthly fee");
        }
    }
    
}