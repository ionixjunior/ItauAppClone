using System;
using System.Globalization;
using Xamarin.Forms;

namespace ItauAppClone.Converters
{
    public class DeveVisualizarConteudoConverter : IValueConverter
    {
        private Func<bool> _deveVisualizarConteudoConverterParameter;

        public DeveVisualizarConteudoConverter(Func<bool> deveVisualizarConteudoConverterParameter)
        {
            _deveVisualizarConteudoConverterParameter = deveVisualizarConteudoConverterParameter;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (_deveVisualizarConteudoConverterParameter())
                return value;

            return "● ● ● ●";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
