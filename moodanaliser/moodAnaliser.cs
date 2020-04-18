using MoodAnaliser;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnaliser
{
    public class MoodAnalyzer
    {
        private string massage;
        //default constructor
        public MoodAnalyzer()
        {
        }
        /// <summary>
        /// parameterised constructor and initialize massage
        /// </summary>
        /// <param name="massage"></param>
        public MoodAnalyzer(string massage)
        {
            this.massage = massage;
           
        }
        /// <summary>
        /// it can analise mood 
        /// </summary>
        /// <returns>return happy or sad</returns>
        public string analyseTheMood()
        {
            try
            {
                //massage length is zero then throws this is empty 
                if (massage.Length == 0)
                {
                    throw new moodAnalyseException(moodAnalyseException.ExceptionType.EMPTY, "this is empty ,please enter proper mood");
                }
                //if massage contains sad then return sad otherwise return happy
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
    