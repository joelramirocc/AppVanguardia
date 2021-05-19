using FinancialApp.Core;
using FinancialApp.Core.Model;
using FinancialApp.Data.Entities;
using FinancialApp.Data.Repositories;
using FinancialApp.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialApp.Services.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepository<Transaction> transactionRepository;
        private readonly IRepository<Account> accountRepository;

        public TransactionService(IRepository<Transaction> transactionRepository, IRepository<Account> accountRepository)
        {
            this.transactionRepository = transactionRepository;
            this.accountRepository = accountRepository;
        }

        public async Task<ServiceResult<bool>> CreateTransactionAsync(Transaction transaction)
        {
            try
            {
                var account = await this.accountRepository.FirstOrDefaultAsync(a => a.Id == transaction.AccountId);
                if (account == null)
                {
                    return ServiceResult<bool>.ErrorResult("El id de la cuenta es inválido");
                }
                if (transaction.Amount == 0)
                {
                    return ServiceResult<bool>.ErrorResult("La cantidad no puede ser cero");

                }
                if (account.Amount < transaction.Amount)
                {
                    return ServiceResult<bool>.ErrorResult("El monto solicitado excede a la cantidad en la cuenta");
                }

                account.Amount += transaction.Amount;
                this.accountRepository.Update(account);
                this.transactionRepository.Create(transaction);
                await this.transactionRepository.SaveChangesAsync();
                return ServiceResult<bool>.SuccessResult(true);
            }
            catch (Exception e)
            {
                return ServiceResult<bool>.ErrorResult(e.Message);
            }
        }

        public async Task<ServiceResult<IEnumerable<Transaction>>> GetLastFiveTransactionsOfCurrentMonthAsync()
        {
            try
            {
                var date = DateTime.Now;
                var transactions = await this.transactionRepository
                    .Filter(t => t.TransactionDate.Year == date.Year && t.TransactionDate.Month == date.Month)
                    .OrderByDescending(d => d.TransactionDate)
                    .Take(5)
                    .ToListAsync();

                return ServiceResult<IEnumerable<Transaction>>.SuccessResult(transactions);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<Transaction>>.ErrorResult(e.Message);
            }
        }

        public async Task<ServiceResult<IEnumerable<TransactionResumeModel>>> GetResumeOfActualMonthAsync()
        {
            try
            {
                var date = DateTime.Now;
                var transactions = await this.transactionRepository
                    .Filter(t => t.TransactionDate.Year == date.Year && t.TransactionDate.Month == date.Month)
                    .ToListAsync();
                var positives = transactions.Where(t => t.Amount >= 0);
                var negatives = transactions.Where(t => t.Amount < 0);

                var result = transactions.Select(t => new TransactionResumeModel
                {
                    Income = positives.Sum(d => d.Amount * d.Account.ConversionRate),
                    Expenses = negatives.Sum(d => d.Amount * d.Account.ConversionRate),
                    Total = positives.Sum(d => d.Amount * d.Account.ConversionRate) - negatives.Sum(d => d.Amount * d.Account.ConversionRate),
                });

                return ServiceResult<IEnumerable<TransactionResumeModel>>.SuccessResult(result);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<TransactionResumeModel>>.ErrorResult(e.Message);
            }
        }
    }
}
