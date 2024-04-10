using Lab9.ViewModels;
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
using static System.Net.WebRequestMethods;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Lab9
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class AddFilmPage : Page
    {
        public AddFilmPage()
        {
            this.InitializeComponent();
            ViewModel = App.ViewModel;
        }
        public MainViewModel ViewModel { get; }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleTextBox.Text) ||
                string.IsNullOrWhiteSpace(DirectorTextBox.Text) ||
                string.IsNullOrWhiteSpace(YearTextBox.Text))
            {
                ShowErrorMessage("Please fill in all fields.");
                return;
            }
            if (!YearTextBox.Text.All(char.IsDigit))
            {
                ShowErrorMessage("Year must contain only digits.");
                return;
            }

            ViewModel.SaveNewFilm();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ClearNewFilm();
        }
        private void ShowErrorMessage(string message)
        {
            ErrorMessageTextBlock.Text = message;
            ErrorMessageTextBlock.Visibility = Visibility.Visible;
        }
    }
}
