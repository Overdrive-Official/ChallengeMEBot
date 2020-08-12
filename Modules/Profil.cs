using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChallengeMe.Modules
{
    public class Profil : ModuleBase<SocketCommandContext>
    {

        [Command("profil")]
        public async Task GetProfil(Discord.IUser user = null)
        {
            if (user == null)
            {
                user = Context.User;
            }
            var embed = new EmbedBuilder();
            string certificationtext = "";
            string[] certificationList = File.ReadAllText("data/certification.json").Split('/');
            foreach (var certuser in certificationList)
            {
                if (certuser == user.Id.ToString())
                {
                    certificationtext = ":computer: **Programmeur Certifié** :computer:" + Environment.NewLine;

                }
            }
            string[] adminlist = File.ReadAllText("data/admin.json").Split('/');
            string admintext = "";
            foreach (var item in adminlist)
            {
                if (user.Id.ToString() == item)
                {
                    admintext = ":scales: **Staff ChallengeMe** :scales:" + Environment.NewLine+
                        "<a:diamand:712764066136981604>  **Administrateur de ChallengeMe** <a:diamand:712764066136981604>";
                }
            }
            string message = "Aucun";
            if (File.Exists("data/profil/message/" + user.Id.ToString() + ".json"))
            {
                string result = File.ReadAllText("data/profil/message/" + user.Id.ToString() + ".json");
                if (user.Id.ToString() == "691683248601956363")
                {
                    message = "Grosse Merde en C# qui suce Zelly";
                }
                else
                {
                    message = result;
                }
              
            }
            if (File.Exists("data/profil/image/"+user.Id.ToString()+".json"))
            {
                try
                {
                    string result = File.ReadAllText("data/profil/image/" + user.Id.ToString() + ".json");
                    embed.WithImageUrl(result);
                }
                catch (Exception)
                {

                   
                }
                
            }
            string OnlinePoints = "0";
            try
            {
                OnlinePoints=File.ReadAllText("data/multiplayer/onlinepoints/" + user.Id.ToString() + ".json");
            }
            catch (Exception)
            {

                OnlinePoints = "0";
            }
            
            int points = Core.Points.ReadPoints(user);
            int lose = Core.Points.ReadLosePoints(user);
            if (points >= 10)
            {
                certificationtext += ":cd: **Apprenti Challenger (+10 Chall)** :cd: ";
            }
            if (points >= 50)
            {
                certificationtext += Environment.NewLine+":dvd: **Challenger (+50 Chall)** :dvd: ";
            }
            if (points >= 100)
            {
                certificationtext += Environment.NewLine + ":ballot_box_with_check: **Expert des Challenges (+100 Chall)** :ballot_box_with_check:";
            }
            if (File.Exists("data/profil/title/"+user.Id.ToString()+".json"))
            {
                string title = File.ReadAllText("data/profil/title/"+user.Id.ToString()+".json");
                certificationtext += Environment.NewLine + title;
            }
            
            embed.WithTitle("Information : " + user.Username + "#" + user.Discriminator.ToString());
            embed.WithThumbnailUrl(user.GetAvatarUrl());
            embed.WithColor(220, 0, 0);
            embed.WithDescription("**Id :** " + user.Id.ToString() + Environment.NewLine +
                 admintext + Environment.NewLine +
                certificationtext + Environment.NewLine +
                "**Victoires Challenges :** " + points.ToString() + Environment.NewLine +
                "**Lose Challenges : **" + lose.ToString() + Environment.NewLine+
                "**Victoires CTF Online : **"+OnlinePoints+Environment.NewLine + Environment.NewLine +
                "**Message Personnalisé :** " + message);
            embed.WithFooter("Created By Zelly");
            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }

  

        [Command("profil_message")]
        public async Task ProfilMessage([Remainder]string mess = "")
        {
            if (File.Exists("data/profil/message/"+Context.User.Id.ToString()+".json"))
            {
                File.WriteAllText("data/profil/message/"+Context.User.Id.ToString() + ".json",mess);
                await Context.Channel.SendMessageAsync("Message personnalisé modifié avec succès");
            }
            else
            {
                var c = File.Create("data/profil/message/"+Context.User.Id.ToString()+".json");
                c.Close();
                c.Dispose();
                File.WriteAllText("data/profil/message/"+Context.User.Id.ToString()+".json",mess);
                await Context.Channel.SendMessageAsync("Message personnalisé créé avec succès");
            }
        }

        [Command("profil_image")]
        public async Task ProfilImage(string url)
        {
            if (File.Exists("data/profil/image/" + Context.User.Id.ToString() + ".json"))
            {
                File.WriteAllText("data/profil/image/" + Context.User.Id.ToString() + ".json", url);
                await Context.Channel.SendMessageAsync("Image personnalisé modifié avec succès");
            }
            else
            {
                var c = File.Create("data/profil/image/" + Context.User.Id.ToString() + ".json");
                c.Close();
                c.Dispose();
                File.WriteAllText("data/profil/image/" + Context.User.Id.ToString() + ".json", url);
                await Context.Channel.SendMessageAsync("Image personnalisé créé avec succès");
            }
        }
    }
}
