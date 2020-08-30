using Apteka.Database.Entities;
using Microsoft.EntityFrameworkCore;
using pierwszaPodpiecieEntityframework.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apteka.Database.Repositories
{
    public class DoctorRepository : baseRepository<Doctor>, IDoctorRepository
    {
        protected override DbSet<Doctor> DbSet => dbContext.Doctors;
        public DoctorRepository(AptekaDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return DbSet/*.Include(x => x.Prescriptions).ThenInclude(x => x.Medicines)*/.Select(x => x);
        }

        
    }
}
