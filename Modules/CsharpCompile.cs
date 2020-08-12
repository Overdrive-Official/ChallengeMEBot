using Discord.Commands;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMe.Modules
{
    public class CsharpCompile : ModuleBase<SocketCommandContext>
    {
        [Command("c#_compile")]
        public async Task CsharpCompileAsync(string name, [Remainder] string code)
        {
            string baseCode = @"using System; 
  
public class App { 
  
    static public void Main() 
    { 
  
        " + code + @"
       
     }
} ";

            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeCompiler icc = codeProvider.CreateCompiler();
            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = name;
           // parameters.ReferencedAssemblies.Add("lib/Discord.Net.Core.dll");
           // parameters.ReferencedAssemblies.Add("lib/Discord.Net.WebSocket.dll");
            if (File.Exists(name))
            {
                File.Delete(name);
            }
            CompilerResults results = icc.CompileAssemblyFromSource(parameters, baseCode);

            if (results.Errors.Count > 0)
            {
                string t = "";
                foreach (CompilerError CompErr in results.Errors)
                {
                    t += "Line number " + CompErr.Line +
                        ", Error Number: " + CompErr.ErrorNumber +
                        ", '" + CompErr.ErrorText + ";" +
                        Environment.NewLine + Environment.NewLine;

                }
                await Context.Channel.SendMessageAsync(t);
            }
            else
            {

                await Context.Channel.SendFileAsync(name, "**Compilation réussite**");
            }


        }
    }
}
