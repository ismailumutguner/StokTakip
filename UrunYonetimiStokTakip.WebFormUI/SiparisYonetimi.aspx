<%@ Page Title="" Language="C#" MasterPageFile="~/AnaSablon.Master" AutoEventWireup="true" 
    CodeBehind="SiparisYonetimi.aspx.cs" Inherits="UrunYonetimiStokTakip.WebFormUI.SiparisYonetimi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Sipariş Yönetimi</h1>

    <asp:GridView ID="dgvSiparisler" runat="server" OnSelectedIndexChanged="dgvSiparisler_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
            <Columns>
                <asp:CommandField CancelText="İptal" DeleteText="Sil" EditText="Düzenle" SelectText="Seç" ShowSelectButton="True" />
            </Columns>

            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    <hr />
    <div>

        <table class="auto-style1">
            <tr>
                <td>Sipariş No : </td>
                <td>
                    <asp:TextBox ID="txtSiparisNo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Müşteri : </td>
                <td>
                    <asp:DropDownList ID="cbMusteriler" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Ürün : </td>
                <td>
                    <asp:DropDownList ID="cbUrunler" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Sipariş Tarihi : </td>
                <td>
                    <asp:Calendar ID="dtpSiparisTarihi" runat="server"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblId" runat="server" Text="0"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnEkle" runat="server" OnClick="btnEkle_Click" Text="Ekle" />
                    <asp:Button ID="btnGuncelle" runat="server" OnClick="btnGuncelle_Click" Text="Güncelle" />
                    <asp:Button ID="btnSil" runat="server" OnClick="btnSil_Click" Text="Sil" />
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
