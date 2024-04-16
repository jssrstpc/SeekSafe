using SeekSafe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeekSafe.Utils
{
    public enum ErrorCode
    {
        Success,
        Error
    }
    public enum Status
    {
        InActive,
        Active
    }

    public enum RoleType
    {
        User,
        Admin
    }

    public enum ProductStatus
    {
        NoStock,
        HasStock
    }

    public class Constant
    {
        public const string Role_User = "User";
        public const string Role_Admin = "Admin";

        public const int ERROR = 1;
        public const int SUCCESS = 0;
    }

    public class Utilities
    {
        public static String gUid
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
        }
        // Return random number for OTP
        public static int code
        {
            get
            {
                Random r = new Random();
                return r.Next(100000, 999999);
            }
        }

        public static List<SelectListItem> ListRole
        {
            get
            {
                BaseRepository<UserRole> role = new BaseRepository<UserRole>();
                var list = new List<SelectListItem>();
                foreach (var item in role.GetAll())
                {
                    var r = new SelectListItem
                    {
                        Text = item.roleName,
                        Value = item.roleID.ToString()
                    };

                    list.Add(r);
                }

                return list;
            }
        }


        public static List<SelectListItem> SelectListItemCategoryByUser(String username)
        {
            CategoryManager _categoryMgr = new CategoryManager();
            var list = new List<SelectListItem>();
            foreach (var item in _categoryMgr.ListCategory(username))
            {
                var r = new SelectListItem
                {
                    Text = item.categoryName,
                    Value = item.categoryID.ToString()
                };
                list.Add(r);
            }

            return list;
        }
    }
}