using iText.Layout.Element;
using QuanLyBanCaffe.BLL;
using QuanLyBanCaffe.BLL.impl;
using QuanLyBanCaffe.DTO;
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
    /// Interaction logic for frmBill.xaml
    /// </summary>
    public partial class frmBill : Page
    {
        IBillBLL billBLL = new BillBLL();
        IBillDetailsBLL billDetailsBLL = new BillDetailsBLL();
        IUserBLL userBLL = new UserBLL();
        IProductBLL productBLL = new ProductBLL();
        ITableBLL tableBLL = new TableBLL();
        List<string> status = new List<string> {"PENDING", "PAID", "CANCELLED"};

        public frmBill()
        {
            InitializeComponent();
            showBillList(billBLL.findAll());
        }

        public void showBillList(List<BillDTO> list)
        {
            try
            {
                billList.Columns.Clear();

                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("ID", typeof(long));
                dataTable.Columns.Add("user", typeof(string));
                dataTable.Columns.Add("table", typeof(string));
                dataTable.Columns.Add("quantity", typeof(int));
                dataTable.Columns.Add("total", typeof(decimal));
                dataTable.Columns.Add("discount", typeof(int));
                dataTable.Columns.Add("final", typeof(decimal));
                dataTable.Columns.Add("createdDate", typeof(DateTime));
                dataTable.Columns.Add("status", typeof(string));

                foreach (BillDTO item in list)
                {
                    dataTable.Rows.Add(item.billId, userBLL.findById(item.userId).username, tableBLL.findById(item.tableId).name, item.quantity, item.total, item.discount, item.final, item.createdDate, item.status);
                }

                billList.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void showBillDetailsList(long id)
        {
            try
            {
                billDetailsList.Columns.Clear();

                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("name", typeof(string));
                dataTable.Columns.Add("quantity", typeof(int));
                dataTable.Columns.Add("total", typeof(decimal));

                List<BillDetailsDTO> list = billDetailsBLL.findByBillId(id);

                if (list != null)
                {
                    foreach (BillDetailsDTO item in list)
                    {
                        dataTable.Rows.Add(productBLL.findById(item.productId).name, item.quantity, item.total);
                    }
                }

                billDetailsList.ItemsSource = dataTable.DefaultView;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void billList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if ((DataGrid)sender != null)
                {
                    DataGrid dg = (DataGrid)sender;
                    DataRowView rowSelected = dg.SelectedItem as DataRowView;
                    if (rowSelected != null && rowSelected["ID"].ToString() != null)
                    {
                        showBillDetailsList(long.Parse(rowSelected["ID"].ToString()));

                        BillDTO model = billBLL.findById((long.Parse(rowSelected["ID"].ToString())));

                        billId_textBox.Text = rowSelected["ID"].ToString();
                        staffName_textBox.Text = rowSelected["user"].ToString();
                        tableName_textBox.Text = rowSelected["table"].ToString();
                        quantity_textBox.Text = rowSelected["quantity"].ToString();
                        createdDate_textBox.Text = rowSelected["createdDate"].ToString();
                        status_textBox.Text = rowSelected["status"].ToString();

                        total_textBox.Text = rowSelected["total"].ToString();
                        discount_textBox.Text = rowSelected["discount"].ToString();
                        final_textBox.Text = rowSelected["final"].ToString();
                        receive_textBox.Text = model.receive.ToString();
                        change_textBox.Text = model.change.ToString();
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
                List<BillDTO> list = billBLL.findLikeUserName(search_textBox.Text);

                if (start_datePicker.SelectedDate != null && end_datePicker.SelectedDate != null)
                {
                    List<BillDTO> result = new List<BillDTO>();
                    billBLL.findByRange((DateTime)start_datePicker.SelectedDate, (DateTime)end_datePicker.SelectedDate);

                    foreach (BillDTO item in result)
                    {
                        if ((DateTime)start_datePicker.SelectedDate <= item.createdDate && (DateTime)end_datePicker.SelectedDate >= item.createdDate)
                        {
                            result.Add(item);
                        }
                    }

                    showBillList(result);
                }
                else
                {
                    showBillList(list);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
