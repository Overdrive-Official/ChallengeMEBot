using Discord.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMe.Modules
{
    public class Reponse_Challenge : ModuleBase<SocketCommandContext>
    {
        [Command("ctf_reponse")]
        public async Task Answer_MultiAsync([Remainder]string arg)
        {
            await Context.Message.DeleteAsync();
            DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory()+"/data/multiplayer/challenge/");
            FileInfo[] Files = d.GetFiles("*.json");
            bool isinfile = false;
            string f = "";
            string fname = "";
            string path = "";
            foreach (var file in Files)
            {
                if (file.Name.Contains(Context.User.Id.ToString()))
                {
                    isinfile = true;
                    f = File.ReadAllText(file.FullName);
                    fname = file.Name;
                    path = file.FullName;
                }
            }

            if (isinfile)
            {
                string[] results = f.Split('/');
                string challid = results[0];
                string challtype = results[1];
                string difficulty = results[2];

                string infaw = fname.Replace(".json", "");
                string inforaw = infaw.Replace(Context.User.Id.ToString(),"");
                string otheruser = inforaw.Replace("_","");
                ulong otheruserid = Convert.ToUInt64(otheruser);
                var user = Context.Client.GetUser(otheruserid);

                bool res = Core.Multi.AnswerMulti.ResolveChallenge(challid,challtype,difficulty, arg);
                if (res == true)
                {
                    File.Delete(path);
                    await Context.Channel.SendMessageAsync("Vous avez gagné le challenge contre "+user.Mention);
                    Core.Multi.MultiPoints.AddOnlinePoints(Context.User.Id.ToString());

                }
                else
                {
                    File.Delete(path);
                    await Context.Channel.SendMessageAsync("Vous avez perdu le challenge contre "+user.Mention);
                }

            }
            if (!isinfile)
            {
                await Context.Channel.SendMessageAsync("Erreur, aucun challenge en cours trouvé");
            }
           
        }
    }
}
