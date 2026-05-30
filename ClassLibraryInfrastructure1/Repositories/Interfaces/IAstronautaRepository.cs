using ClassLibraryInfrastructure1.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryInfrastructure1.Repositories.Interfaces
{
    public interface IAstronautaRepository
    {
        public Task<List<Astronauta>> GetAllAsync();
        public Task CreateAsync(Astronauta astronauta);
        public Task<List<Astronauta>> GetAllWithMissionsAsync();
        public Task<Astronauta?> LoginAsync(string usuario, string contrasena);
        public Task<Astronauta?> GetByIdAsync(int id);
        public Task UpDateTokenAsync(int AstronautaId, string token); 
    }
}
