﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;

namespace DataAccess.Interfacies
{
    public interface ICollectionRepository : IRepository<DalCollection>
    {
        IEnumerable<DalCollection> GetUserCollections(DalUser user);
        DalCollectionBook GetCollectionBook(int id);
        IEnumerable<DalCollectionBook> GetCollectionBooks(DalCollection collection);
        IEnumerable<DalBook> GetCollcetionBooks(DalCollection collection);
        void AddUserCollection(DalCollection collection);
        void AddBook(DalCollection collection, DalBook book);
        void DeleteBook(DalCollectionBook book);
        void MoveBook(DalCollectionBook book, DalCollection collection);
        void AddBookmark(DalBookmark bookmark);
        DalBookmark GetBookmark(int id);
        void DeleteBookmark(DalBookmark bookmark);
        IEnumerable<DalBookmark> GetBookmarks(DalCollectionBook cb);
        void AddQuote(DalQuote quote);
        DalQuote GetQuote(int id);
        void DeleteQuote(DalQuote quote);
        IEnumerable<DalQuote> GetQuotes(DalCollectionBook cb);
    }
}
