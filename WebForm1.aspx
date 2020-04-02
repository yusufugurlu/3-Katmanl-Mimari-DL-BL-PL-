<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="KatmanliMimariCSharp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .Text{
            width:80%;
            border:1px solid dashed;
            border-radius:30px;

        }
        .auto-style1 {
            width: 78px;
        }
         .hider
{
    position: fixed;
    top: 0px;
    left: 0px;
    bottom: 0px;
    right: 0px;
    z-index: 99;
    background-color: Black;
    opacity: 0.2;
    filter: alpha(opacity=20);
}


        .popupbox
{
	position: fixed;
	top: 50%;
	left: 50%;
	width: 500px;
	height: 500px;
	margin-top: -25px; /*yüksekliğin yarısı olmalı*/
	margin-left: -250px; /*genişliğin yarısı olmalı*/
	border: 2px solid #555;
	z-index: 100;
	background-color: #fff;
	padding: 10px;
	-moz-box-shadow: 10px 10px 5px rgb(50,50,50);
	-webkit-box-shadow: 10px 10px 5px rgb(50,50,50);
	box-shadow: 10px 10px 5px rgba(50,50,50,0.3);
}
        .btn{
            float:right;

        }
     </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        

                <asp:Panel ID="pnplHider" CssClass="hider" Visible="false" runat="server"></asp:Panel>
                    <asp:Panel ID="pnlPopup" CssClass="popupbox" runat="server">
                        <div style="float:left;">
                      Sayin   <asp:Label ID="lblKullaniciAdi" runat="server" Text="Label"></asp:Label><br />
                      Email: <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
                        </div>
                  
                           <asp:Button ID="btnKapat" CssClass="btn"  OnClick="btnKapat_Click" runat="server" Text="X" />
                    </asp:Panel>
  


        <div style="background-color:#fdd;">
            <div  style="position:fixed; top:40%; left:40%; background-color:#ddd; float:left;  width:30%;">
                <h2>Müşteri Login Ekranına Hoşgeldiniz.</h2>
                 <table>
           
                <tr>
                    <td class="auto-style1" >Email</td>
                    <td >
                        <asp:TextBox CssClass=" Text" ID="txtEmail" runat="server" Height="16px" Width="327px"></asp:TextBox></td>
                </tr>
                       <tr>
                    <td class="auto-style1" >Şifre</td>
                    <td >
                        <asp:TextBox CssClass=" Text" ID="txtSifre" TextMode="Password" runat="server" Height="16px" Width="327px"></asp:TextBox></td>
                </tr>
                     <tr >
                         <td colspan="2">
                             <asp:Button ID="btnKaydet" OnClick="btnKaydet_Click" runat="server" Text="Giriş" /> <br />
                             <asp:Label ID="lblDurum" runat="server" Text="Label"></asp:Label>
                         </td>

                     </tr>
            </table>

            </div>
        </div>
    </form>
</body>
</html>
