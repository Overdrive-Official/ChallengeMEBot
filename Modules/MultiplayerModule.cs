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
    public class MultiplayerModule : ModuleBase<SocketCommandContext>
    {
        [Command("ctf")]
        public async Task MultiPlayerService(Discord.IUser user, string langage, string difficulty)
        {
            Random rdm = new Random();
            int res = rdm.Next(0,4);
            
             if (difficulty == "easy")
             {
               
                    
                if (File.Exists("data/multiplayer/"+Context.User.Id.ToString()+"_"+user.Id.ToString()+".json"))
                {
                    File.Delete("data/multiplayer/" + Context.User.Id.ToString() + "_" + user.Id.ToString() + ".json");
                    var c = File.Create("data/multiplayer/" + Context.User.Id.ToString() + "_" + user.Id.ToString() + ".json");
                    c.Close();
                    c.Dispose();
                    File.WriteAllText("data/multiplayer/" + Context.User.Id.ToString() + "_" + user.Id.ToString() + ".json", res.ToString() + "/" + langage + "/" + difficulty);
                    await Context.Channel.SendMessageAsync(user.Mention + " Vous avez reçu un CTF de "+Context.User.Mention+Environment.NewLine+
                        "tapez .accepte @Mention pour accepter le challenge ou .refuser @mention pour le refuser");
                    // 
                }
                else
                {
                    var c = File.Create("data/multiplayer/" + Context.User.Id.ToString() + "_" + user.Id.ToString() + ".json");
                    c.Close();
                    c.Dispose();
                    File.WriteAllText("data/multiplayer/" + Context.User.Id.ToString() + "_" + user.Id.ToString() + ".json", res.ToString() + "/" + langage + "/" + difficulty);
                    await Context.Channel.SendMessageAsync(user.Mention + " Vous avez reçu un CTF de " + Context.User.Mention + Environment.NewLine +
                      "tapez .accepte @Mention pour accepter le challenge ou .refuser @mention pour le refuser");


                }
            }
            
        }



        [Command("accepte")]
        public async Task AccepteChallengeAsync(Discord.IUser user)
        {
            DirectoryInfo d = new DirectoryInfo("data/multiplayer");
            FileInfo[] Files = d.GetFiles("*.json");

            bool isinfile = false;
            foreach (FileInfo file in Files)
            {
                string[] name = file.Name.Replace(".json","").Split('_');
                if (name[0] == user.Id.ToString() && name[1] == Context.User.Id.ToString())
                {
                    isinfile = true;
                
                }
            }
            if (isinfile == true)
            {
                string[] result = File.ReadAllText("data/multiplayer/"+user.Id.ToString()+"_"+Context.User.Id.ToString()+".json").Split('/');
                var c = File.Create("data/multiplayer/challenge/"+user.Id.ToString()+"_"+Context.User.Id.ToString()+".json");
                
                c.Close();
                c.Dispose();
                File.WriteAllText("data/multiplayer/challenge/" + user.Id.ToString() + "_" + Context.User.Id.ToString() + ".json",result[0]+"/"+result[1]+"/"+result[2]);
                await Context.Channel.SendMessageAsync("Challenge accepté !");
                File.Delete("data/multiplayer/" + user.Id.ToString() + "_" + Context.User.Id.ToString() + ".json");
                await Core.Multi.Challenges.SendChallengeMulti(user.Id.ToString(), Context.User.Id.ToString(), Context);

            }
            if (isinfile == false)
            {
                await Context.Channel.SendMessageAsync("Aucun challenge a accepter  de cet utilisateur");
            }
        }
    }
}
