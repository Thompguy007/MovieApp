using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookmarksController : ControllerBase
    {
        private readonly BookmarkService _bookmarkService;

        public BookmarksController(BookmarkService bookmarkService)
        {
            _bookmarkService = bookmarkService;
        }

        // POST: api/Bookmarks/Add
        [HttpPost("Add")]
        public async Task<IActionResult> AddBookmark(int userId, string itemType, string itemId, string annotation)
        {
            await _bookmarkService.AddBookmarkAsync(userId, itemType, itemId, annotation);
            return Ok("Bookmark added successfully");
        }

        // GET: api/Bookmarks/User/{userId}
        [HttpGet("User/{userId}")]
        public async Task<IActionResult> GetBookmarks(int userId)
        {
            var bookmarks = await _bookmarkService.GetBookmarksAsync(userId);
            return Ok(bookmarks);
        }
    }
}
