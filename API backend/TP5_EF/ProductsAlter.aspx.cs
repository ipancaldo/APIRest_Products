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
    public partial class ProductsEdit : System.Web.UI.Page
    {
        int productID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Desde acá tomamos el QueryString que pasamos desde Default en el redirect
            if (Request.QueryString["productid"] != "")
            {
                productID = Convert.ToInt32(Request.QueryString["productid"]);
            }
            else
            {
                Response.Redirect("Default.aspx");
            }

            // Debe cargar los campos sólo si no es postback, ya que de lo contrario volvería a cargar
            //los datos al querer editar y se guardarían los datos originales
            if (!IsPostBack)
            {
                FillProductData();
            }
        }


        private void FillProductData()
        {
            ProductsLogic productsLogic = new ProductsLogic();
            Products product = new Products();    
            product = productsLogic.GetData(productID);

            this.txtNombre.Text = product.ProductName;
            this.txtCantidad.Text = product.QuantityPerUnit;
            this.txtPrecio.Text = (product.UnitPrice).ToString();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            ProductsLogic productsLogic = new ProductsLogic();

            Products product = new Products
            {
                ProductID = productID,
                ProductName = this.txtNombre.Text,
                QuantityPerUnit = this.txtCantidad.Text,
                UnitPrice = decimal.Parse(this.txtPrecio.Text)
            };

            productsLogic.Update(product);

            Response.Redirect("Default.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}