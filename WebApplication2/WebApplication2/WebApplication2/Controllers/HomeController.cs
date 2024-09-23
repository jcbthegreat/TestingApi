using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("{*catchall}")]
    public class HomeController : Controller
    {
        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> HandleRequest(string catchall)
        {
            if (HttpContext.Request.Method == HttpMethods.Get)
            {
                var queryParams = HttpContext.Request.Query;
                                

                Console.WriteLine("Method: GET");
                Console.WriteLine($"Caught Route: {catchall}");

                foreach (var item in queryParams)
                {
                    Console.WriteLine($"Query Param: {item.Key} = {item.Value}");
                }

                return Ok(new
                {
                    Method = "GET",
                    CaughtRoute = catchall,
                    QueryStringData = queryParams
                });
            }
            else
            {
                return BadRequest("Unsupported Method");
            }
        }
    }

}
