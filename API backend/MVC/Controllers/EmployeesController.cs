using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using MVC.Models;
using Logic;
using AutoMapper;
using System.Text;
using System.IO;

namespace MVC.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeesLogic logic = new EmployeesLogic();

        // GET: Employees
        public ActionResult Index()
        {
            List<Employees> employees = logic.GetAll();
            DateTime Today = DateTime.Today;

            List<EmployeesView> employeesViews = employees.Select(e => new EmployeesView
            {
                Id = e.EmployeeID,
                Lastname = e.LastName,
                FirstName = e.FirstName,
                BirthDate = (DateTime)e.BirthDate,
                HireDate = (DateTime)e.HireDate,
                Seniority = Today.Year - ((DateTime)(e.HireDate)).Year,
                HomePhone = e.HomePhone
            }).ToList();

            return View(employeesViews);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            try
            {
                Employees employee = logic.GetData(id);
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Employees, EmployeesView>();
                });
                EmployeesView employeesView = config.CreateMapper().Map<EmployeesView>(employee);

                return View(employeesView);
            }
            catch (Exception ex)
            {
                string mensaje = $"No existe el empleado seleccionado. Error: {ex.Message}";
                TempData["MensajeError"] = mensaje;

                //Desde acá podemos logear el error en un TXT que se guarda en D:/
                LogErrorsLogic logErrorsLogic = new LogErrorsLogic();
                logErrorsLogic.LogError(mensaje);
               
                
                return RedirectToAction("Index", "Error");
            }
        }
    }
}