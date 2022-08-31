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

namespace MyProject.ViewModels
{
    public static class InputAndOutputFile
    {
        public static string path = @"C:\Users\Exper\Downloads\file.txt";
        public static async Task InputFile(string firstname, string lastname, string phonenumber)
        {
            await Task.Run(() =>
            { 
             using (StreamWriter writer = new StreamWriter(path, true))
             {
                writer.WriteLine($"{firstname} {lastname} {phonenumber}");
                }
            });
        }

        public static void OutputFile()
        {
            
        }
    }
}
