using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MoodAnaliser
{
    public class moodAnalyserReflector<T>
    {
        /// <summary>
        /// create instance and return 
        /// </summary>
        /// <param name="constructor"> it is return bu dconstructor parameter</param>
        /// <param name="NameOfClass">we send as a string at calling </param>
        /// <returns></returns>
        public object creteMoodAnalyser(ConstructorInfo constructor, string NameOfClass)
        {
            try
            {
                // type of class assign to type using typeof
                Type type = typeof(T);
                //name of class is not equle to type.name then throw wexception otherwise continiue
                if (NameOfClass != type.Name)
                {
                    throw new moodAnalyseException(moodAnalyseException.ExceptionType.CLASS_NOT_FOUND, "class not found");
                }
                //constructor(void. const()) is not equle to ype.GetConstructors()[0] then throws exception otherwise continiue
                //at zero position i am store the type of default constructor
                if (constructor != type.GetConstructors()[0])
                {
                    throw new moodAnalyseException(moodAnalyseException.ExceptionType.METHOD_NOT_FOUND, "method not found");
                }               
                //create instance of MoodAnalyzer and return MoodAnaliser.MoodAnalyzer
                T ReturnObject = Activator.CreateInstance<T>();
                return ReturnObject;

            }
            //any exception created in try block it handle in cathc block
            catch (Exception ex)
            {
                throw new moodAnalyseException(moodAnalyseException.ExceptionType.NO_OBJECT_CREATED, ex.Message);
            }
        }
        /// <summary>
        /// create instance of parameterised constructor
        /// </summary>
        /// <param name="constructor">retern by parameterised constructor</param>
        /// <param name="NameOfClass">class neame send at calling</param>
        /// <param name="message">i am in happy mood or sad mood</param>
        /// <returns></returns>
        public object creteMoodAnalyser(ConstructorInfo constructor, string NameOfClass, string message)
        {
            try
            {
                //assign typeof genric type to tupe
                Type type = typeof(T);
                //name of class is not equle to type.name then throw wexception otherwise continiue
                if (NameOfClass != type.Name)
                {
                    throw new moodAnalyseException(moodAnalyseException.ExceptionType.CLASS_NOT_FOUND, "class not found");
                }
                //constructor(void. const(string)) is not equle to ype.GetConstructors()[1] then throws exception otherwise continiue
                //at 1 position i am store the type of parameterised constructor
                if (constructor != type.GetConstructors()[1])
                {
                    throw new moodAnalyseException(moodAnalyseException.ExceptionType.METHOD_NOT_FOUND, "method not found");
                }
                //create instance of and return MoodAnaliser.MoodAnalyzer
                object ReturnObject = Activator.CreateInstance(type, message);
                return ReturnObject;
            }
            //handle exception in vatch block
            catch (Exception ex)
            {
                throw new moodAnalyseException(moodAnalyseException.ExceptionType.NO_OBJECT_CREATED, ex.Message);
            }

        }
        /// <summary>
        /// use default constructor for reflection
        /// </summary>
        /// <returns>onstructor information</returns>
        public ConstructorInfo dConstructor()
        {
            try
            {   //type can identify the class of genric type
                Type type = typeof(T);
                //getconstructor return type of default constructor 
                ConstructorInfo[] constructor = type.GetConstructors();
                
                foreach (ConstructorInfo c in constructor)
                {   //getparameter is return parameter and length can find parameter length 
                    //if parameter length is zero then return constructor information like void.const();
                    if (c.GetParameters().Length == 0)
                    {
                        return c;
                    }
                }
                return constructor[0];
            }//if the class is not found then throwss exception and catch it and show message class is not available
            catch (Exception e)
            {
                throw new moodAnalyseException(moodAnalyseException.ExceptionType.CLASS_NOT_FOUND, "this class not available");

            }
        }
        /// <summary>
        /// send number of parameter to parameterised constructor
        /// </summary>
        /// <param name="noOfParameter"></param>
        /// <returns>constructor information</returns>
        public ConstructorInfo ParameteriseConstructor(int noOfParameter)
        {
            try
            {
                //type can identify the class of genric type
                Type type = typeof(T);
                //getconstructor return type of parameterised constructor 
                ConstructorInfo[] constructor = type.GetConstructors();
                foreach (ConstructorInfo c in constructor)
                {
                    //if parameters and number of parameter seme then return Void .ctor(System.String)
                    if (c.GetParameters().Length == noOfParameter)
                    {
                      
                        return c;
                    }
                }
                return constructor[0];
            }
            //if excpetion created then hande in cathch block
            catch (Exception e)
            {
                throw new moodAnalyseException(moodAnalyseException.ExceptionType.CLASS_NOT_FOUND, "this class not available");
            }
        }
        /// <summary>
        /// chenge mood dynamically  sending massage
        /// </summary>
        /// <param name="mood">send massage </param>
        /// <returns>daynamically send mood</returns>
        public dynamic ChengeMoodDynamically(string mood)
        {
            try
            {
                //type of moodanalyzer
                Type type = typeof(T);
                //it can return type constructor to constructor info
                ConstructorInfo[] constructor = type.GetConstructors();
                //get method from type if string is match with method then ok otherwise throws method not found
                MethodInfo method = type.GetMethod("analyseTheMood");
                //if mood is null then throws enter proper mood exception
                if (mood is null)
                {
                    throw new moodAnalyseException(moodAnalyseException.ExceptionType.NULL, "enter proper input");
                }
                else if (method is null)
                {
                    throw new moodAnalyseException(moodAnalyseException.ExceptionType.NO_SUCH_FIELD, "no such method");
                }
                //if no any exception then return mood dynamically 
                return mood;
            }
            //throws exception catch in catch block 
            catch (Exception e)
            {
                throw new moodAnalyseException(moodAnalyseException.ExceptionType.NO_SUCH_FIELD, e.Message);
            }
        }
    }
}