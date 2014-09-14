using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
//using Steamworks;

namespace steam_idle
{
    static class Program
    {
        [DllImport("steam_api.dll")]
        private static extern bool SteamAPI_Init();

        [STAThread]
        static void Main(string[] args)
        {
            long appId = long.Parse(args[0]);
            Environment.SetEnvironmentVariable("SteamAppId", appId.ToString());

            if (!SteamAPI_Init())
            {
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain(appId));
        }
    }
}