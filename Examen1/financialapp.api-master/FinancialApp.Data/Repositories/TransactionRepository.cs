using FinancialApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinancialApp.Data.Repositories
{
    public class TransactionRepository : FinnancialAppContextRepositoryBase<Transaction>
    {
        public TransactionRepository(FinancialAppContext context)
            : base(context)
        {
        }

        public override IQueryable<Transaction> All()
        {
            return this.Context.Transaction;
        }

        protected override Transaction MapNewValuesToOld(Transaction oldEntity, Transaction newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
