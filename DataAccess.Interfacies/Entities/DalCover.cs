﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfacies.Entities
{
    public class DalCover:IEntity
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public string ImagePath { get; set; }
    }
}
