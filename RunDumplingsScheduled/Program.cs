// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

namespace RunDumplingsScheduled
{
    public class Program
    {
        private static void Main(string[] args)
        {
            DumplingScheduler.RunDumplingsScript();
        }
    }

    public class DumplingScheduler
    {
        public static void RunDumplingsScript()
        {
            Process process = new();
            try
            {
                Console.WriteLine("Starting scheduled run of Dumplings.");

                ProcessStartInfo startInfo = new(".\\ScheduledProgram.bat");
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;

                process.OutputDataReceived += Process_OutputDataReceived;
                process.ErrorDataReceived += Process_ErrorDataReceived;
                process.StartInfo = startInfo;
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
            }
            catch (Exception exc)
            {
                Logger.LogError(exc.Message);
            }
            finally
            {
                process.OutputDataReceived -= Process_OutputDataReceived;
                process.ErrorDataReceived -= Process_ErrorDataReceived;
            }
        }

        private static void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Logger.LogError(e.Data);
        }

        private static void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }
    }

    public static class Logger
    {
        public static void LogError(string? message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}