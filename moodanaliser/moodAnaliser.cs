using System;
using System.Collections.Generic;
using System.Text;

namespace moodanaliser
{
    public class MoodAnalyzer
    {
        private string massage;

        public MoodAnalyzer(string massage)
        {
            this.massage = massage;
        }

        public string analyseTheMood()
        {
            if (massage.Contains("sad"))
            {
                return "sad";
            }
            else
            {
                return "happy";
            }
        }
    }
}
    