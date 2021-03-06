﻿using Apteka.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apteka.Database
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {

        IEnumerable<Prescription> GetAllPrescription();
    }
}
