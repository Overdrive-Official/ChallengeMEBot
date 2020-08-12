using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMe.Core.Multi
{
    public class Challenges
    {
        public static async Task SendChallengeMulti(string idsender, string idreceiver,SocketCommandContext Context)
        {
            string[] results = File.ReadAllText("data/multiplayer/challenge/"+idsender+"_"+idreceiver+".json").Split('/');
            string challid = results[0];
            string type = results[1];
            string difficulty = results[2];

            if (type.ToLower() == "c#")
            {
                if (difficulty == "easy")
                {
                    var embed = new EmbedBuilder();
                    embed.WithFooter("Created By Zelly");
                    embed.WithThumbnailUrl(Context.User.GetAvatarUrl());
                    if (challid == "0")
                    {
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
                    if (challid == "1")
                    {
                        embed.WithTitle("Challenge C# Difficulté : Facile");
                        embed.WithDescription("**But :** Convertir les minutes en secondes" + Environment.NewLine +
                            "**variables :**int minutes" + Environment.NewLine +
                          "méthode : public int MinutesToSeconds(int minutes)" + Environment.NewLine +
                          "{" + Environment.NewLine +
                          "// Méthode a compléter" + Environment.NewLine +
                         "}");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());
                    }
                    if (challid == "2")
                    {
                        embed.WithTitle("Challenge C# Difficulté : Facile");
                        embed.WithDescription("**But :** Envoyer le premier élément d'un tableau" + Environment.NewLine +
                            "**variables :**string[] mots;" + Environment.NewLine +
                          "méthode : public string PremierMot(string[] mots)" + Environment.NewLine +
                          "{" + Environment.NewLine +
                          "// Méthode a compléter" + Environment.NewLine +
                         "}");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());
                    }
                    if (challid == "3")
                    {
                        embed.WithTitle("Challenge C# Difficulté : Facile");
                        embed.WithDescription("**But :** Faire une Incrémentation d'un int par opérateurs" + Environment.NewLine +
                            "**variables :**int nombre;" + Environment.NewLine +
                          "méthode : public int Incrémente(int nombre)" + Environment.NewLine +
                          "{" + Environment.NewLine +
                          "// Méthode a compléter" + Environment.NewLine +
                         "}");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());
                    }
                    if (challid == "4")
                    {
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
            if (type.ToLower() == "js" || type.ToLower() == "javascript")
            {
                if (difficulty.ToLower() == "easy")
                {
                    var embed = new EmbedBuilder();
                    if (challid == "0")
                    {
                        embed.WithDescription("**Buts :** Résoudre la Fonction suivante" + Environment.NewLine +
                            "function MinutesToSeconds(minutes)" + Environment.NewLine +
                            "{" + Environment.NewLine +
                            "  // Fonction a compléter" + Environment.NewLine +
                            "}");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());
                    }
                    if (challid == "1")
                    {
                        embed.WithDescription("**Buts :** Résoudre la Fonction suivante" + Environment.NewLine +
                            "function Addition(a,b)" + Environment.NewLine +
                            "{" + Environment.NewLine +
                            "  // Fonction a compléter" + Environment.NewLine +
                            "}");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());

                    }
                    if (challid == "2")
                    {
                        embed.WithDescription("**Buts :** Résoudre la Fonction suivante" + Environment.NewLine +
                           "function Multiplication(a,b)" + Environment.NewLine +
                           "{" + Environment.NewLine +
                           "  // Fonction a compléter" + Environment.NewLine +
                           "}");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());
                    }
                    if (challid =="3")
                    {
                        embed.WithDescription("**Buts :** Résoudre la Fonction suivante" + Environment.NewLine +
                          "function Soustraction(a,b)" + Environment.NewLine +
                          "{" + Environment.NewLine +
                          "  // Fonction a compléter" + Environment.NewLine +
                          "}");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());
                    }
                    if (challid=="4")
                    {
                        embed.WithDescription("**Buts :** Résoudre la Fonction suivante" + Environment.NewLine +
    "function Triangle(a,b)" + Environment.NewLine +
    "{" + Environment.NewLine +
    "  // Fonction a compléter" + Environment.NewLine +
    "}");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());
                    }
                }
            }

            if (type == "network")
            {
                var embed = new EmbedBuilder();
                embed.WithThumbnailUrl(Context.Client.CurrentUser.GetAvatarUrl());
                embed.WithFooter("Created By Zelly");

                if (difficulty == "easy")
                {
                    if (challid == "0")
                    {
                        embed.WithTitle("Challenge Réseau Difficulté : Facile");
                        embed.WithDescription("**Question :** Combien y'a T-il de bits par segment, dans une IPV4 ? (Répondre que le chiffre)");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());
                    }
                    if (challid == "1")
                    {
                        embed.WithTitle("Challenge Réseau Difficulté : Facile");
                        embed.WithDescription("**Question :** Donne moi le nom la première couche du Modèle OSI");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());
                    }
                    if (challid == "2")
                    {
                        embed.WithTitle("Challenge Réseau Difficulté : Facile");
                        embed.WithDescription("**Question :** Combien de bits faut-il pour faire 1 byte ? (Réponse que le chiffre)");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());
                    }
                    if (challid == "3")
                    {
                        embed.WithTitle("Challenge Réseau Difficulté : Facile");
                        embed.WithDescription("**Question :** Quelle est la valeur maximale d'un int d'un segment d'une IPV4");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());
                    }
                    if (challid == "4")
                    {
                        embed.WithTitle("Challenge Réseau Difficulté : Facile");
                        embed.WithDescription("**Question :** Quel protocol est relié au port 80 ?");
                        await Context.Channel.SendMessageAsync("", false, embed.Build());
                    }
                }
            }
        }
    }
}
