// <copyright file="LookupsManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Helpers.Lookups
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using TEHA.Portal.Common;
    using TEHA.Portal.Data;
    using TEHA.Portal.Data.Models.Administration;
    using TEHA.Portal.Data.Services.Administration;
    using TEHA.Portal.ProxyAPI.Clients.Lookup;

    /// <summary>
    /// System settings manager
    /// </summary>
    public static class LookupsManager
    {
        /// <summary>
        /// Lookups contains the lookups list
        /// </summary>
        private static LookupBase lookupBase = null;

        static LookupsManager()
        {
            Load();
        }

        /// <summary>
        /// return Lookups
        /// </summary>
        /// <returns>LanguageBase</returns>
        public static LookupBase GetLookups()
        {
            return lookupBase;
        }

        /// <summary>
        /// Get Lookup from internal API
        /// </summary>
        private static void GetValue()
        {
            LookupClient lookupClient = new LookupClient();
            HttpResponseMessage response = lookupClient.Get().Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var obj = JsonConvert.DeserializeObject<ProxyResponse<LookupBase>>(response.Content.ReadAsStringAsync().Result);

                lookupBase = obj.Data;
            }
            else
            {
                Utility.LogExeption(null, "Lookup Manager: GetValue 'Error in lookup TEHA API call'", DateTime.Now.ToString(), "API", null, "url: API/DefaultData/Get", new SystemLogService(new Configuration(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings"))));
            }
        }

        /// <summary>
        /// set the lookups
        /// </summary>
        private static void SetValues()
        {
            //lookupBase.RwmStatus = new System.Collections.Generic.List<LookUps>
            //{
            //    new LookUps
            //    {
            //    Code = "OK",
            //    Value = "OK",
            //    Status = true,
            //    SortOrder = 0,
            //    },
            //    new LookUps
            //    {
            //    Code = "Warning",
            //    Value = "Warning",
            //    Status = true,
            //    SortOrder = 0,
            //    },
            //    new LookUps
            //    {
            //    Code = "Error",
            //    Value = "Error",
            //    Status = true,
            //    SortOrder = 0,
            //    },
            //};

            //lookupBase.AccountingStatus = new System.Collections.Generic.List<LookUps>
            //{
            //    new LookUps
            //    {
            //    Code = "WAIT_DATA",
            //    Value = "WAIT_DATA",
            //    Status = true,
            //    SortOrder = 0,
            //    },
            //    new LookUps
            //    {
            //     Code = "IN_PREPARATION",
            //     Value = "IN_PREPARATION",
            //     Status = true,
            //     SortOrder = 0,
            //    },
            //    new LookUps
            //    {
            //     Code = "FINISH",
            //     Value = "FINISH",
            //     Status = true,
            //     SortOrder = 0,
            //    },
            //    new LookUps
            //    {
            //     Code = "DOWNLOADED",
            //     Value = "DOWNLOADED",
            //     Status = true,
            //     SortOrder = 0,
            //    },
            //};

            //lookupBase.PlumbingStatus = new System.Collections.Generic.List<LookUps>
            //{
            //new LookUps
            //{
            //    Code = "NOT_PENDING",
            //    Value = "NOT_PENDING",
            //    Status = true,
            //    SortOrder = 0,
            //},
            //new LookUps
            //{
            //    Code = "OPEN",
            //    Value = "OPEN",
            //    Status = true,
            //    SortOrder = 0,
            //},
            //new LookUps
            //{
            //    Code = "PLAN",
            //    Value = "PLAN",
            //    Status = true,
            //    SortOrder = 0,
            //},
            //new LookUps
            //{
            //    Code = "FINISHED",
            //    Value = "FINISHED",
            //    Status = true,
            //    SortOrder = 0,
            //},
            //};
            //lookupBase.ReadingStatus = new System.Collections.Generic.List<LookUps>
            //{
            //new LookUps
            //{
            //    Code = "NOT_PENDING",
            //    Value = "NOT_PENDING",
            //    Status = true,
            //    SortOrder = 0,
            //},
            //new LookUps
            //{
            //    Code = "OPEN",
            //    Value = "OPEN",
            //    Status = true,
            //    SortOrder = 0,
            //},
            //new LookUps
            //{
            //    Code = "PLAN",
            //    Value = "PLAN",
            //    Status = true,
            //    SortOrder = 0,
            //},
            //new LookUps
            //{
            //    Code = "FINISHED",
            //    Value = "FINISHED",
            //    Status = true,
            //    SortOrder = 0,
            //},
            //};

            //lookupBase.OrderStatus = new System.Collections.Generic.List<LookUps>
            //{
            //    new LookUps
            //    {
            //        Code = "OPEN",
            //        Value = "osVal0",
            //        Status = true,
            //        SortOrder = 0,
            //    },
            //    new LookUps
            //    {
            //        Code = "GENERATED",
            //        Value = "osVal1",
            //        Status = true,
            //        SortOrder = 1,
            //    }, new LookUps
            //    {
            //        Code = "PLAN",
            //        Value = "osVal2",
            //        Status = true,
            //        SortOrder = 2,
            //    }, new LookUps
            //    {
            //        Code = "CANCEL",
            //        Value = "osVal3",
            //        Status = true,
            //        SortOrder = 3,
            //    }, new LookUps
            //    {
            //        Code = "FINISH",
            //        Value = "osVal4",
            //        Status = true,
            //        SortOrder = 4,
            //    },
            //};

            //lookupBase.OrderType = new System.Collections.Generic.List<LookUps>
            //{
            //    new LookUps
            //    {
            //         Code = "drinkingWaterSampling",
            //         Value = "otVal1",
            //         Status = true,
            //         SortOrder = 0,
            //    }, new LookUps
            //    {
            //         Code = "energyCertificate",
            //         Value = "otVal2",
            //         Status = true,
            //         SortOrder = 0,
            //    }, new LookUps
            //    {
            //         Code = "interimReading",
            //         Value = "otVal3",
            //         Status = true,
            //         SortOrder = 0,
            //    }, new LookUps
            //    {
            //         Code = "offer",
            //         Value = "otVal4",
            //         Status = true,
            //         SortOrder = 0,
            //    }, new LookUps
            //    {
            //         Code = "plumbing",
            //         Value = "otVal5",
            //         Status = true,
            //         SortOrder = 0,
            //    }, new LookUps
            //    {
            //         Code = "postInterimReading",
            //         Value = "otVal6",
            //         Status = true,
            //         SortOrder = 0,
            //    }, new LookUps
            //    {
            //         Code = "reading",
            //         Value = "otVal7",
            //         Status = true,
            //         SortOrder = 0,
            //    }, new LookUps
            //    {
            //         Code = "smokeDetectorTest",
            //         Value = "otVal8",
            //         Status = true,
            //         SortOrder = 0,
            //    },
            //};
            lookupBase.InvoiceStatus = new System.Collections.Generic.List<LookUps>
            {
               new LookUps
               {
                Code = "P",
                Value = "Paid",
                Status = true,
                SortOrder = 0,
               },
               new LookUps
               {
                Code = "U",
                Value = "UnPaid",
                Status = true,
                SortOrder = 0,
               },
            };
            lookupBase.DocumentType = new System.Collections.Generic.List<LookUps>
            {
               new LookUps
               {
                Code = "I",
                Value = "InvoiceDoc",
                Status = true,
                SortOrder = 0,
               },
               new LookUps
               {
                Code = "A",
                Value = "AccountingDoc",
                Status = true,
                SortOrder = 0,
               },
               new LookUps
               {
                Code = "R",
                Value = "ReadingDoc",
                Status = true,
                SortOrder = 0,
               },
               new LookUps
               {
                Code = "P",
                Value = "PlumbingDoc",
                Status = true,
                SortOrder = 0,
               },
               new LookUps
               {
                Code = "E",
                Value = "EnergyDoc",
                Status = true,
                SortOrder = 0,
               },
               new LookUps
               {
                Code = "D",
                Value = "DrinkingDoc",
                Status = true,
                SortOrder = 0,
               },
            };
        }

        /// <summary>
        /// load Lookups from DB/Internal API
        /// </summary>
        private static void Load()
        {
            lookupBase = new LookupBase();
            GetValue();
            SetValues();
        }
    }
}
