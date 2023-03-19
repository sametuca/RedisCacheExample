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
        return _memoryCache.TryGetValue("name", out string? name) ? name : "Not Found";
    }

    [HttpGet("set-date")]
    public void SetDate()
    {
        _memoryCache.Set<DateTime>("date",DateTime.Now,options:new()
        {
            //net olarak ne kadar süre cachede tutulacağı
            AbsoluteExpiration = DateTime.Now.AddSeconds(30),
            //ne aralıklarla erişim sağlanması gerektiği. aksi halde silinecektir.
            SlidingExpiration = TimeSpan.FromSeconds(5)
        });
    }
    
    [HttpGet("get-date")]
    public DateTime GetDate()
    {
        return _memoryCache.Get<DateTime>("date");
    }
}