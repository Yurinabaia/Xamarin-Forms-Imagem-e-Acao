using System;
using System.Collections.Generic;
using System.Text;

namespace ImagemAcao.Model
{
    public class Jogo
    {
        public Grupo grupo1 { get; set; }
        public Grupo grupo2 { get; set; }

        public string Niveis { get; set; }
        public short TempoPalavra { get; set; }
        public short Rodadas { get; set; }
        public int NivelNumerico { get; set; }
    }
}
