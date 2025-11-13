using CommunityToolkit.Mvvm.ComponentModel;

namespace MusicList.ViewModels;

public partial class MainViewModel : ObservableRecipient
{
    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";
}
