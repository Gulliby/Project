﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies;
using DataAccess.Interfacies.Entities;

namespace DataAccessLibrary.Repository
{
    public class ListRepository : IRepository<DalList>
    {
        private readonly DbContext context;
        public ListRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(DalList entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalList entity)
        {
            throw new NotImplementedException();
        }

        public DalList Find(Expression<Func<DalList, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalList> FindAll(Expression<Func<DalList, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalList> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalList GetById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(DalList entity)
        {
            throw new NotImplementedException();
        }
    }
}