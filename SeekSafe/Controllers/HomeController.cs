using SeekSafe.Models;
using SeekSafe.Repository;
using SeekSafe.Utils;
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
            IsUserLoggedSession();

            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }

        [Authorize(Roles = "User,Admin")]
        public ActionResult Home()
        {
            return View();
        }

        [Authorize(Roles = "User,Admin")]
        public ActionResult LostItems()
        {
            return View();
        }

        [Authorize(Roles = "User,Admin")]
        public ActionResult FoundItems()
        {
            return View();
        }

        [Authorize(Roles = "User,Admin")]
        public ActionResult Report()
        {
            return View();
        }

        public ActionResult ManageUsers()
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

            return RedirectToAction("ManageUsers");
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

            return RedirectToAction("ManageUsers");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            _userRepo.Delete(id);
            TempData["Msg"] = $"User deleted!";

            return RedirectToAction("ManageUsers");
        }

        [AllowAnonymous] // Override allow not authenticated user to access login
        public ActionResult Login(String ReturnUrl)
        {
            if (User.Identity.IsAuthenticated)
            return RedirectToAction("Index");

            ViewBag.Error = String.Empty;
            ViewBag.ReturnUrl = ReturnUrl;

            return View();
        }

        [AllowAnonymous] // not set to allow anonymous during POST submit
        [HttpPost]
        public ActionResult Login(String username, String password, String ReturnUrl)
        {
            if (_userManager.Login(username, password, ref ErrorMessage) == ErrorCode.Success)
            {
                var user = _userManager.GetUserByUsername(username);

                if (user.status != (Int32)Status.Active)
                {
                    TempData["username"] = username;
                    return RedirectToAction("Verify");
                }
                //
                FormsAuthentication.SetAuthCookie(username, false);
                //
                if (!String.IsNullOrEmpty(ReturnUrl))
                    return Redirect(ReturnUrl);

                switch (user.UserRole.roleName)
                {
                    case Constant.Role_User:
                        return RedirectToAction("Home");
                    case Constant.Role_Admin:
                        return RedirectToAction("Home");
                    default:
                        return RedirectToAction("Index");
                }
            }
            ViewBag.Error = ErrorMessage;

            return View();
        }

        [AllowAnonymous]
        public ActionResult Verify()
        {
            if (String.IsNullOrEmpty(TempData["username"] as String))
                return RedirectToAction("Login");

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Verify(String code, String username)
        {
            if (String.IsNullOrEmpty(username))
                return RedirectToAction("Login");

            TempData["username"] = username;

            var user = _userManager.GetUserByUsername(username);

            if (!user.code.Equals(code))
            {
                TempData["error"] = "Incorrect Code";
                return View();
            }

            user.status = (Int32)Status.Active;
            _userManager.UpdateUser(user, ref ErrorMessage);

            return RedirectToAction("Login");
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index");

            ViewBag.Role = Utilities.ListRole;

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(UserAccount ua, String ConfirmPass)
        {
            if (!ua.password.Equals(ConfirmPass))
            {
                ModelState.AddModelError(String.Empty, "Password not match");
                ViewBag.Role = Utilities.ListRole;
                return View(ua);
            }

            if (_userManager.Register(ua, ref ErrorMessage) != ErrorCode.Success)
            {
                ModelState.AddModelError(String.Empty, ErrorMessage);

                ViewBag.Role = Utilities.ListRole;
                return View(ua);
            }
            TempData["username"] = ua.username;
            return RedirectToAction("Verify");
        }


    }
}