using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLBanSach.Models;

namespace QLBanSach
{
    public partial class QTSach : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
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
                            btn.OnClientClick = "return confirm('Bạn có chắc muốn xóa sách: " + tenSach + " (Mã: " + maSach + ") không?');";
                        }
                    }
                }
            }
        }

        protected void gvSach_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                // 1. Lấy mã sách từ DataKeys của dòng đang chọn
                int maSach = Convert.ToInt32(e.Keys["MaSach"]);

                // 2. Sử dụng SachDAO để xóa (tận dụng code bạn đã có)
                SachDAO dao = new SachDAO();
                Sach s = new Sach { MaSach = maSach };

                int result = dao.Delete(s); // Gọi hàm Delete trong SachDAO

                if (result > 0)
                {
                    // Xóa thành công -> Thông báo và nạp lại lưới
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Xóa sách thành công!');", true);
                    gvSach.DataBind(); // Cập nhật lại danh sách trên giao diện
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Xóa thất bại. Có thể sách không còn tồn tại.');", true);
                }

                // 3. Ngăn SqlDataSource tự động xóa (vì mình đã xóa thủ công rồi)
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Lỗi khi xóa: " + ex.Message + "');", true);
                e.Cancel = true;
            }
        }
    }
}