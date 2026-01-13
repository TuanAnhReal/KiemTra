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
            dsSach.SelectCommand =
                "SELECT * FROM Sach WHERE TenSach LIKE N'%' + @ten + '%'";
            dsSach.SelectParameters.Clear();
            dsSach.SelectParameters.Add("ten", txtTen.Text.Trim());
            gvSach.DataBind();

            if (gvSach.Rows.Count == 0)
                lblThongBao.Text = "Tìm kiếm không có kết quả nào";
            else
                lblThongBao.Text = "";
        }

        protected void gvSach_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (Control c in e.Row.Cells[e.Row.Cells.Count - 1].Controls)
                {
                    if (c is Button btn && btn.CommandName == "Delete")
                    {
                        btn.OnClientClick =
                            "return confirm('Bạn có chắc muốn xoá sách này không?');";
                    }
                }
            }
        }


        // XÓA SÁCH
        protected void gvSach_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int maSach = Convert.ToInt32(gvSach.DataKeys[e.RowIndex].Value);

            dsSach.DeleteCommand = "DELETE FROM Sach WHERE MaSach=@MaSach";
            dsSach.DeleteParameters.Clear();
            dsSach.DeleteParameters.Add("MaSach", maSach.ToString());

            dsSach.Delete();
        }

    }
}