using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMe.Core
{
    public class NetworkChallenge
    {
        public static bool ResolveChallenge(string challenge, string difficulty, string arg)
        {
            if (difficulty == "easy")
            {
                if (challenge == "0")
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
                if (challenge == "1")
                {
                    if (arg.ToLower() == "physique")
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
                    if (arg == "8")
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
                    if (arg == "255")
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
            return false;
        }
    }
}
