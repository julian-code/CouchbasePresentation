using System;
using System.Threading.Tasks;
using api.models;
using Couchbase.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IDefaultBucketProvider _bucketProvider;

        public UserController(IDefaultBucketProvider bucketProvider)
        {
            _bucketProvider = bucketProvider;
        }

        [HttpPost]
        public async Task<IActionResult> InsertUser(User user) 
        {
            var bucket = await _bucketProvider.GetBucketAsync();
            var key = Guid.NewGuid().ToString();
            var result = await bucket.DefaultCollection().InsertAsync<User>(key, user);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id) 
        {
            var bucket = await _bucketProvider.GetBucketAsync();
            var result = await bucket.DefaultCollection().GetAsync(id.ToString());
            return Ok(result.ContentAs<User>());
        }
    }
}