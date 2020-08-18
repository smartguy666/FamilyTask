using Domain.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    //public class MemberTasksContext:DbContext
    //{
    //    public MemberTasksContext(DbContextOptions<FamilyTaskContext> options) : base(options)
    //    {

    //    }
    //    public DbSet<Tasks> MemberTasks { get; set; }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder);

    //        modelBuilder.Entity<Member>(entity => {
    //            entity.HasKey(k => k.Id);
    //            entity.ToTable("Tasks");
    //        });
    //    }

    //}

   
}
