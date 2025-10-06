using Exercise_1.Context;
using Exercise_1.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Exercise_1
{
    public class Exercise_1
    {
        private readonly WheelzyContext dbContext = null!;

        public Exercise_1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WheelzyContext>();
            optionsBuilder.UseSqlServer("Server=(local);Database=Wheelzy;User Id=sa;Password=sqldb;TrustServerCertificate=True;");
            dbContext = new WheelzyContext(optionsBuilder.Options);
        }

        /*** EXERCISE 1 - ENTITY FRAMEWORK QUERY ***/
        public async Task<List<CarInfoDto>> GetCarsInformationAsync()
        {
            var query = dbContext.Cars
                .Select(c => new
                {
                    Year = c.Year,
                    Make = c.Make.Name,
                    Model = c.Model.Name,
                    Submodel = c.Submodel.Name,
                    ZipCode = c.ZipCode.Code,
                    CarQuote = c.CarQuotes
                            .Where(cq => cq.IsCurrent)
                            .Select(cq => new
                            {
                                BuyerName = cq.Buyer != null ? cq.Buyer.Name : null,
                                Quote = cq.Buyer != null ? cq.Buyer.Amount : (decimal?)null,
                                StatusName = cq.Status != null ? cq.Status.Name : null,
                                StatusDate = cq.StatusHistories
                                    .Where(sh => sh.StatusId == cq.StatusId)
                                    .Select(sh => sh.Date)
                                    .FirstOrDefault()
                            })
                            .FirstOrDefault()
                })
                .Select(x => new CarInfoDto()
                {
                    Year = x.Year,
                    Make = x.Make,
                    Model = x.Model,
                    Submodel = x.Submodel,
                    ZipCode = x.ZipCode,
                    BuyerName = x.CarQuote != null ? x.CarQuote.BuyerName : null,
                    Quote = x.CarQuote != null ? x.CarQuote.Quote : null,
                    Status = x.CarQuote != null ? x.CarQuote.StatusName : null,
                    StatusDate = x.CarQuote != null ? x.CarQuote.StatusDate : null
                });

            return await query.ToListAsync();
        }
    }
}
