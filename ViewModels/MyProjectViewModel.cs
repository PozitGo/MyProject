using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace MyProject.ViewModels
{
    public class MyProjectViewModel : ObservableObject
    {
		private string _firstName;

		public string FirstName
		{
			get => _firstName; 
			set => SetProperty(ref _firstName, value);    
		}

        private string _lastName;

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        private string _phoneNumber;

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }

        private bool _IsVisibleProgressRing;
        
        public bool IsVisibleProgressRing
        {
            get => _IsVisibleProgressRing;
            set => SetProperty(ref _IsVisibleProgressRing, value);
        }

        private string _ProgressText;

        public string ProgressText
        {
            get => _ProgressText;
            set =>  SetProperty(ref _ProgressText, value);
        }
        public ICommand ButtonCommand { get; }

        public MyProjectViewModel()
        {
            ButtonCommand = new RelayCommand(OnButtonClickAsync);
        }
        
        
        private async void OnButtonClickAsync()
        {
             IsVisibleProgressRing = true;
            if (FirstName != null && LastName != null && PhoneNumber != null)
            {
                StorageFile sf = await DownloadsFolder.CreateFileAsync("Folder");
                _ = InputAndOutputFile.InputFile(FirstName, LastName, PhoneNumber);
                ProgressText = "Data saved";
                IsVisibleProgressRing = false;
            }
            else
            {
                ProgressText = "Please fill all fields";
                IsVisibleProgressRing = false;
            }
        }

    }
}
