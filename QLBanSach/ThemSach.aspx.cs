using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLBanSach.Models;

namespace QLBanSach
{
    public partial class ThemSach : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btXuLy_Click(object sender, EventArgs e)
        {
            try
            {
                string tenHinh = "no_image.jpg";
                if (FHinh.HasFile)
                {
                    tenHinh = FHinh.FileName;
                    string path = Server.MapPath("~/Bia_sach/" + tenHinh);
                    FHinh.SaveAs(path);
                }

                Sach s = new Sach();
                s.TenSach = txtTen.Text;
                s.Dongia = int.Parse(txtDonGia.Text);
                s.MaCD = int.Parse(ddlChuDe.SelectedValue);
                s.Hinh = tenHinh;
                s.KhuyenMai = chkKhuyenMai.Checked;
                s.NgayCapNhat = DateTime.Now;

                SachDAO dao = new SachDAO();
                int ketqua = dao.Insert(s);

                if (ketqua > 0)
                {
                    lblThongBao.Text = "Thêm sách thành công!";
                    lblThongBao.ForeColor = System.Drawing.Color.Green;

                    txtTen.Text = "";
                    txtDonGia.Text = "";
                }
                else
                {
                    lblThongBao.Text = "Thêm thất bại, vui lòng thử lại.";
                    lblThongBao.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblThongBao.Text = "Lỗi: " + ex.Message;
                lblThongBao.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}