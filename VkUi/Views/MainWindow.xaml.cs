using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using VkUi.ViewModels;

namespace VkUi.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            
        }
        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            DataContext = mainWindowViewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void Auth()
        {
            
        }
    }
}