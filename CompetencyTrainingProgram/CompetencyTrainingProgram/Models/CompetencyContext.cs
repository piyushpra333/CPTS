using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CompetencyTrainingProgram.Models
{
    public class CompetencyContext : DbContext
    {
        public CompetencyContext() : base("name=MajorProject")
        {
            //this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new CompetencyInitialized());
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Question>()
        //    .HasRequired(c => c.Training)
        //    .WithMany()
        //    .WillCascadeOnDelete(false);
        //}
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Training> Trainings { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }
    }
}