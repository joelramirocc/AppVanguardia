using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialApp.API.Models.Transaction
{
    public class TransactionResumeDTO
    {
        public double Income { get; set; }

        public double Expenses { get; set; }

        public double Total { get; set; }
    }
}
