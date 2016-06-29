using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace vbsp
{
    class Program
    {
        static void Main()
        {
            //Call precompiler operation to ensure the STEAMID64 directory exists
            /* I will need to write my own version of this section */
            //var ccEnsureSteamIDDirectoryExists = new Process();
            //ccEnsureSteamIDDirectoryExists.StartInfo.FileName = "CCEnsureSteamIDDirectoryExists.exe";
            //ccEnsureSteamIDDirectoryExists.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //ccEnsureSteamIDDirectoryExists.Start();
            //ccEnsureSteamIDDirectoryExists.WaitForExit();

            //Call alternate compilers
            var ccVilleIntermediateCompilerProcess = new Process();
            ccVilleIntermediateCompilerProcess.StartInfo.FileName = "CCVilleIntermediateCompiler.exe";
            ccVilleIntermediateCompilerProcess.StartInfo.Arguments = string.Format("\"{0}\"", Environment.GetCommandLineArgs().Last());
            ccVilleIntermediateCompilerProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ccVilleIntermediateCompilerProcess.Start();
            ccVilleIntermediateCompilerProcess.WaitForExit();


            //Call standard compiler
            var hl2Process = new Process();
            hl2Process.StartInfo.FileName = "vbsp_original.exe";
            hl2Process.StartInfo.Arguments = Environment.CommandLine.Substring(Environment.CommandLine.IndexOf("exe\"") + 4).Trim();
            hl2Process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            hl2Process.Start();
            hl2Process.WaitForExit();
        }
    }
}
