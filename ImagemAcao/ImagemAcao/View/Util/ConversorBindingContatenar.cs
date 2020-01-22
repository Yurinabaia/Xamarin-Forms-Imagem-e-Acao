using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ImagemAcao.View.Util
{
    class ConversorBindingContatenar : IValueConverter
    {
        //O convert e chamado quando é chamado pela view
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if((byte)value == 0) 
            {
                return "Pontução: "; //Aqui está contatena nosso label apenas 
            }
            else return "Pontução: " + value; //Aqui está contatena nosso label
        }
        //O convertBack e quando estou na minha View Model e estou chamando o convert
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
