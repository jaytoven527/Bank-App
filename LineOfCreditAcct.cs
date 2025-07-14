using Bank;
public class LineOfCreditAcct : BankAccount
{   
    public LineOfCreditAcct (decimal initAmount, string name, decimal creditLimit, string AcctName) : base(initAmount, name, -creditLimit) 
    {
        
        locBalance  = initAmount;
        CreditLimit = creditLimit;
        CheckBalance(initAmount, creditLimit, name, AcctName);
        
    }

    public decimal locBalance {get;}
    public decimal CreditLimit {get;}

    public override void Greeting (string name, string AcctName) 
    {
        Console.WriteLine($"{Environment.NewLine}Congratulations, {name}!");
        Console.Write($"Your new {AcctName} Account has been created!");
    }

    public void CheckBalance (decimal amount, decimal creditLimit, string name, string AcctName) 
    {
        if (amount > creditLimit)
        {
            throw new ArgumentOutOfRangeException (nameof(amount), "Balance cannot be greater than the absolute value of the credit limit.");
        }

     Greeting(name, AcctName);
    }

    protected override Transaction? CheckForOverdraft(bool isOverdrawn) =>
    isOverdrawn
    ? new Transaction(-20, DateTime.Now, "Apply overdraft fee")
    : default;

    public override void withdrawal (decimal amount, DateTime date, string note)
    {
        if (amount <= 0) 
        {
            throw new ArgumentOutOfRangeException (nameof(amount), "The amount of withdrawal must be positive.");
        }
        Transaction? OverdraftFee = CheckForOverdraft(locBalance - amount < CreditLimit);
        if(OverdraftFee != null)
        {
            allTransactions.Add(OverdraftFee);
        }
        Transaction? withdraw   = new(-amount, date, note);
        allTransactions.Add(withdraw);
        
    }

    public override void PerformMonthEndTransaction () 
    {
        if (locBalance > 0)
        {
            decimal interest = locBalance * 0.02m;
            withdrawal(interest, DateTime.Now, "Apply monthly fee");
        }
        
    }
    
}