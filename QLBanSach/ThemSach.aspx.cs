using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLBanSach.Models; // Sử dụng Namespace chứa SachDAO

namespace QLBanSach
{
    public partial class ThemSach : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Không cần xử lý gì khi load trang vì DropDownList đã tự động bind dữ liệu từ SqlDataSource
        }

        protected void btXuLy_Click(object sender, EventArgs e)
        {
            // Kiểm tra lại Validation phía server để đảm bảo an toàn
            if (!Page.IsValid) return;

            try
            {
                // 1. Xử lý Upload hình
                string tenHinh = "";
                if (FHinh.HasFile)
                {
                    tenHinh = FHinh.FileName;
                    // Lưu hình vào thư mục Bia_sach trong project
                    string path = Server.MapPath("~/Bia_sach/" + tenHinh);
                    FHinh.SaveAs(path);
                }

                // 2. Tạo đối tượng Sách
                Sach s = new Sach();
                s.TenSach = txtTen.Text;
                s.Dongia = int.Parse(txtDonGia.Text);
                s.MaCD = int.Parse(ddlChuDe.SelectedValue);
                s.Hinh = tenHinh;
                s.KhuyenMai = chkKhuyenMai.Checked;
                s.NgayCapNhat = DateTime.Now; // Ngày hiện hành

                // 3. Gọi DAO để insert
                SachDAO dao = new SachDAO();
                int ketqua = dao.Insert(s);

                // 4. Thông báo kết quả
                if (ketqua > 0)
                {
                    lblThongBao.Text = "Thêm sách thành công!";
                    lblThongBao.ForeColor = System.Drawing.Color.Green;

                    // Xóa trắng form để nhập tiếp
                    txtTen.Text = "";
                    txtDonGia.Text = "";
                    txtTen.Focus();
                }
                else
                {
                    lblThongBao.Text = "Thêm thất bại. Vui lòng thử lại.";
                    lblThongBao.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblThongBao.Text = "Lỗi hệ thống: " + ex.Message;
                lblThongBao.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}