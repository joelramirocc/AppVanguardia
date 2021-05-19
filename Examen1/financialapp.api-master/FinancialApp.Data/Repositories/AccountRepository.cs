using FinancialApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinancialApp.Data.Repositories
{
   public class AccountRepository : FinnancialAppContextRepositoryBase<Account>
    {
        public AccountRepository(FinancialAppContext context)
            : base(context)
        {
        }

        public override IQueryable<Account> All()
        {
            return this.Context.Account;
        }

        protected override Account MapNewValuesToOld(Account oldEntity, Account newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
