﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using Service.Interfacies.Entities;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.CollectionBookModels;
using WebApplication.Models.CollectionModels;
using WebApplication.Models.ViewModels.CollectionBookModels;

namespace WebApplication.Models.DataModels
{
    public class CollectionBook : IEqualityComparer<ServiceCollectionBook>
    {
        private static readonly IServiceManager manager = DependencyResolver.Current.GetService<IServiceManager>();
        public static ReadBookModel GetReadBookModel(int id)
        {
            var cb = manager.collectionService.GetCollectionBookById(id);
            var b = manager.bookService.GetBookById(cb.BookID);
            ReadBookModel result = new ReadBookModel()
            {
                ID = b.ID,
                FilePath = "",
            };
            return result;
        }

        public static CollectionBookModel GetColectionBookModel(int id)
        {
            var cb = manager.collectionService.GetCollectionBookById(id);
            var dbCl = manager.collectionService.GetCollectionById(cb.CollectionID);
            var book = Book.GetBookShortModel(cb.BookID, dbCl.UserID);
            var cl = Collection.GetCollectionModel(manager.collectionService.GetCollectionById(cb.CollectionID));
            return cb.ToCollectionBookModel(book, cl);
        }

        public static CollectionBookPageModel GetCollectionBookPageModel(int id, int userID)
        {
            var cb = manager.collectionService.GetCollectionBookById(id);
            CollectionBookPageModel result = new CollectionBookPageModel(User.Get_UserProfileModel(userID));
            result.Book = GetColectionBookModel(id);
            result.Bookmarks = manager.collectionService.GetBookmarks(cb).Select(Bookmark.GetBookmarkModel);
            result.Quotes = manager.collectionService.GetQuotes(cb).Select(Quote.GetQuoteModel);
            result.Files = manager.bookService.GetBookFiles(manager.bookService.GetBookById(cb.BookID));
            return result;
        }

        public static BookInCollectionsModel GetBookInCollectionModel(int bookID, int userID)
        {
            BookInCollectionsModel result = new BookInCollectionsModel();
            var cwb = new List<CollectionModel>();
            var cwob = new List<CollectionModel>();
            result.BookID = bookID;
            if (userID > 0)
            {
                var user = manager.userService.GetUserById(userID);
                var collections = manager.collectionService.GetUserCollections(user);
                foreach (var cl in collections)
                {
                    if (manager.collectionService.GetCollectionBooks(cl).Any(e => e.BookID == bookID))
                        cwb.Add(Collection.GetCollectionModel(cl));
                    else
                        cwob.Add(Collection.GetCollectionModel(cl));
                }
            }
            result.CollectionsWithBook = cwb;
            result.CollectionsWithoutBook = cwob;
            return result;
        }

        public bool Equals(ServiceCollectionBook x, ServiceCollectionBook y)
        {
            return x.ID == y.ID;
        }

        public int GetHashCode(ServiceCollectionBook obj)
        {
            return obj.ID;
        }
    }
}