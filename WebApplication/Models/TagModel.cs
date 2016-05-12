﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models
{
    public class TagModel
    {
        [HiddenInput(DisplayValue =false)]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name can't be empty.")]
        public string Name { get; set; }
    }
}