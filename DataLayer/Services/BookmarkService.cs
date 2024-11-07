using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class BookmarkService
    {
        private readonly MovieContext _context;

        public BookmarkService(MovieContext context)
        {
            _context = context;
        }

        // AddBookmarkAsync method
        public async Task AddBookmarkAsync(int userId, string itemType, string itemId, string annotation)
        {
            var command = $"SELECT add_bookmark({userId}, '{itemType}', '{itemId}', '{annotation}');";
            await _context.Database.ExecuteSqlRawAsync(command);
        }

        // New GetBookmarksAsync method to retrieve bookmarks for a user
        public async Task<List<Bookmark>> GetBookmarksAsync(int userId)
        {
            var command = $"SELECT * FROM get_bookmarks({userId});";
            var bookmarks = await _context.Bookmarks
                                          .FromSqlRaw(command)
                                          .ToListAsync();

            return bookmarks;
        }

    }
}
