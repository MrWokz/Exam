using System;

public class Logger
{
    private static Logger _instance;
    private static readonly object _lock = new object();

    private Logger() { }

    public static Logger Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
        }
    }

    public void Log(string message)
    {
        Console.WriteLine($"[LOG - {DateTime.Now}] {message}");
    }
}

public class BankAccount
{
    public string AccountNumber { get; private set; }
    public decimal Balance { get; private set; }

    private readonly Logger logger = Logger.Instance;

    public BankAccount(string accountNumber, decimal initialBalance = 0)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
        logger.Log($"Account {AccountNumber} created with balance {Balance}");
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
        logger.Log($"Deposited {amount} to account {AccountNumber}. New balance: {Balance}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            logger.Log($"Failed withdrawal of {amount} from account {AccountNumber}: Insufficient funds.");
            throw new InvalidOperationException("Insufficient funds");
        }

        Balance -= amount;
        logger.Log($"Withdrew {amount} from account {AccountNumber}. New balance: {Balance}");
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            var account = new BankAccount("UA123456", 500);
            account.Deposit(200);
            account.Withdraw(100);
            account.Withdraw(700); // Це викличе виняток
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] {ex.Message}");
        }
    }
}
