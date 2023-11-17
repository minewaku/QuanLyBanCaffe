using QuanLyBanCaffe.BLL.impl;
using QuanLyBanCaffe.BLL;
using QuanLyBanCaffe.DTO;
using QuanLyBanCaffe.LIB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace QuanLyBanCaffe.GUI
{
    /// <summary>
    /// Interaction logic for frmUser.xaml
    /// </summary>
    public partial class frmUser : Page
    {
        IUserBLL userBll = new UserBLL();

        List<string> roles = new List<string> { "STAFF", "ADMIN" };

        public frmUser()
        {
            InitializeComponent(); ;
            loadRoleCb(roles, "");
            loadRoleCb1(roles);
            showList(userBll.findAll());
        }

        public void showList(List<UserDTO> list)
        {
            try
            {
                userList.Columns.Clear();

                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("ID", typeof(long));
                dataTable.Columns.Add("email", typeof(string));
                dataTable.Columns.Add("username", typeof(string));
                dataTable.Columns.Add("password", typeof(string));
                dataTable.Columns.Add("phone", typeof(string));
                dataTable.Columns.Add("address", typeof(string));
                dataTable.Columns.Add("role", typeof(string));
                dataTable.Columns.Add("active", typeof(bool));

                foreach (UserDTO item in list)
                {
                    dataTable.Rows.Add(item.userId, item.email, item.username, item.password, item.phone, item.address, item.role, item.active);
                }

                userList.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadRoleCb(List<String> list, String selectedItem)
        {
            try
            {
                ObservableCollection<string> values = new ObservableCollection<string>();
                foreach (string item in list)
                {
                    values.Add(item);
                }
                role_comboBox.ItemsSource = values;
                role_comboBox.SelectedItem = selectedItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadRoleCb1(List<String> list)
        {
            try
            {
                ObservableCollection<string> values = new ObservableCollection<string>();

                values.Add("");
                foreach (string item in list)
                {
                    values.Add(item);
                }
                role_comboBox1.ItemsSource = values;
                role_comboBox1.SelectedItem = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void userList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if ((DataGrid)sender != null)
                {
                    DataGrid dg = (DataGrid)sender;
                    DataRowView rowSelected = dg.SelectedItem as DataRowView;
                    if (rowSelected != null)
                    {
                        userId_textBox.Text = rowSelected["ID"].ToString();
                        email_textBox.Text = rowSelected["email"].ToString();
                        username_textBox.Text = rowSelected["username"].ToString();
                        loadRoleCb(roles,  rowSelected["role"].ToString());
                        password_textBox.Text = rowSelected["password"].ToString();
                        phone_textBox.Text = rowSelected["phone"].ToString();
                        address_textBox.Text = rowSelected["address"].ToString();
                        active_checkBox.IsChecked = (bool)rowSelected["active"];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Add_Click(Object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkValidForAdd())
                {
                    UserDTO model = new UserDTO();

                    model.email = email_textBox1.Text;
                    model.username = username_textBox1.Text;
                    model.password = password_textBox1.Text;
                    model.phone = phone_textBox1.Text;
                    model.address = address_textBox1.Text;

                    if (userBll.add(model) >= 1)
                    {
                        showList(userBll.findAll());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkValidForUpdate())
                {
                    UserDTO model = new UserDTO();

                    model.userId = long.Parse(userId_textBox.Text);
                    model.email = email_textBox.Text;
                    model.username = username_textBox.Text;
                    model.role = role_comboBox.SelectedItem.ToString();
                    model.password = password_textBox.Text;
                    model.phone = phone_textBox.Text;
                    model.address = address_textBox.Text;
                    model.active = active_checkBox.IsChecked.Value;

                    if (userBll.update(model) >= 1)
                    {
                        showList(userBll.findAll());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (role_comboBox1.SelectedItem == "")
                {
                    showList(userBll.findLikeName(search_textBox.Text));
                }
                else
                {
                    List<UserDTO> list = userBll.findLikeName(search_textBox.Text);
                    List<UserDTO> result = new List<UserDTO>();

                    foreach (UserDTO item in list)
                    {
                        if (item.role == role_comboBox1.SelectedItem.ToString())
                        {
                            result.Add(item);
                        }
                    }

                    showList(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private bool checkValidForUpdate()
        {
            try
            {
                long temp = long.Parse((userId_textBox.Text).Trim());
            }
            catch
            {
                MessageBox.Show("userId khong hop le");
                return false;
            }

            if (role_comboBox.SelectedItem == null || role_comboBox.SelectedItem == "")
            {
                MessageBox.Show("Quyen khong hop le");
                return false;
            }

            return true;
        }

        private bool checkValidForAdd()
        {
            return true;
        }
    }
}
