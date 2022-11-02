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

namespace WordReplacerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Properties.Settings.Default.languageCode = "pl-PL";
            Properties.Settings.Default.Save();

            var langCode = Properties.Settings.Default.languageCode;
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langCode);
        }
    }
}
