
using moodanaliser;
using MoodAnaliser;
using NUnit.Framework;
using System;
using System.Reflection;

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
            [Test]
            public void checkFordefaultConstructor()
            {
                MoodAnalyzer mod = new MoodAnalyzer();
                moodAnalyserReflector<MoodAnalyzer> analyser = new moodAnalyserReflector<MoodAnalyzer>();
                ConstructorInfo returnObject = analyser.dConstructor();
                object constructor = analyser.creteMoodAnalyser(returnObject, "MoodAnalyzer");
                Assert.IsInstanceOf(typeof(MoodAnalyzer), constructor);
            }
            [Test]
            public void checkForClassNotFound()
            {
                try
                {
                    moodAnalyserReflector<MoodAnalyzer> analyser = new moodAnalyserReflector<MoodAnalyzer>();
                ConstructorInfo returnObject = analyser.dConstructor();
                    object constructor = analyser.creteMoodAnalyser(returnObject, "mood");
                }

                catch (Exception e)
                {
                    Assert.AreEqual("class not found", e.Message);
                }
            }


            [Test]
            public void checkForMethodNotFound()
            {
                try
                {
                    moodAnalyserReflector<MoodAnalyzer> analyser = new moodAnalyserReflector<MoodAnalyzer>();
                    ConstructorInfo returnObject = analyser.dConstructor();
                    ConstructorInfo mood = null;
                    object constructor = analyser.creteMoodAnalyser(mood, "MoodAnalyzer");
                }
                catch (Exception e)
                {
                    Assert.AreEqual("method not found", e.Message);
                }
            }
            [Test]
            public void checkForParamterisedConstructor()
            {
                MoodAnalyzer mod = new MoodAnalyzer("i am in sad mood");
                moodAnalyserReflector<MoodAnalyzer> analyser = new moodAnalyserReflector<MoodAnalyzer>();
                ConstructorInfo returnObject = analyser.ParameteriseConstructor(1);  
                object constructor = analyser.creteMoodAnalyser(returnObject, "MoodAnalyzer", "i am in sad mood");
                Assert.IsInstanceOf(typeof(MoodAnalyzer), constructor);

            }
        }
    }