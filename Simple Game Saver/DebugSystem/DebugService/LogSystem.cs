using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace DebugSystem.DebugService
{
    public static class LogSystem
    {
        private static string _filename = "app.log";
        private static bool _primoAvvio = true;
        private static bool _eliminaLog;
        private static bool _console = false;

        public static Stream LogStream { get; private set; }

        public static bool Console
        {
            set { LogSystem._console = value; }
        }

        public static bool EliminaLog 
        {
            get { return _eliminaLog; }
            set { _eliminaLog = value; }
        }

        public static void Log(string messaggio)
        {
            if (_primoAvvio == true)
            {
                File.Delete(_filename);
                _primoAvvio = false;
            }
            messaggio = messaggio.Replace("\r\n", "");
            messaggio = messaggio.Replace("  ", "");
            StreamWriter sw = new StreamWriter(_filename, true);
            sw.WriteLine("- |" + DateTime.Now + " | " + messaggio);
            sw.Close();
            if (_console == true)
            {
                //System.Console.WriteLine("- |" + DateTime.Now + " | " + messaggio);
            }


        }

        public static void LogError(Exception ex)
        {
            string trace = ex.StackTrace;
            int ind1 = trace.LastIndexOf("\r\n")+2;
            string frame = trace.Substring(ind1, trace.Length-ind1);
            string linea = frame.Substring(frame.LastIndexOf(' ') + 1, frame.Length - 1 - frame.LastIndexOf(' '));
            string nomeF = frame.Substring(frame.LastIndexOf('\\') + 1, frame.LastIndexOf(':') - frame.LastIndexOf('\\')-1);
            string metodo = frame.Substring(0, frame.IndexOf(')') + 1);
            Log("{Errore: ( " + nomeF +
                "[" + linea +
                "]: " + metodo.TrimStart() +
                " }: " + ex.Message);
        }

        public static void LogDatabase(string messaggio)
        {
            Log("[Database]: " + messaggio);
        }
    }
}
