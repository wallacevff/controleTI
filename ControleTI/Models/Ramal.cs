namespace ControleTI.Models
{
    public class Ramal
    {
        public int Id { get; set; }
        public int PontoId { get; set; }
        public PontoRede PontoRede { get; set; }
        public int VoicePanelPonto { get; set; }
        public int RamalNro { get; set; }
    }
}
