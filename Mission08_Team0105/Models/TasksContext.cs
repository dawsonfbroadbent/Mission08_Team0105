using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0105.Models;

public partial class TasksContext : DbContext
{
    public TasksContext()
    {
    }

    public TasksContext(DbContextOptions<TasksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=tasks.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>(entity =>
        {
            entity.ToTable("tasks");

            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.Completed).HasColumnName("completed");
            entity.Property(e => e.DueDate)
                .HasColumnType("DATE")
                .HasColumnName("due_date");
            entity.Property(e => e.Quadrant).HasColumnName("quadrant");
            entity.Property(e => e.TaskName).HasColumnName("task_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
