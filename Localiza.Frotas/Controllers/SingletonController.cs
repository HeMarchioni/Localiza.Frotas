using Localiza.Frotas.Infra.Singleton;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Localiza.Frotas.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SingletonController : ControllerBase
    {

        public SingletonController(SingletonContainer singletonContainer)  //-> Utilizar construtor
        {
            SingletonContainer = singletonContainer;
        }

        public SingletonContainer SingletonContainer { get; } //-> e Variavel para implementação do padrão singleton



        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return id switch
            {
                1 => Ok(SingletonContainer),
                _ => Ok(Singleton.Instance)
            };
        }



    }
}
