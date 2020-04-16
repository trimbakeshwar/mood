
using moodanaliser;
using MoodAnaliser;
using NUnit.Framework;
using System;
namespace moodTest
{
        public class moodAnalyzerTest
        {
            MoodAnalyzer obj = null;
            [SetUp]
            public void Setup()
            {
            }

            [Test]
            public void checkForSad()
            {
                obj = new MoodAnalyzer("i am in sad mood");
                string mood = obj.analyseTheMood();
                Assert.AreEqual("sad", mood);
            }
            [Test]
            public void checkForHappy()
            {
                obj = new MoodAnalyzer("i am in any mood");
                string mood = obj.analyseTheMood();
                Assert.AreEqual("happy", mood);
            }
            [Test]
            public void checkForEmptyException()
            {
                string massage = "";
                obj = new MoodAnalyzer(massage);
                try
                {
                    string mood = obj.analyseTheMood();
                }
                catch (moodAnalyseException exception)
                {
                    Assert.AreEqual("this is empty ,please enter proper mood", exception.Message);
                }
            }
            [Test]
            public void checkForNullException()
            {
                obj = new MoodAnalyzer(null);
                try
                {
                    string mood = obj.analyseTheMood();
                }
                catch (moodAnalyseException exception)
                {
                    Assert.AreEqual("please enter proper mood", exception.Message);
                }
            }
        }
    }