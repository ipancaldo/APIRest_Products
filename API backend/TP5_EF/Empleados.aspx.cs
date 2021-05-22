using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;

namespace TP5_EF
{
    public partial class Empleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillEmployeesGrid();
        }

        private void FillEmployeesGrid()
        {
            EmployeesLogic employeesLogic = new EmployeesLogic();
            gridEmployeesList.DataSource = employeesLogic.GetAll();
            gridEmployeesList.DataBind();
        }

        protected void gridEmployeesList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("OnMouseOver", "this.style.cursor='pointer';");
                e.Row.ToolTip = "Click en la fila para seleccionarla";
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            foreach (GridViewRow row in gridEmployeesList.Rows)
            {
                row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference
                    (gridEmployeesList, "Select$" + row.RowIndex.ToString(), true));
            }
            base.Render(writer);
        }


        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            string employeeID = null;
            if (gridEmployeesList.SelectedIndex != -1) employeeID = gridEmployeesList.SelectedRow.Cells[0].Text;
            //Este productid= es el que le estaremos pasando a la QueryString
            Response.Redirect("EmpleadoDetalle.aspx?employeeid=" + employeeID);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

    }
}