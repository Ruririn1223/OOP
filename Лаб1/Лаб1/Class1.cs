using System;

// BankAccount.cs
public class BankAccount
{
    // Поля (можно сделать private, а доступ — через свойства)
    private string _accountNumber;
    private string _ownerName;
    private decimal _balance;
    private decimal _interestRate; // процентная ставка в долях (например, 0.05 = 5%)

    // Конструктор
    public BankAccount(string accountNumber, string ownerName, decimal initialBalance = 0, decimal interestRate = 0)
    {
        _accountNumber = accountNumber;
        _ownerName = ownerName;
        _balance = initialBalance >= 0 ? initialBalance : throw new ArgumentException("Начальный баланс не может быть отрицательным.");
        _interestRate = interestRate >= 0 ? interestRate : throw new ArgumentException("Процентная ставка не может быть отрицательной.");
    }

    // Метод пополнения счёта
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сумма пополнения должна быть положительной.");
        _balance += amount;
    }

    // Метод снятия средств
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сумма снятия должна быть положительной.");
        if (amount > _balance)
            throw new InvalidOperationException("Недостаточно средств на счёте.");
        _balance -= amount;
    }

    // Метод начисления процентов (за один период, например, за месяц)
    public void ApplyInterest()
    {
        _balance += _balance * _interestRate;
    }

    // Метод вывода баланса
    public void PrintBalance()
    {
        Console.WriteLine($"Счёт: {_accountNumber}");
        Console.WriteLine($"Владелец: {_ownerName}");
        Console.WriteLine($"Текущий баланс: {_balance:C}");
    }
}