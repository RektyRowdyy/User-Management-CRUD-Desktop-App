using System;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace Assignment.View.CustomControls
{

    public partial class BindablePasswordBox : UserControl
    {

        public static readonly DependencyProperty PassswordProperty = 
            DependencyProperty.Register("Password",typeof(SecureString), typeof(BindablePasswordBox));

        public SecureString Password
        {
            get { return (SecureString)GetValue(PassswordProperty); }
            set { SetValue(PassswordProperty, value);}
        }

        public BindablePasswordBox()
        {
            InitializeComponent();
            txtPassword.PasswordChanged += OnPasswordChanged;
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = txtPassword.SecurePassword;
        }
    }
}
