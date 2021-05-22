<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP5_EF._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <asp:Label Text="" ID="lblError" class="text-danger" runat="server" />

    <div>
        <h1>Productos</h1>

        <asp:GridView Id="gridProductList" runat="server" OnRowDataBound="gridProductList_RowDataBound"
            CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="ID" ItemStyle-Width="5%"/>
                <asp:BoundField DataField="ProductName" HeaderText="Nombre"/>
                <asp:BoundField DataField="QuantityPerUnit" HeaderText="Cantidad por unidad" ItemStyle-Width="30%"/>
                <asp:BoundField DataField="UnitPrice" HeaderText="Precio" DataFormatString="{0:n2}" ItemStyle-Width="10%"/>
            </Columns>

            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"/>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"/>
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="False" ForeColor="#333333"/>
            <SortedAscendingCellStyle BackColor="#E9E7E2"/>
            <SortedAscendingHeaderStyle BackColor="#506C8C"/>
            <SortedDescendingCellStyle BackColor="#FFFDF8"/>
            <SortedDescendingHeaderStyle BackColor="#6F8DAE"/>
        </asp:GridView>

        <br />

        <asp:Button Id="btnNuevo" Text="Nuevo" onclick="btnNuevo_Click" runat="server" />
        <asp:Button Id="btnEditar" Text="Editar" onclick="btnEditar_Click" runat="server" />
        <asp:Button Id="btnEliminar" Text="Eliminar" onclick="btnEliminar_Click" OnClientClick="return confirm('Realmente desea eliminarlo?')" runat="server" />
    </div>

</asp:Content>
