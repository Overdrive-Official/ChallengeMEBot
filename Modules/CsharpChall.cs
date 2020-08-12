using Discord;
using Discord.Commands;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMe.Modules
{
    public class CsharpChall : ModuleBase<SocketCommandContext>
    {
        [Command("c#_challenge")]
        public async Task CsharpChallenge(string arg)
        {
                // C# Challenge Easy
                if (arg == "easy")
                {
                    if (File.Exists("data/challenge/" + Context.User.Id.ToString() + ".json"))
                    {
                        await Context.Channel.SendMessageAsync("Vous avez deja un challenge en cours");
                    }
                    else
                    {
                        Random rdm = new Random();
                        int result = rdm.Next(0, 5);
                        // FORCE CHALLENGE
                        //result = 4;
                        var embed = new EmbedBuilder();
                        embed.WithFooter("Created By Zelly");
                        embed.WithThumbnailUrl(Context.Client.CurrentUser.GetAvatarUrl());
                        if (result == 0)
                        {
                       
                                var c = File.Create("data/challenge/" + Context.User.Id.ToString() + ".json");
                                c.Close();
                                c.Dispose();
                                File.WriteAllText("data/challenge/" + Context.User.Id.ToString() + ".json", "0/c#/easy");
                                embed.WithTitle("Challenge C# Difficulté : Facile");
                                embed.WithColor(220, 0, 0);
                                embed.WithDescription("**But :** Compléter la méthode d'addition" + Environment.NewLine +
                                    "**variables :** a et b" + Environment.NewLine +
                                  "méthode : public int Addition(int a, int b)" + Environment.NewLine +
                                  "{" + Environment.NewLine +
                                  "// Méthode a compléter" + Environment.NewLine +
                                 "}");
                                await Context.Channel.SendMessageAsync("", false, embed.Build());

                        }
                        if (result == 1)
                        {
                            var c = File.Create("data/challenge/" + Context.User.Id.ToString() + ".json");
                            c.Close();
                            c.Dispose();
                            File.WriteAllText("data/challenge/" + Context.User.Id.ToString() + ".json", "1/c#/easy");
                            embed.WithTitle("Challenge C# Difficulté : Facile");
                            embed.WithDescription("**But :** Convertir les minutes en secondes" + Environment.NewLine +
                                "**variables :**int minutes" + Environment.NewLine +
                              "méthode : public int MinutesToSeconds(int minutes)" + Environment.NewLine +
                              "{" + Environment.NewLine +
                              "// Méthode a compléter" + Environment.NewLine +
                             "}");
                            await Context.Channel.SendMessageAsync("", false, embed.Build());
                        }
                        if (result == 2)
                        {
                            var c = File.Create("data/challenge/" + Context.User.Id.ToString() + ".json");
                            c.Close();
                            c.Dispose();
                            File.WriteAllText("data/challenge/" + Context.User.Id.ToString() + ".json", "2/c#/easy");
                            embed.WithTitle("Challenge C# Difficulté : Facile");
                            embed.WithDescription("**But :** Envoyer le premier élément d'un tableau" + Environment.NewLine +
                                "**variables :**string[] mots;" + Environment.NewLine +
                              "méthode : public string PremierMot(string[] mots)" + Environment.NewLine +
                              "{" + Environment.NewLine +
                              "// Méthode a compléter" + Environment.NewLine +
                             "}");
                            await Context.Channel.SendMessageAsync("", false, embed.Build());
                        }
                        if (result == 3)
                        {
                            var c = File.Create("data/challenge/" + Context.User.Id.ToString() + ".json");
                            c.Close();
                            c.Dispose();
                            File.WriteAllText("data/challenge/" + Context.User.Id.ToString() + ".json", "3/c#/easy");
                            embed.WithTitle("Challenge C# Difficulté : Facile");
                            embed.WithDescription("**But :** Faire une Incrémentation d'un int par opérateurs" + Environment.NewLine +
                                "**variables :**int nombre;" + Environment.NewLine +
                              "méthode : public int Incrémente(int nombre)" + Environment.NewLine +
                              "{" + Environment.NewLine +
                              "// Méthode a compléter" + Environment.NewLine +
                             "}");
                            await Context.Channel.SendMessageAsync("", false, embed.Build());
                        }
                        if (result == 4)
                        {
                            var c = File.Create("data/challenge/" + Context.User.Id.ToString() + ".json");
                            c.Close();
                            c.Dispose();
                            File.WriteAllText("data/challenge/" + Context.User.Id.ToString() + ".json", "4/c#/easy");
                            embed.WithTitle("Challenge C# Difficulté : Facile");
                            embed.WithDescription("**But :** Convertir un Int en String" + Environment.NewLine +
                                "**variables :**int nombre;" + Environment.NewLine +
                              "méthode : public string ConvertString(int nombre)" + Environment.NewLine +
                              "{" + Environment.NewLine +
                              "// Méthode a compléter" + Environment.NewLine +
                             "}");
                            await Context.Channel.SendMessageAsync("", false, embed.Build());
                        }
                    }

                }
                // Medium Challenge C#
            if (arg == "medium")
            {
                if (File.Exists("data/challenge/" + Context.User.Id.ToString() + ".json"))
                {
                    await Context.Channel.SendMessageAsync("Vous avez deja un challenge en cours");
                }
                else
                {

                }
            }
                else
                {
                    await Context.Channel.SendMessageAsync("Le module est en cours de développement");
                }
            
           
        }
    }
}
