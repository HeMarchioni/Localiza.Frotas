using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.Frotas.Infra.Singleton
{

    //-> Usando singleton de forma Automatica por meio do framework (configuração em Program)

    public class SingletonContainer
    {

        public Guid Id { get; } = Guid.NewGuid();

    }
}
