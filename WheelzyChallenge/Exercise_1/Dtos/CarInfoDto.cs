namespace Exercise_1.Dtos
{
    public class CarInfoDto
    {
        public string Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Submodel { get; set; }
        public string ZipCode { get; set; }
        public string? BuyerName { get; set; }
        public decimal? Quote { get; set; }
        public string? Status { get; set; }
        public DateTime? StatusDate { get; set; }
    }
}
