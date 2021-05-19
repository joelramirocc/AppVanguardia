using FinancialApp.API.Models.Transaction;
using FinancialApp.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }


        [HttpGet("GetResumeOfActualMonth")]
        public async Task<IActionResult> GetResumeOfActualMonthAsync()
        {
            var transactionsResume = await this.transactionService.GetResumeOfActualMonthAsync();
            if (transactionsResume.ResponseCode != Core.ResponseCode.Success)
            {
                return this.BadRequest(transactionsResume.Error);
            }

            return this.Ok(transactionsResume.Result.Select(d => new TransactionResumeDTO 
            {
                Income = d.Income,
                Expenses = d.Expenses,
                Total = d.Total,
            }));
        }

        [HttpGet("GetLastFiveTransactionsOfCurrentMonth")]
        public async Task<IActionResult> GetLastFiveTransactionsOfCurrentMonthAsync()
        {
            var transactionsResume = await this.transactionService.GetLastFiveTransactionsOfCurrentMonthAsync();
            if (transactionsResume.ResponseCode != Core.ResponseCode.Success)
            {
                return this.BadRequest(transactionsResume.Error);
            }

            return this.Ok(transactionsResume.Result.Select(d => new TransactionDTO 
            {
                Account = d.Account?.Name,
                AccountId = d.AccountId,
                Amount = d.Amount,
                Description = d.Description,
                TransactionDate = d.TransactionDate,
            }));
        }

        [HttpPost()]
        public async Task<IActionResult> CreateAsync(TransactionCreateDTO transactionCreateDTO)
        {
            var transactionsResume = await this.transactionService.CreateTransactionAsync(new Data.Entities.Transaction 
            {
                AccountId = transactionCreateDTO.AccountId,
                Amount = transactionCreateDTO.Amount,
                Description = transactionCreateDTO.Description,
                TransactionDate = transactionCreateDTO.TransactionDate,
            });

            if (transactionsResume.ResponseCode != Core.ResponseCode.Success)
            {
                return this.BadRequest(transactionsResume.Error);
            }

            return this.Ok(transactionsResume.Result);
        }   

    }
}
