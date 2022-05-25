<%@ Page Title="" Language="C#" MasterPageFile="~/AnaSablon.Master" AutoEventWireup="true" 
    CodeBehind="MusteriYonetimi.aspx.cs" Inherits="UrunYonetimiStokTakip.WebFormUI.MusteriYonetimi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Müşteri Yönetimi</h1>
    <div>
        <asp:TextBox ID="txtAra" runat="server"></asp:TextBox>
        <asp:Button ID="btnAra" runat="server" OnClick="btnAra_Click" Text="Ara" ValidationGroup="ara" />
    </div>
        <asp:GridView ID="dgvMusteriler" runat="server" OnSelectedIndexChanged="dgvMusteriler_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
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
        <table class="auto-style1">
            <tr>
                <td>Adı * : </td>
                <td>
                    <asp:TextBox ID="txtAdi" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Soyadı * : </td>
                <td>
                    <asp:TextBox ID="txtSoyadi" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>E-mail : </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Telefon : </td>
                <td>
                    <asp:TextBox ID="txtTelefon" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Adres : </td>
                <td>
                    <asp:TextBox ID="txtAdres" runat="server" TextMode="MultiLine"></asp:TextBox>
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
    <br />
</asp:Content>
