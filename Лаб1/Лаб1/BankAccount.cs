using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб1
{
	internal abstract class BankAccount
	{
		public string _accountNumber { get; set; }
		protected double _balance { get; set; }
		private string _ownerName { get; set; }

		protected BankAccount(string accountNumber, string ownerName, double initialBalance)
		{
			this._accountNumber = accountNumber;
			this._ownerName = ownerName;
			this._balance = initialBalance;
		}

		public abstract double CalculateInterest();

		public virtual void Deposit(double amount)
		{
			if (amount > 0)
			{
				_balance += amount;
				Console.WriteLine($"Внесено: {amount:N}. Новый баланс: {_balance:N}");
			}
		}

		public virtual bool Withdraw(double amount)
		{
			if (amount > 0 && amount <= _balance)
			{
				_balance -= amount;
				Console.WriteLine($"Снято: {amount:N}. Остаток: {_balance:N}");
				return true;
			}
			Console.WriteLine("Недостаточно средств!");
			return false;
		}

		public virtual void DisplayInfo()
		{
			Console.WriteLine($"\n{GetType().Name}");
			Console.WriteLine($"Владелец: {_ownerName}");
			Console.WriteLine($"Номер счета: {_accountNumber}");
			Console.WriteLine($"Баланс: {_balance:N}");
		}
	}
}
