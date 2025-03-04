using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryMS.View
{
    /// <summary>
    /// Interaction logic for UserManageUserControl.xaml
    /// </summary>
    public partial class UserManageUserControl : UserControl
    {
        public ObservableCollection<User> Users { get; set; }
        public UserManageUserControl()
        {
            InitializeComponent();

            // Sample user list
            Users = new ObservableCollection<User>
            {
                new User { Username = "admin", Role = "Admin" },
                new User { Username = "john_doe", Role = "Manager" },
                new User { Username = "staff_member", Role = "Staff" }
            };

            UserGrid.ItemsSource = Users; // Bind DataGrid to Users list
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password; // Store securely in real apps!
            string role = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(role))
            {
                Users.Add(new User { Username = username, Role = role });
                ClearForm();
            }
            else
            {
                MessageBox.Show("Please enter a username and select a role.");
            }
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            if (UserGrid.SelectedItem is User selectedUser)
            {
                UsernameTextBox.Text = selectedUser.Username;
                RoleComboBox.SelectedItem = RoleComboBox.ItemsSource; // Match role
            }
        }

        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            if (UserGrid.SelectedItem is User selectedUser)
            {
                selectedUser.Username = UsernameTextBox.Text;
                selectedUser.Role = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

                UserGrid.Items.Refresh(); // Refresh UI
                ClearForm();
            }
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (UserGrid.SelectedItem is User selectedUser)
            {
                Users.Remove(selectedUser);
            }
        }

        private void ClearForm()
        {
            UsernameTextBox.Clear();
            PasswordBox.Clear();
            RoleComboBox.SelectedIndex = -1;
        }


    }
    public class User
    {
        public string Username { get; set; }
        public string Role { get; set; }
    }

}
