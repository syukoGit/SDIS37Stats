// -----------------------------------------------------------------------
// <copyright file="Log.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace SDIS37Stats.Core.Syst
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Static class for writes the log in the file.
    /// </summary>
    public static class Log
    {
        /// <summary>
        /// The path where the logs are saved.
        /// </summary>
        private static readonly string Path = @"Logs\";

        /// <summary>
        /// Defines the type of logs that will be written.
        /// </summary>
        public enum EType
        {
            /// <summary>
            /// The logs used for the error logs.
            /// </summary>
            Error,

            /// <summary>
            /// The type used for the warning logs.
            /// </summary>
            Warning,

            /// <summary>
            /// The type used for the information or default logs.
            /// </summary>
            Normal,
        }

        /// <summary>
        /// Writes the logs in the file correspond to the today date and the type's log file.
        /// </summary>
        /// <param name="logType">A <see cref="EType"/> enumerator for defines the log's type.</param>
        /// <param name="logToWrite">The log to be written.</param>
        public static void WriteLog(EType logType, string logToWrite)
        {
            var logDateTime = DateTime.Now;
            string logPath = Path + logDateTime.ToString("yyyy-MM-dd");

            logToWrite = $"[{logDateTime:dd-MM-yyyy HH:mm:ss}] {logToWrite}";

            if (!Directory.Exists(logPath))
            {
                _ = Directory.CreateDirectory(logPath);
            }

            logPath += logType switch
            {
                EType.Error => @"\errors",
                EType.Warning => @"\warns",
                _ => @"\logs",
            };

            using (FileStream fs = new (logPath, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write))
            {
                logToWrite += "\n";
                fs.Write(Encoding.UTF8.GetBytes(logToWrite), 0, Encoding.UTF8.GetByteCount(logToWrite));
                fs.Close();
            }
        }
    }
}
