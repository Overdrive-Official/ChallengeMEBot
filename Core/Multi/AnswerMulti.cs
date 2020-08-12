using Microsoft.ClearScript.V8;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMe.Core.Multi
{
    public class AnswerMulti
    {
        public static bool ResolveChallenge(string challid, string langage, string difficulty, string arg)
        {
            bool IsSuccess = false;
            if (langage == "c#" || langage.ToLower() == "csharp")
            {
                if (difficulty == "easy")
                {
                    if (challid == "0")
                    {
                        // Console.WriteLine("challid 0");
                        IsSuccess = false;
                        var a = CSharpScript.EvaluateAsync<int>("int a = 200; int b = 300;" + arg);
                        if (a.Result.ToString() == "500")
                        {
                            return true;

                        }
                        else
                        {
                            return false;
                            Console.WriteLine("FALSE");
                            Console.WriteLine(a.Result.ToString());
                        }
                    }
                    if (challid == "1")
                    {
                        var a = CSharpScript.EvaluateAsync<int>("int minutes = 10;" + arg);
                        if (a.Result.ToString() == "600")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (challid == "2")
                    {
                        string req = "string[] mots = new string[3]{*chien*, *chat*, *renard*};";
                        var a = CSharpScript.EvaluateAsync(req.Replace('*', '"') + arg);
                        if (a.Result.ToString() == "chien")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (challid == "3")
                    {
                        var a = CSharpScript.EvaluateAsync<int>("int nombre = 28; " + arg);
                        Console.WriteLine(a.Result.ToString());

                        if (arg == "return nombre++;")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }


                    }
                    if (challid == "4")
                    {
                        var a = CSharpScript.EvaluateAsync("int nombre = 12;" + arg);
                        if (arg == "return nombre.ToString();")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                }
                if (difficulty == "medium")
                {
                    IsSuccess = false;
                }
                if (difficulty == "hard")
                {
                    IsSuccess = false;
                }
                return IsSuccess;
            
            }
            if (langage.ToLower() == "network")
            {
                if (difficulty == "easy")
                {
                    if (challid == "0")
                    {
                        if (arg == "8")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (challid == "1")
                    {
                        if (arg == "physique")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (challid == "2")
                    {
                        if (arg == "8")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (challid == "3")
                    {
                        if (arg == "255")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (challid == "4")
                    {
                        if (arg == "HTTP" || arg == "http")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            if (langage.ToLower() == "js" || langage.ToLower() == "javascript")
            {
                if (difficulty == "easy")
                {
                    if (challid == "0")
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
                                engine.Dispose();
                                return false;
                            }

                        }
                    }
                    if (challid == "1")
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
                                engine.Dispose();
                                return false;
                            }
                        }
                    }
                    if (challid == "2")
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
                                engine.Dispose();
                                return false;
                            }
                        }
                    }
                    if (challid=="3")
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

                                engine.Dispose();
                                return false;
                            }
                        }
                    }
                    if (challid == "4")
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

                                engine.Dispose();
                                return false;
                            }
                        }
                    }

                }
            
            }
            return false;
        }
    }
}
