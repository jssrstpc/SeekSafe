using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeekSafe.Repository;

namespace SeekSafe.Controllers
{
    public class BaseController : Controller
    {
        public SeekSafeEntities _db;
        public BaseRepository<UserAccount> _userRepo;
        public UserManager _userManager;
        public String ErrorMessage;



        public BaseController()
        {
            _db = new SeekSafeEntities();
            _userRepo = new BaseRepository<UserAccount>();
            _userManager = new UserManager();

        }
    }
}