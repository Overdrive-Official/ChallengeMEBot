using Discord.Commands;
using Microsoft.ClearScript.V8;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMe.Modules
{
    public class EvaluationModule : ModuleBase<SocketCommandContext>
    {
        
        [Command("evaluate")]
        public async Task EvaluateAsync(string lang,[Remainder]string code)
        {
            if (Context.User.Id.ToString() == "491805519552446464")
            {
                if (lang.ToLower() == "c#" || lang.ToLower() == "csharp")
                {
                    var a = CSharpScript.EvaluateAsync(code);
                    await Context.Channel.SendMessageAsync("**__Code C# a Évaluer : __**" + Environment.NewLine +
                        "```cs" + Environment.NewLine + code + Environment.NewLine + "```" + Environment.NewLine + Environment.NewLine +
                        "**__Resultat__**" + Environment.NewLine +
                        a.Result.ToString());
                }
                if (lang.ToLower() == "js" || lang.ToLower() == "javascript")
                {
                    using (var engine = new V8ScriptEngine())
                    {
                        try
                        {

                            engine.Evaluate("function Multiplication() { " + code + " }");
                            var test = engine.Script.Multiplication();
                            Console.WriteLine(test.ToString());
                            await Context.Channel.SendMessageAsync("**__Code Javascript a Évaluer : __**" + Environment.NewLine +
                                "```js" + Environment.NewLine + code + Environment.NewLine + "```" + Environment.NewLine + Environment.NewLine +
                                "**__Resultat__**" + Environment.NewLine +
                                test);
                        }
                        catch (Exception)
                        {


                        }
                    }
                }
            }
           
        }
    }
}
