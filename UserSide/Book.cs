using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.UserSide
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string PublishedDate { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public string Thumbnail { get; set; }
        public string Id { get; set; }

    }
}