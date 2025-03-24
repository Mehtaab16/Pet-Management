using System;
using System.Collections.Generic;

namespace Pet_Management.Models;

public partial class Pet
{
    public int PetId { get; set; }

    public string Name { get; set; } = null!;

    public string Species { get; set; } = null!;

    public string? Breed { get; set; }

    public int? Age { get; set; }

    public string? Gender { get; set; }

    public int? OwnerId { get; set; }

    public string? MedicalHistory { get; set; }

    public DateTime? DateRegistered { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

    public virtual Owner? Owner { get; set; }
}
