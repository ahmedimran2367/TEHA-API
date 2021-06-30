// <copyright file="Utility.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Common
{
    using TEHA.Portal.Data.Models.Administration;
    using TEHA.Portal.Data.Services.Administration;

    /// <summary>
    /// Implements Utilities
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Log Exeption
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="message">message</param>
        /// <param name="logDate">logDate</param>
        /// <param name="processName">processName</param>
        /// <param name="stackTrace">stackTrace</param>
        /// <param name="errorData">errorData</param>
        /// <param name="systemLogService">SystemLogService</param>
        public static void LogExeption(string type, string message, string logDate, string processName, string stackTrace, string errorData, SystemLogService systemLogService)
        {
            SystemLog systemLog = new SystemLog()
            {
                Type = type,
                Message = message,
                LogDate = logDate,
                ProcessName = processName,
                StackTrace = stackTrace,
                ErrorData = errorData,
            };

            systemLogService.Insert(systemLog);
        }
    }
}
