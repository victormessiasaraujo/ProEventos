namespace ProEventos.Domain.Models
{
    public class RedeSocial
    {
        public int RedeSocialId { get; set; }
        public string Nome { get; set; }    
        public string URL { get; set; }
        public int? EventoId { get; set; }
        public Evento Evento { get; set; }
        public int? PalestranteId { get; set; }
        public Palestrante Palestrante { get; set; }
    }
}