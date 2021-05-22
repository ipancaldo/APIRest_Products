using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using Logic;

namespace TP5_EF
{
    public partial class ProductsCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductsLogic productsLogic = new ProductsLogic();
            //Devuelve el último string +1
            this.lblIdProducto.Text = (productsLogic.GetLastID()+1).ToString();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ProductsLogic productsLogic = new ProductsLogic();

            productsLogic.Add(new Products
            {
                //ProductID = productsLogic.GetLastID() + 1, /* Tiene generador de ID automático, no es necesario  */
                ProductName = this.txtNombre.Text,
                QuantityPerUnit = this.txtCantidad.Text,
                UnitPrice = decimal.Parse(this.txtPrecio.Text)
            });
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Producto agregado!'); window.location='" + Request.ApplicationPath + "Default.aspx';", true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}