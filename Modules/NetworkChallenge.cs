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
    public class NetworkChallenge : ModuleBase<SocketCommandContext>
    {
        [Command("network_challenge")]
        public async Task NetChallenge([Remainder]string arg)
        {
            if (arg == "easy")
            {
                if (!File.Exists("data/challenge/"+Context.User.Id.ToString()+".json"))
                {
                    Random rdm = new Random();
                    int result = rdm.Next(0,4);
                  //  result = 1;
                    var embed = new EmbedBuilder();
                    embed.WithThumbnailUrl(Context.Client.CurrentUser.GetAvatarUrl());
                    embed.WithFooter("Created By Zelly");
                    
                    if (result == 0)
                    {
                        var c = File.Create("data/challenge/"+Context.User.Id.ToString()+".json");
                        c.Close();
                        c.Dispose();
                        File.WriteAllText("data/challenge/"+Context.User.Id.ToString()+".json","0/network/easy");
                        embed.WithTitle("Challenge Réseau Difficulté : Facile");
                        embed.WithDescription("**Question :** Combien y'a T-il de bits par segment, dans une IPV4 ? (Répondre que le chiffre)");
                        await Context.Channel.SendMessageAsync("",false,embed.Build());

                    }
                    if (result == 1)
                    {
                        var c = File.Create("data/challenge/" + Context.User.Id.ToString() + ".json");
                        c.Close();
                        c.Dispose();
                        File.WriteAllText("data/challenge/" + Context.User.Id.ToString() + ".json", "1/network/easy");
                        embed.WithTitle("Challenge Réseau Difficulté : Facile");
                        embed.WithDescription("**Question :** Donne moi le nom la première couche du Modèle OSI");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());
                    }
                    if (result == 2)
                    {
                        var c = File.Create("data/challenge/" + Context.User.Id.ToString() + ".json");
                        c.Close();
                        c.Dispose();
                        File.WriteAllText("data/challenge/" + Context.User.Id.ToString() + ".json", "2/network/easy");
                        embed.WithTitle("Challenge Réseau Difficulté : Facile");
                        embed.WithDescription("**Question :** Combien de bits faut-il pour faire 1 byte ? (Réponse que le chiffre)");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());
                    }
                    if (result == 3)
                    {
                        var c = File.Create("data/challenge/" + Context.User.Id.ToString() + ".json");
                        c.Close();
                        c.Dispose();
                        File.WriteAllText("data/challenge/" + Context.User.Id.ToString() + ".json", "3/network/easy");
                        embed.WithTitle("Challenge Réseau Difficulté : Facile");
                        embed.WithDescription("**Question :** Quelle est la valeur maximale d'un int d'un segment d'une IPV4");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());
                    }
                    if (result == 4)
                    {
                        var c = File.Create("data/challenge/" + Context.User.Id.ToString() + ".json");
                        c.Close();
                        c.Dispose();
                        File.WriteAllText("data/challenge/" + Context.User.Id.ToString() + ".json", "4/network/easy");
                        embed.WithTitle("Challenge Réseau Difficulté : Facile");
                        embed.WithDescription("**Question :** Quel protocol est relié au port 80 ?");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());
                    }
                }
                else
                {
                    await Context.Channel.SendMessageAsync("Vous avez déja un challenge en cours!");
                }
            }
            else
            {
                await Context.Channel.SendMessageAsync("Le Module est en cours de développement");
            }
        }
    }
}
