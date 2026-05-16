using ClassLibraryInfrastructure1.Data;
using ClassLibraryInfrastructure1.Data.Entities;
using ClassLibraryInfrastructure1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryInfrastructure1.Repositories
{
    public class AstronautaRepository : IAstronautaRepository
    {

        private readonly AppDbContext _context;

        public AstronautaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Astronauta>> GetAllAsync()
        {
            List<Astronauta> Astronautas = new List<Astronauta>();

            try
            {
                Astronautas = await _context.Astronauta
                                    .Include(a => a.Pais) //Carga la información del país relacionado con cada astronauta
                                                          //Le dice a EntityFramework que cuando traiga los astronautas, haga también una consulta a la tabla
                                                          //Pais y una a la tabla Astronauta y las una.En SQL sería equivalente a un JOIN
                                                          //"por cada astronauta, incluye su Pais".
                                    .ToListAsync();
                
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener los astronautas.", ex);
            }
            return Astronautas;
        }



        public async Task CreateAsync(Astronauta astronauta)
        {
            try
            {
                _context.Astronauta.Add(astronauta);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al crear el astronauta.", ex);
            }
        }

        public async Task<List<Astronauta>> GetAllWithMissionsAsync()
        {
            List<Astronauta> Astronautas = new List<Astronauta>();
            try
            {

                Astronautas = await _context.Astronauta
                    .Include(a => a.MisionesAsignadas) //Include: trae las relaciones MisionAstronauta de cada astronauta
                    .ThenInclude(ma => ma.Mision)      //ThenInclude: dentro de cada relación, trae la Mision completa
                    .ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener los astronautas con misiones.", ex);
            }
            return Astronautas;
        }
    }
}
