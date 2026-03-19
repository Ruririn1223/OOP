using System;

var account = new BankAccount("RU123456789", "Иванов Иван Иванович", 1000m, 0.05m);


account.PrintBalance();       
account.Deposit(500m);        
account.Withdraw(200m);       
account.ApplyInterest();      
account.PrintBalance();       