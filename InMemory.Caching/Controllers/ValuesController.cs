using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemory.Caching.Controllers;

// The [ApiController] attribute is used to indicate that the controller responds to web API requests.
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly IMemoryCache _memoryCache;

    public ValuesController(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    // GET api/values
    [HttpGet("set/{name}")]
    public void Set(string name)
    {
        // The Set method adds or updates a cache entry in the cache.
        _memoryCache.Set("name", name);
    }
    
    // GET api/values
    [HttpGet("get")]
    public string? Get()
    {
        // If the key is not found, the method returns false and the value parameter contains the default value for the type of the value parameter.
        if (_memoryCache.TryGetValue("name", out string? name))
        {
            return name;
        }
        
        return "Not Found";
    }
}