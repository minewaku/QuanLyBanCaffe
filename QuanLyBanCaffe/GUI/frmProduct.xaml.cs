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
using QuanLyBanCaffe.LIB.Error;

namespace QuanLyBanCaffe.GUI
{
    /// <summary>
    /// Interaction logic for frmProduct.xaml
    /// </summary>
    public partial class frmProduct : Page
    {
        IProductBLL productBll = new ProductBLL();
        ICatagoryBLL catagoryBll = new CatagoryBLL();

        public static List<ProductDTO> prList;

        public frmProduct()
        {
            InitializeComponent();
            prList = productBll.findAll();
            loadCatagoryCb(catagoryBll.findAll(), "");
            loadCatagoryCb1(catagoryBll.findAll(), "");
            showList(productBll.findAll());
        }

        public void showList(List<ProductDTO> list)
        {
            try
            {
                productList.Columns.Clear();

                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("ID", typeof(long));
                dataTable.Columns.Add("Ten", typeof(string));
                dataTable.Columns.Add("Loai", typeof(string));
                dataTable.Columns.Add("Gia", typeof(decimal));
                dataTable.Columns.Add("So luong", typeof(int));
                dataTable.Columns.Add("Da ban", typeof(int));
                dataTable.Columns.Add("hoat dong", typeof(bool));

                foreach (ProductDTO item in list)
                {
                    dataTable.Rows.Add(item.productId, item.name, catagoryBll.findById(item.catagoryId).name, item.price, item.quantity, item.sold, item.active);
                }

                productList.ItemsSource = dataTable.DefaultView;
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadCatagoryCb(List<CatagoryDTO> list, String selectedItem)
        {
            try
            {
                ObservableCollection<string> values = new ObservableCollection<string>();
                foreach(CatagoryDTO item in list)
                {
                    values.Add(item.name);
                }
                catagory_comboBox.ItemsSource = values;
                catagory_comboBox.SelectedItem = selectedItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadCatagoryCb1(List<CatagoryDTO> list, String selectedItem)
        {
            try
            {
                ObservableCollection<string> values = new ObservableCollection<string>();
                foreach (CatagoryDTO item in list)
                {
                    values.Add(item.name);
                }
                catagory_comboBox1.ItemsSource = values;
                catagory_comboBox1.SelectedItem = selectedItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void productList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   try
            {
                if ((DataGrid)sender != null)
                {
                    DataGrid dg = (DataGrid)sender;
                    DataRowView rowSelected = dg.SelectedItem as DataRowView;
                    if (rowSelected != null)
                    {
                        productId_textBox.Text = rowSelected["ID"].ToString();
                        name_textBox.Text = rowSelected["Ten"].ToString();
                        loadCatagoryCb(catagoryBll.findAll(), rowSelected["Loai"].ToString());
                        price_textBox.Text = rowSelected["Gia"].ToString();
                        quantity_textBox.Text = rowSelected["So luong"].ToString();
                        sold_textBox.Text = rowSelected["Da ban"].ToString();
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
                if(checkValidForAdd())
                {
                    ProductDTO model = new ProductDTO();
                    model.name = name_textBox1.Text;
                    model.catagoryId = (catagoryBll.findByName(catagory_comboBox1.SelectedItem.ToString())).catagoryId;
                    model.price = Decimal.Parse(price_textBox1.Text);
                    model.quantity = Int32.Parse(quantity_textBox1.Text);
 
                    if(productBll.add(model) >= 1)
                    {
                        showList(productBll.findAll());
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
                    ProductDTO model = new ProductDTO();

                    model.productId = Int32.Parse(productId_textBox.Text);
                    model.name = name_textBox.Text;
                    model.catagoryId = (catagoryBll.findByName(catagory_comboBox.SelectedItem.ToString())).catagoryId;
                    model.price = Decimal.Parse(price_textBox.Text);
                    model.quantity = Int32.Parse(quantity_textBox.Text);
                    model.active = active_checkBox.IsChecked.Value;

                    if (productBll.update(model) >= 1)
                    {
                        showList(productBll.findAll());
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
                showList(productBll.findLikeName(search_textBox.Text));
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
                long temp = long.Parse((productId_textBox.Text).Trim());
            } catch {
                MessageBox.Show("productId khong hop le");
                return false;
            }

            if(catagory_comboBox.SelectedItem == null) 
            {
                MessageBox.Show("Loai khong hop le");
                return false;
            }

            try
            {
                decimal temp = Decimal.Parse(price_textBox.Text);
            } catch {
                MessageBox.Show("Gia tien khong hop le");
                return false;
            }

            try
            {
                int temp = Int32.Parse(quantity_textBox.Text);
            }
            catch
            {
                MessageBox.Show("So luong khong hop le");
                return false;
            }

            return true;
        }

        private bool checkValidForAdd()
        {
            if (catagory_comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Loai khong hop le");
                return false;
            }

            try
            {
                decimal temp = Decimal.Parse(price_textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Gia tien khong hop le");
                return false;
            }

            try
            {
                int temp = Int32.Parse(quantity_textBox1.Text);
            }
            catch
            {
                MessageBox.Show("So luong khong hop le");
                return false;
            }

            return true;
        }
    }
}
