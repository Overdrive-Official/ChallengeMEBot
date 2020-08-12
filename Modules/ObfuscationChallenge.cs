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
    public class ObfuscationChallenge : ModuleBase<SocketCommandContext>
    {
        [Command("obfuscation_challenge")]
        public async Task ObfuscationAsync(string arg)
        {
            if (arg == "easy")
            {
                Random rdm = new Random();
                int result = rdm.Next(0,1);
                result = 0;
                var embed = new EmbedBuilder();
                embed.WithTitle("Challenge Obfuscation Difficulté : Facile");
                embed.WithThumbnailUrl(Context.Client.CurrentUser.GetAvatarUrl());
                embed.WithFooter("Created By Zelly");
                if (File.Exists("data/challenge/"+Context.User.Id.ToString()+".json"))
                {
                    await Context.Channel.SendMessageAsync("Vous avez deja un challenge en cours !");
                }
                if (File.Exists("data/obfuscation/"+Context.User.Id.ToString()+".json"))
                {
                    await Context.Channel.SendMessageAsync("Impossible de faire 2 fois ce challenge");
                }
                else
                {
                    if (result == 0)
                    {
                        var c = File.Create("data/challenge/"+Context.User.Id.ToString()+".json");
                        c.Close();
                        c.Dispose();
                        File.WriteAllText("data/challenge/"+Context.User.Id.ToString()+".json","0/obfuscation/easy"); 
                        embed.WithDescription("**Décompile** le .exe et envoie la **valeur** du string **resultat**");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());
                        await Context.Channel.SendFileAsync("data/obfuscation/Obfuscation0.exe");
                    }
                }
               
            }
            else
            {
                await Context.Channel.SendMessageAsync("Le Module est en cours de développement");
            }

        }

    }
}
