﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies;
using DataAccess.Interfacies.Entities;
using ORMLibrary;
using DataAccessLibrary.Mappers;

namespace DataAccessLibrary.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ProjectDataEntities context;
        public BookRepository(ProjectDataEntities context)
        {
            this.context = context;
        }

        public void AddAuthor(DalBook book, DalAuthor author)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            if (dbBook != null)
                dbBook.Authors.Add(author.ToOrmAuthor());
        }

        public void AddComment(DalBook book, DalUser user, DalComment comment)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            var dbUser = context.Users.FirstOrDefault(e => e.UserID == user.ID);
            if (dbBook != null && dbUser != null)
            {
                comment.BookID = book.ID;
                comment.UserID = user.ID;
                context.Comments.Add(comment.ToOrmComment());
            }
        }

        public void AddContent(DalBook book, DalUser user, DalContent content)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            var dbUser = context.Users.FirstOrDefault(e => e.UserID == user.ID);
            if (dbBook != null && dbUser != null)
            {
                content.BookID = book.ID;
                content.UserID = user.ID;
                context.Contents.Add(content.ToOrmContent());
            }
        }

        public void AddCover(DalBook book, DalCover cover)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            if (dbBook != null)
            {
                dbBook.Covers.Add(cover.ToOrmCover());
            }
        }

        public void AddFile(DalBook book, DalFile file)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            if (dbBook != null)
            {
                dbBook.Files.Add(file.ToOrmFile());
            }
        }

        public void AddGenre(DalBook book, DalGenre genre)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            if (dbBook != null)
            {
                dbBook.Genres.Add(genre.ToOrmGenre());
            }
        }

        public void AddLike(DalBook book, DalUser user, DalLike like)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            var dbUser = context.Users.FirstOrDefault(e => e.UserID == user.ID);
            if (dbBook != null && dbUser != null)
            {
                like.BookID = book.ID;
                like.UserID = user.ID;
                context.Likes.Add(like.ToOrmLike());
            }
        }

        public void AddReview(DalBook book, DalUser user, DalReview review)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            var dbUser = context.Users.FirstOrDefault(e => e.UserID == user.ID);
            if (dbBook != null && dbUser != null)
            {
                review.BookID = book.ID;
                review.UserID = user.ID;
                context.Reviews.Add(review.ToOrmReview());
            }
        }

        public void AddScreening(DalBook book, DalScreening screening)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            if (dbBook != null)
            {
                dbBook.Screenings.Add(screening.ToOrmScreening());
            }
        }

        public void AddTag(DalBook book, DalTag tag)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            if (dbBook != null)
            {
                dbBook.Tags.Add(tag.ToOrmTag());
            }
        }

        public int Create(DalBook entity)
        {
            Books book = context.Books.Add(entity.ToOrmBook());
            return book.BookID;
        }

        public void Delete(DalBook entity)
        {
            var book = context.Books.FirstOrDefault(e => e.BookID == entity.ID);
            if (book != null)
                context.Books.Remove(book);
        }

        public void DeleteAuthor(DalBook book, DalAuthor author)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            var dbAuthor = context.Authors.FirstOrDefault(e => e.AuthorID == author.ID);
            if (dbBook != null && dbAuthor!=null)
                dbBook.Authors.Remove(dbAuthor);
        }

        public void DeleteComment(DalComment comment)
        {
            var dbComment = context.Comments.FirstOrDefault(e => e.CommentID == comment.ID);
            if (dbComment != null)
                context.Comments.Remove(dbComment);

        }

        public void DeleteContent(DalContent content)
        {
            var dbContent = context.Contents.FirstOrDefault(e => e.ContentID == content.ID);
            if (dbContent != null)
                context.Contents.Remove(dbContent);
        }

        public void DeleteCover(DalCover cover)
        {
            var dbCover = context.Covers.FirstOrDefault(e => e.CoverID == cover.ID);
            if (dbCover != null)
                context.Covers.Remove(dbCover);
        }

        public void DeleteFile(DalFile file)
        {
            var dbFile = context.Files.FirstOrDefault(e =>e.FileID == file.ID);
            if (dbFile != null)
            {
                if (File.Exists(dbFile.Path))
                    File.Delete(dbFile.Path);
                context.Files.Remove(dbFile);
            }
        }

        public void DeleteGenre(DalBook book, DalGenre genre)
        {
            var dbGenre = context.Genres.FirstOrDefault(e => e.GenreID == genre.ID);
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            if (dbBook != null && dbGenre != null)
                dbBook.Genres.Remove(dbGenre);
        }

        public void DeleteLike(DalLike like)
        {
            var dbLike = context.Likes.FirstOrDefault(e => e.LikeID == like.ID);
            if (dbLike != null)
                context.Likes.Remove(dbLike);
        }

        public void DeleteReview(DalReview reivew)
        {
            var dbReview = context.Reviews.FirstOrDefault(e => e.ReviewID == reivew.ID);
            if (dbReview != null)
                context.Reviews.Remove(dbReview);
        }

        public void DeleteScreening(DalScreening screening)
        {
            var dbScr = context.Screenings.FirstOrDefault(e => e.ScreeningID == screening.ID);
            if (dbScr != null)
                context.Screenings.Remove(dbScr);
        }

        public void DeleteTag(DalBook book, DalTag tag)
        {
            var dbTag = context.Tags.FirstOrDefault(e => e.TagID == tag.ID);
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            if (dbBook != null && dbTag != null)
                dbBook.Tags.Remove(dbTag);
        }

        public DalBook Find(Expression<Func<DalBook, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalBook> FindAll(Expression<Func<DalBook, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalBook> GetAll()
        {
            return context.Books.ToList().Select(e => e.ToDalBook());
        }

        public IEnumerable<DalAuthor> GetAuthors(DalBook book)
        {
            return context.Books.FirstOrDefault(e => e.BookID == book.ID)?.Authors.Select(e => e.ToDalAuthor());
        }

        public DalBook GetById(int key)
        {
            return context.Books.FirstOrDefault(e => e.BookID == key)?.ToDalBook();
        }

        public IEnumerable<DalComment> GetComments(DalBook book)
        {
            return context.Books.FirstOrDefault(e => e.BookID == book.ID)?.Comments.Select(e => e.ToDalComment());
        }

        public IEnumerable<DalContent> GetContents(DalBook book)
        {
            return context.Books.FirstOrDefault(e => e.BookID == book.ID)?.Contents.Select(e => e.ToDalContent());
        }

        public IEnumerable<DalCover> GetCovers(DalBook book)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            if (dbBook != null)
                return dbBook.Covers.Select(e=>e.ToDalCover());
            return new List<DalCover>();
        }

        public IEnumerable<DalFile> GetFiles(DalBook book)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            if (dbBook != null)
                return dbBook.Files.Select(e => e.ToDalFile());
            return new List<DalFile>();
        }

        public IEnumerable<DalGenre> GetGenres(DalBook book)
        {
            return context.Books.FirstOrDefault(e => e.BookID == book.ID)?.Genres.Select(e => e.ToDalGenre());
        }

        public IEnumerable<DalLike> GetLikes(DalBook book)
        {
            return context.Books.FirstOrDefault(e => e.BookID == book.ID)?.Likes.Select(e => e.ToDalLike());
        }

        public IEnumerable<DalReview> GetReviews(DalBook book)
        {
            return context.Books.FirstOrDefault(e => e.BookID == book.ID)?.Reviews.Select(e => e.ToDalReview());
        }

        public IEnumerable<DalScreening> GetScreenings(DalBook book)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            if (dbBook != null)
                return dbBook.Screenings.Select(e => e.ToDalScreening());
            return new List<DalScreening>();
        }

        public IEnumerable<DalTag> GetTags(DalBook book)
        {
            return context.Books.FirstOrDefault(e => e.BookID == book.ID)?.Tags.Select(e => e.ToDalTag());
        }

        public void Update(DalBook entity)
        {
            var a = context.Books.FirstOrDefault(e => e.BookID == entity.ID);
            if (a != null)
            {
                a.Age_Caegory = entity.AgeCategory;
                a.First_Publication = entity.FirstPublication;
                a.Name = entity.Name;
            }
        }
    }
}
