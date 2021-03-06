﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;

namespace DataAccess.Interfacies
{
    public interface IAuthorRepository:IRepository<DalAuthor>
    {
        int GetAuthorsCount();
        IEnumerable<DalAuthor> OrderTake(int offset, int count);
        IEnumerable<DalBook> GetBooks(DalAuthor author);
        DalAuthor GetByName(string name);
    }
}
