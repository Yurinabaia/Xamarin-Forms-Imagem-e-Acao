using System;
using System.Collections.Generic;
using System.Text;
using ImagemAcao.Model;//Aqui estamos chamando os conteudos da pasta model
using Xamarin.Forms; //Sera necesario está biblioteca para chamar o Command
using System.ComponentModel;//Esta biblioteca ira buscar a interface do INotifyPropertyChanged
using ImagemAcao.Amarzenamento;//Serve para pegarmos a informação do tempo de contagem


namespace ImagemAcao.ViewModel
{
   public class JogoViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Todas as propriedades estão vindo da pasta view
        /// </summary>
        //Propriedade da nossa tela
        public string NumeroGrupao { get; set; }
        public string NomeGrupo { get; set; }

        private Grupo grup { get; set; }

        private byte _PalavraPontuacao;
        public byte PalavraPontuacao { get { return _PalavraPontuacao; } set { _PalavraPontuacao = value; OnPropertyChanged("PalavraPontuacao"); } }


        private string _Palavra;
        public string Palavra { get { return _Palavra; } set { _Palavra = value; OnPropertyChanged("Palavra"); } }

        
        private string _TextoContagem;
        public string TextoContagem { get { return _TextoContagem; } set { _TextoContagem = value; OnPropertyChanged("TextoContagem"); } }

        private bool _StackLayoutTrueFalse;
        public bool StackLayoutTempoTrueFalse { get { return _StackLayoutTrueFalse; } set { _StackLayoutTrueFalse = value;  OnPropertyChanged("StackLayoutTempoTrueFalse"); } }
        //Aqui serve para poder mostar a palavra


        private bool _InicarTrueFalse;
        public bool StackLayoutIniciarTrueFalse { get { return _InicarTrueFalse; } set { _InicarTrueFalse = value; OnPropertyChanged("StackLayoutIniciarTrueFalse"); } }
        //Aqui serve para poder mostra o botão iniciar

        private bool _PalavraTrueFalse;
        public bool PalavraTrueFalse { get { return _PalavraTrueFalse; } set { _PalavraTrueFalse = value; OnPropertyChanged("PalavraTrueFalse"); } }//Aqui serve para poder mostra a palavra

        //Command
        public Command MostraPalavra { get; set; }
        public Command Acertou { get; set; }
        public Command Errou { get; set; }
        public Command Iniciar { get; set; }
        public JogoViewModel(Grupo GRUPANDO)
        {
            grup = GRUPANDO;
            if(grup == armazenando.jogo.grupo1) 
            {
                NumeroGrupao = "Grupo 1";
            }
            else 
            {
                NumeroGrupao = "Grupo 2";
            }


            NomeGrupo = GRUPANDO.Nome;//Aqui esta recebendo o nome do grupo
            //Todo command tem que colocar ter que estar aqui no construtor
            StackLayoutTempoTrueFalse = false;//AQUI DEFINIMOS QUE A CONTAGEM VAI SER INVISIVEL ATE QUE APARECAR A PALAVRA
            StackLayoutIniciarTrueFalse = false; //Aqui definimos que o botão iniciar vai aparecer invisivel
            PalavraTrueFalse = true; //Aqui deixar a palavra escondidar


            Palavra = "***********";
            //Aqui temos os command
            MostraPalavra = new Command(MostrarPalavraAction);
            Acertou = new Command(AcertouAction);
            Errou = new Command(ErrouAction);
            Iniciar = new Command(IniciarAction);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string NamePropriedade)
        //Necessitar criar este metodo para verificar poder fazer as atualização em tempo real
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NamePropriedade));//Necessitar deste evento
            }
        }
        private void MostrarPalavraAction() 
        {
            //TODO - aqui devemos implmentar a opção de aparecer um valores das palavras aleatório
            PalavraTrueFalse = false;//Aqui esta fazendo com que o botão mostra não apareça
            StackLayoutIniciarTrueFalse = true;//Aqui faz com que o botão iniciar apareça
            var NumNivel = armazenando.jogo.NivelNumerico;
            if(armazenando.jogo.NivelNumerico == 0) 
            {
                Random rd = new Random();
                int niv = rd.Next(0, 3);//Aqui ira fazer aleatoriamente qual valor vai entra no nivel
                int ind = rd.Next(0, armazenando.Palavra[niv].Length);//Aqui está escolhendo a palavra aleatorio
                Palavra = armazenando.Palavra[niv][ind];//Aqui está pegando a palavra gerada aleatoria
                if(niv == 0) PalavraPontuacao = 1;//Numero de pontos de cada nivel
                else if(niv == 1) PalavraPontuacao = 3;//Numero de pontos de cada nivel
                else PalavraPontuacao = 5;//Numero de pontos de cada nivel
            }
            else if (armazenando.jogo.NivelNumerico == 1)
            {
                Random rd = new Random();
                int ind = rd.Next(0, armazenando.Palavra[NumNivel - 1].Length);//Aqui está escolhendo a palavra aleatorio
                Palavra = armazenando.Palavra[NumNivel - 1][ind];//Aqui está pegando a palavra gerada aleatoria
                PalavraPontuacao = 1;//Numero de pontos de cada nivel
            }
           else if (armazenando.jogo.NivelNumerico == 2)
            {
                Random rd = new Random();
                int ind = rd.Next(0, armazenando.Palavra[NumNivel - 1].Length);//Aqui está escolhendo a palavra aleatorio
                Palavra = armazenando.Palavra[NumNivel - 1][ind];//Aqui está pegando a palavra gerada aleatoria
                PalavraPontuacao = 3;//Numero de pontos de cada nivel
            } 
            else if (armazenando.jogo.NivelNumerico == 3)
            {
                Random rd = new Random();
                int ind = rd.Next(0, armazenando.Palavra[NumNivel - 1].Length);//Aqui está escolhendo a palavra aleatorio
                Palavra = armazenando.Palavra[NumNivel - 1][ind];//Aqui está pegando a palavra gerada aleatoria
                PalavraPontuacao = 5;//Numero de pontos de cada nivel
            }
        }
        private void IniciarAction() 
        {
            StackLayoutIniciarTrueFalse = false;
            StackLayoutTempoTrueFalse = true;
            int i = armazenando.jogo.TempoPalavra;
            //TODO - quando tempo terminar para a contagem
            TextoContagem = i.ToString();
            i--;
            Device.StartTimer(TimeSpan.FromSeconds(1), () => //Aqui ira fazer o cronometro
            {
                TextoContagem = i.ToString();
                i--;
                if(i < 0) 
                {
                    TextoContagem = "Tempo esgotado";
                }
                return true;
            });
        }
        private void AcertouAction() 
        {
            grup.Pontuacao += PalavraPontuacao;//Aqui faz a soma dos pontos do grupo
            //Todo - ir para pagina seguinte
            Grupo SaberAVezDoGrupo; //Isso é uma variavel que vai receber qual grupo vai entra
            if(armazenando.jogo.grupo1 == grup) 
            {
                SaberAVezDoGrupo = armazenando.jogo.grupo2;
            }
            else 
            {
                SaberAVezDoGrupo = armazenando.jogo.grupo1;
                armazenando.RodadaAtual++;
            }
            if(armazenando.RodadaAtual > armazenando.jogo.Rodadas) 
            {
                App.Current.MainPage = new View.Resultado();
            }
            else
            App.Current.MainPage = new View.Jogo(SaberAVezDoGrupo);
        }
        private  void ErrouAction () 
        {
            //Todo - ir para pagina seguinte
            Grupo SaberAVezDoGrupo; //Isso é uma variavel que vai receber qual grupo vai entra
            if (armazenando.jogo.grupo1 == grup)
            {
                SaberAVezDoGrupo = armazenando.jogo.grupo2;
            }
            else
            {
                SaberAVezDoGrupo = armazenando.jogo.grupo1;
                armazenando.RodadaAtual++;
            }
            if(armazenando.RodadaAtual > armazenando.jogo.Rodadas) 
            {
                App.Current.MainPage = new View.Resultado();
            }
            else
            App.Current.MainPage = new View.Jogo(SaberAVezDoGrupo);
        }
    }
}
