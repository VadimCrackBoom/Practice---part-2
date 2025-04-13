using Microsoft.AspNetCore.Mvc;

[Route("")]
[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok("API is running");
}