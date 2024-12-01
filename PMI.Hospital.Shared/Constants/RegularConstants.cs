﻿using System.Collections.Generic;

namespace PMI.Hospital.Shared.Constants
{
    /// <summary>
    /// Provides collection constants.
    /// </summary>
    public static class RegularConstants
    {
        /// <summary>
        /// The only letters expression.
        /// </summary>
        public const string OnlyLettersExpression = @"^[a-zA-Z ]+$";

        /// <summary>
        /// The date search expression.
        /// </summary>
        public const string SearchByDateExpression = @"^[A-Za-zА-Яа-я]{2}\d{4}(-\d{2}){0,2}(T\d{2}:\d{2}(:\d{2})?)?$";
    }
}
