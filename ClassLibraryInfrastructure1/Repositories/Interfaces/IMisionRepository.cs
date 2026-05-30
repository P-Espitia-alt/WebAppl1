using ClassLibraryInfrastructure1.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryInfrastructure1.Repositories.Interfaces
{
    public interface IMisionRepository
    {
        public Task<List<Mision>> GetAllAsync();
        //CRUD
        public Task CreateAsync(Mision mision);
        public Task<Mision?> GetByIdAsync(int id);
        public Task UpDateAsync(Mision mision);
        public Task DeleteAsync(int id);
    }
}
