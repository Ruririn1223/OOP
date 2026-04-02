using System;
using System.Collections.Generic;
using Лаб1;

Bank<SavingsAccount> savingsBank = new Bank<SavingsAccount>("Сберегательный Банк");
Bank<CheckingAccount> checkingBank = new Bank<CheckingAccount>("Расчетный Банк");

SavingsAccount savings1 = new SavingsAccount("SA-001", "Концевой Д.Д.", 100000, 5.5);
SavingsAccount savings2 = new SavingsAccount("SA-002", "Винковский М.М.", 250000, 6.0);
SavingsAccount savings3 = new SavingsAccount("SA-002", "Хисматулина С.С.", 75000, 6.5);

savingsBank.OpenAccount(savings1);
savingsBank.OpenAccount(savings2);
savingsBank.OpenAccount(savings3);

CheckingAccount checking1 = new CheckingAccount("CA-001", "ИП Дубровин ", 50000, 10000);
CheckingAccount checking2 = new CheckingAccount("CA-002", "OOO Хисамединова", 75000, 15000);

checkingBank.OpenAccount(checking1);
checkingBank.OpenAccount(checking2);

Console.WriteLine("Информация о всех счетах");

SavingsAccount foundSavings = savingsBank.FindAccount("SA-002");
if (foundSavings != null)
{
	foundSavings.DisplayInfo();
}

CheckingAccount foundChecking = checkingBank.FindAccount("CA-999");

savingsBank.CalculateAllInterest();
checkingBank.CalculateAllInterest();

savingsBank.DisplayAllAccounts();
checkingBank.DisplayAllAccounts();

Console.WriteLine("Статистика");
Console.WriteLine($"Счетов в Сберегательном банке: {savingsBank.AccountsCount}");
Console.WriteLine($"Счетов в Расчетном банке: {checkingBank.AccountsCount}");
Console.WriteLine($"Всего счетов открыто: {Bank<SavingsAccount>.TotalAccountsCount}");

savings1.Deposit(50000);
checking1.Deposit(25000);

savings2.Withdraw(30000);
checking2.Withdraw(85000);

Console.WriteLine("\n");
savingsBank.CalculateAllInterest();
checkingBank.CalculateAllInterest();