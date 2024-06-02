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
using System.Windows.Shapes;

namespace AnimeVoices.MVVM.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void ChangeTheme_btn_Click(object sender, RoutedEventArgs e)
        {
            var newTheme = Application.Current.Resources.MergedDictionaries.First();

            Application.Current.Resources.MergedDictionaries.RemoveAt(0);
            Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }
    }
}
