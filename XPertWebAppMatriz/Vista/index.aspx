<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="XPertWebAppMatriz.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
            <tr>
                <td>
                    <label>T</label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtT" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>  
                <td>
                    Dato</td>
                <td>
                    <asp:TextBox ID="txtDato" runat="server" Width="392px"></asp:TextBox>
                </td>
                <td>                    
                    <asp:Button ID="cmdReg" runat="server" OnClick="cmdReg_Click" Text="Ingreso" Width="64px" />
                </td>
            </tr>
            <tr>  
                <td>
                    <label>Ingreso</label>                                      
                </td>
                <td>
                    <asp:TextBox ID="txtIngreso" runat="server" TextMode="MultiLine" Width="400px" Height="200px" Enabled="False" ReadOnly="True"></asp:TextBox>
                </td>
                <td>                    
                    <asp:Button ID="cmdCalcular" runat="server" Text="Calcular" OnClick="cmdCalcular_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <label>Resultado</label>                    
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtResultado" runat="server" TextMode="MultiLine" Width="400px" Height="200px" Enabled="False" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
