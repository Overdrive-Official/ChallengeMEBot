using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace ChallengeMe.Core
{
    public class CsharpChallenge
    {
        public static bool ResolveChallenge(string challenge, string difficulty, string arg)
        {
            bool IsSuccess = false;
            if (difficulty == "easy")
            {
                if (challenge == "0")
                {
                   // Console.WriteLine("challenge 0");
                    IsSuccess = false;
                    var a = CSharpScript.EvaluateAsync<int>("int a = 200; int b = 300;"+arg);
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
                if (challenge == "1")
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
                if (challenge == "2")
                {
                    string req = "string[] mots = new string[3]{*chien*, *chat*, *renard*};";
                    var a = CSharpScript.EvaluateAsync(req.Replace('*','"') + arg);
                    if (a.Result.ToString() == "chien")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                if (challenge == "3")
                {
                    var a = CSharpScript.EvaluateAsync<int>("int nombre = 28; "+arg);
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
                if (challenge == "4")
                {
                    var a = CSharpScript.EvaluateAsync("int nombre = 12;"+arg);
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
    }
}
