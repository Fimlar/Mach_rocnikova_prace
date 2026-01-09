using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mach_rocnikova_prace.Controls
{
    /// <summary>
    /// Interakční logika pro WidgetCard.xaml
    /// </summary>
    public partial class WidgetCard : UserControl
    {
        public WidgetCard()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(WidgetCard), new PropertyMetadata(""));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty HeaderRightProperty =
            DependencyProperty.Register(nameof(HeaderRight), typeof(object), typeof(WidgetCard), new PropertyMetadata(null));

        public object HeaderRight
        {
            get => GetValue(HeaderRightProperty);
            set => SetValue(HeaderRightProperty, value);
        }
    }
}
