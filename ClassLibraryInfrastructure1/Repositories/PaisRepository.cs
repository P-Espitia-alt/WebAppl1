using ClassLibraryInfrastructure1.Data;
using ClassLibraryInfrastructure1.Data.Entities;
using ClassLibraryInfrastructure1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryInfrastructure1.Repositories
{
    public class PaisRepository : IPaisRepository
    {

        private readonly AppDbContext _context;

        public PaisRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pais>> GetAllAsync()
        {

            List<Pais> Paises = new List<Pais>();
            try
            {
                Paises = await _context.Pais.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener los paises.", ex);
            }

            return Paises;
        }
    }
}
