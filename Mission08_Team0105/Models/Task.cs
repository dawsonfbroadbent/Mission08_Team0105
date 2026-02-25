using System;
using System.Collections.Generic;

namespace Mission08_Team0105.Models;

public partial class Task
{
    public int Id { get; set; }

    public string Task1 { get; set; } = null!;

    public DateOnly? DueDate { get; set; }

    public int Quadrant { get; set; }

    public int? CategoryId { get; set; }

    public bool Completed { get; set; }

    public virtual Category? Category { get; set; }
}
