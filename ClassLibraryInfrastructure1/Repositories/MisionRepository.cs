using ClassLibraryInfrastructure1.Data;
using ClassLibraryInfrastructure1.Data.Entities;
using ClassLibraryInfrastructure1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryInfrastructure1.Repositories
{
    public class MisionRepository : IMisionRepository
    {
        private readonly AppDbContext _context;

        public MisionRepository(AppDbContext context)
        {
            _context = context;
        }

        //C
        public async Task CreateAsync(Mision mision)
        {
            try
            {
                _context.Mision.Add(mision);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            { 
                throw new Exception("Error al crear la mision.", ex);
            }
        }

        public async Task<List<Mision>> GetAllAsync()
        {
            List<Mision> MisionesList = new List<Mision>();

            try
            {
                MisionesList = await _context.Mision
               //.Where(m => m.Estado == "Completada")
               .ToListAsync<Mision>();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener las misiones.", ex);
            }
            return MisionesList;
        }

        //R
        public async Task<Mision?> GetByIdAsync(int id)
        {
            return await _context.Mision.FirstOrDefaultAsync(m => m.MisionId == id);
        }

        //U
        public async Task UpDateAsync(Mision mision)
        {
            _context.Mision.Update(mision);
            await _context.SaveChangesAsync();
        }

        //D
        public async Task DeleteAsync(int id)
        {
            var mision = await GetByIdAsync(id);
            if (mision != null)
            {
                _context.Mision.Remove(mision);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Misión no encontrada.");
            }
        }
    }
}
