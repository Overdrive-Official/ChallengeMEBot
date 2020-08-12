using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using IronPython;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace ChallengeMe.Core
{
    public class PythonChallenge
    {
        public static bool ResolverChallenge(string challid, string difficulty, string arg)
        {
            if (difficulty == "easy")
            {
                if (challid == "0")
                {

                    var engine = Python.CreateEngine();
                    var r = engine.Execute("def T(a=100,b=200):" +
                        "   "+arg);
                    
                    Console.WriteLine(r.T(0,0));
                    if (r.T(0,0) == "300")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
