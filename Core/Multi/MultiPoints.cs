using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMe.Core.Multi
{
    public class MultiPoints
    {

        public static string ReadOnlinePoints(string userid)
        {
           
                if (File.Exists(@"\data\multiplayer\onlinepoints\"+userid+".json"))
                {
                    return File.ReadAllText(@"\data\multiplayer\onlinepoints\" + userid + ".json");

                }
                else
                {
                    return "0";
                }

            
        }

        public static void AddOnlinePoints(string userid)
        {
            if (File.Exists("data/multiplayer/onlinepoints/"+userid+".json"))
            {
                string points = File.ReadAllText("data/multiplayer/onlinepoints/"+userid+".json");
                int pts = Convert.ToInt32(points);
                int result = pts + 1;
                File.WriteAllText("data/multiplayer/onlinepoints/"+userid+".json",result.ToString());
            }
            else
            {
                var c = File.Create("data/multiplayer/onlinepoints/"+userid+".json");
                c.Close();
                c.Dispose();
                File.WriteAllText("data/multiplayer/onlinepoints/"+userid+".json","1");
            }
        }
    }
}
