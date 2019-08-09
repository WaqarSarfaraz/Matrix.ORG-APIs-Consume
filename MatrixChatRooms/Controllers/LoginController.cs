using MatrixApiLogics.BusinessLogics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MatrixChatRooms.Controllers
{
    public class LoginController : Controller
    {
        private Authentication Auth = new Authentication();
        // GET: Login
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(string email,string pwd)
        {
            string Result = Auth.MatrixAuthentication(email,pwd);
            if (Result == Auth.ApiLimitError)
            {
                ViewBag.Error = Result;
                return View();

            }
            else if(Result == HttpStatusCode.Forbidden.ToString())
            {
                ViewBag.Error = Result;
                return View();
            }
            else 
            {
                HttpCookie TokenCookies = new HttpCookie("Access_Token");
                TokenCookies.Value = Result;
                TokenCookies.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Add(TokenCookies);
                return RedirectToAction("Index", "Home", new { ids = "" });

            }
           
        }
        // GET: Login/Details/5
        public ActionResult Logout()
        {
            if (Request.Cookies["Access_Token"] != null)
            {
                Response.Cookies["Access_Token"].Expires = DateTime.Now.AddDays(-1);
            }

            return RedirectToAction("Index", "Login");
        }
        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
