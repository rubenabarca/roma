using Microsoft.AspNetCore.Mvc;

namespace roma.Controllers;


[ApiController]
[Route("[controller]")]
public class TwoMultiplesController : ControllerBase
{
    private bool IsMultipleOf2(int target) {
        return target % 2 == 0;
    }
    [HttpGet(Name = "GetMultiplesOf2")]
    public IEnumerable<int> GetMultiplesOf2(int start,int finish)
    {
        return Enumerable
            .Range(start, finish-start)
            .Where(IsMultipleOf2)
            .ToArray();
    }
}
