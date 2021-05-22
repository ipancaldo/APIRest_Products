<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="TP5_EF.Empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div>
        <h1>Empleados</h1>

        <asp:GridView Id="gridEmployeesList" runat="server" OnRowDataBound="gridEmployeesList_RowDataBound" 
            CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

            <Columns>
                <asp:BoundField DataField="EmployeeID" HeaderText="ID" ItemStyle-Width="5%"/>
                <asp:BoundField DataField="LastName" HeaderText="Apellido" ItemStyle-Width="20%"/>
                <asp:BoundField DataField="FirstName" HeaderText="Nombre" ItemStyle-Width="20%"/>
                <asp:BoundField DataField="BirthDate" HeaderText="Nacimiento" HtmlEncode="false" DataFormatString="{0:d}" ItemStyle-Width="20%"/>
                <asp:BoundField DataField="HireDate" ItemStyle-Width="20%" HtmlEncode="false" DataFormatString="{0:d}" HeaderText="Contratación"/>
                <asp:BoundField DataField="HomePhone" HeaderText="Telefono" ItemStyle-Width="20%"/>
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
        <asp:Button Id="btnDetalle" Text="Detalle" onclick="btnDetalle_Click" runat="server" />
        <asp:Button Id="btnVolver" Text="Volver" onclick="btnVolver_Click" runat="server" />
    </div>


</asp:Content>
