using System.Windows;

namespace Devil.Wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Resources.Add("services", App.Host!.Services);
    }
}
