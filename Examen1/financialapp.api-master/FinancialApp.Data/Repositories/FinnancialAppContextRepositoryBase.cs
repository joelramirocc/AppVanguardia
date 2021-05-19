using FinancialApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialApp.Data.Repositories
{
public abstract class FinnancialAppContextRepositoryBase<TEntity> : RepositoryBase<TEntity, FinancialAppContext>
       where TEntity : class
{
    public FinnancialAppContextRepositoryBase(FinancialAppContext context)
        : base(context)
    {
        this.Context = context;
    }
}
}
