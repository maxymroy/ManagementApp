using ManagementApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManagementApp.ViewModels
{
    public class ExpenseGridViewModel
    {
        public IList<BudgetItem> Expenses { get; set; }

        public ExpenseGridViewModel()
        {
            this.Expenses = new List<BudgetItem>();
        }
        public decimal BiWeeklyTotal {
            get
            {
                decimal total = 0;
                foreach(var expense in Expenses)
                {
                    total += expense.BiWeekly;
                }
                return total;
            }
        }
        public decimal MonthlyTotal
        {
            get
            {
                decimal total = 0;
                foreach (var expense in Expenses)
                {
                    total += expense.Monthly;
                }
                return total;
            }
        }
        public decimal YearlyTotal
        {
            get
            {
                decimal total = 0;
                foreach (var expense in Expenses)
                {
                    total += expense.Yearly;
                }
                return total;
            }
        }
    }
}