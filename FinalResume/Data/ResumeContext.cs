using Microsoft.EntityFrameworkCore;
using FinalResume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalResume.Data
{
    public class ResumeContext : DbContext
    {
        public ResumeContext(DbContextOptions<ResumeContext> options) : base(options)
        {
        }

        public DbSet<applicant> applicant { get; set; }
        public DbSet<education> education { get; set; }
        public DbSet<references> references { get; set; }
        public DbSet<skills> skills { get; set; }
        public DbSet<Experience> experience { get; set; }
        public DbSet<duties> duties { get; set; }
        


    }
}
