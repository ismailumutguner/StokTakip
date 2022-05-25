<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UrunYonetimiStokTakip.WebFormUI.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #menu { 
            display: flex;
            align-content: space-around;
            justify-content: space-around;
            align-items: center;
            list-style: none;
        }
        #menu li:hover {
            background-color: #F7F6F3;
        }
        #menu a {
            color: black;
            text-decoration: none;
            padding: 1rem 2rem;
        }
        #menu a:hover {
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ul id="menu">
                <li><a href="Default.aspx">Giriş</a></li>
                <li><a href="/KategoriYonetimi.aspx">Kategori Yönetimi</a></li>
                <li><a href="/KullaniciYonetimi.aspx">Kullanıcı Yönetimi</a></li>
                <li><a href="/MarkaYonetimi.aspx">Marka Yönetimi</a></li>
                <li><a href="/MusteriYonetimi.aspx"></a>Müşteri Yönetimi</li>                
                <li><a href="SiparisYonetimi.aspx"></a>Sipariş Yönetimi</li>                
                <li><a href="#"></a>Ürün Yönetimi</li>                
                <li><a href="#">Çıkış</a></li>
            </ul>
            <hr />
        </div>
    </form>
</body>
</html>
