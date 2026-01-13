<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="XemSach.aspx.cs" Inherits="QLBanSach.XemSach" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NoiDung" runat="server">
    <h3>Trang xem sách</h3>
    <hr />
    <div class="alert alert-info">
         <div class="form-inline justify-content-center">
              <label class="font-weight-bold">Chủ đề</label>
             <asp:DropDownList ID="ddlChuDe" CssClass="form-control ml-2" runat="server" AutoPostBack="True" ></asp:DropDownList>
         </div>
    </div>   
    <div class="row mt-2">
               <div class="col-md-4">
                    <div class="card mb-2">
                        <div class="card-header">
                            <img class="img-fluid" src='Bia_sach/pic01.jpg' alt="Card image cap" />
                        </div>
                        <div class="card-body">
                            Tên sách :<span class="font-weight-bold"> Lập trình C# </span>
                            <br />
                             Giá bán: <span class="price"> 105,000 VNĐ </span>
                                
                            <br />
                        </div>
                        <div class="card-footer text-center">
                            <a href="#" class="btn btn-success mr-3">Xem chi tiết</a>
                            <a href="#" class="btn btn-info">Đặt mua</a>
                        </div>
                    </div>
                </div>            
    </div>
    
</asp:Content>
