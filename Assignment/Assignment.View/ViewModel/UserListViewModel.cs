using Assignment.View.Model;
using Assignment.View.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Data;
using System.Reflection;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using Assignment.View.View;
using System.Windows.Input;
using System.Collections;

namespace Assignment.View.ViewModel
{
    public class UserListViewModel : ViewModelBase
    {
        //Fields
        private bool _isViewVisible = true;
        private string _searchTerm;
        private ObservableCollection<UserDetailsModel> _data;

        //Properties
        public ObservableCollection<UserDetailsModel> Data
        {
            get { return _data; }
            set
            {
                _data = value;
                OnPropertyChanged(nameof(Data));
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

        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value;
                OnPropertyChanged(nameof(SearchTerm));
                PerformSearch();
            }
        }

        //Commands
        public ICommand ViewLoginCommand { get; }
        public ICommand MinimizeWindow { get; }
        public ICommand ShutDownWindow { get; }


        //Constructor
        public UserListViewModel()
        {
            ViewLoginCommand = new ViewModelCommand(p => ExecuteMyCommand());
            MinimizeWindow = new ViewModelCommand(p => minimize());
            ShutDownWindow = new ViewModelCommand(p => shutdown());
            BindDataGrid();
        }

        private void BindDataGrid()
        {
            var dataList = new ObservableCollection<UserDetailsModel>();

            using (var connection = new SqlConnection("Server=10.50.18.16;Database=training_db;User ID=SVC_TRANING;Password=Gemini@123;"))
            using (var command = new SqlCommand())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = "SELECT FirstName,LastName,Gender,DateOfBirth,Email FROM [Users_Hridya] WHERE FirstName IS NOT NULL";
                command.CommandText = query;
                command.Connection = connection;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dataItem = new UserDetailsModel();
                        {
                            dataItem.FirstName = reader.GetString(0);
                            dataItem.LastName = reader.GetString(1);
                            dataItem.Gender = reader.GetString(2);
                            dataItem.DateOfBirth = reader.GetDateTime(3);
                            dataItem.Email = reader.GetString(4);
                        };
                        dataList.Add(dataItem);
                    }
                }
            }
            Data = dataList;
        }

        private void ExecuteMyCommand()
        {
            IsViewVisible = false;
            var goBack = new LoginView();
            goBack.Show();
            Application.Current.MainWindow.Close();
        }

        //Minimize and Shutdown Functions
        private void minimize()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void shutdown()
        {
            Application.Current.Shutdown();
        }

        private void PerformSearch()
        {
            var filteredData = new ObservableCollection<UserDetailsModel>();
            string searchTerm = SearchTerm.Trim();

            string sqlQuery = "SELECT FirstName,LastName,Gender,DateOfBirth,Email FROM [Users_Hridya] WHERE " +
                "FirstName LIKE @searchTerm OR LastName LIKE @searchTerm OR " +
                "Gender LIKE @searchTerm OR DateOfBirth LIKE @searchTerm OR Email LIKE @searchTerm";

            using (SqlConnection connection = new SqlConnection("Server=10.50.18.16;Database=training_db;User ID=SVC_TRANING;Password=Gemini@123;"))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.CommandText = sqlQuery;
                command.Connection = connection;
                command.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dataItem = new UserDetailsModel();
                        {
                            dataItem.FirstName = reader.GetString(0);
                            dataItem.LastName = reader.GetString(1);
                            dataItem.Gender = reader.GetString(2);
                            dataItem.DateOfBirth = reader.GetDateTime(3);
                            dataItem.Email = reader.GetString(4);
                        };

                        filteredData.Add(dataItem);
                    }
                }

            }
            Data = filteredData;
        }

    }
}
