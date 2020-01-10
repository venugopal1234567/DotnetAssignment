using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginSignup.Models;

namespace LoginSignup.Controllers
{
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)] // will be applied to all actions in MyController, unless those actions override with their own decoration
    public class HomeController : Controller
    {

        static List<User> userList = new List<User>();

        public ActionResult Index()
        {

            //cookie check
            HttpCookie cookie = Request.Cookies["UserInfo"];
            if (cookie != null)
            {
                var std = userList.Where(s => s.username == cookie["username"]).FirstOrDefault();
                if (std != null)
                {
                    if (std.password == cookie["password"])
                    {
                        return RedirectToAction("ListUser");
                    }
                }
            
            }



            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            if (cookie != null)
            {
                var std = userList.Where(s => s.username == cookie["username"]).FirstOrDefault();
                if (std != null)
                {
                    if (std.password == cookie["password"])
                    {
                        return RedirectToAction("ListUser");
                    }
                }

            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            
                string username1 = user.username;
                string password1 = user.password;

                var std = userList.Where(s => s.username == username1).FirstOrDefault();
                if (std == null)
                {
                    Response.Write("No User Exists");
                }
                else
                {
                    if (std.password == password1)
                    {

                        HttpCookie cookie = new HttpCookie("UserInfo");
                        cookie["username"] = std.username;
                        cookie["password"] = std.password;
                        cookie["NickName"] = std.NickName;
                        cookie.Expires = DateTime.Now.AddDays(20);
                        Response.Cookies.Add(cookie);
                        return RedirectToAction("ListUser");
                    }
                    else
                        Response.Write("Bad Credentials");
                }
            
            return View(); 
            
        }

        public ActionResult SignUp()
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            if (cookie != null)
            {
                var std = userList.Where(s => s.username == cookie["username"]).FirstOrDefault();
                if (std != null)
                {
                    if (std.password == cookie["password"])
                    {
                        return RedirectToAction("ListUser");
                    }
                }

            }

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                string username1 = user.username;
                string NickName1 = user.NickName;
                string password1 = user.password;
                DateTime BirthDay1 = Convert.ToDateTime(user.BirthDate);

                var std = userList.Where(s => s.username == username1).FirstOrDefault();
                if (std == null)
                {
                    userList.Add(new User() { username = username1, password = password1, BirthDate = BirthDay1, NickName = NickName1 });
                }
                else
                {
                    Response.Write("User Already exists");
                    return View();
                }
                HttpCookie cookie = new HttpCookie("UserInfo");
                cookie["username"] = username1;
                cookie["password"] = password1;
                cookie["NickName"] = NickName1;
                cookie.Expires = DateTime.Now.AddDays(20);
                Response.Cookies.Add(cookie);


                return RedirectToAction("ListUser");

            }

            return View();

           
        }
    

        public ActionResult ListUser()
        {
           
            //cookie check
            HttpCookie cookie = Request.Cookies["UserInfo"];
            if (cookie != null)
            {
                var std = userList.Where(s => s.username == cookie["username"]).FirstOrDefault();
                if (std == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    if (std.password != cookie["password"])
                    {
                        return RedirectToAction("Index");
                    }
                }
       
            }
            if (cookie == null)
            {
                return RedirectToAction("Index");
            }
            if (userList == null)
            {
                return RedirectToAction("Index");
            }
         

            return View(userList);
        }

        public ActionResult Logout()
        {
            HttpCookie cookie = new HttpCookie("UserInfo");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }

    }

}