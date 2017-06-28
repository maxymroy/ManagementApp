using ManagementApp.DataContext;
using ManagementApp.Models;
using ManagementApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.ViewModels
{
    public class ExpenseManagingViewModel
    {
        public IEnumerable<Frequency_> Frequency { get; set; }
        public BudgetItem BudgetItem { get; set; }

        public ExpenseManagingViewModel()
        {

        }

        public ExpenseManagingViewModel(BudgetItem budgetitem)
        {
            this.Frequency = new FrequencyRepository().GetAllIndicators();
            this.BudgetItem = budgetitem;
        }
    }
}