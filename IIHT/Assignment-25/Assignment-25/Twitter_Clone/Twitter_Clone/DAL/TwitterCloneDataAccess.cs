using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_Clone
{
    public class TwitterCloneDataAccess
    {
        public static bool UserLogin(LoginModel login)
        {
            bool isUserExist = false;
            using (var _context = new TwitterCloneDBEntities())
            {
                var items = _context.People.Where(x => x.user_id == login.UserName && x.password == login.PassWord).FirstOrDefault();
                isUserExist = (items != null && items.user_id != null) ? true : false;
            }

            return isUserExist;
        }

        public static bool UserAlreadyExists(string userId)
        {
            bool isUserExist = false;
            using (var _context = new TwitterCloneDBEntities())
            {
                var items = _context.People.Where(x => x.user_id.Trim() == userId.Trim()).FirstOrDefault();
                isUserExist = (items == null) ? true : false;
            }

            return isUserExist;
        }
        public static SignUpViewModel GetProfile(string userId)
        {
            SignUpViewModel pr = new SignUpViewModel();
            using (var _context = new TwitterCloneDBEntities())
            {
                var items = _context.People.Where(x => x.user_id.Trim() == userId.Trim()).FirstOrDefault();
                if (items != null && items.user_id != null)
                {
                    pr.UserName = items.user_id;
                    pr.Email = items.email;
                    pr.FullName = items.fullName;
                    pr.Password = items.password;
                }
            }

            return pr;
        }

        public static List<string> GetUserList(string UserName)
        {
            List<string> lstUser = new List<string>();
            using (var _context = new TwitterCloneDBEntities())
            {
                lstUser = _context.People.Select(x => x.user_id).ToList();//.Where(x => x.user_id.Trim().Contains(UserName))
            }

            return lstUser != null ? lstUser : new List<string>();
        }

        public static bool RegisterUser(SignUpViewModel userInfo)
        {
            bool isRegistered = false;
            try
            {
                using (var _context = new TwitterCloneDBEntities())
                {
                    var items = _context.People.Where(x => x.user_id.ToUpper().Trim() == userInfo.UserName.ToUpper().Trim()).FirstOrDefault();

                    if (items == null)
                    {
                        Person user = new Person();
                        user.user_id = userInfo.UserName;
                        user.password = userInfo.Password;
                        user.fullName = userInfo.FullName;
                        user.email = userInfo.Email;
                        user.joined = DateTime.Now;
                        user.active = true;

                        _context.People.Add(user);
                    }
                    else
                    {
                        items.password = userInfo.Password;
                        items.fullName = userInfo.FullName;
                    }

                    _context.SaveChanges();
                    isRegistered = true;
                }
            }
            catch (Exception ex)
            {
                isRegistered = false;
            }

            return isRegistered;
        }
        public static Tweetdetails GetTweetDetails(string userName)
        {
            Tweetdetails td = new Tweetdetails();
            try
            {



            }
            catch (Exception ex)
            {

            }
            return td;
        }

        public static Tweetdetails GetTweetMessageDetails(string userName)
        {
            Tweetdetails tmv = new Tweetdetails();
            try
            {
                using (var _context = new TwitterCloneDBEntities())
                {
                    var tweets = _context.TWEETs.Where(x => x.user_id.Trim().ToUpper() == userName.ToUpper().Trim());
                    var follows = _context.People.Where(x => x.user_id.Trim().ToUpper() == userName.ToUpper().Trim()).FirstOrDefault();

                    if (tweets != null)
                        tmv.TotalTweets = tweets.Count();

                    if (follows != null)
                    {
                        tmv.TotalFollowers = follows.People.Count();
                        tmv.TotalFollowing = follows.Person1.Count();
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return tmv;
        }

        public static List<TweetMessageViewModel> GetTweets(string userName)
        {
            List<TweetMessageViewModel> lsttmv = new List<TweetMessageViewModel>();
            try
            {
                using (var _context = new TwitterCloneDBEntities())
                {
                    var users = _context.People.Where(x => x.user_id.Trim().ToUpper() == userName.ToUpper().Trim());
                    var tweets = _context.TWEETs.Where(x => x.user_id.Trim().ToUpper() == userName.ToUpper().Trim());

                    lsttmv = tweets.Select(t =>
                    new TweetMessageViewModel
                    {
                        TweetId = t.tweet_id,
                        TweetMessage = t.message,
                        userid = t.user_id,
                        Created = t.created,
                        isUserTweet = t.user_id.Trim().ToUpper() == userName.ToUpper().Trim() ? true : false
                    }).ToList();
                }

            }
            catch (Exception ex)
            {

            }
            return lsttmv;
        }

        public static bool SaveTweet(TweetMessageViewModel tweetMsg)
        {
            bool IsSuccess = false;
            try
            {
                using (var _context = new TwitterCloneDBEntities())
                {
                    var tweets = _context.People.Where(x => x.user_id.Trim().ToUpper() == tweetMsg.userid.Trim().ToUpper()).FirstOrDefault();
                    var tweet = tweets.TWEETs.Where(x => x.tweet_id == tweetMsg.TweetId).FirstOrDefault();//_context.TWEETs.Where(x => x.tweet_id == tweetMsg.TweetId).FirstOrDefault();
                    if (tweet == null && tweetMsg.TweetId == 0)
                    {
                        tweet = new TWEET();
                        tweet.user_id = tweetMsg.userid;
                        tweet.message = tweetMsg.TweetMessage;
                        tweet.created = DateTime.Now;

                        _context.Entry(tweet).State = EntityState.Added;
                    }
                    else
                    {
                        tweet.message = tweetMsg.TweetMessage;
                    }
                    IsSuccess = true;

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }

            return IsSuccess;
        }
        public static string DeleteTweet(int tweetId)
        {
            string strUserName = string.Empty;
            try
            {
                using (var _context = new TwitterCloneDBEntities())
                {
                    var tweet = _context.TWEETs.Where(x => x.tweet_id == tweetId).FirstOrDefault();//_context.TWEETs.Where(x => x.tweet_id == tweetMsg.TweetId).FirstOrDefault();
                    if (tweet != null && tweetId != 0)
                    {
                        strUserName = tweet.user_id;
                        _context.TWEETs.Remove(tweet);
                        //_context.Entry(tweet).State = EntityState.Deleted;
                    }
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
            return strUserName;
        }

        public static TweetMessageViewModel EditTweet(int tweetId)
        {
            TweetMessageViewModel _editTweet = new TweetMessageViewModel();
            try
            {
                using (var _context = new TwitterCloneDBEntities())
                {
                    var tweet = _context.TWEETs.Where(x => x.tweet_id == tweetId).FirstOrDefault();//_context.TWEETs.Where(x => x.tweet_id == tweetMsg.TweetId).FirstOrDefault();
                    _editTweet.userid = tweet.user_id;
                    _editTweet.TweetMessage = tweet.message;
                    _editTweet.TweetId = tweet.tweet_id;
                    _editTweet.Created = tweet.created;
                }
            }
            catch (Exception ex)
            {

            }

            return _editTweet;

        }

    }
}