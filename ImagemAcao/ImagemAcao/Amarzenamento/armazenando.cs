using System;
using System.Collections.Generic;
using System.Text;
using ImagemAcao.Model;

namespace ImagemAcao.Amarzenamento
{
   public class armazenando
    {
        public static Jogo jogo { get; set; }
        public static short RodadaAtual { get; set; }
        public static string[][] Palavra =
        {
            //Easy Pont 1
            new string[] {"Olho", "Lingua", "Boca", "Testa", "Rua", "Cachorro", "Nariz", "Tenis",
            "Cinto", "Travessero", "Nadadeira" },
            //Intermed Pont 2
            new string[] {"Cabelo","Tenis","Flamengo","Casaco","Terapia","Frango","Pena", "Jogador de Futebol",
            "Malhação","Carteiro","Bolinha","Tamanco","Chinelo", "Passaro"},
            //Prof Pont 3
            new string[] {"Ornitorrinco", "Panela", "Vidro", "Madeira", "Teclado", "Xbox", "Neymar", 
            "Cruzeiro", "Atletar", "Caneta", "Rosquinha", "Pendrive", "Cimento", "Camareira", "Lula", "Bolsonaro", "Burro"},
        };
    }
}
