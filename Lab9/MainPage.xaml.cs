using System;
using System.Collections.Generic;
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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Lab9
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem != null && args.SelectedItemContainer != null)
            {
                var selectedItem = (NavigationViewItem)args.SelectedItem;
                sender.Header = $"{selectedItem.Content}";
                string pageName = $"{args.SelectedItemContainer.Tag}Page";
                Type pageType = Type.GetType($"Lab9.{pageName}");
                ContentFrame.Navigate(pageType);
            }
            else
            {
                ContentFrame.Navigate(typeof(FilmsPage));
            }
        }
    }
}
