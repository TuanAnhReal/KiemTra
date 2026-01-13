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
                // Tìm nút Xóa ở cột cuối cùng (index có thể thay đổi tùy số cột)
                // Duyệt qua các control trong cell cuối để tìm nút Delete
                foreach (Control c in e.Row.Cells[e.Row.Cells.Count - 1].Controls)
                {
                    if (c is Button btn && btn.CommandName == "Delete")
                    {
                        btn.OnClientClick = "return confirm('Bạn có chắc chắn muốn xóa sách này không?');";
                    }
                }
            }
        }

        protected void dsSach_Deleted(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                // Hiển thị lỗi ra màn hình để biết nguyên nhân
                Response.Write("<script>alert('Lỗi khi xóa: " + e.Exception.Message + "');</script>");
                e.ExceptionHandled = true; // Báo đã xử lý lỗi để không bị vàng trang
            }
            else if (e.AffectedRows == 0)
            {
                Response.Write("<script>alert('Không xóa được dòng nào. Kiểm tra lại MaSach!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Xóa thành công!');</script>");
            }
        }
    }
}