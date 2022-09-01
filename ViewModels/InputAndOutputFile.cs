using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments;
using Windows.Storage;
using Windows.System;
using static System.Net.WebRequestMethods;
using Windows.UI.Xaml.Controls;
using File = System.IO.File;
using Windows.Storage.Streams;

namespace MyProject.ViewModels
{
    public static class InputAndOutputFile
    {
        public static async void InputFile(string firstname, string lastname, string phonenumber)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.GetFileAsync("sample.txt");
            await FileIO.WriteTextAsync(sampleFile, $"{firstname} {lastname} {phonenumber}");

        }

        public static void OutputFile()
        {

        }
    }
}
