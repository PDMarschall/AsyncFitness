﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Interfaces
{
    public interface IRepositoryAsync<T>
    {

        Task SaveChangesAsync();
    }
}
