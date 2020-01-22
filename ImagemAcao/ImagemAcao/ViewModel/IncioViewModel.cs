using System;
using System.Collections.Generic;
using System.Text;
using ImagemAcao.Model;//Aqui estamos chamando os conteudos da pasta model
using System.ComponentModel;//Esta biblioteca ira buscar a interface do INotifyPropertyChanged
using Xamarin.Forms; //Sera necesario está biblioteca para chamar o Command para acionar nosso botão
using ImagemAcao.Amarzenamento;//Este arquivo sera importante para armezenar as informações

namespace ImagemAcao.ViewModel
{
    //Vamos utilizar o Binding Bidimensional
    public class IncioViewModel : INotifyPropertyChanged
        //Esta interface faz com que possamos atualizar nossa Binding em tempo real
    {
        public Jogo Jogo { get; set; }
        public Command IniciarJogo { get; set; }//Este metodo so foi possivel ser criado por causa da biblioteca Xamari.Forms

        private string _ERRODD;
        public string ErroDD { get {return _ERRODD; } set { _ERRODD = value; OnPropertyChanged("ErroDD"); } }
        public IncioViewModel()
        {
            IniciarJogo = new Command(InciarComando);
            //é preciso instanciar as classes do jogo
            Jogo = new Jogo();
            Jogo.grupo1 = new Grupo();
            Jogo.grupo2 = new Grupo();

            Jogo.TempoPalavra = 120;//Valores que ira mostra no começo do jogo
            Jogo.Rodadas = 7;//Valores que ira mostra no começo do jogo
        }
        private void InciarComando()
        {
            string errando = "";
            if(Jogo.TempoPalavra < 10) 
            {
                errando += "O tempo minimo para as palavras é 10 segundoss";
            }
           else if(Jogo.Rodadas <= 0) 
            {
                errando += "\n O valor minimo de rodadas é 1";
            }
           if (errando.Length > 0)
            {
                ErroDD = errando;
            }
            else
            {
                armazenando.jogo = this.Jogo;//Aqui estamos armazenando todas as informações do Jogo
                armazenando.RodadaAtual = 1;
                App.Current.MainPage = new View.Jogo(Jogo.grupo1);
                //Aqui estou instanciando uma nova pagina que vai aparece quando clickar no botao
                //Este botão se encotra na pasta view, arquivo Inicio.Xaml;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        //Aqui tenmos o metodo obrigatorio para interface INotifyPropertyChanged
        private void OnPropertyChanged(string NamePropriedade) 
            //Necessitar criar este metodo para verificar poder fazer as atualização em tempo real
        {
            if(PropertyChanged != null) 
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NamePropriedade));//Necessario para este evento
            }
        }
    }
}
