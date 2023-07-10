using Microsoft.AspNetCore.Mvc;

public class HomeController : ControllerBase
{
    public IActionResult Index()
    {
        var data = new { Message = "Welcome to the Home Page" };
        return Ok(data);
    }
}
