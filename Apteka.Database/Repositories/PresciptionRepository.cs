using Apteka.Database.Entities;
using Microsoft.EntityFrameworkCore;
using pierwszaPodpiecieEntityframework.Database;
using System.Collections.Generic;
using System.Linq;

namespace Apteka.Database.Repositories
{
    public class PresciptionRepository : baseRepository<Prescription>, IPrescriptionRepository
    {
        protected override DbSet<Prescription> DbSet => dbContext.Prescriptions;

        public PresciptionRepository(AptekaDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Prescription> GetAllPrescription()
        {
            return DbSet/*.Include(x => x.Medicines)*/.Select(x => x);
        }

        
    }
}
