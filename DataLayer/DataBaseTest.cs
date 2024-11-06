namespace DataLayer
{
    public class DatabaseTest
    {
        private readonly MovieContext _context;

        public DatabaseTest(MovieContext context)
        {
            _context = context;
        }

        public void TestConnection()
        {
            var bookmarks = _context.Bookmarks.Take(10).ToList();
            foreach (var bookmark in bookmarks)
            {
                Console.WriteLine($"Bookmark ID: {bookmark.BookmarkId}, User ID: {bookmark.UserId}, Item Type: {bookmark.ItemType}, Annotation: {bookmark.Annotation}");
            }
        }
    }
}
