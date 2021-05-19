using FinancialApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinancialApp.Services.IServices
{
    public interface ITransactionService
    {
        Task<ServiceResult<IEnumerable<Data.Entities.Transaction>>> GetLastFiveTransactionsOfCurrentMonthAsync();
        Task<ServiceResult<IEnumerable<FinancialApp.Core.Model.TransactionResumeModel>>> GetResumeOfActualMonthAsync();
        Task<ServiceResult<bool>> CreateTransactionAsync(Data.Entities.Transaction transaction);
    }
}
