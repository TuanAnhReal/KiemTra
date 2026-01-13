<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="ThemSach.aspx.cs" Inherits="QLBanSach.ThemSach" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NoiDung" runat="server">
    <h2>THÊM SÁCH MỚI</h2>
    <hr />
    <div class="w-100">

        <div class="form-group">
            <label class="font-weight-bold">Tên sách</label>
            <asp:TextBox ID="txtTen" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTen" runat="server" ControlToValidate="txtTen" 
                ErrorMessage="Tên sách không được để trống" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        
        <div class="form-group">
            <label class="font-weight-bold">Đơn giá</label>
            <asp:TextBox ID="txtDonGia" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvGia" runat="server" ControlToValidate="txtDonGia" 
                ErrorMessage="Đơn giá không được để trống" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvGia" runat="server" ControlToValidate="txtDonGia" 
                Operator="DataTypeCheck" Type="Integer" ErrorMessage="Đơn giá phải là số" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
        </div>
        
        <div class="form-group">
            <label class="font-weight-bold">Chủ đề</label>
            <asp:DropDownList ID="ddlChuDe" runat="server" CssClass="form-control" 
                DataSourceID="dsChuDe" DataTextField="TenCD" DataValueField="MaCD">
            </asp:DropDownList>
        </div>
        
        <div class="form-group">
            <label class="font-weight-bold">Ảnh bìa sách</label>
            <asp:FileUpload ID="FHinh" runat="server" CssClass="form-control-file" />
        </div>
        
        <div class="form-group form-check">
            <asp:CheckBox ID="chkKhuyenMai" runat="server" Checked="true" CssClass="form-check-input" />
            <label class="form-check-label font-weight-bold">Khuyến mãi</label>
        </div>
        
        <div class="form-group text-center">
            <asp:Button ID="btXuLy" runat="server" Text="Lưu" CssClass="btn btn-success pl-4 pr-4" OnClick="btXuLy_Click" />
            <asp:Label ID="lblThongBao" runat="server" Text="" CssClass="d-block mt-2"></asp:Label>
        </div>

    </div>
    <br />

    <asp:SqlDataSource ID="dsChuDe" runat="server" ConnectionString="<%$ ConnectionStrings:BanSachDBConn %>" SelectCommand="SELECT * FROM [ChuDe]"></asp:SqlDataSource>
</asp:Content>
