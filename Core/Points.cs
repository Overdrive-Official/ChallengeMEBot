using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMe.Core
{
    public class Points
    {
        public static int ReadPoints(Discord.IUser user)
        {
            if (File.Exists("data/points/"+user.Id.ToString()+".json"))
            {
                string result = File.ReadAllText("data/points/" + user.Id.ToString() + ".json");

                int res = Convert.ToInt32(result);
                return res;
            }
            else
            {
                return 0;
            }
         
        }
        public static int ReadLosePoints(Discord.IUser user)
        {
            if (File.Exists("data/lose/"+user.Id.ToString()+".json"))
            {
                string result = File.ReadAllText("data/lose/"+user.Id.ToString()+".json");
                int rest = Convert.ToInt32(result);
                return rest;
            }
            else
            {
                return 0;
            }
        }
        public static void AddLosePoints(Discord.IUser user , int points)
        {
            if (File.Exists("data/lose/"+user.Id.ToString() + ".json"))
            {
                string result = File.ReadAllText("data/lose/"+user.Id.ToString()+".json");
                int rest = Convert.ToInt32(result) + points;
                File.WriteAllText("data/lose/"+user.Id.ToString()+".json",rest.ToString());
            }
            else
            {
                var c = File.Create("data/lose/"+user.Id.ToString() +".json");
                c.Close();
                c.Dispose();
                File.WriteAllText("data/lose/"+user.Id.ToString()+".json",points.ToString());
            }
        }

        public static void AddPoints(Discord.IUser user, int points)
        {
            if (File.Exists("data/points/"+user.Id.ToString()+".json"))
            {
                string result = File.ReadAllText("data/points/"+user.Id.ToString()+".json");

                int rest = Convert.ToInt32(result) + points;

                File.WriteAllText("data/points/"+user.Id.ToString()+".json",rest.ToString());
            }
            else
            {
                var c = File.Create("data/points/"+user.Id.ToString()+".json");
                c.Close();
                c.Dispose();
                File.WriteAllText("data/points/"+user.Id.ToString()+".json",points.ToString());
            }
        }




    }
}
