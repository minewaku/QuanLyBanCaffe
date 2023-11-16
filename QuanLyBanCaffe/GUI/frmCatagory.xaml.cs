using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using QuanLyBanCaffe.LIB.Error;
using QuanLyBanCaffe.BLL.impl;
using QuanLyBanCaffe.BLL;
using QuanLyBanCaffe.DTO;

namespace QuanLyBanCaffe.GUI
{
    /// <summary>
    /// Interaction logic for frmCatagoryxaml.xaml
    /// </summary>
    public partial class frmCatagory : Page
    {
        ICatagoryBLL catagoryBll = new CatagoryBLL();

        public frmCatagory()
        {
            InitializeComponent();
            showList(catagoryBll.findAll());
        }

        private void showList(List<CatagoryDTO> list)
        {
            try
            {
                catagoryList.Columns.Clear();

                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("ID", typeof(long));
                dataTable.Columns.Add("Ten", typeof(string));
                dataTable.Columns.Add("hoat dong", typeof(bool));

                foreach (CatagoryDTO item in list)
                {
                    dataTable.Rows.Add(item.catagoryId, item.name, item.active);
                }

                catagoryList.ItemsSource = dataTable.DefaultView;
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
                        catagoryId_textBox.Text = rowSelected["ID"].ToString();
                        name_textBox.Text = rowSelected["Ten"].ToString();
                        active_checkBox.IsChecked = (bool)rowSelected["hoat dong"];
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
                    CatagoryDTO model = new CatagoryDTO();
                    model.name = name_textBox1.Text;
                  
                    if (catagoryBll.add(model) >= 1)
                    {
                        showList(catagoryBll.findAll());
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
                    CatagoryDTO model = new CatagoryDTO();

                    model.catagoryId = Int32.Parse(catagoryId_textBox.Text);
                    model.name = name_textBox.Text;
                    model.active = active_checkBox.IsChecked.Value;

                    if (catagoryBll.update(model) >= 1)
                    {
                        showList(catagoryBll.findAll());
                        System.Diagnostics.Debug.WriteLine("test");
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
                showList(catagoryBll.findLikeName(search_textBox.Text));
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
                long temp = long.Parse((catagoryId_textBox.Text).Trim());
            }
            catch
            {
                MessageBox.Show("catagoryId khong hop le");
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
