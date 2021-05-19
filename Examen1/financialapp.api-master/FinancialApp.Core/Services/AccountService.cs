using FinancialApp.Core;
using FinancialApp.Data.Entities;
using FinancialApp.Data.Repositories;
using FinancialApp.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinancialApp.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> accountRepository;

        public AccountService(IRepository<Account> accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task<ServiceResult<IEnumerable<Account>>> GetAllAccountsAsync()
        {
            try
            {
                var accounts = await this.accountRepository.All().Include(d => d.Transactions).ToListAsync();
                return ServiceResult<IEnumerable<Account>>.SuccessResult(accounts);
            }
            catch (Exception r)
            {
                return ServiceResult<IEnumerable<Account>>.ErrorResult(r.Message);
            }
        }
    }
}
