using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLBanSach
{
    public partial class QTSach : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btTraCuu_Click(object sender, EventArgs e)
        {
            if (txtTen.Text.Trim() != null)
            {
                dsSach.SelectCommand = "SELECT * FROM [Sach] WHERE [TenSach] LIKE N'%" + txtTen.Text.Trim() + "%'";
            }
            else
            {
                dsSach.SelectCommand = "SELECT * FROM [Sach]";
            }
        }

        protected void gvSach_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var drv = e.Row.DataItem as System.Data.DataRowView;
                if (drv != null)
                {
                    string maSach = drv["MaSach"].ToString();
                    string tenSach = drv["TenSach"].ToString();

                    foreach (Control c in e.Row.Cells[e.Row.Cells.Count - 1].Controls)
                    {
                        if (c is Button btn && btn.CommandName == "Delete")
                        {
                            //btn.CausesValidation = false;
                            btn.OnClientClick = "return confirm('Bạn có chắc muốn xóa sách: " + tenSach + " (Mã: " + maSach + ") không?');";
                        }
                    }
                }
            }
        }

        protected void dsSach_Deleted(object sender, SqlDataSourceStatusEventArgs e)
        {
            string thongBao = "";

            if (e.Exception != null)
            {
                // Nếu có lỗi từ SQL (ví dụ: lỗi khóa ngoại)
                thongBao = "alert('Lỗi khi xóa: " + e.Exception.Message + "');";
                e.ExceptionHandled = true; // Báo đã xử lý lỗi để chương trình không bị dừng
            }
            else if (e.AffectedRows == 0)
            {
                // Nếu chạy lệnh xóa nhưng không có dòng nào bị xóa
                thongBao = "alert('Xóa thất bại! Không tìm thấy Mã sách này.');";
            }
            else
            {
                // Xóa thành công
                thongBao = "alert('Đã xóa sách thành công!');";
            }

            // Đăng ký đoạn script javascript để chạy ngay khi trang tải xong
            ClientScript.RegisterStartupScript(this.GetType(), "ThongBao", thongBao, true);
        }
    }
}