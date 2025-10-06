using Exercise_3.Context;
using Exercise_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercise_3
{
    public class Exercise_3
    {
        private Exercise3Context dbContext = null!;

        public Exercise_3()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Exercise3Context>();
            optionsBuilder.UseSqlServer("Server=(local);Database=Exercise3;User Id=sa;Password=sqldb;TrustServerCertificate=True;");
            dbContext = new Exercise3Context(optionsBuilder.Options);
        }

        /*** EXERCISE 3 ***/
        public void UpdateCustomersBalanceByInvoices(List<Invoice> invoices)
        {
            if (invoices == null || !invoices.Any())
                return;

            // Obtains list of different Customer Ids from the Invoices
            var customerIds = invoices.Select(i => i.CustomerId).Distinct().ToList();

            // Gets list of Customers from database, using Customer Ids list as filter
            var customers = dbContext.Customers.Where(c => customerIds.Contains(c.Id)).ToList();

            // Goes through every Invoice from the list to update Customer balance
            foreach (var invoice in invoices)
            {
                var customer = customers.Where(c => c.Id == invoice.CustomerId).FirstOrDefault();

                if (customer != null)
                    customer.Balance -= invoice.Total;
            }

            dbContext.SaveChanges();
        }
    }
}
