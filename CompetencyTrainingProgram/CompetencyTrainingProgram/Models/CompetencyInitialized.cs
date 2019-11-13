using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CompetencyTrainingProgram.Models
{
    public class CompetencyInitialized : DropCreateDatabaseIfModelChanges<CompetencyContext>
    {

        protected override void Seed(CompetencyContext context)
        {

           

            base.Seed(context);
        }
    }
}