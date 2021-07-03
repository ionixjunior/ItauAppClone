using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace ItauAppClone.ViewModels.Home
{
    public class HomeContentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _deveVisualizarSaldoEmConta = false;
        public bool DeveVisualizarSaldoEmConta
        {
            get => _deveVisualizarSaldoEmConta;
            set
            {
                _deveVisualizarSaldoEmConta = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SaldoEmConta));
                OnPropertyChanged(nameof(ChequeEspecial));
            }
        }

        private decimal _saldoEmConta;
        public decimal SaldoEmConta
        {
            get => _saldoEmConta;
            set
            {
                _saldoEmConta = value;
                OnPropertyChanged();
            }
        }

        private decimal _chequeEspecial;
        public decimal ChequeEspecial
        {
            get => _chequeEspecial;
            set
            {
                _chequeEspecial = value;
                OnPropertyChanged();
            }
        }

        public ICommand MostrarEsconderSaldoEmContaCommand { get; private set; } 

        public HomeContentViewModel()
        {
            MostrarEsconderSaldoEmContaCommand = new Command(MostrarEsconderSaldoEmConta);
            SaldoEmConta = 1014.96m;
            ChequeEspecial = 700.00m;
        }

        private void MostrarEsconderSaldoEmConta() => DeveVisualizarSaldoEmConta = !DeveVisualizarSaldoEmConta;
    }
}
