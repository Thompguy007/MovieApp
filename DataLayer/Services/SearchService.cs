using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class SearchService
    {
        private readonly MovieContext _context;

        public SearchService(MovieContext context)
        {
            _context = context;
        }

        // Method to call the best_match function
        public async Task<List<BestMatchResults>> BestMatchAsync(string keyword1, string keyword2)
        {
            var command = $"SELECT * FROM best_match('{keyword1}', '{keyword2}');";
            var results = await _context.BestMatchResults.FromSqlRaw(command).ToListAsync();
            return results;
        }
    }
}
