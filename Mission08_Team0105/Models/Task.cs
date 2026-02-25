using System;
using System.Collections.Generic;

namespace Mission08_Team0105.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public DateTime? DueDate { get; set; }

    public int Quadrant { get; set; }

    public string? Category { get; set; }

    public int Completed { get; set; }
}
