using Discord.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMe.Modules
{
    public class ResponseChallenge : ModuleBase<SocketCommandContext>
    {
        [Command("reponse")]
        public async Task AnswerAsync([Remainder]string arg)
        {
            await Context.Message.DeleteAsync();
            if (File.Exists("data/challenge/" + Context.User.Id.ToString() + ".json"))
            {
                string[] results = File.ReadAllText("data/challenge/" + Context.User.Id.ToString() + ".json").Split('/');
                if (results[1] == "c#")
                {
                    bool result = Core.CsharpChallenge.ResolveChallenge(results[0],results[2],arg);
                    if (result)
                    {
                        await Context.Channel.SendMessageAsync("Bonne réponse vous avez réussi votre challenge ! ");
                        File.Delete("data/challenge/"+Context.User.Id.ToString() + ".json");
                        Core.Points.AddPoints(Context.User,1);

                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Mauvaise réponse, challenge désactivé");
                        File.Delete("data/challenge/" + Context.User.Id.ToString() + ".json");
                        Core.Points.AddLosePoints(Context.User,1);
                    }
                }
                if (results[1] == "obfuscation")
                {
                    bool IsSuccess = Core.ObfuscationChallenge.ResolveChallenge(results[0], results[2], arg);
                    if (IsSuccess)
                    {
                        var c = File.Create("data/obfuscation/"+Context.User.Id.ToString()+".json");
                        c.Close();
                        c.Dispose();
                        File.WriteAllText("data/obfuscation/"+Context.User.Id.ToString()+".json","test");
                        await Context.Channel.SendMessageAsync("bonne réponse vous avez réussi votre challenge !");
                        File.Delete("data/challenge/" + Context.User.Id.ToString() + ".json");
                        Core.Points.AddPoints(Context.User, 1);

                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Mauvaise réponse, le chalenge est désactivé ");
                        File.Delete("data/challenge/" + Context.User.Id.ToString() + ".json");
                        Core.Points.AddLosePoints(Context.User, 1);
                    }
                }
                if (results[1] == "js")
                {
                    bool ISSuccess = Core.JsChallenge.ResolveChallenge(results[0], results[2], arg);
                    if (ISSuccess)
                    {
                        await Context.Channel.SendMessageAsync("Bonne réponse, le challenge est désactivé");
                        File.Delete("data/challenge/"+Context.User.Id.ToString()+".json");
                        Core.Points.AddPoints(Context.User, 1);

                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Mauvaise réponse le challenge est désactivé");
                        File.Delete("data/challenge/" + Context.User.Id.ToString() + ".json");
                        Core.Points.AddLosePoints(Context.User, 1);
                    }
                }
                if (results[1] == "network")
                {
                    bool ISSuccess = Core.NetworkChallenge.ResolveChallenge(results[0], results[2], arg);
                    if (ISSuccess)
                    {
                        await Context.Channel.SendMessageAsync("Bonne réponse vous avez réussi votre challenge !");
                        File.Delete("data/challenge/"+Context.User.Id.ToString() + ".json");
                        Core.Points.AddPoints(Context.User, 1);
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Mauvaise réponse, le challenge est désactivé");
                        File.Delete("data/challenge/" + Context.User.Id.ToString() + ".json");
                        Core.Points.AddLosePoints(Context.User, 1);
                    }
                }
                if (results[1] == "py")
                {
                    bool IsSuccess = Core.PythonChallenge.ResolverChallenge(results[0], results[2], arg);
                    if (IsSuccess)
                    {
                        await Context.Channel.SendMessageAsync("Bonne réponse vous avez réussi votre challenge!");
                        File.Delete("data/challenge/" + Context.User.Id.ToString() + ".json");
                        Core.Points.AddLosePoints(Context.User, 1);
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Mauvaise réponse, le challenge est désactivé");
                        File.Delete("data/challenge/" + Context.User.Id.ToString() + ".json");
                        Core.Points.AddLosePoints(Context.User, 1);
                    }
                }
            }
            else { await Context.Channel.SendMessageAsync("Aucun challenge en cours"); }
            
        }
    }
}
