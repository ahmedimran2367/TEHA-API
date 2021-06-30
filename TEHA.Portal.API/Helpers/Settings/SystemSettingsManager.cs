// <copyright file="SystemSettingsManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Helpers.Settings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Extensions.Configuration;
    using TEHA.Portal.Data.Models.Administration;
    using TEHA.Portal.Data.Services.Administration;

    /// <summary>
    /// System settings manager
    /// </summary>
    public static class SystemSettingsManager
    {
        /// <summary>
        /// System setting contains the settings messages
        /// </summary>
        private static SystemSettingBase systemSettingsBase = null;
        private static SystemSettingService systemSettingService = new SystemSettingService(new Configuration(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")));

        static SystemSettingsManager()
        {
            Load();
        }

        /// <summary>
        /// re-set the Language messages
        /// </summary>
        public static void Refresh()
        {
            lock (systemSettingsBase)
            {
                Load();
            }
        }

        /// <summary>
        /// return English Messages
        /// </summary>
        /// <returns>LanguageBase</returns>
        public static SystemSettingBase GetSystemSettingMessages()
        {
            return systemSettingsBase;
        }

        /// <summary>
        /// Find system setting by code
        /// </summary>
        /// <typeparam name="TValue">TValue</typeparam>
        /// <param name="list">list</param>
        /// <param name="code">code</param>
        /// <param name="defaultValue">defaultValue</param>
        /// <returns>result</returns>
        public static TValue GetValue<TValue>(List<SystemSetting> list, EnumSystemSettings code, TValue defaultValue = default(TValue))
        {
            var item = list.FirstOrDefault(t => t.Code == code.ToString());
            if (item != null)
            {
                return (TValue)Convert.ChangeType(item.Value, typeof(TValue));
            }

            return defaultValue;
        }

        /// <summary>
        /// set the systemMessage from messages list
        /// </summary>
        /// <param name="dbMessages">Language</param>
        private static void SetValues(List<SystemSetting> dbMessages, SystemSettingBase obj)
        {
            // admin
            // home
            obj.EmailSetting.From = GetValue(dbMessages, EnumSystemSettings.From, "Code");
            obj.EmailSetting.SmtpServer = GetValue(dbMessages, EnumSystemSettings.SmtpServer, "Code");
            obj.EmailSetting.SmtpUsername = GetValue(dbMessages, EnumSystemSettings.SmtpUsername, "Code");
            obj.EmailSetting.SmtpPassword = GetValue(dbMessages, EnumSystemSettings.SmtpPassword, "Code");
            obj.EmailSetting.SmtpPort = GetValue(dbMessages, EnumSystemSettings.SmtpPort, 9000);
            obj.MaxRecord = GetValue(dbMessages, EnumSystemSettings.MaxRecord, 10);
            obj.GridPageSize = GetValue(dbMessages, EnumSystemSettings.GridPageSize, 500);
            obj.Url.Web = GetValue(dbMessages, EnumSystemSettings.Web, "Code");
            obj.Url.Api = GetValue(dbMessages, EnumSystemSettings.Api, "Code");
            obj.Url.TehaApi = GetValue(dbMessages, EnumSystemSettings.TehaApi, "Code");
            obj.DataExchangeUrl = GetValue(dbMessages, EnumSystemSettings.DataExchangeUrl, "http://onlineservices.teha-wd.de:652/ishaca/loginDataExchange.do");

            obj.ExceptionSettings.JavascriptErrors = GetValue(dbMessages, EnumSystemSettings.JavascriptErrors, false);
            obj.ExceptionSettings.ExceptionEmails = GetValue(dbMessages, EnumSystemSettings.ExceptionEmails, false);
        }

        /// <summary>
        /// load system messages from DB
        /// </summary>
        private static void Load()
        {
            List<Data.Models.Administration.SystemSetting> dbMessages = systemSettingService.GetAll();

            if (dbMessages != null)
            {
                systemSettingsBase = new SystemSettingBase();
                SetValues(dbMessages, systemSettingsBase);
            }
        }
    }
}
