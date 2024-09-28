using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace MultiInstanceWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StateController : ControllerBase
    {
        private readonly IDatabase _redisDb;

        public StateController(IConnectionMultiplexer redis)
        {
            _redisDb = redis.GetDatabase();
        }

        [HttpGet("increment")]
        public IActionResult Increment()
        {
            // Increment a shared counter
            var newValue = _redisDb.StringIncrement("global_counter");
            return Ok(new { Counter = newValue });
        }

        [HttpGet("value")]
        public IActionResult GetValue()
        {
            var value = _redisDb.StringGet("global_counter");
            return Ok(new { Counter = value });
        }
    }
}
