using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using Entities;

namespace TP5_EF
{
    public partial class EmpleadoDetalle : System.Web.UI.Page
    {
        int employeeID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["employeeid"] != "")
            {
                employeeID = Convert.ToInt32(Request.QueryString["employeeid"]);
                FillEmployeeData();
            }
            else
            {
                Response.Redirect("Empleados.aspx");
            }
        }

        private void FillEmployeeData()
        {
            EmployeesLogic employeesLogic = new EmployeesLogic();
            Employees employee = new Employees();
            employee = employeesLogic.GetData(employeeID);

            this.lblNombre.Text = employee.FirstName;
            this.lblApellido.Text = employee.LastName;
            this.lblNacimiento.Text = string.Format("{0:dd/MM/yyyy}", (employee.BirthDate));
            this.lblContratacion.Text = string.Format("{0:dd/MM/yyyy}", (employee.HireDate));
            this.lblDireccion.Text = employee.Address;
            this.lblCiudad.Text = employee.City;
            this.lblTelefono.Text = employee.HomePhone;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empleados.aspx");
        }
    }
}