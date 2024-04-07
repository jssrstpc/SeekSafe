using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SeekSafe.Controllers
{
    [Authorize(Roles = "User,Admin")] // (must login)
    public class HomeController : BaseController
    {
        // GET: Home
        [AllowAnonymous]
        public ActionResult Index()
        {
            // Only authenticated Admin can create | update | dalete
            List<UserAccount> UserList = _userRepo.GetAll();
            return View(UserList);
        }

        [Authorize(Roles = "Admin")] // filtered to Admin only
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserAccount u)
        {
            _userRepo.Create(u);
            TempData["Msg"] = $"User {u.username} added!";

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(_userRepo.Get(id));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View(_userRepo.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(UserAccount u)
        {
            _userRepo.Update(u.roleID, u);
            TempData["Msg"] = $"User {u.username} updated!";

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            _userRepo.Delete(id);
            TempData["Msg"] = $"User deleted!";

            return RedirectToAction("Index");
        }

        [AllowAnonymous] // Override allow not authenticated user to access login
        public ActionResult Login()
        {
            //check if already login no need to login again, redirect to the index
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index");

            return View();
        }
        [AllowAnonymous] // not set to allow anonymous during POST submit
        [HttpPost]
        public ActionResult Login(UserAccount u)
        {
            // same as Select * from User where username = u.username limit 1 or top 1 or default if no data
            var user = _userRepo.Table.Where(m => m.username == u.username).FirstOrDefault();
            if (user == null)
            {
                // User is correct username and password
                ModelState.AddModelError("", "Username not exist!");
                return View();
            }

            if (!user.password.Equals(u.password))
            {
                // User is correct username and password
                ModelState.AddModelError("", "Incorrect Password");
                return View();
            }
            // user is not exist or incorrect password
            // add error to the form
            FormsAuthentication.SetAuthCookie(u.username, false);

            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }



    }
}