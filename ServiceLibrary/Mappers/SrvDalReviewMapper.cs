﻿using DataAccess.Interfacies.Entities;
using Service.Interfacies.Entities;

namespace ServiceLibrary.Mappers
{
    public static class DalOrmReviewMapper
    {
        public static ServiceReview ToServiceReview(this DalReview review)
        {
            return new ServiceReview
            {
                ID = review.ID,
                BookID = review.BookID,
                UserID = review.UserID,
                Text = review.Text
            };
        }

        public static DalReview ToDalReview(this ServiceReview review)
        {
            return new DalReview
            {
                ID = review.ID,
                BookID = review.BookID,
                UserID = review.UserID,
                Text = review.Text
            };
        }
    }
}
