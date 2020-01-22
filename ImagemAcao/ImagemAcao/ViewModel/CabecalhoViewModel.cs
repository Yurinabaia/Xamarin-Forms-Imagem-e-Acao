using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ImagemAcao.ViewModel
{
    class CabecalhoViewModel
    {
        public Command Sair { get; set; }

        public CabecalhoViewModel()
        {
            Sair = new Command(SairPartida);
        }
        private void SairPartida() 
        {
            App.Current.MainPage = new View.Inicio();
        }
    }
}
