﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfacies.Entities
{
    public class DalGenre:IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? ParentGenreID { get; set; }
    }
}
