using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow currentWindow;

        public MainWindow()
        {
            InitializeComponent();
            currentWindow = this;
            Browser.JavascriptObjectRepository.ResolveObject += (sender, e) =>
            {
                var repo = e.ObjectRepository;
                if (e.ObjectName == "boundAsync")
                {
                    repo.Register("boundAsync", new BoundObject(), isAsync: true);
                }
            };
        }
    }

    public class BoundObject
    {
        public void Agree()
        {
            MainWindow.currentWindow.Dispatcher.Invoke(() => {
                MessageBox.Show("Hello world");
            });
        }
    }
}
