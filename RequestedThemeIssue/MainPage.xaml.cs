using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RequestedThemeIssue
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            if (Application.Current.Resources["CardBackgroundFillColorDefaultBrush"] is SolidColorBrush brush)
            {
                BorderBehind.Background = brush;
                Trace.WriteLine("BorderBehind brushed");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            ElementTheme theme;
            switch ((string)button.Tag)
            {
                case "Dark":
                    theme = ElementTheme.Dark;
                    break;
                case "Light":
                    theme = ElementTheme.Light;
                    break;
                default:
                    theme = ElementTheme.Default;
                    break;
            }

            if (Window.Current.Content is FrameworkElement rootElement)
            {
                rootElement.RequestedTheme = theme;
                Trace.WriteLine($"Theme changed to {theme}");
            }
        }
    }
}
