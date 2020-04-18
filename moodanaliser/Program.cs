using MoodAnaliser;
using System;
using System.Reflection;

namespace MoodAnaliser
{
    class Program
    {
        static void Main(string[] args)
        {

            MoodAnalyzer mod = new MoodAnalyzer("i am in sad mood");
            moodAnalyserReflector<MoodAnalyzer> analyser = new moodAnalyserReflector<MoodAnalyzer>();
            ConstructorInfo returnObject = analyser.ParameteriseConstructor(1);
            object constructor = analyser.creteMoodAnalyser(returnObject, "MoodAnalyzer", "i am in sad mood");
            Console.WriteLine("outputttt  " + constructor);
        }
    }
}
