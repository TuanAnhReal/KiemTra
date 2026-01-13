<%@ Page Title="QUẢN TRỊ SÁCH" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="QTSach.aspx.cs" Inherits="QLBanSach.QTSach" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NoiDung" runat="server">
    <h2 class="text-center mt-3">TRANG QUẢN TRỊ SÁCH</h2>
    <hr />
    
    <div class="row mb-2">
        <div class="col-md-6 form-inline">
            Tựa sách: 
            <asp:TextBox ID="txtTen" runat="server" CssClass="form-control ml-2 mr-2" placeholder="Nhập tên sách..."></asp:TextBox>
            <asp:Button ID="btTraCuu" runat="server" Text="Tra cứu" CssClass="btn btn-primary" OnClick="btTraCuu_Click" />
        </div>
        <div class="col-md-6 text-right">
            <a href="ThemSach.aspx" class="btn btn-success">Thêm sách mới</a>
        </div>
    </div>

    <asp:GridView ID="gvSach" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="MaSach" DataSourceID="dsSach" AllowPaging="True" PageSize="4"
        CssClass="table table-bordered table-hover" OnRowDataBound="gvSach_RowDataBound">
        <Columns>
            <asp:BoundField DataField="TenSach" HeaderText="Tựa sách" SortExpression="TenSach" />
            
            <asp:TemplateField HeaderText="Ảnh bìa">
                <ItemTemplate>
                    <img src='<%# "Bia_sach/" + Eval("Hinh") %>' width="80" />
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:BoundField DataField="Dongia" HeaderText="Đơn giá" DataFormatString="{0:#,##0} VNĐ" />
            
            <asp:TemplateField HeaderText="Khuyến mãi">
                <ItemTemplate>
                    <%# (bool)Eval("KhuyenMai") ? "x" : "" %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:CheckBox ID="chkKM" runat="server" Checked='<%# Bind("KhuyenMai") %>' />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" 
                ButtonType="Button" HeaderText="Chọn thao tác" 
                EditText="Sửa" DeleteText="Xóa" UpdateText="Ghi" CancelText="Không" />
        </Columns>
        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
    </asp:GridView>

    <asp:SqlDataSource ID="dsSach" runat="server" 
        ConnectionString="<%$ ConnectionStrings:BanSachDBConn %>" 
        SelectCommand="SELECT * FROM [Sach]" 
        DeleteCommand="DELETE FROM Sach WHERE MaSach=@MaSach"
        UpdateCommand="UPDATE [Sach] SET [TenSach] = @TenSach, [Dongia] = @Dongia, [KhuyenMai] = @KhuyenMai WHERE [MaSach] = @MaSach">
        <DeleteParameters>
            <asp:Parameter Name="MaSach" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="TenSach" Type="String" />
            <asp:Parameter Name="Dongia" Type="Int32" />
            <asp:Parameter Name="KhuyenMai" Type="Boolean" />
            <asp:Parameter Name="MaSach" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

</asp:Content>
