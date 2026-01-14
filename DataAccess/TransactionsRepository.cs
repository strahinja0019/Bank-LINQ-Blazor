using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TransactionsRepository
    {
        private BankDbContext _context;
        public TransactionsRepository(BankDbContext context)
        {
            _context = context;
        }

        public IQueryable<Transaction> Get()
        {
            return _context.Transactions;
        }
        public Transaction Get(int transactionId)
        {
            return (from t in _context.Transactions
                    where t.transactionId == transactionId
                    select t).FirstOrDefault();
        }
        public void Update()
        {
            _context.SaveChanges();
        }
        public void Add(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            //# check
        }
        public void Add(int accountId,string type,int amount,DateTime timeStamp,string status)
        {
            Add(new Transaction()
            {
                accountId = accountId,
                type = type,
                amount = amount,
                timeStamp = timeStamp,
                status = status
            });
        }
    }
}