using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyProject.DB;
using MySql.Data.MySqlClient;
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

        private string _login;

        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }

        private string _password;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _passwordrepeat;

        public string PasswordRepeat
        {
            get => _passwordrepeat;
            set => SetProperty(ref _passwordrepeat, value);
        }

        public ICommand ButtonCommand { get; }
        public ICommand ButtonCommandLogin { get; }
        public ICommand ButtonCommandRegister { get; }

        public MyProjectViewModel()
        {
            ButtonCommand = new RelayCommand(OnButtonClick);
            ButtonCommandLogin = new RelayCommand(ButtonLogin);
            ButtonCommandRegister = new RelayCommand(ButtonRegister);
        }


        private void ButtonRegister()
        {
            DataBase.RegiserUser(Login, Password, PasswordRepeat, FirstName, LastName);
        }
        private void ButtonLogin()
        {
            DataBase.AuthToLogin(Login, Password);
        }
        private void OnButtonClick()
        {
             IsVisibleProgressRing = true;
            if (FirstName != null && LastName != null && PhoneNumber != null)
            {
                // Create sample file; replace if exists.
                
                InputAndOutputFile.InputFile(FirstName, LastName, PhoneNumber);
                //ProgressText = "Data saved";
                //IsVisibleProgressRing = false;
            }
            else
            {
                ProgressText = "Please fill all fields";
                IsVisibleProgressRing = false;
            }
        }  

    }
}
