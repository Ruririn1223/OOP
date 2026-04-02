using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб1
{
	public class SavingsAccount : BankAccount
	{
		private double interestRate { get; set; }

		public SavingsAccount(string accountNumber, string ownerName, double initialBalance, double interestRate) : base(accountNumber, ownerName, initialBalance)
		{
			this.interestRate = interestRate;
		}

		public override double CalculateInterest()
		{
			return _balance * interestRate / 100;
		}

		public override void DisplayInfo()
		{
			base.DisplayInfo();
			Console.WriteLine($"Процентная ставка: {interestRate}%");
			Console.WriteLine($"Начисленные проценты: {CalculateInterest():N}");
		}
	}
}
