using ClassLibraryInfrastructure1.Data;
using ClassLibraryInfrastructure1.Data.Entities;
using ClassLibraryInfrastructure1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryInfrastructure1.Repositories
{
    public class MisionAstronautaRepository : IMisionAstronautaRepository
    {
        private readonly AppDbContext _context;

        public MisionAstronautaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(MisionAstronauta misionAstronauta)
        {
            try
            {
                _context.MisionAstronauta.Add(misionAstronauta);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al crear la relación entre misión y astronauta.", ex);
            }
        }

        public async Task<bool> ExistsAsync(int astronautaId, int misionId)
        {
            try
            {
                return await _context.MisionAstronauta
                    .AnyAsync(ma => ma.AstronautaID == astronautaId && ma.MisionID == misionId);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al verificar la existencia de la relación entre misión y astronauta.", ex);
            }
        }

        
    }
}
