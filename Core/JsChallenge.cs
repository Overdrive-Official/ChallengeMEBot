using Microsoft.ClearScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ClearScript.V8;
using Microsoft.ClearScript.JavaScript;



namespace ChallengeMe.Core
{
    // The class For JS Challenge Resolver
    public class JsChallenge
    {
        public static bool ResolveChallenge(string challenge, string difficulty, string arg)
        {
            if (difficulty == "easy")
            {
                if (challenge == "0")
                {
                    using (var engine = new V8ScriptEngine())
                    {
                        try
                        {
                            engine.Evaluate("function MinutesToSeconds(minutes) { " + arg + " }");
                            int test = engine.Script.MinutesToSeconds(10);
                            if (test == 600)
                            {
                                engine.Dispose();

                                return true;
                            }
                            else
                            {
                                engine.Dispose();
                                return false;

                            }
                        }
                        catch (Exception)
                        {

                            return false;
                        }
                        
                    }

                }
                if (challenge == "1")
                {
                    using (var engine = new V8ScriptEngine())
                    {
                        try
                        {
                           
                            engine.Evaluate("function Addition(a,b) { " + arg + " }");
                            int test = engine.Script.Addition(10, 25);
                            Console.WriteLine(test.ToString());
                            if (test == 35)
                            {
                                engine.Dispose();

                                return true;
                            }
                            else
                            {
                                engine.Dispose();
                                return false;

                            }
                        }
                        catch (Exception)
                        {

                           
                        }
                    }
                }
                if (challenge == "2")
                {
                    using (var engine = new V8ScriptEngine())
                    {
                        try
                        {

                            engine.Evaluate("function Multiplication(a,b) { " + arg + " }");
                            int test = engine.Script.Multiplication(10, 25);
                            Console.WriteLine(test.ToString());
                            if (test == 250)
                            {
                                engine.Dispose();

                                return true;
                            }
                            else
                            {
                                engine.Dispose();
                                return false;

                            }
                        }
                        catch (Exception)
                        {


                        }
                    }
                }
                if (challenge == "3")
                {
                    using (var engine = new V8ScriptEngine())
                    {
                        try
                        {

                            engine.Evaluate("function Soustraction(a,b) { " + arg + " }");
                            int test = engine.Script.Soustraction(48, 25);
                            Console.WriteLine(test.ToString());
                            if (test == 23)
                            {
                                engine.Dispose();

                                return true;
                            }
                            else
                            {
                                engine.Dispose();
                                return false;

                            }
                        }
                        catch (Exception)
                        {


                        }
                    }
                }
                if (challenge == "4")
                {
                    using (var engine = new V8ScriptEngine())
                    {
                        try
                        {

                            engine.Evaluate("function Triangle(a,b) { " + arg + " }");
                            int test = engine.Script.Triangle(4, 7);
                            Console.WriteLine(test.ToString());
                            if (test == 14)
                            {
                                engine.Dispose();

                                return true;
                            }
                            else
                            {
                                engine.Dispose();
                                return false;

                            }
                        }
                        catch (Exception)
                        {


                        }
                    }
                }

            }
            return false;
        }
    }
}
