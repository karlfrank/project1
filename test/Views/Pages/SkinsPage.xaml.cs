using Elibrium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace ElibriumWPF.Views.Pages
{
    /// <summary>
    /// Interaction logic for SkinsPage.xaml
    /// </summary>
    public partial class SkinsPage : Page
    {
        public SkinsPage()
        {
            InitializeComponent();
            List<String> themes = new List<String> { "BureauBlue", "BureauBlack","ExpressionDark","ExpressionLight","ShinyBlue","ShinyRed","WhistlerBlue"};
            cboxSkin.ItemsSource = themes;
            cboxSkin.SelectedItem = "WhistlerBlue";

            List<String> colours = new List<String> {};

            Type colors = typeof(System.Drawing.Color);
            PropertyInfo[] colorInfo = colors.GetProperties(BindingFlags.Public |
                BindingFlags.Static);
            foreach (PropertyInfo info in colorInfo)
            {
                colours.Add(info.Name);
            }

            cboxColor.SelectedItem = MainWindow.Colour;
            cboxColor.ItemsSource = colours;
        }
    }
}
