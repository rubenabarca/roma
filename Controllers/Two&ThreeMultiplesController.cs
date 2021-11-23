using Microsoft.AspNetCore.Mvc;

namespace roma.Controllers;


[ApiController]
[Route("[controller]")]
public class TwoAndThreeMultiplesController : ControllerBase
{
    private bool IsMultipleOf2(int target) {
        return target % 2 == 0;
    }
     private bool IsMultipleOf3(int target) {
        return target % 3 == 0;
    }
    [HttpGet(Name = "GetMultiplesOf2and3")]
    public IEnumerable<IEnumerable<int>> GetMultiplesOf2and3(int start,int finish)
    {
        yield return Enumerable
            .Range(start, finish-start)
            .Where(IsMultipleOf2)
            .ToArray();
        yield return Enumerable
            .Range(start, finish-start)
            .Where(IsMultipleOf3)
            .ToArray();
    }
    
}