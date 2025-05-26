using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GESTION.model;
using GESTION.Data;
using GESTION.Dto.Venue;
using GESTION.Mappers;

namespace GESTION.Services
{
    public class VenueService
    {
        private readonly DataContext _context;

        public VenueService(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupère toutes les venues.
        /// </summary>
        /// <returns>Liste de VenueDto.</returns>
        public async Task<IEnumerable<VenueDto>> GetAllVenuesAsync()
        {
            var venues = await _context.Venues
                .Include(v => v.Students)
                .ToListAsync();

            return venues.Select(venue => venue.ToVenueDto());
        }

        /// <summary>
        /// Récupère une venue par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de la venue.</param>
        /// <returns>Un VenueDto ou null si introuvable.</returns>
        public async Task<VenueDto?> GetVenueByIdAsync(int id)
        {
            var venue = await _context.Venues
                .Include(v => v.Students)
                .FirstOrDefaultAsync(v => v.IdVenue == id);

            return venue?.ToVenueDto();
        }

        /// <summary>
        /// Crée une nouvelle venue.
        /// </summary>
        /// <param name="dto">Données de création de la venue.</param>
        /// <returns>Le VenueDto de la venue créée.</returns>
        public async Task<VenueDto> CreateVenueAsync(CreateVenueRequestDto dto)
        {
            var venue = dto.ToVenueFromCreateDto();
            await _context.Venues.AddAsync(venue);
            await _context.SaveChangesAsync();
            return venue.ToVenueDto();
        }

        /// <summary>
        /// Met à jour les informations d'une venue existante.
        /// </summary>
        /// <param name="id">Identifiant de la venue.</param>
        /// <param name="dto">Données de mise à jour.</param>
        /// <returns>Le VenueDto mis à jour ou null si introuvable.</returns>
        public async Task<VenueDto?> UpdateVenueAsync(int id, CreateVenueRequestDto dto)
        {
            var venue = await _context.Venues.FirstOrDefaultAsync(v => v.IdVenue == id);
            if (venue == null)
            {
                return null;
            }

            venue.VenueName = dto.VenueName;

            await _context.SaveChangesAsync();
            return venue.ToVenueDto();
        }

        /// <summary>
        /// Supprime une venue par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de la venue.</param>
        /// <returns>True si supprimée, sinon false.</returns>
        public async Task<bool> DeleteVenueAsync(int id)
        {
            var venue = await _context.Venues.FirstOrDefaultAsync(v => v.IdVenue == id);
            if (venue == null)
            {
                return false;
            }

            _context.Venues.Remove(venue);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
