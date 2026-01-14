using Common;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccountsRepository
    {
        private BankDbContext _context;
        public AccountsRepository(BankDbContext context) {
            _context = context;
            TransactionsRepository transactionsRepository = new TransactionsRepository(_context);
        }

        public IQueryable<Account> Get()
        {
            return _context.Accounts;
        }
        public Account Get(int accountId)
        {
            //Lambda
            //return Get().Where(x => x.accountid == accountId).FirstOrDefault();

            //RAW LINQ
            //var list = from a in _context.Accounts
            //           where a.accountId == accountId
            //           select a;
            //return list.FirstOrDefault();
            return (from a in _context.Accounts
                    where a.accountId == accountId
                    select a).FirstOrDefault();
        }
        public Account Get(string email)
        {
            return Get().Where(x => x.email == email).FirstOrDefault();
        }
        public void Remove(Account account)
        {
            _context.Accounts.Remove(account);
            _context.SaveChanges();
        }
        public void Remove(int accountId)
        {
            Remove(Get(accountId));
        }
        public void Remove(string email)
        {
            Remove(Get(email));
        }
        public void Add(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
        public void Add(string IBAN,string accountType,string firstName,string lastName,string email,string phone,string address,decimal balance)
        {
            Add(new Account()
            {
                IBAN = IBAN,
                accountType = accountType,
                firstName = firstName,
                lastName = lastName,
                email = email,
                phone = phone,
                address = address,
                balance = balance,
                dateCreate = DateTime.Now
            });
        }
        public void Update()
        {
            _context.SaveChanges();
        }
        public void Update(int accountId, string accountType, string firstName, string lastName, string email, string phone, string address)
        {
            Account account = Get(accountId);
            if (account != null)
            {
                account.accountType = accountType ?? account.accountType;
                account.firstName = firstName ?? account.firstName;
                account.lastName = lastName ?? account.lastName;
                account.email = email ?? account.email;
                account.phone = phone ?? account.phone;
                account.address = address ?? account.address;
                Update();
            }
        }
        public void changeBalance(int accountId, decimal amount)
        {
            Account account = Get(accountId);
            if (account != null)
            {
                account.balance += amount;
                Update();
            }
        }
        public void SendMoney(int fromAccountId, int toAccountId, decimal amount)
        {
            Account fromAccount = Get(fromAccountId);
            Account toAccount = Get(toAccountId);
            changeBalance(fromAccountId, -amount);
            
            changeBalance(toAccountId, amount);
        }
    }
}
