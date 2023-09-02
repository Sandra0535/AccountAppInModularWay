using AccountAppInModularWay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAppInModularWay
{
    internal class AccountController
    {
        private AccountManager accountManager;

        public AccountController()
        {
            accountManager = new AccountManager();
        }
        public static void Start()
        {
            AccountManager accountManager = new AccountManager();
            if (!accountManager.AccountCreated)
            {
                Console.WriteLine("Welcome! Enter Account Details to create a new Account ");
                Console.WriteLine("Enter Account number:");
                int accountNo = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Account Holder Name:");
                string accountHolderName = Console.ReadLine();
                Console.WriteLine("Enter Bank Name:");
                string bankName = Console.ReadLine();
                Console.WriteLine("Enter opening balance:");
                bool openingBalanceResult = double.TryParse(Console.ReadLine(), out double openingBalance);
                accountManager.CreateAccount(accountNo, accountHolderName, bankName, openingBalance);
                Console.WriteLine("Account created successfully!!!");
            }
            while (true)
            {
                Console.WriteLine("What do you wish to do?\n1. Deposit\n2. Withdraw\n3. Display Balance\n4. Exit");
                Console.WriteLine("Enter your choice");
                bool result = int.TryParse(Console.ReadLine(), out int decision);

                if (decision == 1)
                {
                    Console.WriteLine("Enter amount to deposit:");
                    bool depositResult = double.TryParse(Console.ReadLine(), out double depositAmount);
                    Console.WriteLine(accountManager.Deposit(depositAmount));
                }
                else if (decision == 2)
                {
                    Console.WriteLine("Enter amount to withdraw:");
                    bool withdrawResult = double.TryParse(Console.ReadLine(), out double withdrawAmount);
                    Console.WriteLine(accountManager.Withdraw(withdrawAmount));
                }
                else if (decision == 3)
                {
                    Console.WriteLine(accountManager.CheckBalance());
                }
                else if (decision == 4)
                {
                    accountManager.SerializeAccount();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }
        public static void WelcomeBack(Account acc)
        {
            Console.WriteLine("Welcome Back");
            Console.WriteLine($"Account Holder name: {acc.AccountHolderName}\nAccount balance is {acc.Balance}");
        }
    }
}