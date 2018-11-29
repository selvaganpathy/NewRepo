using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twitter_Clone
{
    public class TwitterCloneController : Controller
    {
        public TwitterCloneBusinessLayer _tcBLayer = null;

        public TwitterCloneController()
        {
            _tcBLayer = new TwitterCloneBusinessLayer();
        }
        // GET: TwitterClone
        public ActionResult Index()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel userLogin)
        {
            if (ModelState.IsValid)
            {
                var isUser = _tcBLayer.UserLogin(userLogin);
                if (!isUser)
                    ModelState.AddModelError("UserName", "InValid User");
                else
                {
                    SetTempUser(userLogin.UserName);
                    //TempData["userLogin"] = userLogin;
                    return RedirectToAction("TwitterHome");
                }

            }
            return View("Index", userLogin);
        }


        public ActionResult signUp()
        {
            return View(new SignUpViewModel());
        }

        [HttpPost]
        public ActionResult RegisterUser(SignUpViewModel regUser)
        {
            if (ModelState.IsValid)
            {
                regUser = _tcBLayer.RegisterUser(regUser);

                if (!regUser.isRegistered)
                    ModelState.AddModelError("UserName", "Something went wrong, Please try later.");
            }
            return View("signUp", regUser);
        }

        [HttpPost]
        public ActionResult IsAlreadyExists(string UserName)
        {
            bool isExist = false;
            isExist = _tcBLayer.IsAlreadyExists(UserName);
            return Json(isExist);

        }


        public ActionResult TwitterHome(int EdittweetId = 0, string userName = null)
        {
            LoginModel userLogin = getTempUser(userName);
            ViewBag.SignUp = new SignUpViewModel();
            ViewBag.UserName = userLogin.UserName;
            ViewBag.Users = GetUserList(userLogin.UserName);
            //bool isExist = false;
            var res = _tcBLayer.GetTweet(userLogin.UserName, EdittweetId);
            return View(res);

        }

        public ActionResult TwitterHomeRefresh(int EdittweetId = 0, string userName = null)
        {
            LoginModel userLogin = getTempUser(userName);
            ViewBag.UserName = userLogin.UserName;
            var res = _tcBLayer.GetTweet(userLogin.UserName, EdittweetId);
            return PartialView("_Tweets", res.TweetsViewModel);

        }

        public ActionResult TwitterMessage(TweetViewModel tweetMV)
        {
            SetTempUser(tweetMV.TweetMessageViewModel.userid);

            if (ModelState.IsValid)
            {
                var status = _tcBLayer.SaveTweet(tweetMV.TweetMessageViewModel);
                //bool isExist = false;
                if (status)
                {
                    var res = _tcBLayer.GetTweet(tweetMV.TweetMessageViewModel.userid, tweetMV.TweetMessageViewModel.TweetId);
                    //return PartialView("Tweets", res.TweetsViewModel);
                    return RedirectToAction("TwitterHome", tweetMV);
                }
            }

            return View("TwitterHome", tweetMV);
            //return RedirectToAction("TwitterHome");

        }

        public ActionResult EditTweet(int tweetId)
        {
            return RedirectToAction("TwitterHome", new { EdittweetId = tweetId });
        }

        public ActionResult DeleteTweet(int tweetId)
        {
            SetTempUser(_tcBLayer.DeleteTweet(tweetId));
            return RedirectToAction("TwitterHome");            //, new { EdittweetId = tweetId }
        }

        public ActionResult HomePage(string UserName)
        {
            SetTempUser(UserName);
            return RedirectToAction("TwitterHome");            //, new { EdittweetId = tweetId }
        }

        public ActionResult EditProfile(string UserName)
        {
            SetTempUser(UserName);
            return PartialView("_ProfileSetUp", _tcBLayer.EditProfile(UserName));            //, new { EdittweetId = tweetId }
        }

        private Array GetUserList(string UserName)
        {
            return _tcBLayer.GetUserList(UserName).ToArray();
        }

        private void SetTempUser(string userName)
        {
            LoginModel lgn = new LoginModel();
            lgn.UserName = userName;
            TempData["userLogin"] = lgn;
            TempData.Keep("userLogin");
        }

        private LoginModel getTempUser(string userName)
        {
            LoginModel userLogin = null;
            if (!string.IsNullOrEmpty(userName))
            {
                userLogin = new LoginModel();
                userLogin.UserName = userName;
            }
            else
            {
                userLogin = (LoginModel)TempData["userLogin"];
            }

            TempData["userLogin"] = userLogin;
            TempData.Keep("userLogin");
            return userLogin;
        }

    }
}