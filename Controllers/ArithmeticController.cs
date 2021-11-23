using Microsoft.AspNetCore.Mvc;

namespace roma.Controllers;


[ApiController]
[Route("[controller]")]
public class ArithmeticController : ControllerBase
{
    private bool IsMultipleOf3(int target) {
        return target % 3 == 0;
    }
    [HttpGet(Name = "GetMultiplesOf3")]
    public IEnumerable<int> GetMultiplesOf3(
        int start,
        int finish
        )
    {
        return Enumerable
            .Range(start, finish-start)
            .Where(IsMultipleOf3)
            .ToArray();
    }
}
