using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter_Clone
{
    public class TweetViewModel
    {
        public TweetMessageViewModel TweetMessageViewModel { get; set; }
        public List<TweetMessageViewModel> TweetsViewModel { get; set; }
        public Tweetdetails Tweetdetails { get; set; }

    }
}