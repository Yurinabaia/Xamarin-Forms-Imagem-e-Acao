using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImagemAcao.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImagemAcao.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Jogo : ContentPage
    {
        public Jogo(Grupo grup)//Iso quer dizer que o grupo pode ser Nulo
        {
            InitializeComponent();
            BindingContext = new ViewModel.JogoViewModel(grup);
        }
    }
}