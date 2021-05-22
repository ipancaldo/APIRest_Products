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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillProductsGrid();
            }
            else
            {
                this.lblError.Text = " ";
                this.lblError.Visible = false;
            }
        }


        private void FillProductsGrid()
        {
            ProductsLogic productsLogic = new ProductsLogic();
            gridProductList.DataSource = productsLogic.GetAll();
            gridProductList.DataBind();
        }

        //Sirve para poder seleccionar la fila a la cual hacemos click y poder manipularla
        protected override void Render(HtmlTextWriter writer)
        {
            foreach (GridViewRow row in gridProductList.Rows)
            {
                row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference
                    (gridProductList, "Select$" + row.RowIndex.ToString(), true));
            }
            base.Render(writer);
        }

        //Puntero de manito en el hover de la lista
        protected void gridProductList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("OnMouseOver", "this.style.cursor='pointer';");
                e.Row.ToolTip = "Click en la fila para seleccionarla";
            }
        }


        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductsCreate.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string productID = null;
            if (gridProductList.SelectedIndex != -1) productID = gridProductList.SelectedRow.Cells[0].Text;
                            //Este productid= es el que le estaremos pasando a la QueryString
            Response.Redirect("ProductsAlter.aspx?productid=" + productID);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string productID = null;

            if (gridProductList.SelectedIndex != -1)
            {
                productID = gridProductList.SelectedRow.Cells[0].Text;
                ProductsLogic productsLogic = new ProductsLogic();

                try
                {
                    productsLogic.Delete(Int32.Parse(productID));
                }
                catch (Exception ex)
                {
                    this.lblError.Text = "No se puede eliminar el registro ya que genera un conflicto con otros con los cuales se relaciona. Error: " + ex.Message;
                    this.lblError.Visible = true;
                    //Response.Write("No se puede eliminar el registro ya que genera un conflicto con otros con los cuales se relaciona. Error: " + ex.Message);
                }
                FillProductsGrid();
            }
        }
    }
}