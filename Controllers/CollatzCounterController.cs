using Microsoft.AspNetCore.Mvc;

namespace roma.Controllers;


[ApiController]
[Route("[controller]")]
public class CollatzCounterController : ControllerBase
{
    [HttpGet(Name = "GetCollatzCounter")]
    public long GetCollatzCounter(
        long target
        )
    {
        // Si usted tiene un numero cualquiera, si ese numero es par, dividalo entre 2.
        // Si ese numero es impar, multipliquelo por 3 y le suma 1.
        // Siga haciendo esto y detengase si llega a 1.
        var counter = 1;
        do {
            if(target % 2 == 0) {
                target = target / 2;
            }
            else {
                target = (target * 3) + 1;
            }
            counter++;
        } while (target != 1);
        return counter;
    }
}
