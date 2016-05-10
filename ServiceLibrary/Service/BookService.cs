﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies;
using DataAccess.Interfacies.Entities;
using Service.Interfacies;
using Service.Interfacies.Entities;
using ServiceLibrary.Mappers;

namespace ServiceLibrary.Service
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork unit;

        public BookService(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public void AddBook(ServiceBook book)
        {
            unit.Books.Create(book.ToDalBook());
        }

        public void AddCover(ServiceBook book, ServiceCover cover)
        {
            unit.Books.AddCover(book.ToDalBook(), cover.ToDalCover());
        }

        public void AddFile(ServiceBook book, ServiceFile file)
        {
            unit.Books.AddFile(book.ToDalBook(), file.ToDalFile());
        }

        public void AddScreening(ServiceBook book, ServiceScreening screening)
        {
            unit.Books.AddScreening(book.ToDalBook(), screening.ToDalScreening());
        }

        public IEnumerable<ServiceBook> FindAll(Func<ServiceBook, bool> func)
        {
            throw new NotImplementedException();
        }

        public ServiceBook FindFirst(Func<ServiceBook, bool> func)
        {
            throw new NotImplementedException();
        }

        public ServiceBook GetBookById(int id)
        {
            return unit.Books.GetById(id)?.ToServiceBook();
        }

        public Stream GetBookFile(ServiceFile file)
        {
            DalBook book = unit.Books.GetById(file.BookID);
            return new FileStream(unit.Books.GetFiles(book).Single(e => e.ID == file.ID).Path, FileMode.Open,
                FileAccess.Read);
        }

        public ServiceFullBook GetFullBookInfo(ServiceBook book)
        {
            ServiceFullBook fBook = new ServiceFullBook();
            fBook.BookData = book;
            fBook.Authors = unit.Books.GetAuthors(book.ToDalBook()).Select(e => e.ToServiceAuthor());
            fBook.Covers = unit.Books.GetCovers(book.ToDalBook()).Select(e => e.ToServiceCover());
            fBook.Files = unit.Books.GetFiles(book.ToDalBook()).Select(e => e.ToServiceFile());
            fBook.Genres = unit.Books.GetGenres(book.ToDalBook()).Select(e => e.ToServiceGenre());
            fBook.Screeninigs = unit.Books.GetScreenings(book.ToDalBook()).Select(e => e.ToServiceScreening());
            fBook.Tags = unit.Books.GetTags(book.ToDalBook()).Select(e => e.ToServiceTag());
            return fBook;
        }

        public ServiceFullBook GetFullBookInfo(int id)
        {
            ServiceBook book = unit.Books.GetById(id).ToServiceBook();
            return GetFullBookInfo(book);
        }

        public IEnumerable<ServiceBook> GetUserBooks(ServiceUser user)
        {
            return
                unit.Collections.GetUserCollections(user.ToDalUser())
                    .SelectMany(cl => unit.Collections.GetCollcetionBooks(cl).Select(e => e.ToServiceBook()));
        }

        public ServiceBook RandomBook()
        {
            Random random = new Random();
            DalBook book = null;
            while (book == null)
                book = unit.Books.GetById(random.Next());
            return book.ToServiceBook();
        }

        public ServiceBook RandomBook(Func<ServiceBook, bool> func)
        {
            throw new NotImplementedException();
        }

        public void RemoveBook(ServiceBook book)
        {
            unit.Books.Delete(book.ToDalBook());
        }

        public void RemoveCover(ServiceCover cover)
        {
            unit.Books.DeleteCover(cover.ToDalCover());
        }

        public void RemoveFile(ServiceFile file)
        {
            unit.Books.DeleteFile(file.ToDalFile());
        }

        public void RemoveScreening(ServiceScreening screening)
        {
            unit.Books.DeleteScreening(screening.ToDalScreening());
        }

        public void UpdateBook(ServiceBook book)
        {
            unit.Books.Update(book.ToDalBook());
        }
    }
}