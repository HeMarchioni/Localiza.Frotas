namespace Localiza.Frotas.Infra.Facade
{
    public class DetranOptions  //-> classe das opçoes que estao sendo setadas no appSettings
    {


        public Guid Id { get; } = Guid.NewGuid();
        public string BaseUrl { get; set; }
        public string VistoriaUri { get; set; }
        public int QuantidadeDiasParaAgendamento { get; set; }
    }
}
