using System;
using System.Collections.Generic;
namespace System.Domain.Entities;
public partial class Cities
{
    public int ID { get; set; }
    public string CityName { get; set; } = null!;
    public virtual ICollection<Branches> Branches { get; set; } = new List<Branches>();
}
