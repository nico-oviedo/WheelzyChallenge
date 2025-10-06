using Exercise_4.Context;
using Exercise_4.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Exercise_4
{
    public class Exercise_4
    {
        private Exercise4Context dbContext = null!;

        public Exercise_4()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Exercise4Context>();
            optionsBuilder.UseSqlServer("Server=(local);Database=Exercise4;User Id=sa;Password=sqldb;TrustServerCertificate=True;");
            dbContext = new Exercise4Context(optionsBuilder.Options);
        }

        /*** EXERCISE 4 ***/
        public async Task<List<OrderDto>> GetOrders(DateTime? dateFrom, DateTime? dateTo, List<int> customerIds, List<int> statusIds, bool? isActive)
        {
            var query = dbContext.Orders.AsQueryable();

            if (dateFrom.HasValue)
                query = query.Where(o => o.Date >= dateFrom.Value);

            if (dateTo.HasValue)
                query = query.Where(o => o.Date <= dateTo.Value);

            if (customerIds != null && customerIds.Any())
                query = query.Where(o => customerIds.Contains(o.CustomerId));

            if (statusIds != null && statusIds.Any())
                query = query.Where(o => statusIds.Contains(o.StatusId));

            if (isActive.HasValue)
                query = query.Where(o => o.IsActive == isActive.Value);

            return await query
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    Date = o.Date,
                    Status = o.Status.Name,
                    Customer = o.Customer.Name,
                    IsActive = o.IsActive
                })
                .ToListAsync();
        }
    }
}
