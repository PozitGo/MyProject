using MyProject.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyProject.Views
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MyProject : Page
    {
        MyProjectViewModel viewModel = new MyProjectViewModel();
        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        public MyProject()
        {
            this.InitializeComponent();
        }
        private void Current_Resuming(object sender, object e)
        {
            fName.Text = localSettings.Values["FirstName"] as string;
            lName.Text = localSettings.Values["LastName"] as string;
            pNumber.Text = localSettings.Values["PhoneNumber"] as string;
        }
        private void Current_Suspending(object sender, Windows.ApplicationModel.SuspendingEventArgs e)
        {
            localSettings.Values["FirstName"] = fName.Text;
            localSettings.Values["LastName"] = lName.Text;
            localSettings.Values["PhoneNumber"] = pNumber.Text;
        }
    }
}
