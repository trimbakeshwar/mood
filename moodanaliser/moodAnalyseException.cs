using System;
using System.Collections.Generic;
using System.Text;

namespace moodanaliser
{
    public class moodAnalyseException : Exception
    {
        public enum ExceptionType
        {
            EMPTY, NULL,
            CLASS_NOT_FOUND,
            NO_OBJECT_CREATED,
            METHOD_NOT_FOUND
        }
        ExceptionType type;
        public moodAnalyseException(ExceptionType type, string massage) : base(massage)
        {
            this.type = type;
        }
    }
}
