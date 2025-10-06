using System;
using System.Collections.Generic;

namespace Exercise_1.Models;

public partial class Make
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
