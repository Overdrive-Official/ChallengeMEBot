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
    public class JsChallenge : ModuleBase<SocketCommandContext>
    {
        [Command("js_challenge")]
        public async Task JsChallAsync(string arg)
        {
            if (arg == "easy")
            {

                Random rdm = new Random();
                int result = rdm.Next(0,3);
               // result = 1;
                var embed = new EmbedBuilder();
                embed.WithTitle("Challenge JavaScript Difficulté : Easy");
                embed.WithThumbnailUrl(Context.Client.CurrentUser.GetAvatarUrl());
                embed.WithFooter("Created By Zelly");
               
                if (File.Exists("data/challenge/"+Context.User.Id.ToString() +".json"))
                {
                     await Context.Channel.SendMessageAsync("Vous avez deja un challenge en cours !");
                }
                else
                {
                    if (result == 0)
                    {
                        var c = File.Create("data/challenge/" + Context.User.Id.ToString() + ".json");
                        c.Close();
                        c.Dispose();
                        File.WriteAllText("data/challenge/" + Context.User.Id.ToString() + ".json", "0/js/easy");
                        embed.WithDescription("**Buts :** Résoudre la Fonction suivante" + Environment.NewLine +
                            "function MinutesToSeconds(minutes)" + Environment.NewLine +
                            "{" + Environment.NewLine +
                            "  // Fonction a compléter" + Environment.NewLine +
                            "}");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());
                    }
                    if (result == 1)
                    {
                        var c = File.Create("data/challenge/" + Context.User.Id.ToString() + ".json");
                        c.Close();
                        c.Dispose();
                        File.WriteAllText("data/challenge/" + Context.User.Id.ToString() + ".json", "1/js/easy");
                        embed.WithDescription("**Buts :** Résoudre la Fonction suivante" + Environment.NewLine +
                            "function Addition(a,b)" + Environment.NewLine +
                            "{" + Environment.NewLine +
                            "  // Fonction a compléter" + Environment.NewLine +
                            "}");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());
                    }
                    if (result == 2)
                    {
                        var c = File.Create("data/challenge/" + Context.User.Id.ToString() + ".json");
                        c.Close();
                        c.Dispose();
                        File.WriteAllText("data/challenge/" + Context.User.Id.ToString() + ".json", "2/js/easy");
                        embed.WithDescription("**Buts :** Résoudre la Fonction suivante" + Environment.NewLine +
                            "function Multiplication(a,b)" + Environment.NewLine +
                            "{" + Environment.NewLine +
                            "  // Fonction a compléter" + Environment.NewLine +
                            "}");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());
                    }
                    if (result == 3)
                    {
                        var c = File.Create("data/challenge/" + Context.User.Id.ToString() + ".json");
                        c.Close();
                        c.Dispose();
                        File.WriteAllText("data/challenge/" + Context.User.Id.ToString() + ".json", "3/js/easy");
                        embed.WithDescription("**Buts :** Résoudre la Fonction suivante" + Environment.NewLine +
                            "function Soustraction(a,b)" + Environment.NewLine +
                            "{" + Environment.NewLine +
                            "  // Fonction a compléter" + Environment.NewLine +
                            "}");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());
                    }
                    if (result == 4)
                    {
                        var c = File.Create("data/challenge/" + Context.User.Id.ToString() + ".json");
                        c.Close();
                        c.Dispose();
                        File.WriteAllText("data/challenge/" + Context.User.Id.ToString() + ".json", "4/js/easy");
                        embed.WithDescription("**Buts :** Résoudre la Fonction suivante" + Environment.NewLine +
                            "function Triangle(a,b)" + Environment.NewLine +
                            "{" + Environment.NewLine +
                            "  // Fonction a compléter" + Environment.NewLine +
                            "}");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());
                    }
                  
                }
                   
                
            }
            else
            {
                await Context.Channel.SendMessageAsync("Le module est en cours de développement");
            }
        }
    }
}
