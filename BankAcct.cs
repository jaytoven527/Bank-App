namespace Bank;

public class BankAccount 
{
    private static int accountNumberSeed = 1234567890;
    private readonly decimal _minimumBalance;

    public BankAccount (decimal initAmount, string name): this(initAmount, name, 0 ) {}
    public BankAccount (decimal initAmount, string name, decimal minimumBalance)
    {
        owner   = name;
        accNum  = accountNumberSeed.ToString();
        accountNumberSeed++;

        _minimumBalance = minimumBalance;
        if (initAmount > 0) 
        {
            deposit (initAmount, DateTime.Now, "Opening account");
        }
    }

    protected List<Transaction> allTransactions = new List<Transaction>();
    
    public string accNum {get;}
    public string owner {get; set;}
    public decimal balance 
    {
        get
        {
            decimal balance = 0;
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
            }

        return balance;
        }
    }

    public void deposit (decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException (nameof(amount), "The amount of deposit must be positive.");
        }
        var deposit = new Transaction (amount, date, note);
        allTransactions.Add(deposit);
    }

    public virtual void withdrawal (decimal amount, DateTime date, string note)
    {
        if (amount <= 0) 
        {
            throw new ArgumentOutOfRangeException (nameof(amount), "The amount of withdrawal must be positive.");
        }
        Transaction? OverdraftFee = CheckForOverdraft(balance - amount < _minimumBalance);
        if(OverdraftFee != null)
        {
            allTransactions.Add(OverdraftFee);
        }
        Transaction? withdraw   = new(-amount, date, note);
        allTransactions.Add(withdraw);
        
        
    }

    protected virtual Transaction? CheckForOverdraft (bool isOverdrawn)
    {
       if(isOverdrawn)
       {
           throw new InvalidOperationException ("Not enough sufficient funds for this withdrawal");
       }
       else
       {
           return default;
       }
    }

    public string getAcctHistory () 
    {
        var statement   = new System.Text.StringBuilder();
        statement.AppendLine("Date\tAmount\tBalance\t Notes");
        decimal balance = 0;

        foreach (var item in allTransactions)
        {
            balance += item.Amount;
            statement.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }
        return statement.ToString();
    }

    public virtual void Greeting (string name, string AcctName) 
    {
        Console.WriteLine($"Congratulations, {name}!");
        Console.Write("Your new Bank Account has been created!");
    }

    public virtual void PerformMonthEndTransaction () {}

}