using System;

namespace E_Players37_AspNetCore.Models
{
    public class Partidas
    {
        public int IdPartida { get; set; }
        public int IdEquipe1 { get; set; }
        public int IdEquipe2 { get; set; }
        public DateTime Horario { get; set; }
    }
}