<%@ Page Title="" Language="C#" MasterPageFile="~/AnaSablon.Master" AutoEventWireup="true" CodeBehind="MarkaYonetimi.aspx.cs" 
    Inherits="UrunYonetimiStokTakip.WebFormUI.MarkaYonetimi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            height: 26px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1> Marka Yönetimi </h1>
        <asp:GridView ID="dgvMarkalar" runat="server" OnSelectedIndexChanged="dgvMarkalar_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
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
                <td class="auto-style3">Marka Adı : </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtMarkaAdi" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Marka Açıklaması : </td>
                <td>
                    <asp:TextBox ID="txtMarkaAciklamasi" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:CheckBox ID="cbDurum" runat="server" Text="Durum" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Eklenme Tarihi : </td>
                <td class="auto-style2">
                    <asp:Label ID="lblEklenmeTarihi" runat="server" Text="-"></asp:Label>
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
</asp:Content>
