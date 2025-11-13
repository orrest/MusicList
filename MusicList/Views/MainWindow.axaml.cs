using Avalonia.Controls;
using MusicList.ViewModels;

namespace MusicList.Views;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}