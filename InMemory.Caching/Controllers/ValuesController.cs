using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemory.Caching.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly IMemoryCache _memoryCache;

    public ValuesController(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    [HttpGet("set/{name}")]
    public void Set(string name)
    {
        _memoryCache.Set("name", name);
    }
    
    [HttpGet("get")]
    public string? Get()
    {
        return _memoryCache.Get<string>("name");
    }
}