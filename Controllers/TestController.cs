using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
namespace order_system.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    [SwaggerOperation(Summary = "測試")]
    [SwaggerResponse(200, "Hello World")]
    public IActionResult Get()
    {
        return Ok("Hello World");
    }
}