using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Drawing;

namespace DebugSystem.DebugService
{
    public static class LogSystem
    {
        private static string _filename = "app.log";
        private static bool _primoAvvio = true;
        private static bool _eliminaLog;
        private static bool _console = false;

        public static System.Windows.Forms.TextBox LogTextBox { get; set; }
        public static System.Windows.Forms.RichTextBox LogRichTextBox { get; set; }

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
            Log(messaggio, Color.Black);
        }

        public static void Log(string messaggio, Color color)
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

            if (LogTextBox != null)
            {
                LogTextBox.AppendText("- |" + DateTime.Now + " | " + messaggio + "/r/n" );
            }

            if (LogRichTextBox != null)
            {
                int initial = LogRichTextBox.Text.Length;
                LogRichTextBox.AppendText("- | " + DateTime.Now + " | " + messaggio + Environment.NewLine);
                LogRichTextBox.Select(initial, LogRichTextBox.Text.Length - 1);
                LogRichTextBox.SelectionColor = color;
            }

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
                " }: " + ex.Message, Color.Red);
        }

        public static void LogDatabase(string messaggio)
        {
            Log("[Database]: " + messaggio, Color.Gray);
        }
    }
}
