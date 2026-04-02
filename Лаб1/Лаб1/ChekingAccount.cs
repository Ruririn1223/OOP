using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб1
{
	public class CheckingAccount: BankAccount
	{
		public double _overdraftLimit { get; set; }

		public CheckingAccount(string accountNumber, string ownerName, double initialBalance, double overdraftLimit) : base(accountNumber, ownerName, initialBalance)
		{
			this._overdraftLimit = overdraftLimit;
		}

		public override double CalculateInterest()
		{
			if (_balance > 0)
				return _balance * 0.5 / 100;
			return 0;
		}

		public override bool Withdraw(double amount)
		{
			if (amount > 0 && amount <= _balance + _overdraftLimit)
			{
				_balance -= amount;
				Console.WriteLine($"Снято: {amount:N}. Остаток: {_balance:N}");
				return true;
			}
			Console.WriteLine("превышен лимит");
			return false;
		}

		public override void DisplayInfo()
		{
			base.DisplayInfo();
			Console.WriteLine($"Лимит: {_overdraftLimit}");
			Console.WriteLine($"Начисленные проценты: {CalculateInterest():N}");
		}

	}
}
