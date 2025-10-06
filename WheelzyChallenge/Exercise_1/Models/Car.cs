namespace Exercise_1.Models;

public partial class Car
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string Year { get; set; } = null!;

    public int MakeId { get; set; }

    public int ModelId { get; set; }

    public int SubmodelId { get; set; }

    public int ZipCodeId { get; set; }

    public virtual ICollection<CarQuote> CarQuotes { get; set; } = new List<CarQuote>();

    public virtual Customer Customer { get; set; } = null!;

    public virtual Make Make { get; set; } = null!;

    public virtual Model Model { get; set; } = null!;

    public virtual Submodel Submodel { get; set; } = null!;

    public virtual ZipCode ZipCode { get; set; } = null!;
}
