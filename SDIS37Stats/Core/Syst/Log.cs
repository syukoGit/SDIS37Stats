using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SDIS37Stats.Core.Syst
{
    public static class Log
    {
        public enum TYPE
        {
            Error,
            Warning,
            Normal,
            Information
        }

        private static readonly string path = @"Logs\";

        public static void WriteLog(TYPE logType, string logToWrite)
        {
            var logDateTime = DateTime.Now;
            string logPath = path + logDateTime.ToString("yyyy-MM-dd");

            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            switch (logType)
            {
                case TYPE.Error:
                    logPath += @"\errors";
                    break;
                case TYPE.Warning:
                    logPath += @"\warns";
                    break;
                default:
                case TYPE.Normal:
                    logPath += @"\logs";
                    break;
                case TYPE.Information:
                    logPath += @"\infos";
                    break;
            }

            using (FileStream fs = new FileStream(logPath, FileMode.OpenOrCreate, FileAccess.Write))
            {

            }
        }
    }
}
