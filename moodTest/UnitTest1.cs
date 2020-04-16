
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
            public void checkHappyForNull()
            {
                obj = new MoodAnalyzer(null);
                string mood = obj.analyseTheMood();
                Assert.AreEqual("happy", mood);
            }
    }
    }