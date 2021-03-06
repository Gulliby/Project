﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.BookModels;

namespace WebApplication.Models
{
    public class TagBookListModel
    {
        public TagModel Tag { get; set; }
        public IEnumerable<BookShortModel> Books { get; set; }
    }
}