using Common;
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

    }
}
