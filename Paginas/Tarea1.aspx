<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tarea1.aspx.cs" Inherits="Tarea_1.Paginas.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        .Tabla{
            background-color:antiquewhite;
            font-family:Arial;
            font-weight:bold;
            margin:auto;
            text-align:center;
            width:100%;
        }
        div{
            margin:auto;
            width:300px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView runat="server" AutoGenerateColumns="false" EmptyDataText="No hay Nombres"
                ID="gvNombres" CssClass="Tabla">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
