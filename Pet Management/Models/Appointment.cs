using System;
using System.Collections.Generic;

namespace Pet_Management.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? PetId { get; set; }

    public int? OwnerId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string? Type { get; set; }

    public string? Status { get; set; }

    public virtual Owner? Owner { get; set; }

    public virtual Pet? Pet { get; set; }
}
