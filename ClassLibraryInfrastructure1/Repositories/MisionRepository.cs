using ClassLibraryInfrastructure1.Data;
using ClassLibraryInfrastructure1.Data.Entities;
using ClassLibraryInfrastructure1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryInfrastructure1.Repositories
{
    public class MisionRepository : IMisionRepository
    {
        private readonly AppDbContext _context;

        public MisionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Mision>> GetAllAsync()
        {
            List<Mision> MisionesList = new List<Mision>();

            try
            {
                MisionesList = await _context.Mision
               //.Where(m => m.Estado == "Completada")
               .ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener las misiones.", ex);
            }
            return MisionesList;
        }
    }
}
