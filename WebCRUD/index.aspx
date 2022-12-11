<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebCRUD.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WebCRUD</title>
    <link href="Css/style.css" rel="stylesheet" />
        <link href="bootstrap.min.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GrdResults" runat="server" UseAccessibleHeader="true" CssClass="table table-condensed table-hover" Width="100%" AutoGenerateColumns="False"  OnRowCancelingEdit="GrdResults_RowCancelingEdit" OnRowEditing="GrdResults_RowEditing" OnRowUpdating="GrdResults_RowUpdating" OnRowDeleting="GrdResults_RowDeleting" DataKeyNames="ID">
                <Columns >              
                    <asp:BoundField DataField="ID" HeaderText="Id" ReadOnly="true"></asp:BoundField>
                    <asp:BoundField DataField="FIRSTNAME" HeaderText="First Name"></asp:BoundField>
                    <asp:BoundField DataField="LASTNAME" HeaderText="Last Name"></asp:BoundField>
                    <asp:BoundField DataField="FATHERNAME" HeaderText="Father Name"></asp:BoundField>
                    <asp:BoundField DataField="EMAIL" HeaderText="Email"></asp:BoundField>
                    <asp:BoundField DataField="PHONE" HeaderText="Phone"></asp:BoundField>
                    <asp:CommandField ShowEditButton="True" ButtonType="Button"  ItemStyle-CssClass="edit" ControlStyle-CssClass="update"  ></asp:CommandField>
                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ItemStyle-CssClass="del" ControlStyle-CssClass="cancel" ></asp:CommandField>  
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
