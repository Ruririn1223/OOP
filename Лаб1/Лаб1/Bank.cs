using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Лаб1
{
	public class Bank<T> where T : BankAccount
	{
		private static int totalAccountsCount = 0;

		private List<T> accounts;
		private string bankName;
		public int AccountsCount => accounts.Count;
		public static int TotalAccountsCount => totalAccountsCount;

		public Bank(string bankName)
		{
			this.bankName = bankName;
			this.accounts = new List<T>();
		}

		public void OpenAccount(T account)
		{
			if (account != null)
			{
				accounts.Add(account);
				totalAccountsCount++;
				Console.WriteLine($"Счет {account._accountNumber} открыт в банке {bankName}");
			}
		}

		public T FindAccount(string number)
		{
			foreach (var account in accounts)
			{
				if (account._accountNumber == number)
				{
					Console.WriteLine($"Счет {number} найден");
					return account;
				}
			}
			Console.WriteLine($"Счет {number} не найден");
			return null;
		}

		public void CalculateAllInterest()
		{
			Console.WriteLine($"\nРасчет процентов в банке {bankName} ");
			double totalInterest = 0;

			foreach (var account in accounts)
			{
				double interest = account.CalculateInterest();
				totalInterest += interest;
				Console.WriteLine($"Счет {account._accountNumber}: {interest:F2}");
			}
			Console.WriteLine($"Общая сумма процентов: {totalInterest:F2}");
		}
        
        public void DisplayAllAccounts()
		{
			Console.WriteLine($"\nВсе счета банка {bankName} ");
			Console.WriteLine($"Количество счетов: {accounts.Count}");

			foreach (var account in accounts)
			{
				account.DisplayInfo();
				Console.WriteLine();
			}
		}

		public bool CloseAccount(string number)
		{
			T account = FindAccount(number);
			if (account != null)
			{
				accounts.Remove(account);
				totalAccountsCount--;
				Console.WriteLine($"Счет {number} закрыт");
				return true;
			}
			return false;
		}
	}
}
