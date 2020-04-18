
using MoodAnaliser;
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
        /// <summary>
        /// check for sad 
        /// </summary>
            [Test]
            public void checkForSad()
            {
                //create object of moodanalyzer constructor
                obj = new MoodAnalyzer("i am in sad mood");
                //massage contain sad then analyseTheMood return sad
                string mood = obj.analyseTheMood();
                //if string and mood is same test case pass
                Assert.AreEqual("sad", mood);
            }
        /// <summary>
        /// check for happy
        /// </summary>
            [Test]
            public void checkForHappy()
            {
                //create object of moodanalyzer constructor
                obj = new MoodAnalyzer("i am in any mood");
                //massage does not contain sad then analyseTheMood return happy
                string mood = obj.analyseTheMood();
                //if string and mood is same test case pass
                Assert.AreEqual("happy", mood);
            }
        /// <summary>
        /// if we send empty massage throws exception
        /// </summary>
            [Test]
            public void checkForEmptyException()
            {
                //empty massege send to object
                string massage = "";
                obj = new MoodAnalyzer(massage);
                try
                {
                    //throes the exception
                    string mood = obj.analyseTheMood();
                }
                catch (moodAnalyseException exception)
                {
                    Assert.AreEqual("this is empty ,please enter proper mood", exception.Message);
                }
            }
        /// <summary>
        /// send null value then throws null exception
        /// </summary>
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
        /// <summary>
        /// check for reflection default constructor
        /// </summary>
            [Test]
            public void checkFordefaultConstructor()
            {
                //MoodAnalyzer mod = new MoodAnalyzer();
                //create mood analyser reflection object analyser
                moodAnalyserReflector<MoodAnalyzer> analyser = new moodAnalyserReflector<MoodAnalyzer>();
                //call the default constructor
                //return the constructor information to the return object
                ConstructorInfo returnObject = analyser.dConstructor();
                //pass the return object as argument to createmoodanaliser and class name as a string argument
                object constructor = analyser.creteMoodAnalyser(returnObject, "MoodAnalyzer");
                //if constructor name and moodanalyzer same then pass the test
                Assert.IsInstanceOf(typeof(MoodAnalyzer), constructor);
            }
        /// <summary>
        /// check for class not found
        /// </summary>
            [Test]
            public void checkForClassNotFound()
            {
                try
                {
                    //create mood analyser reflection object analyser
                    moodAnalyserReflector<MoodAnalyzer> analyser = new moodAnalyserReflector<MoodAnalyzer>();
                    //call the default constructor
                    //return the constructor information to the return object
                    ConstructorInfo returnObject = analyser.dConstructor();
                    //send the wrong class name as string and throws exception
                    object constructor = analyser.creteMoodAnalyser(returnObject, "mood");
                }

                catch (Exception e)
                {
                    //if e.massage same as class not found then pass the test
                    Assert.AreEqual("class not found", e.Message);
                }
            }

        /// <summary>
        /// ccheck for method not found
        /// </summary>
            [Test]
            public void checkForMethodNotFound()
            {
                try
                {
                    //create mood analyser reflection object analyser
                    moodAnalyserReflector<MoodAnalyzer> analyser = new moodAnalyserReflector<MoodAnalyzer>();
                    //call the default constructor
                    //return the constructor information to the return object
                    ConstructorInfo returnObject = analyser.dConstructor();
                    //send null as constructor information it throws excption
                    ConstructorInfo mood = null;
                    object constructor = analyser.creteMoodAnalyser(mood, "MoodAnalyzer");
                }
                catch (Exception e)
                {
                    //method not found and e.massage same then pass the test
                    Assert.AreEqual("method not found", e.Message);
                }
            }
        /// <summary>
        /// check for reflection parameterised constructor
        /// </summary>
            [Test]
            public void checkForParamterisedConstructor()
            {
                MoodAnalyzer mod = new MoodAnalyzer("i am in sad mood");
                //create mood analyser reflection object analyser
                moodAnalyserReflector<MoodAnalyzer> analyser = new moodAnalyserReflector<MoodAnalyzer>();
                //call the parameterised constructor
                //return the constructor information to the return object
                ConstructorInfo returnObject = analyser.ParameteriseConstructor(1);  
                //send return object as argument to create mood analuser
                object constructor = analyser.creteMoodAnalyser(returnObject, "MoodAnalyzer", "i am in sad mood");
                //object provided as an actual value is an instance of the expected type at that time we use isinstanceof
                Assert.IsInstanceOf(typeof(MoodAnalyzer), constructor);

            }
        /// <summary>
        /// chec for class not found for parameterisesd constructor
        /// </summary>
            [Test]
            public void checkForClassNotFoundForParameterisedConstructor()
            {
                try
                {
                    //create mood analyser reflection object analyser
                    moodAnalyserReflector<MoodAnalyzer> analyser = new moodAnalyserReflector<MoodAnalyzer>();
                    //call the default constructor
                    //return the constructor information to the return object
                    ConstructorInfo returnObject = analyser.ParameteriseConstructor(1);
                    // send wrong class as argumet then throws exception and catch in catch block
                    object constructor = analyser.creteMoodAnalyser(returnObject, "mood","i am in sad mood");
                }

                catch (Exception e)
                {
                    //exception massage same ass class not found then pass the test
                    Assert.AreEqual("class not found", e.Message);
                }
            }

        /// <summary>
        ///  check For Method Not Found For Parameterised Constructor
        /// </summary>
            [Test]
            public void checkForMethodNotFoundForParameterisedConstructor()
            {
                try
                {
                    //create mood analyser reflection object analyser
                    moodAnalyserReflector<MoodAnalyzer> analyser = new moodAnalyserReflector<MoodAnalyzer>();
                    //call the default constructor
                    //return the constructor information to the return object
                    ConstructorInfo returnObject = analyser.ParameteriseConstructor(1);
                    //send null ass ConstructorInfo and throws exception catch in catch block
                    ConstructorInfo mood = null;
                    object constructor = analyser.creteMoodAnalyser(mood, "MoodAnalyzer","i am in sad mood");
                }
            catch (Exception e)
            {
                //exception massage same ass "method not found" then pass the test
                Assert.AreEqual("method not found", e.Message);
            }
        }
        /// <summary>
        /// check for chenge mood 
        /// </summary>
        [Test]
        public void checkforchengeMood()
        {
            //create mood analyser reflection object analyser
            moodAnalyserReflector<MoodAnalyzer> analyser = new moodAnalyserReflector<MoodAnalyzer>();
            string result=analyser.ChengeMoodDynamically("happy");
            Assert.AreEqual("happy", result);
        }

    }
}