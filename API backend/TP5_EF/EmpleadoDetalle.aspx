<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmpleadoDetalle.aspx.cs" Inherits="TP5_EF.EmpleadoDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Detalle Empleado 👷‍</h3>
        </div>
        <div class="panel-body">
            <div class="panel panel-info">
                <div class="panel-heading">Nombre</div>
                <div class="panel-body">
                    <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="panel panel-info">
                <div class="panel-heading">Apellido</div>
                <div class="panel-body">
                    <asp:Label ID="lblApellido" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="panel panel-info">
                <div class="panel-heading">Fecha de nacimiento</div>
                <div class="panel-body">
                    <asp:Label ID="lblNacimiento" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="panel panel-info">
                <div class="panel-heading">Fecha de contratación</div>
                <div class="panel-body">
                    <asp:Label ID="lblContratacion" runat="server" Text=""></asp:Label>
                </div>
            </div>            
            <div class="panel panel-info">
                <div class="panel-heading">Dirección</div>
                <div class="panel-body">
                    <asp:Label ID="lblDireccion" runat="server" Text=""></asp:Label>
                </div>
            </div>            
            <div class="panel panel-info">
                <div class="panel-heading">Ciudad</div>
                <div class="panel-body">
                    <asp:Label ID="lblCiudad" runat="server" Text=""></asp:Label>
                </div>
            </div>            
            <div class="panel panel-info">
                <div class="panel-heading">Teléfono</div>
                <div class="panel-body">
                    <asp:Label ID="lblTelefono" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>    

    <asp:Button Text="Volver" ID="btnVolver" OnClick="btnVolver_Click" runat="server" />

</asp:Content>
