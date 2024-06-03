using System;
using System.Collections.Generic;

namespace AdoptionLab.Models;

public partial class Pet
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Breed { get; set; }

    public short? Age { get; set; }

    public string? Imagepath { get; set; }

    public virtual PetCategory? BreedNavigation { get; set; }
}
