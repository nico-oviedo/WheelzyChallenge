namespace Exercise_4.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

        public string Customer { get; set; }

        public bool IsActive { get; set; }
    }
}
