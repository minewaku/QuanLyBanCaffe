using QuanLyBanCaffe.BLL.impl;
using QuanLyBanCaffe.BLL;
using QuanLyBanCaffe.DTO;
using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;

namespace QuanLyBanCaffe.GUI
{
    /// <summary>
    /// Interaction logic for frmTable.xaml
    /// </summary>
    public partial class frmTable : Page
    {

        ITableBLL tableBll = new TableBLL();

        List<string> status = new List<string> { "EMPTY", "FULL" };

        public frmTable()
        {
            InitializeComponent();
            showList(tableBll.findAll());
            loadStatusCb(status, "");
            loadStatusCb1(status);
        }

        private void showList(List<TableDTO> list)
        {
            try
            {
                tableList.Columns.Clear();

                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("ID", typeof(long));
                dataTable.Columns.Add("Name", typeof(string));
                dataTable.Columns.Add("Status", typeof(string));
                dataTable.Columns.Add("Active", typeof(bool));

                foreach (TableDTO item in list)
                {
                    dataTable.Rows.Add(item.tableId, item.name, item.status, item.active);
                }

                tableList.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadStatusCb(List<String> list, String selectedItem)
        {
            try
            {
                ObservableCollection<string> values = new ObservableCollection<string>();
                foreach (string item in list)
                {
                    values.Add(item);
                }
                status_comboBox.ItemsSource = values;
                status_comboBox.SelectedItem = selectedItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadStatusCb1(List<String> list)
        {
            try
            {
                ObservableCollection<string> values = new ObservableCollection<string>();

                values.Add("");
                foreach (string item in list)
                {
                    values.Add(item);
                }
                status_comboBox1.ItemsSource = values;
                status_comboBox1.SelectedItem = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void catogoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if ((DataGrid)sender != null)
                {
                    DataGrid dg = (DataGrid)sender;
                    DataRowView rowSelected = dg.SelectedItem as DataRowView;
                    if (rowSelected != null)
                    {
                        tableId_textBox.Text = rowSelected["ID"].ToString();
                        name_textBox.Text = rowSelected["Name"].ToString();
                        status_comboBox.SelectedItem = rowSelected["Status"].ToString();
                        active_checkBox.IsChecked = (bool)rowSelected["Active"];
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
                    TableDTO model = new TableDTO();
                    model.name = name_textBox1.Text;

                    if (tableBll.add(model) >= 1)
                    {
                        showList(tableBll.findAll());
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
                    TableDTO model = new TableDTO();

                    model.tableId = Int32.Parse(tableId_textBox.Text);
                    model.name = name_textBox.Text;
                    model.active = active_checkBox.IsChecked.Value;

                    if (tableBll.update(model) >= 1)
                    {
                        showList(tableBll.findAll());
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
            if (status_comboBox1.SelectedItem == "")
            {
                showList(tableBll.findLikeName(search_textBox.Text));
            }
            else
            {
                List<TableDTO> list = tableBll.findLikeName(search_textBox.Text);
                List<TableDTO> result = new List<TableDTO>();

                foreach (TableDTO item in list)
                {
                    if (item.status == status_comboBox1.SelectedItem.ToString())
                    {
                        result.Add(item);
                    }
                }

                showList(result);
            }
        }

        private bool checkValidForUpdate()
        {
            try
            {
                long temp = long.Parse((tableId_textBox.Text).Trim());
            }
            catch
            {
                MessageBox.Show("tableId khong hop le");
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
