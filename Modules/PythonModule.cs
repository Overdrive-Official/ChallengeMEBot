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
    public class PythonModule : ModuleBase<SocketCommandContext>
    {
        [Command("python_challenge")]
        public async Task PythonChallAsync(string difficulty)
        {
            if (File.Exists("data/challenge/" + Context.User.Id.ToString() + ".json"))
            {
                await Context.Channel.SendMessageAsync("Vous avez deja un Challenge en cours");
            }
            else
            {
                Random rdm = new Random();
                int result = rdm.Next(0, 4);
                // FORCE CHALLENGE
                //result = 4;
                var embed = new EmbedBuilder();
                embed.WithFooter("Created By Zelly");
                embed.WithThumbnailUrl(Context.Client.CurrentUser.GetAvatarUrl());
                result = 0;
                if (result == 0)
                {

                    var c = File.Create("data/challenge/" + Context.User.Id.ToString() + ".json");
                    c.Close();
                    c.Dispose();
                    File.WriteAllText("data/challenge/" + Context.User.Id.ToString() + ".json", "0/py/easy");
                    embed.WithTitle("Challenge Python Difficulté : Facile");
                    embed.WithColor(220, 0, 0);
                    embed.WithDescription("**But :** Compléter la méthode d'addition" + Environment.NewLine +
                        "**variables :** a et b" + Environment.NewLine +
                      "méthode : def Addition(a,b):" + Environment.NewLine +
                      "// Méthode a compléter" + Environment.NewLine +
                     "");
                    await Context.Channel.SendMessageAsync("", false, embed.Build());

                }
            }
        }
    }
}
