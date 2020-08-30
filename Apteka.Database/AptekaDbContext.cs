using Apteka.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apteka.Database
{
    public class AptekaDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<Medicine> Medicines { get; set; }
        public AptekaDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
