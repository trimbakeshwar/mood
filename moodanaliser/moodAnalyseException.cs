using System;
using System.Collections.Generic;
using System.Text;

namespace moodanaliser
{
    public class moodAnalyseException : Exception
    {
        public enum ExceptionType
        {
            EMPTY, NULL
        }
        ExceptionType type;
        public moodAnalyseException(ExceptionType type, string massage) : base(massage)
        {
            this.type = type;
        }
    }
}
