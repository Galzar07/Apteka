using Apteka.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apteka.Database
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        IEnumerable<Doctor> GetAllDoctors();
        
    }
}
