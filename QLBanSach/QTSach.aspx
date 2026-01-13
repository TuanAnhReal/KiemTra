<%@ Page Title="QUẢN TRỊ SÁCH" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="QTSach.aspx.cs" Inherits="QLBanSach.QTSach" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NoiDung" runat="server">
    <h2>TRANG QUẢN TRỊ SÁCH</h2>
    <hr />
    <div class="row mb-2">
        <div class="col-md-6">
            <div class="form-inline">
                Tựa sách
                <asp:TextBox ID="txtTen" runat="server" placeholder="Nhập tựa sách cần tìm" CssClass="form-control ml-2" Width="300"></asp:TextBox>
                <asp:Button ID="btTraCuu" OnClick="btTraCuu_Click" runat="server" Text="Tra cứu" CssClass="btn btn-info ml-2" />
            </div>
            <asp:Label ID="lblThongBao" runat="server" Text=""></asp:Label>
        </div>
        <div class="col-md-6 text-right">
            <a href="#" class="btn btn-success">Thêm sách mới</a>
        </div>
    </div>

            <div class="text-center">

            <asp:GridView ID="gvSach" runat="server"
                        DataSourceID="dsSach"
                        DataKeyNames="MaSach"
                        AutoGenerateColumns="False"
                        AllowPaging="True"
                        PageSize="4"
                        OnRowDataBound="gvSach_RowDataBound" Width="1046px">

                <Columns>
                    <asp:BoundField DataField="TenSach" HeaderText="Tựa Sách" SortExpression="TenSach" />
                    <asp:TemplateField HeaderText="Ảnh bìa">
                        <ItemTemplate>
                            <img src="<%# "Bia_sach/" + Eval("Hinh") %>" width="150" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Dongia" HeaderText="Đơn giá" SortExpression="Dongia" />

                    <asp:TemplateField HeaderText="Khuyến mãi">
                        <ItemTemplate>
                            <%# (bool)Eval("KhuyenMai") ? "x" : "" %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkKM" runat="server"
                                Checked='<%# Bind("KhuyenMai") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:CommandField ButtonType="Button" HeaderText="Chọn thao tác"
                        ShowDeleteButton="True" DeleteText="Xóa"
                        ShowEditButton="True" EditText="Sửa" ShowHeader="True" />
                </Columns>

                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />

            </asp:GridView>

    </div>

    <asp:SqlDataSource ID="dsSach" runat="server"
        ConnectionString="<%$ ConnectionStrings:BanSachDBConn %>"
        SelectCommand="SELECT * FROM Sach"
        DeleteCommand="DELETE FROM Sach WHERE MaSach=@MaSach">
        <DeleteParameters>
            <asp:Parameter Name="MaSach" Type="Int32" />
        </DeleteParameters>
    </asp:SqlDataSource>

</asp:Content>
