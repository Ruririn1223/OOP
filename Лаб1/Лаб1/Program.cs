using System;
using System.Collections.Generic;
using Лаб1;

List<BankAccount> accounts = new List<BankAccount>();

accounts.Add(new SavingsAccount("SA-001", "Концевой Д.Д.", 100000, 5.5));
accounts.Add(new SavingsAccount("SA-002", "Винковский М.М.", 250000, 6.0));
accounts.Add(new CheckingAccount("CA-001", "Дубровин Ю.Ю.", 50000, 10000));
accounts.Add(new CheckingAccount("CA-002", "Хисматулина С.С.", 75000, 15000));



Console.WriteLine("Информация о всех счетах");
foreach (var account in accounts)
{
	account.DisplayInfo();
	Console.WriteLine();
}

Console.WriteLine("\nРасчёт процентов");
double totalInterest = 0;
foreach (var account in accounts)
{
	double interest = account.CalculateInterest();
	Console.WriteLine($"Счет {account._accountNumber}: проценты = {interest:N}");
	totalInterest += interest;
}
Console.WriteLine($"\nОбщая сумма процентов: {totalInterest:N}");

Console.WriteLine("\nОперации со счетами");

accounts[0].Deposit(25000);

accounts[2].Withdraw(30000);

accounts[3].Withdraw(85000);

Console.WriteLine("\nФинальное состояние счетов");
foreach (var account in accounts)
{
	account.DisplayInfo();
	Console.WriteLine();
}