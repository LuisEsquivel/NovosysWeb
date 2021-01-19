﻿using Novosys.Services;
using NovosysWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovosysWEB.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            return View(Get());
        }



        public ApiServices apiServices;
        public Services services;
        public HomeController hc;


        public ProductosController()
        {
            apiServices = new ApiServices();
            services = new Services();
            hc = new HomeController();
        }



        public object Get()
        {
            object o;

            try
            {
                o = services.Get<Producto>("producto").ToList();
            }
            catch (Exception)
            {
                return null;
            }

            return o;
        }


  

        [HttpPost]
        public ActionResult Detalle(int id)
        {
            object o;

            try
            {
                o = services.Get<Producto>("producto", id).ToList();
            }
            catch (Exception)
            {
                return null;
            }

            return Json(o, JsonRequestBehavior.AllowGet);
        }


    }
}