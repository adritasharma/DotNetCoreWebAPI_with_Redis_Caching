using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Demo.DB.Entities;
using Demo.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Demo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        private readonly IToDoRepository _toDoRepository;
        private readonly IDistributedCache _distributedCache;
        public ToDoController(IToDoRepository repository, IDistributedCache distributedCache)
        {
            _toDoRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _distributedCache = distributedCache;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var res = new List<ToDo>();
            bool IsCached = false;
            string cachedTodos = string.Empty;
            cachedTodos = await _distributedCache.GetStringAsync("_todos");
            if (!string.IsNullOrEmpty(cachedTodos))
            {
                // loaded data from the redis cache.
                res = JsonSerializer.Deserialize<List<ToDo>>(cachedTodos);
                IsCached = true;
            }
            else
            {
                res = (_toDoRepository.GetAllToDos()).ToList();
                cachedTodos = JsonSerializer.Serialize<List<ToDo>>(res);
                var expiryOptions = new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60),
                    SlidingExpiration = TimeSpan.FromSeconds(60)
                };
                await _distributedCache.SetStringAsync("_todos", cachedTodos);
            }
            return Ok(new { IsCached, res });
        }

        [HttpGet]
        [Route("clear-cache/{key}")]
        public async Task<IActionResult> ClearCache(string key)
        {
            await _distributedCache.RemoveAsync(key);
            return Ok(new { Message = $"cleared cache for key - {key}" });
        }

    }
}