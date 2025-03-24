using System;
using System.Collections.Generic;

namespace Pet_Management.Models;

public partial class Owner
{
    public int OwnerId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}
