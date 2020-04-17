using moodanaliser;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnaliser
{
    public class MoodAnalyzer
    {
        private string massage;

        public MoodAnalyzer()
        {
        }

        public MoodAnalyzer(string massage)
        {
            this.massage = massage;
        }

        public string analyseTheMood()
        {
            try
            {
                if (massage.Length == 0)
                {
                    throw new moodAnalyseException(moodAnalyseException.ExceptionType.EMPTY, "this is empty ,please enter proper mood");
                }
                if (massage.Contains("sad"))
                {
                    return "sad";
                }
                else
                {
                    return "happy";
                }

            }
            catch (NullReferenceException e)
            {
                throw new moodAnalyseException(moodAnalyseException.ExceptionType.NULL, "please enter proper mood");
            }

        }
    }
}
    