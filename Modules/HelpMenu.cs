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
    public class HelpMenu : ModuleBase<SocketCommandContext>
    {
        
        [Command("help")]
        public async Task HelpAsync()
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Menu d'aide");
            embed.WithDescription("**__Commandes du Profil__**"+Environment.NewLine+"```.profil_message MESSAGE : Modifier le message personnalisé du profil"+Environment.NewLine+Environment.NewLine+
                ".profil_image URL : Modifier l'image personnalisé du profil```" +Environment.NewLine+Environment.NewLine+
                "**__Commandes Challenges__**"+Environment.NewLine+
                "```.reponse (RÉPONSE/CODE) : Répondre a un challenge en cours"+Environment.NewLine+Environment.NewLine+
                ".c#_challenge (easy/medium/hard) : Commence un challenge en C# aléatoirement, selon la difficulté séléctionnée"+Environment.NewLine+Environment.NewLine+
                ".network_challenge (easy/medium/hard : Commence un challenge réseau aléatoirement selon la difficulté séléctionnée"+Environment.NewLine+Environment.NewLine+
                ".js_challenge (easy/medium/hard) : Commence un challenge Javascript Aléatoire Selon la difficulté séléctionné"+Environment.NewLine+Environment.NewLine+
                ".obfuscation_challenge (easy/medium/hard) : Commence un challenge Obfuscation Aléatoire selon la difficulté sléctionné```"+Environment.NewLine+Environment.NewLine+
                "**__Challenges Online__**"+Environment.NewLine+
                "```.ctf @MENTION LANGUAGE DIFFICULTÉ : Envois un challenge contre un utilisateur discord"+Environment.NewLine+Environment.NewLine+
                ".ctf_reponse REPONSE : Envois la réponse du challenge en cours```"+Environment.NewLine+Environment.NewLine+
                "**__Commandes Évaluations De Code__**"+Environment.NewLine+
                "```.evaluate LANGAGE (CODE) : Évalue le code dans l'engine  de ChallengeMe```" +Environment.NewLine+
                "**__Autres Commandes__**"+Environment.NewLine+
                "```.information : Affiche les informations concernant les challenges actuels```");
            embed.WithFooter("Created By Zelly");
            embed.WithImageUrl("https://i.pinimg.com/originals/2e/a7/f5/2ea7f5d29b0fe88cc8e1c93bb50d3c40.gif");
            embed.WithColor(220,0,0);
            embed.WithThumbnailUrl(Context.Client.CurrentUser.GetAvatarUrl());
            await Context.Channel.SendMessageAsync("",false,embed.Build());
            
        }


        [Command("challenge_cancel")]
        public async Task CancelChallengeAsync(Discord.IUser user)
        {
            string[] adminlist = File.ReadAllText("data/admin.json").Split('/');
            bool isadmin = false;
            foreach (var item in adminlist)
            {
                if (Context.User.Id.ToString() == item)
                {
                    isadmin = true;
                }
            }
            if (isadmin)
            {
                if (File.Exists("data/challenge/" + Context.User.Id.ToString() + ".json"))
                {
                    File.Delete("data/challenge/" + Context.User.Id.ToString() + ".json");
                    await Context.Channel.SendMessageAsync("Challenge Annulé avec succès");
                }
                else
                {
                    await Context.Channel.SendMessageAsync("l'utilisateur a aucun challenge a annuler");
                }
            }
            else
            {
                await Context.Channel.SendMessageAsync("Seulement les admins peuvent annuler des challenges");
            }
           
        }
    }
}
