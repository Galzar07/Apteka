using Apteka.Database.Entities;
using Microsoft.EntityFrameworkCore;
using pierwszaPodpiecieEntityframework.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apteka.Database.Repositories
{
    public class MedicineRepository : baseRepository<Medicine>, IMedicineRepository
    {
        protected override DbSet<Medicine> DbSet => dbContext.Medicines;

        

        public MedicineRepository(AptekaDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Medicine> GetAllMedicines()
        {
            return DbSet.Select(x => x);
        }

        
    }
}
