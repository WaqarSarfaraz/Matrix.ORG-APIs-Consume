using MatrixApiLogics.BusinessLogics;
using MatrixApiLogics.DTOS;
using MatrixApiLogics.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MatrixChatRooms.Controllers
{
    public class HomeController : Controller
    {
        private Rooms RoomLogic = new Rooms();
        private Message MessageLogic = new Message();
        public ActionResult Index(string ids)
        {
            if (Request.Cookies["Access_Token"] != null)
            {
                ViewBag.demo = Request.Cookies["Access_Token"].Value;

                List<detail> jrr = RoomLogic.JoinedRooms(ViewBag.demo);
                ViewBag.Message = "";
                ViewBag.RoomName = "";
                if (ids == "" || ids == null)
                {
                    ViewBag.Message = RoomLogic.GetMessage(ViewBag.demo,jrr.Select(x=>x.Roomid).FirstOrDefault());
                    ViewBag.RoomName = jrr.Select(x => x.Name).FirstOrDefault();
                }
                else
                {

                    ViewBag.Message = RoomLogic.GetMessage(ViewBag.demo,ids);
                    ViewBag.RoomName = jrr.Where(x => x.Roomid == ids).Select(x=>x.Name).FirstOrDefault();
            
                }
             
                ViewBag.Rooms =   jrr;
                return View();
            }
            else
            {
                return RedirectToAction("Index","Login");
            }

       
        }

        public ActionResult Logout()
        {
            if (Request.Cookies["Access_Token"] != null)
            {
                Response.Cookies["Access_Token"].Expires = DateTime.Now.AddDays(-1);
            }

            return View("Index","Login");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}