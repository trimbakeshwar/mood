using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace moodanaliser
{
        public class moodAnalyserReflector<T>
        {
            public object creteMoodAnalyser( ConstructorInfo constructor, string NameOfClass)
            {
                try
                {
                    Type type = typeof(T);
                    Console.WriteLine("name " + type.Name);
                    Console.WriteLine("name const " + constructor);
                    Console.WriteLine("name getconst " + type.GetConstructors()[0]);
                    if (NameOfClass != type.Name)
                    {
                        throw new moodAnalyseException(moodAnalyseException.ExceptionType.CLASS_NOT_FOUND, "class not found");
                    }
                    if (constructor != type.GetConstructors()[0])
                    {
                        throw new moodAnalyseException(moodAnalyseException.ExceptionType.METHOD_NOT_FOUND, "method not found");
                    }
                    var obj = constructor.Invoke(new object[0]);
                    Console.WriteLine("name obj " + obj);
                    T ReturnObject = Activator.CreateInstance<T>();
                    Console.WriteLine("name return object " + ReturnObject);
                    return ReturnObject;

                }

                catch (Exception ex)
                {
                    throw new moodAnalyseException(moodAnalyseException.ExceptionType.NO_OBJECT_CREATED, ex.Message);
                }
            }
            public object creteMoodAnalyser(ConstructorInfo constructor, string NameOfClass, string message)
            {
                try
                {
                    Type type = typeof(T);
                    Console.WriteLine("name " + type.Name);
                    Console.WriteLine("name const " + constructor);
                    Console.WriteLine("name getconst " + type.GetConstructors()[1]);
                    if (NameOfClass != type.Name)
                    {
                        throw new moodAnalyseException(moodAnalyseException.ExceptionType.CLASS_NOT_FOUND, "class not found");
                    }
                    if (constructor != type.GetConstructors()[1])
                    {
                        throw new moodAnalyseException(moodAnalyseException.ExceptionType.METHOD_NOT_FOUND, "method not found");
                    }
                    object ReturnObject = Activator.CreateInstance(type, message);
                    return ReturnObject;
                }
                catch (Exception ex)
                {
                    throw new moodAnalyseException(moodAnalyseException.ExceptionType.NO_OBJECT_CREATED, ex.Message);
                }

            }
  
            public ConstructorInfo dConstructor()
            {
                try
                {
                    Type type = typeof(T);
                    ConstructorInfo[] constructor = type.GetConstructors();
                    foreach (ConstructorInfo c in constructor)
                    {
                        if (c.GetParameters().Length == 0)
                        {
                            return c;
                        }
                    }
                    return constructor[0];
                }
                catch (Exception e)
                {
                    throw new moodAnalyseException(moodAnalyseException.ExceptionType.CLASS_NOT_FOUND, "this class not available");

                }
            }
            public ConstructorInfo ParameteriseConstructor(int noOfParameter)
            {
               try
               {
                    Type type = typeof(T);
                    ConstructorInfo[] constructor = type.GetConstructors();
                    foreach (ConstructorInfo c in constructor)
                    {
                        if (c.GetParameters().Length == noOfParameter)
                        {
                            Console.WriteLine(c);
                            return c;
                        }
                    }
                    return constructor[0];
               }
               catch (Exception e)
               {
                    throw new moodAnalyseException(moodAnalyseException.ExceptionType.CLASS_NOT_FOUND, "this class not available");
               }
            }
        }
}