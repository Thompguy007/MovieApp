using DataLayer.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    private readonly SearchService _searchService;

    public SearchController(SearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpGet("BestMatch")]
    public async Task<IActionResult> GetBestMatch([FromQuery] string keyword1, [FromQuery] string keyword2)
    {
        var results = await _searchService.BestMatchAsync(keyword1, keyword2);
        return Ok(results);
    }
}
