using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace Mach_rocnikova_prace.Controls
{
    /// <summary>
    /// Interakční logika pro CustomTextBox.xaml
    /// </summary>
    public partial class CustomTextBox : UserControl, INotifyPropertyChanged
    {
        public CustomTextBox()
        {
            InitializeComponent();
            DataContext = this;
        }

        private string placeHolder;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public string PlaceHolder
        {
            get { return placeHolder; }
            set 
            {
                if (placeHolder != value)
                {
                    placeHolder = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string text;
        public string Text
        {
            get => text;
            set
            {
                if (text != value)
                {
                    text = value;
                    RaisePropertyChanged();
                }
            }
        }


        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Clear();
            txtInput.Focus();
        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
                tbPlaceholder.Visibility = Visibility.Visible;
            else
                tbPlaceholder.Visibility = Visibility.Hidden;
        }
    }
}
