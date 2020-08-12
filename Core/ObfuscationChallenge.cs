using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMe.Core
{
    public class ObfuscationChallenge
    {
        public static bool ResolveChallenge(string challenge, string difficulty, string arg)
        {
            if (difficulty == "easy")
            {
                if (challenge == "0")
                {
                    if (arg == "20")
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
