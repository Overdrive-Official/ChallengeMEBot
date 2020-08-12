using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMe.Modules
{
    public class InformationModule : ModuleBase<SocketCommandContext>
    {
        [Command("information")]
        public async Task InformationAsync()
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Information concernant ChallengeMe");
            embed.WithColor(220, 0, 0);
            embed.WithFooter("Created By Zelly");
            embed.WithDescription("ChallengeMe est un bot servant a résoudre des challenges et se pratiquer dans de diverses domaines."+Environment.NewLine+
                "**Challenges actuels disponibles**"+Environment.NewLine+
                "**C#:** Easy : 5 / Medium : 0 / Hard : 0"+Environment.NewLine+
                "**JavaScript:** Easy : 5 / Medium : 0 / Hard : 0"+Environment.NewLine+
                "**Obfuscation:** Easy : 1 / Medium : 0 / Hard : 0"+Environment.NewLine+
                "**Network:** Easy : 5 / Medium : 0 / Hard : 0");
            await Context.Channel.SendMessageAsync("",false,embed.Build());


        }


        [Command("rank")]
        public async Task RankAstbc()
        {
            DirectoryInfo d = new DirectoryInfo("data/points/");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.json"); //Getting Text files
            string str = "";
            List<string> pointsList = new List<string>();
            List<string> namelist = new List<string>();
            List<Tuple<string, int>> list = new List<Tuple<string, int>>();
            string final = "";

            foreach (FileInfo file in Files)
            {

                try
                {
                    string resut = File.ReadAllText(file.FullName);


                    ulong id = Convert.ToUInt64(file.Name.Replace(".json", ""));
                    var user = Context.Client.GetUser(id);
                    //namelist.Add(user.Username + "#" + user.Discriminator.ToString());
                    // pointsList.Add(resut);
                    int t = Convert.ToInt32(resut);
                    try
                    {
                        if (user != null)
                        {
                            list.Add(new Tuple<string, int>(user.Username + "#" + user.Discriminator, t));
                        }
                      
                    }
                    catch (Exception)
                    {

                       // throw;
                    }
                    //list.Add(new Tuple<string, int>(user.Username+"#"+user.Discriminator,t));
                }
                catch (Exception)
                {


                }
                
               
               
              
            }
            string result = "";
            int compt = 1;
            var lit = list.OrderByDescending(c => c.Item2);
            foreach (var item in lit)
            {
                if (compt<=10)
                {
                    final += compt.ToString() + ") " + item.Item1 + Environment.NewLine +
    "```Nombre de challenge réussi : " + item.Item2.ToString() + "```" + Environment.NewLine;
                    compt++;

                }
                
            }
            var embed = new EmbedBuilder();
            embed.WithTitle("Rank ChallengeMe");
            embed.WithThumbnailUrl(Context.Client.CurrentUser.GetAvatarUrl());
            embed.WithColor(220, 0, 0);
            embed.WithDescription(final);
            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
    }
}
