using ClassLibraryInfrastructure1.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryInfrastructure1.Repositories.Interfaces
{
    public interface IMisionAstronautaRepository
    {
        public Task CreateAsync(MisionAstronauta misionAstronauta);
        public Task<bool> ExistsAsync(int astronautaId, int misionId);
        
    }
}
