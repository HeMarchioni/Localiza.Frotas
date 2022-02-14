namespace Localiza.Frotas.Infra.Singleton
{


    // Modelo de Classe utilizando Singleton de forma manual
    public sealed class Singleton
    {

        private static Singleton instance = null;
        public Guid Id { get; } = Guid.NewGuid();  //--> toda vez que chama a classe gera um novo Guid



        private Singleton()
        {
        }


        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }




        }
    }
}
