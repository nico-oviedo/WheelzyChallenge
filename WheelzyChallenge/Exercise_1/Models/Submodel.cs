using System;
using System.Collections.Generic;

namespace Exercise_1.Models;

public partial class Submodel
{
    public int Id { get; set; }

    public int ModelId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual Model Model { get; set; } = null!;
}
