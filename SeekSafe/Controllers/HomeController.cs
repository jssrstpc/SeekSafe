using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Login()
        {
            //check if already login no need to login again, redirect to the index
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Home");

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
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Home");

            return View();
        }
        
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(UserAccount u)
        {
            // Check model validation
            if (!ModelState.IsValid)
            {
                // If model validation fails, return the registration view with validation errors
                return View(u);
            }

            var existingUser = _userRepo.Table.FirstOrDefault(m => m.userIDNum == u.userIDNum);
            // Check if the userIDNum already exists in the database
            if (existingUser != null)
            {
                ModelState.AddModelError("userIDNum", "User ID Number already exists.");
                return View(u);
            }

            // Save the user to the database
            _userRepo.Create(u);
            TempData["Msg"] = $"User {u.username} was recently added!";

            // Redirect to the login page after successful registration
            return RedirectToAction("Login");
        }

        [Authorize(Roles = "User,Admin")]
        public ActionResult LostItemReport()
        {   
            return View();
        }

        [Authorize(Roles = "User,Admin")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult LostItemReport(Item lostItem)
        {
            if (!ModelState.IsValid)
            {
                // If model validation fails, return the registration view with validation errors
                return View(lostItem);
            }
            // Save the lost item to the database
            _ItemRepo.Create(lostItem);
            TempData["Msg"] = $"Lost item '{lostItem.itemName}' was successfully reported!";

            // Redirect to a confirmation page or other appropriate action
            return RedirectToAction("FoundItems");
        }


        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file, Item lostItem)
        {
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    // Save the file to a directory
                    string fileName = Path.GetFileName(file.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/Views/FileUpload"), fileName);
                    file.SaveAs(filePath);

                    ViewBag.Message = "File uploaded successfully.";
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "An error occurred: " + ex.Message;
                }
            }
            else
            {
                ViewBag.Error = "Please select a file.";
            }
            TempData["ReportMsg"] = $"Lost item '{lostItem.itemLostName}' was successfully reported! ";
            _ItemRepo.Create(lostItem);
            return View("LostItems");
        }



    }
}