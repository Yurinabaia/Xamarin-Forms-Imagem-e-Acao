using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImagemAcao.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();
            BindingContext = new ViewModel.IncioViewModel();
            //Aqui está mandado que minha logica vai está na pasta ViewModel arquivo InicioViewModel
            //E necessario fazer isso para poder usar o parametro MVVM
        }

    }
}