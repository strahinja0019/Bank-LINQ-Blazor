using Common;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AccountsRepository repo = new AccountsRepository(new BankDbContext());

            IQueryable<Account> accounts = repo.Get();

            foreach(Account a in accounts)
            {
                Console.WriteLine($"Account Details:{a.firstName}");
            }

            //Console.WriteLine($"Account Details:{a.firstName}");
            Console.ReadKey();
        }
    }
}
