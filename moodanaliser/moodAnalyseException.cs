using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnaliser
{
    public class moodAnalyseException : Exception
    {
        /// <summary>
        /// create exception type enum
        /// all exception type is written in enum
        /// </summary>
        public enum ExceptionType
        {
            EMPTY, NULL,
            CLASS_NOT_FOUND,
            NO_OBJECT_CREATED,
            METHOD_NOT_FOUND,
            NO_SUCH_FIELD
        }
        ExceptionType type;
        //create constructor and exted exception base class
        public moodAnalyseException(ExceptionType type, string massage) : base(massage)
        {
            this.type = type;
        }
    }
}
