using System;
using System.IO;
using System.Windows.Forms;

namespace Tarek_BLL.Errors
{
    public static class ErrorManagement
    {
        private const string LOG_FILE = "Tarek.log";

        private static string LogFilePath
        {
            get
            {
                return Path.Combine(new FileInfo(Application.ExecutablePath.Replace("/", "\\")).Directory.FullName,
                                    LOG_FILE);
            }
        }

        public static void Log(Exception e, string text = "")
        {
            StreamWriter FileWriter = null;

            try
            {
                FileWriter = new StreamWriter(LogFilePath, true);

                DateTime dt = DateTime.Now;
                FileWriter.WriteLine(string.Format("{0} -> {1} ({2})",
                                                   DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                                                   text,
                                                   e.Message).Replace("  ", " "));

                foreach (string tmp in e.StackTrace.Split(Environment.NewLine.ToCharArray()))
                    FileWriter.WriteLine(tmp.Trim());

                FileWriter.WriteLine();
            }
            catch (IOException)
            {
            }
            catch (Exception)
            {
            }
            finally
            {
                if (FileWriter != null)
                {
                    FileWriter.Flush();
                    FileWriter.Close();
                }
            }
        }

        public static void Track(string text = "", bool separator = false, string logFile = "")
        {
            StreamWriter FileWriter = null;

            try
            {
                if (String.IsNullOrEmpty(logFile))
                    logFile = LogFilePath;

                FileWriter = new StreamWriter(logFile, true);

                if (separator)
                    FileWriter.WriteLine(new String('-', 50));

                if (text.Length > 0)
                    FileWriter.WriteLine(text);

                FileWriter.WriteLine();
            }
            catch (IOException)
            {
            }
            catch (Exception)
            {
            }
            finally
            {
                if (FileWriter != null)
                {
                    FileWriter.Flush();
                    FileWriter.Close();
                }
            }
        }

        public static void DeleteLogFile()
        {
            try
            {
                string strLogFile = Path.Combine(Application.ExecutablePath, LOG_FILE);

                if (File.Exists(strLogFile))
                    File.Delete(strLogFile);
            }
            catch
            {
            }
        }
    }
}