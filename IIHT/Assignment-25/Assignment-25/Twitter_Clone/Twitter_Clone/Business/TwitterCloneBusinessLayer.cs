using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter_Clone
{
    public class TwitterCloneBusinessLayer
    {
        public bool UserLogin(LoginModel login)
        {
            login.PassWord = CommonUtilities.MD5Hash(login.PassWord);
            return TwitterCloneDataAccess.UserLogin(login);
        }

        public bool IsAlreadyExists(string UserId)
        {
            return TwitterCloneDataAccess.UserAlreadyExists(UserId);
        }
        public List<string> GetUserList(string UserName)
        {
            return TwitterCloneDataAccess.GetUserList(UserName);
        }
        public SignUpViewModel RegisterUser(SignUpViewModel userInfo)
        {
            userInfo.Password = CommonUtilities.MD5Hash(userInfo.Password);
            var isRegistered = TwitterCloneDataAccess.RegisterUser(userInfo);
            userInfo.isRegistered = isRegistered;
            return userInfo;
        }
        public SignUpViewModel EditProfile(string UserId)
        {
            var profile = TwitterCloneDataAccess.GetProfile(UserId);
            // profile.Password = PasswordMD5Encryption.MD5Hash(profile.Password);
            return profile;
        }

        public TweetViewModel GetTweet(string userName, int tweetId)
        {
            TweetViewModel tvm = new TweetViewModel();
            tvm.TweetMessageViewModel = new TweetMessageViewModel();

            var Tweets = TwitterCloneDataAccess.GetTweets(userName);
            var tweetDetails = TwitterCloneDataAccess.GetTweetMessageDetails(userName);
            if (tweetId == 0)
                tvm.TweetMessageViewModel.userid = userName;
            else
            {
                tvm.TweetMessageViewModel = Tweets.Where(x => x.TweetId == tweetId).FirstOrDefault();
            }

            tvm.TweetsViewModel = Tweets;
            tvm.Tweetdetails = tweetDetails;
            return tvm;
        }

        public bool SaveTweet(TweetMessageViewModel tweetMsg)
        {
            return TwitterCloneDataAccess.SaveTweet(tweetMsg);
        }
        public string DeleteTweet(int tweetId)
        {
            return TwitterCloneDataAccess.DeleteTweet(tweetId);
        }
        public TweetMessageViewModel EditTweet(int tweetId)
        {
            return TwitterCloneDataAccess.EditTweet(tweetId);
        }

    }
}