using System;
using System.Collections.Generic;

namespace Exercise_1.Models;

public partial class Model
{
    public int Id { get; set; }

    public int MakeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual Make Make { get; set; } = null!;

    public virtual ICollection<Submodel> Submodels { get; set; } = new List<Submodel>();
}
