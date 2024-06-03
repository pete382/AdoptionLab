using System;
using System.Collections.Generic;

namespace AdoptionLab.Models;

public partial class PetCategory
{
    public int Id { get; set; }

    public string? Personality { get; set; }

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}
