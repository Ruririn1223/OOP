using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб1
{
    public static class BankExtensions
    {
        public static BankAccount FindRichest(this Bank<BankAccount> bank)
        {
            if (bank == null)
            {
                Console.WriteLine("Банк не существует!");
                return null;
            }

            BankAccount richest = null;
            double maxBalance = double.MinValue;

            foreach (var account in bank.GetAllAccounts())
            {
                if (account._balance > maxBalance)
                {
                    maxBalance = account._balance;
                    richest = account;
                }
            }

            if (richest != null)
            {
                Console.WriteLine($"\nСамый богатый счёт: {richest._accountNumber}");
                Console.WriteLine($"Владелец: {richest._ownerName}");
                Console.WriteLine($"Баланс: {richest._balance:N}");
            }
            else
            {
                Console.WriteLine("В банке нет счетов!");
            }

            return richest;
        }
    }
}
