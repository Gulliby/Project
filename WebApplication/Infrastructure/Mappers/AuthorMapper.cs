﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Models.AuthorModels;

namespace WebApplication.Infrastructure.Mappers
{
    public static class AuthorMapper
    {
        public static AuthorCreateModel ToAuthorCreateModel(this ServiceAuthor author)
        {
            return new AuthorCreateModel()
            {
                Name = author.Name,
                BirthDate = author.BirthDate ?? new DateTime(),
                DeathDate = author.DeathDate ?? new DateTime(),
                Biography = author.Biography
            };
        }

        public static AuthorShortModel ToAuthorShortModel(this ServiceAuthor author)
        {
            return new AuthorShortModel()
            {
                ID = author.ID,
                Name = author.Name,
                PhotoPath = author.Photo
            };
        }

        public static AuthorEditModel ToAuthorEditModel(this ServiceAuthor author)
        {
            return new AuthorEditModel()
            {
                ID = author.ID,
                Name = author.Name,
                BirthDate = author.BirthDate ?? new DateTime(),
                DeathDate = author.DeathDate ?? new DateTime(),
                Biography = author.Biography,
                PhothPath = author.Photo
            };
        }


        public static ServiceAuthor ToServiceAuthor(this AuthorCreateModel author)
        {
            return new ServiceAuthor()
            {
                Name = author.Name,
                BirthDate = author.BirthDate,
                DeathDate = author.DeathDate,
                Biography = author.Biography
            };
        }

        public static ServiceAuthor ToServiceAuthor(this AuthorCreateModel author, string filepath)
        {
            return new ServiceAuthor()
            {
                Name = author.Name,
                BirthDate = author.BirthDate,
                DeathDate = author.DeathDate,
                Biography = author.Biography,
                Photo = filepath
            };
        }

        public static ServiceAuthor ToServiceAuthor(this AuthorEditModel author)
        {
            return new ServiceAuthor()
            {
                ID = author.ID,
                Name = author.Name,
                BirthDate = author.BirthDate,
                DeathDate = author.DeathDate,
                Biography = author.Biography,
                Photo = author.PhothPath
            };
        }
    }
}