using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ImagemAcao.ViewModel;

namespace ImagemAcao.View.Util
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cabecalho : ContentView
    {
        public Cabecalho()
        {
            InitializeComponent();
            BindingContext = new CabecalhoViewModel();
        }
        private void SaindoDaPagian(object sender, EventArgs args) //Todo botão possuir um object sender, EventArgs args
        {
            var ViewModel1 = (ViewModel.CabecalhoViewModel)this.BindingContext;
            if( ViewModel1.Sair.CanExecute(null)) 
            {
                ViewModel1.Sair.Execute(null);
            }
        } 
    }
}