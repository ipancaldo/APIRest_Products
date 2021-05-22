<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductsCreate.aspx.cs" Inherits="TP5_EF.ProductsCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Crear Producto  📃</h3>
        </div>
        <div class="panel-body">
            <div class="panel panel-info">
                <div class="panel-heading">Ingrese datos:</div>
                <div class="panel-body">
                    <asp:Label Text="ProductID:" ID="idProduct" runat="server" />
                    <asp:Label Text="" ID="lblIdProducto" runat="server" />
                    <br />
                    <br />
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
                    <asp:TextBox ID="txtNombre" Width="300px" runat="server" /> 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtNombre" class="text-danger" ErrorMessage="Debe ingresar un nombre."></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Label ID="lblCantidad" runat="server" Text="Cantidad: "></asp:Label>
                    <asp:TextBox ID="txtCantidad" Width="300px" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtCantidad" class="text-danger" ErrorMessage="Debe ingresar algún valor."></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Label ID="lblPrecio" runat="server" Text="Precio: "></asp:Label>
                    <asp:TextBox ID="txtPrecio" Width="300px" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="txtPrecio" class="text-danger" ErrorMessage="Campo requerido."></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server"
                            ControlToValidate="txtPrecio" class="text-danger" ErrorMessage="Debe ser un número mayor a 0." MaximumValue="9999"
                            MinimumValue="0,01" Type="Double"></asp:RangeValidator>
                </div>
            </div>
       </div>
    </div>

    <asp:Button ID="btnAgregar" OnClick="btnAgregar_Click" Text="Agregar" runat="server" />
    <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" CausesValidation="false" Text="Cancelar" runat="server" />

</asp:Content>
