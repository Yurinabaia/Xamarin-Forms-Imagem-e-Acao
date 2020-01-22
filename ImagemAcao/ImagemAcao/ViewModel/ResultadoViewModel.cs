using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;//Sera necesario está biblioteca para chamar o Command
using System.ComponentModel;//Esta biblioteca ira buscar a interface do INotifyPropertyChanged
using ImagemAcao.Model;//Importando a pasta model
using ImagemAcao.Amarzenamento; //Importando a pasta armazenamento
namespace ImagemAcao.ViewModel
{
   public class ResultadoViewModel : INotifyPropertyChanged //Não esqueça de colocar está merda em public
    {
        public Jogo Jogo { get; set; }
        public Command JogarNovamente { get; set; }
        public ResultadoViewModel() 
        {
            Jogo = armazenando.jogo;
            JogarNovamente = new Command(ReiniciandoPartida);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string NamePropriedade)
        //Necessitar criar este metodo para verificar poder fazer as atualização em tempo real
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NamePropriedade));//Necessario para este evento
            }
        }
        private void ReiniciandoPartida() 
        {
            App.Current.MainPage = new View.Inicio();
        }
    }
}
