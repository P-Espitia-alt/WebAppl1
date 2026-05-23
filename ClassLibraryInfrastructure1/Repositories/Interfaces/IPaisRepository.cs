using ClassLibraryInfrastructure1.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryInfrastructure1.Repositories.Interfaces
{
    public interface IPaisRepository
    {
        public Task<List<Pais>> GetAllAsync();
    }
}
