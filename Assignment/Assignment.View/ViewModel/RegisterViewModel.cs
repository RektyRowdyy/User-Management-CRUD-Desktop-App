using Assignment.View.Model;
using Assignment.View.Repositories;
using Assignment.View.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Printing;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;

namespace Assignment.View.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        //Fields
        private string _firstName;
        private string _lastName;
        private string _gender;
        private DateTime _DOB;
        private string _email;
        private SecureString _password;
        private SecureString _confirmPassword;
        private string _errorMessage;
        private bool _isViewVisible = true;
        private IUserRepository userRepository;

        
        //Properties
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        
        public string Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        public DateTime DOB
        {
            get { return _DOB; }
            set
            {
                _DOB = value;
                OnPropertyChanged(nameof(DOB));
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public SecureString Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public SecureString ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
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
        public ICommand RegisterCommand { get; }
        public ICommand ViewLoginCommand { get; }
        public MessageViewModel ErrorMessageViewModel { get; }
        public ICommand MinimizeWindow { get; }
        public ICommand ShutDownWindow { get; }

        //Constructor
        public RegisterViewModel()
        {
            //setting the a default date
            DOB = new DateTime(1980, 01, 01);
            userRepository = new RegisterRepository();
            ErrorMessageViewModel = new MessageViewModel();
            ViewLoginCommand = new ViewModelCommand(p => ExecuteMyCommand());
            RegisterCommand = new ViewModelCommand(ExecuteRegisterCommand, CanExecuteRegisterCommand);
            MinimizeWindow = new ViewModelCommand(p => minimize());
            ShutDownWindow = new ViewModelCommand(p => shutdown());
        }

        //Implementation
        private bool CanExecuteRegisterCommand(object obj)
        {
            return true;
        }
    
        private void ExecuteRegisterCommand(object obj)
        {
            //To check if user already exists!
            var credential = new NetworkCredential(Email, Password);
            var secondCredential = new NetworkCredential(Email, ConfirmPassword);
            var isValidUser = userRepository.AuthenticateUser(credential);

            //check for input validations!
            bool validationResult = true;

            if (!string.Equals(credential.Password, secondCredential.Password))
            {
                ErrorMessage = "Password and Confirm Password are not same!";
                validationResult = false;
            }

            if (credential.Password.Length < 6 || credential.Password.Length > 16)
            {
                ErrorMessage = "Invalid Password Format!";
                validationResult = false;
            }

            if (string.IsNullOrEmpty(Email) || !(IsValidEmail(Email)))
            {
                ErrorMessage = "Invalid Email Format!";
                validationResult = false;
            }

            if (Gender.Contains("Please Select"))
            {
                ErrorMessage = "Please Select your Gender!";
                validationResult = false;
            }

            if (string.IsNullOrEmpty(LastName))
            {
                ErrorMessage = "LastName is required!";
                validationResult = false;
            }

            if (string.IsNullOrEmpty(FirstName)) 
            {
                ErrorMessage = "FirstName is required!";
                validationResult = false;
            }

            if(IsNumeric(FirstName) || IsNumeric(LastName))
            {
                ErrorMessage = "Name credentials format is wrong!";
                validationResult = false;
                return;
            }

            if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName) &&
                Gender.Contains("Please Select") &&
                string.IsNullOrEmpty(Email) &&
                string.IsNullOrEmpty(credential.Password) && string.IsNullOrEmpty(secondCredential.Password)) 
            {
                ErrorMessage = "Kindly Fill the Details!";
                validationResult = false;
            }

            if (isValidUser && validationResult)
            {
                using (var connection = new SqlConnection("Server=10.50.18.16;Database=training_db;User ID=SVC_TRANING;Password=Gemini@123;"))
                using (var command = new SqlCommand())
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string addData = "INSERT INTO [Users_Hridya] VALUES (NEWID(),@firstName,@lastName,@gender,@DOB,@Email,@Password)";
                    command.Connection = connection;
                    command.CommandText = addData;
                    command.Parameters.AddWithValue("@firstName", FirstName);
                    command.Parameters.AddWithValue("@lastName", LastName);
                    command.Parameters.AddWithValue("@gender", SliceString(Gender));
                    command.Parameters.AddWithValue("@DOB", DOB.ToString());
                    command.Parameters.Add("@Email", SqlDbType.VarChar).Value = credential.UserName;
                    command.Parameters.Add("@Password", SqlDbType.VarChar).Value = credential.Password;
                    command.ExecuteNonQuery();
                    connection.Close();
                    ExecuteMyCommand();
                    MessageBox.Show("User Registered Succesfully","Congrats",MessageBoxButton.OK,MessageBoxImage.Information);

                }
            }
            if(isValidUser == false)
            {
                ErrorMessage = "User already Exists!";
            }

        }

        private void ExecuteMyCommand()
        {
            IsViewVisible = false;
            var goBack = new LoginView();
            goBack.Show();
            Application.Current.MainWindow.Close();
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


        //Validation Functions
        public static bool IsNumeric(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            Regex numericRegex = new Regex(@"^[0-9]+$");

            return numericRegex.IsMatch(input);
        }
        private string SliceString(string Gender)
        {
            int spaceIndex = Gender.IndexOf(' ');

            string result = Gender.Substring(spaceIndex + 1, Gender.Length - spaceIndex - 1);

            return result;
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Regular expression pattern for email validation
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }

    }
}
