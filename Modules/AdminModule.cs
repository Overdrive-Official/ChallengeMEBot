using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMe.Modules
{
    public class AdminModule : ModuleBase<SocketCommandContext>
    {
       

        [Command("add_title")]
        public async Task Add_title(SocketGuildUser user,[Remainder] string title)
        {
            if (user == null)
            {
                user = Context.User as SocketGuildUser;
            }
            string adminlist = File.ReadAllText("data/admin.json");
            string admintext = "";
            bool isadmin = false;
            if (adminlist.Contains(Context.User.Id.ToString()))
            {
                isadmin = true;
            }
            if (isadmin)
            {
               
                    if (File.Exists("data/profil/title/" + user.Id.ToString() + ".json"))
                    {
                        File.WriteAllText("data/profil/title/" + user.Id.ToString() + ".json", title);
                    }
                    else
                    {
                        var c = File.Create("data/profil/title/" + user.Id.ToString() + ".json");
                        c.Dispose();
                        c.Close();
                        File.WriteAllText("data/profil/title/" + user.Id.ToString() + ".json", title);
                    }
               
            }
        }
    }
}
