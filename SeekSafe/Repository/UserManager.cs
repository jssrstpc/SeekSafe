using SeekSafe.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeekSafe.Repository
{
    public class UserManager
    {
        private BaseRepository<UserAccount> _userAcc;
        private BaseRepository<UserInfo> _userInf;
        public UserManager()
        {
            _userAcc = new BaseRepository<UserAccount>();
            _userInf = new BaseRepository<UserInfo>();
        }

        #region Get User By ---
        public UserAccount GetUserById(int Id)
        {
            return _userAcc.Get(Id);
        }
        public UserAccount GetUserByUserId(String userId)
        {
            return _userAcc._table.Where(m => m.userIDNum == userId).FirstOrDefault();
        }
        public UserAccount GetUserByUsername(String username)
        {
            return _userAcc._table.Where(m => m.username == username).FirstOrDefault();
        }
        public UserInfo GetUserByEmail(String email)
        {
            return _userInf._table.Where(m => m.email == email).FirstOrDefault();
        }
        #endregion
        public ErrorCode Login(String username, String password, ref String errMsg)
        {
            var userSignIn = GetUserByUsername(username);
            if (userSignIn == null)
            {
                errMsg = "User not exist!";
                return ErrorCode.Error;
            }

            if (!userSignIn.password.Equals(password))
            {
                errMsg = "Password is Incorrect";
                return ErrorCode.Error;
            }

            // user exist
            errMsg = "Login Successful";
            return ErrorCode.Success;
        }

        public ErrorCode Register(UserAccount ua, ref String errMsg, UserInfo ui)
        {
            ua.userIDNum = Utilities.gUid;
            ua.code = Utilities.code.ToString();
            ui.registrationDate = DateTime.Now;
            ua.status = (Int32)Status.InActive;

            if (GetUserByUsername(ua.username) != null)
            {
                errMsg = "Username Already Exist";
                return ErrorCode.Error;
            }

            if (GetUserByEmail(ui.email) != null)
            {
                errMsg = "Email Already Exist";
                return ErrorCode.Error;
            }

            if (_userAcc.Create(ua, out errMsg) != ErrorCode.Success)
            {
                return ErrorCode.Error;
            }

            // use the generated code for OTP "ua.code"
            // send email or sms here...........

            return ErrorCode.Success;
        }

        public ErrorCode UpdateUser(UserAccount ua, ref String errMsg)
        {
            return _userAcc.Update(ua.userID, ua, out errMsg);
        }
        public ErrorCode UpdateUserInformation(UserInfo ua, ref String errMsg)
        {
            return _userInf.Update(ua.userInfoID,   ua, out errMsg);
        }
        public UserInfo GetUserInfoById(int id)
        {
            return _userInf.Get(id);
        }
        public UserInfo GetUserInfoByUsername(String username)
        {
            var userAcc = GetUserByUsername(username);
            return _userInf._table.Where(m => m.userIDNum == userAcc.userIDNum).FirstOrDefault();
        }
        public UserInfo GetUserInfoByUserId(String userId)
        {
            return _userInf._table.Where(m => m.userIDNum == userId).FirstOrDefault();
        }
        public UserInfo CreateOrRetrieve(String username, ref String err)
        {
            var User = GetUserByUsername(username);
            var UserInfo = GetUserInfoByUserId(User.userIDNum);
            if (UserInfo != null)
                return UserInfo;

            UserInfo = new UserInfo();
            UserInfo.userIDNum = User.userIDNum;
            UserInfo.active = (Int32)Status.Active;

            _userInf.Create(UserInfo, out err);

            return GetUserInfoByUserId(User.userIDNum);
        }

        internal ErrorCode Register(UserAccount ua, ref string errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}