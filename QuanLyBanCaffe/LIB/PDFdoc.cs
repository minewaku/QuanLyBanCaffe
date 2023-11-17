using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iText;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using System.IO;
using iText.Layout;
using System.Windows;
using QuanLyBanCaffe.DTO;
using QuanLyBanCaffe.BLL;
using QuanLyBanCaffe.BLL.impl;

namespace QuanLyBanCaffe.LIB
{
    public class PDFdoc
    {
        IUserBLL userBLL = new UserBLL();

        public void PDFprint(BillDTO billDto)
        {
            string filePath = "./Bill/" + billDto.billId.ToString() + ".pdf";

            PdfWriter writer = new PdfWriter(filePath);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            try
            {
                document.Add(new iText.Layout.Element.Paragraph(PDFdoc.PDFtemplate(billDto)));
                document.Close();
                pdf.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                pdf.Close();
            }
        }

        public string PDFtemplate(BillDTO bill)
        {
            string content = String.Format("Mã hoá đơn :{0} \n", bill.billId.ToString());
            content += String.Format("Ngày lập :{0} \n", bill.createdDate.ToString());
            content += String.Format("Nhân viên: {0} - Mã số {1}\n", bill.userId, userBLL.findById(bill.userId));
            content += String.Format("       Sản phẩm        | Số lượng |         Đơn giá    | Thành tiền\n");
            content += String.Format("-----------------------|----------|--------------------|-----------\n");
            foreach (BillDetailsDTO item in bill.billDetails)
            {
                content += item.toprint();
            }
            content += String.Format("-----------------------|----------|--------------------|-----------\n");
            content += String.Format("                                            Thành tiền : {0}\n", this.total);
            content += String.Format("                                            Khách trả  : {0}\n", this.pay);
            content += String.Format("                                            Tiền thừa  : {0}\n", this.change);
            return content;
        }
    }
}
