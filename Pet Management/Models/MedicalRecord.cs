using System;
using System.Collections.Generic;

namespace Pet_Management.Models;

public partial class MedicalRecord
{
    public int RecordId { get; set; }

    public int? PetId { get; set; }

    public string? Diagnosis { get; set; }

    public string? Treatment { get; set; }

    public string? VetName { get; set; }

    public DateTime? Date { get; set; }

    public virtual Pet? Pet { get; set; }
}
