using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб1
{
	public abstract class BankAccount
	{
		public string _accountNumber { get; set; }
        public double _balance { get; set; }
        public string _ownerName { get; set; }

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

        public static BankAccount operator +(BankAccount account, double amount)
        {
            if (account != null && amount > 0)
            {
                account.Deposit(amount);
            }
            return account;
        }

        public static BankAccount operator -(BankAccount account, double amount)
        {
            if (account != null && amount > 0)
            {
                account.Withdraw(amount);
            }
            return account;
        }
        // 2 + 2 

        public static bool operator >(BankAccount left, BankAccount right)
        {
            if (left == null || right == null)
                return false;
            return left._balance > right._balance;
        }

        public static bool operator <(BankAccount left, BankAccount right)
        {
            if (left == null || right == null)
                return false;
            return left._balance < right._balance;
        }


        public override bool Equals(object obj)
        {
            if (obj is BankAccount other)
                return this._accountNumber == other._accountNumber;
            return false;
        }

        public override int GetHashCode()
        {
            return _accountNumber.GetHashCode();
        }
    }
}
