using Assignment.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Assignment.View.Repositories;
using System.Net;
using System.Security.Principal;
using System.Threading;
using Assignment.View.View;
using System.Windows;
using System.Text.RegularExpressions;

namespace Assignment.View.ViewModel
{ 
    public class LoginViewModel : ViewModelBase
    {
        //Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;
        private IUserRepository userRepository;

        //Properties
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public SecureString Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible
        {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        //Commands
        public ICommand LoginCommand { get; }
        public ICommand ViewRegisterCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }
        public ICommand MinimizeWindow { get; }
        public ICommand ShutDownWindow { get; }

        //Constructor
        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p=>ExecuteRecoverPassCommand("",""));
            ViewRegisterCommand = new ViewModelCommand(p => ExecuteMyCommand());
            MinimizeWindow = new ViewModelCommand(p => minimize());
            ShutDownWindow = new ViewModelCommand(p => shutdown());
        }

        //Implementation
        private void ExecuteMyCommand()
        {
            IsViewVisible = false;
            var RegisterWindow = new RegisterView();
            RegisterWindow.Show();
            Application.Current.MainWindow?.Close();
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            return true;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var credential = new NetworkCredential(Username,Password);
            bool validData = true;

            //Validation
            if(string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(credential.Password))
            {
                ErrorMessage = "Kindly Fill the Fields!";
                validData = false;
                return;
            }

            //User Authentication
            var isValidUser = userRepository.AuthenticateUser(credential);
            if(isValidUser && validData)
            {
                IsViewVisible = false;
                var userList = new UserList();
                userList.Show();
                Application.Current.MainWindow?.Close();
            }
            if (isValidUser == false)
            {
                ErrorMessage = "User does not Exist!";
            }
        }

        //Minimize and CLose Button Implementation
        private void minimize()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void shutdown()
        {
            Application.Current.Shutdown();
        }

        private void ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }

        //Validation Functions
        public static bool IsValidEmail(string email)
        {
            // Regular expression pattern for email validation
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }
    }
}
