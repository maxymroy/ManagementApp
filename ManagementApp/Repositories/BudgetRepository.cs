using ManagementApp.Models;
using ManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManagementApp.DataContext;

namespace ManagementApp.Repositories
{
    public class BudgetRepository
    {
        public BudgetViewModel GetBudget()
        {
            var budget = new BudgetViewModel();
            using (var DataContext = new mainEntities())
            {
                foreach (var budgetItem in DataContext.Budget)
                {
                    budget.Budget.Expenses.Add(new BudgetItem(id:Convert.ToInt32(budgetItem.ID),amount: Convert.ToDecimal(budgetItem.Amount),description:budgetItem.Description,frequency:Convert.ToChar(budgetItem.Indicator)));
                }
            }
            return budget;
        }

        public void AddBudgetItem(BudgetItem item)
        {
            using (var DataContext = new mainEntities())
            {
                DataContext.Budget.Add(new Budget { ID = item.ID,Amount = item.Amount, Description = item.Description, Indicator = Convert.ToString(item.Frequency)});
                DataContext.SaveChanges();
            }
        }

        public BudgetItem FindBudgetItem(int id)
        {
            BudgetItem item;
            using (var DataContext = new mainEntities())
            {
                var budgetItem = DataContext.Budget.Where(b => b.ID == id).FirstOrDefault();
                item = new BudgetItem(id: Convert.ToInt32(budgetItem.ID), amount: Convert.ToDecimal(budgetItem.Amount), description: budgetItem.Description, frequency: Convert.ToChar(budgetItem.Indicator));
            }
            return item;
        }

        public void DeleteBudgetItem(int id)
        {
            using (var DataContext = new mainEntities())
            {
                var itemToDelete = DataContext.Budget.Where(b => b.ID == id).FirstOrDefault();
                DataContext.Budget.Remove(itemToDelete);
                DataContext.SaveChanges();
            }
        }

        public void EditBudgetItem(BudgetItem item)
        {
            using (var DataContext = new mainEntities())
            {
                var itemToEdit = DataContext.Budget.Where(b => b.ID == item.ID).FirstOrDefault();
                itemToEdit.Amount = item.Amount;
                itemToEdit.Description = item.Description;
                itemToEdit.Indicator = Convert.ToString(item.Frequency);
                DataContext.SaveChanges();
            }
        }
    }
}