using System;

var account = new BankAccount("RU123456789", "Иванов Иван Иванович", 1000m, 0.05m);


account.PrintBalance();       // Баланс: 1 000 ₽
account.Deposit(500m);        // Пополнили на 500
account.Withdraw(200m);       // Сняли 200
account.ApplyInterest();      // Начислили 5% от текущего баланса
account.PrintBalance();       // Новый баланс с процентами