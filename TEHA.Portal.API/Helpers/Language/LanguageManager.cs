// <copyright file="LanguageManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Helpers.Language
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Extensions.Configuration;
    using TEHA.Portal.Data.Models.Administration;
    using TEHA.Portal.Data.Models.Language;
    using TEHA.Portal.Data.Services.Administration;

    /// <summary>
    /// Language Manager
    /// </summary>
    public static class LanguageManager
    {
        /// <summary>
        /// LanguageBase contains the Language messages
        /// </summary>
        private static LanguageBase englishLanguageBase = null;
        private static LanguageBase germanLanguageBase = null;
        private static LanguageService languageService = new LanguageService(new Configuration(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")));

        static LanguageManager()
        {
            Load();
        }

        /// <summary>
        /// re-set the Language messages
        /// </summary>
        public static void Refresh()
        {
            lock (englishLanguageBase)
            {
                Load();
            }
        }

        /// <summary>
        /// return English Messages
        /// </summary>
        /// <returns>LanguageBase</returns>
        public static LanguageBase GetEnglishMessages()
        {
            return englishLanguageBase;
        }

        /// <summary>
        /// return German Messages
        /// </summary>
        /// <returns>LanguageBase</returns>
        public static LanguageBase GetGermanMessages()
        {
            return germanLanguageBase;
        }

        /// <summary>
        /// set the systemMessage from messages list
        /// </summary>
        /// <param name="dbMessages">Language</param>
        private static void SetValues(List<Language> dbMessages, LanguageBase obj, bool englishInd)
        {
            // Info
            obj.Info.Heading = GetValue(dbMessages, EnumLanguages.Heading, englishInd, "Heading");
            obj.Info.TermsConditionsTab = GetValue(dbMessages, EnumLanguages.TermsConditionsTab, englishInd, "Terms & Conditions");
            obj.Info.LegalTextTab = GetValue(dbMessages, EnumLanguages.LegalTextTab, englishInd, "Legal Text");
            obj.Info.FAQTab = GetValue(dbMessages, EnumLanguages.FAQTab, englishInd, "FAQs");
            obj.Info.TermsReadMsg = GetValue(dbMessages, EnumLanguages.TermsReadMsg, englishInd, "Please read the following documents that list out Terms and Conditions");
            obj.Info.DocumentName = GetValue(dbMessages, EnumLanguages.DocumentName, englishInd, "Document Name");
            obj.Info.Pages = GetValue(dbMessages, EnumLanguages.Pages, englishInd, "Pages");
            obj.Info.PersonalDataPages = GetValue(dbMessages, EnumLanguages.PersonalDataPages, englishInd, "Personal data");

            // accouting
            obj.Accounting.AccountingLabel = GetValue(dbMessages, EnumLanguages.AccountingLabel, englishInd, "Accounting");
            obj.Accounting.DTATooltip = GetValue(dbMessages, EnumLanguages.DTATooltip, englishInd, "In case you want to activate DTA, please contact the Accounting department, Tel: 06252-93800-33 or E-Mail: abrechnung@teha-wd.de");
            obj.Accounting.Reset = GetValue(dbMessages, EnumLanguages.Reset, englishInd, "Reset");
            obj.Accounting.AccountingStatusOverview = GetValue(dbMessages, EnumLanguages.AccountingStatusOverview, englishInd, "Accounting - Status Overview");
            obj.Accounting.AccountingEnterUserData = GetValue(dbMessages, EnumLanguages.AccountingEnterUserData, englishInd, "Accounting - Enter User Data");
            obj.Accounting.TotalBill = GetValue(dbMessages, EnumLanguages.TotalBill, englishInd, "Total Bill:");
            obj.Accounting.FlatUserNo = GetValue(dbMessages, EnumLanguages.FlatUserNo, englishInd, "Flat/ User No.");
            obj.Accounting.NoOfPeople = GetValue(dbMessages, EnumLanguages.NoOfPeople, englishInd, "No. of People");
            obj.Accounting.AdvancePayments = GetValue(dbMessages, EnumLanguages.AdvancePayments, englishInd, "Advance Payments");
            obj.Accounting.HistoricEntries = GetValue(dbMessages, EnumLanguages.HistoricEntries, englishInd, "Historic Entries");
            obj.Accounting.CalcKeyHotWater = GetValue(dbMessages, EnumLanguages.CalcKeyHotWater, englishInd, "Calc. Key (Hot Water)");
            obj.Accounting.CalcKeyHeating = GetValue(dbMessages, EnumLanguages.CalcKeyHeating, englishInd, "Calc. Key (Heating)");
            obj.Accounting.OwnerData = GetValue(dbMessages, EnumLanguages.OwnerData, englishInd, "Owner Data");
            obj.Accounting.AccountingSummaryRelease = GetValue(dbMessages, EnumLanguages.AccountingSummaryRelease, englishInd, "Accounting - Summary & Release");
            obj.Accounting.EnergyCost = GetValue(dbMessages, EnumLanguages.EnergyCost, englishInd, "Energy Cost");
            obj.Accounting.YourEntries = GetValue(dbMessages, EnumLanguages.YourEntries, englishInd, "Your Entries");
            obj.Accounting.CostConcept = GetValue(dbMessages, EnumLanguages.CostConcept, englishInd, "Cost Concept");
            obj.Accounting.Units = GetValue(dbMessages, EnumLanguages.Units, englishInd, "Units");
            obj.Accounting.Consumption = GetValue(dbMessages, EnumLanguages.Consumption, englishInd, "Consumption");
            obj.Accounting.AmountGross = GetValue(dbMessages, EnumLanguages.AmountGross, englishInd, "Amount (Gross)");
            obj.Accounting.VAT = GetValue(dbMessages, EnumLanguages.VAT, englishInd, "VAT");
            obj.Accounting.TotalAmount = GetValue(dbMessages, EnumLanguages.TotalAmount, englishInd, "Total Amount");
            obj.Accounting.TehaEntries = GetValue(dbMessages, EnumLanguages.TehaEntries, englishInd, "TEHA Entries");
            obj.Accounting.UserDataChanges = GetValue(dbMessages, EnumLanguages.UserDataChanges, englishInd, "User Data(No. of User changes)");
            obj.Accounting.HeatingCost = GetValue(dbMessages, EnumLanguages.HeatingCost, englishInd, "Heating Cost");
            obj.Accounting.BackAccountingOverview = GetValue(dbMessages, EnumLanguages.BackAccountingOverview, englishInd, "Back to Accounting Overview");
            obj.Accounting.Previous = GetValue(dbMessages, EnumLanguages.Previous, englishInd, "Previous");
            obj.Accounting.TermsConditions = GetValue(dbMessages, EnumLanguages.TermsConditions, englishInd, "Terms & Conditions:");
            obj.Accounting.CompletenessCheck = GetValue(dbMessages, EnumLanguages.CompletenessCheck, englishInd, "I hereby confirm the completeness of data.");
            obj.Accounting.AccountingCostCheck = GetValue(dbMessages, EnumLanguages.AccountingCostCheck, englishInd, "The order of the individual cost categories is subject to a fee. The prices can be taken from the price list.");
            obj.Accounting.ChargesShift = GetValue(dbMessages, EnumLanguages.ChargesShift, englishInd, "Do you want to shift these charges for Smoke Detector?");
            obj.Accounting.ShiftUserCharges = GetValue(dbMessages, EnumLanguages.ShiftUserCharges, englishInd, "Do you want to shift these charges for User Change?");
            obj.Accounting.ShiftRepairCharges = GetValue(dbMessages, EnumLanguages.ShiftRepairCharges, englishInd, "Do you want to shift these charges for Repair? ");
            obj.Accounting.Heater = GetValue(dbMessages, EnumLanguages.Heater, englishInd, "Heater (100%)");
            obj.Accounting.ConsumptionPercent = GetValue(dbMessages, EnumLanguages.ConsumptionPercent, englishInd, "Consumption (%)");
            obj.Accounting.HotWatePercent = GetValue(dbMessages, EnumLanguages.HotWatePercent, englishInd, "Hot Water (100%)");
            obj.Accounting.BasicCostPercent = GetValue(dbMessages, EnumLanguages.BasicCostPercent, englishInd, "Basic Cost (%)");
            obj.Accounting.BoilerTemperature = GetValue(dbMessages, EnumLanguages.BoilerTemperature, englishInd, "Avg. Boiler Temperature (°C)");
            obj.Accounting.ConsuptionDetailHeading = GetValue(dbMessages, EnumLanguages.ConsuptionDetailHeading, englishInd, "CONSUMPTION ANALYSIS ACCORDING TO § 7 ABS. 2 HEATING COST REGULATION: Our users should receive their individual consumption analysis with the heating bill. From the current billing period, as provided in Section 7 (2) of the Heating Costs Ordinance, create a consumption analysis that takes into account the development of the costs for heating and hot water supply over the past three years. The costs amount to 4.95 euros net per living unit and are according to § 7Abs. 2 HKVO apportionable.");
            obj.Accounting.AccountingOwnerData = GetValue(dbMessages, EnumLanguages.AccountingOwnerData, englishInd, "Accounting - Enter Owner Data");
            obj.Accounting.SaveBackUserData = GetValue(dbMessages, EnumLanguages.SaveBackUserData, englishInd, "Save & Back User Data");
            obj.Accounting.UserData = GetValue(dbMessages, EnumLanguages.UserData, englishInd, "User Data");
            obj.Accounting.CostData = GetValue(dbMessages, EnumLanguages.CostData, englishInd, "Cost Data");
            obj.Accounting.SearchCostConcept = GetValue(dbMessages, EnumLanguages.SearchCostConcept, englishInd, "Search (Cost Concept)");
            obj.Accounting.PropertyData = GetValue(dbMessages, EnumLanguages.PropertyData, englishInd, "Property Data");
            obj.Accounting.AccountingEditData = GetValue(dbMessages, EnumLanguages.AccountingEditData, englishInd, "Accounting - Edit Data");
            obj.Accounting.AccountingDataExchange = GetValue(dbMessages, EnumLanguages.AccountingDataExchange, englishInd, "Accounting - Data Exchange");
            obj.Accounting.All = GetValue(dbMessages, EnumLanguages.All, englishInd, "All");
            obj.Accounting.AdditionalHotWaterCost = GetValue(dbMessages, EnumLanguages.AdditionalHotWaterCost, englishInd, "Additional Hot Water Cost");
            obj.Accounting.AdditionalHeatingCost = GetValue(dbMessages, EnumLanguages.AdditionalHeatingCost, englishInd, "Additional Heating Cost");
            obj.Accounting.WaterWasteWater = GetValue(dbMessages, EnumLanguages.WaterWasteWater, englishInd, "Water/Waste Water");
            obj.Accounting.WaterConsumption = GetValue(dbMessages, EnumLanguages.WaterConsumption, englishInd, "Water Consumption");
            obj.Accounting.GeneralElectricityIncludedMsg = GetValue(dbMessages, EnumLanguages.GeneralElectricityIncludedMsg, englishInd, "Is general electricity included?");
            obj.Accounting.CalculationKey = GetValue(dbMessages, EnumLanguages.CalculationKey, englishInd, "Calculation Key");
            obj.Accounting.WageShare = GetValue(dbMessages, EnumLanguages.WageShare, englishInd, "Wage Share");
            obj.Accounting.HouseCost = GetValue(dbMessages, EnumLanguages.HouseCost, englishInd, "House Cost");
            obj.Accounting.EnergyCostEnteredLiquidGasMsg = GetValue(dbMessages, EnumLanguages.EnergyCostEnteredLiquidGasMsg, englishInd, "You have entered Energy Cost for Liquid Gas");
            obj.Accounting.OpeningBalanceGross = GetValue(dbMessages, EnumLanguages.OpeningBalanceGross, englishInd, "Opening Balance (Gross)");
            obj.Accounting.ClosingStock = GetValue(dbMessages, EnumLanguages.ClosingStock, englishInd, "Closing Stock");
            obj.Accounting.OpeningBalanceQty = GetValue(dbMessages, EnumLanguages.OpeningBalanceQty, englishInd, "Opening Balance (Qty.)");
            obj.Accounting.PleaseFillTheFollowingMsg = GetValue(dbMessages, EnumLanguages.PleaseFillTheFollowingMsg, englishInd, "Please Fill The Following");
            obj.Accounting.EnergyCostEnteredOilPalletsMsg = GetValue(dbMessages, EnumLanguages.EnergyCostEnteredOilPalletsMsg, englishInd, "You have entered energy cost for Oil Pallets");
            obj.Accounting.UploadInvoice = GetValue(dbMessages, EnumLanguages.UploadInvoice, englishInd, "Upload Invoice");
            obj.Accounting.LastConsumption = GetValue(dbMessages, EnumLanguages.LastConsumption, englishInd, "Last Consumption");
            obj.Accounting.NetAmount = GetValue(dbMessages, EnumLanguages.NetAmount, englishInd, "Net Amount");
            obj.Accounting.NetCost = GetValue(dbMessages, EnumLanguages.NetCost, englishInd, "Net Cost");
            obj.Accounting.Enteries = GetValue(dbMessages, EnumLanguages.Enteries, englishInd, "Enteries");
            obj.Accounting.CostDeletedSuccessfully = GetValue(dbMessages, EnumLanguages.CostDeletedSuccessfully, englishInd, "Cost Deleted Successfully");
            obj.Accounting.ErrorFound = GetValue(dbMessages, EnumLanguages.ErrorFound, englishInd, "Error Found");
            obj.Accounting.FirstselectCostConcept = GetValue(dbMessages, EnumLanguages.FirstselectCostConcept, englishInd, "First select Cost Concept");
            obj.Accounting.ConceptAlreadySelected = GetValue(dbMessages, EnumLanguages.ConceptAlreadySelected, englishInd, "This Concept is already selected.");
            obj.Accounting.TooltipText1 = GetValue(dbMessages, EnumLanguages.TooltipText1, englishInd, "The accounting period for the gas invoice must be equal to the accounting period of the building. Otherwise please state the period of the invoice.");
            obj.Accounting.TooltipText2 = GetValue(dbMessages, EnumLanguages.TooltipText2, englishInd, "The calculation of the oil remainder is defined according the FIFO concept (first in/first out)");
            obj.Accounting.TooltipText3 = GetValue(dbMessages, EnumLanguages.TooltipText3, englishInd, "Please only state the invoice amount, not the discount output.");
            obj.Accounting.TooltipText4 = GetValue(dbMessages, EnumLanguages.TooltipText4, englishInd, "Those cost are not possible apportionable. Do you still want to shift them?");
            obj.Accounting.TooltipText5 = GetValue(dbMessages, EnumLanguages.TooltipText5, englishInd, "Do you want to shift rental for smoke detectors? (Please note: There is no statutory basis)");
            obj.Accounting.SuccessfullySaved = GetValue(dbMessages, EnumLanguages.SuccessfullySaved, englishInd, "Successfully Saved");
            obj.Accounting.EnterCostData = GetValue(dbMessages, EnumLanguages.EnterCostData, englishInd, "Enter Cost Data");
            obj.Accounting.LastSavedOn = GetValue(dbMessages, EnumLanguages.LastSavedOn, englishInd, "Last Saved On");
            obj.Accounting.DataExchange = GetValue(dbMessages, EnumLanguages.DataExchange, englishInd, "Data Exchange");
            obj.Accounting.EnterUserData = GetValue(dbMessages, EnumLanguages.EnterUserData, englishInd, "Enter User Data");
            obj.Accounting.AccountingemailMessage = GetValue(dbMessages, EnumLanguages.AccountingemailMessage, englishInd, "You will receive an accounting confirmation by email shortly.");
            obj.Accounting.AccountingeirReciveMsg = GetValue(dbMessages, EnumLanguages.AccountingeirReciveMsg, englishInd, "We have received your accounting, and will take care of it immediately.");
            obj.Accounting.AccountingConfirmationMessage = GetValue(dbMessages, EnumLanguages.AccountingConfirmationMessage, englishInd, "Your accounting has been confirmed.");
            obj.Accounting.WelcomeAccounting = GetValue(dbMessages, EnumLanguages.WelcomeAccounting, englishInd, "Welcome to Accounting Overview!");
            obj.Accounting.AccountingStatusAccounting = GetValue(dbMessages, EnumLanguages.AccountingStatusAccounting, englishInd, "Accounting status");
            obj.Accounting.InterimReading = GetValue(dbMessages, EnumLanguages.InterimReading, englishInd, "interim reading");
            obj.Accounting.Dta = GetValue(dbMessages, EnumLanguages.Dta, englishInd, "DTA");
            obj.Accounting.AddCostConcept = GetValue(dbMessages, EnumLanguages.AddCostConcept, englishInd, "DTA");
            obj.Accounting.RentNo = GetValue(dbMessages, EnumLanguages.RentNo, englishInd, "Rent No.");
            obj.Accounting.AccountingPeriodAccounting = GetValue(dbMessages, EnumLanguages.AccountingPeriodAccounting, englishInd, "Accounting Period");
            obj.Accounting.ClearTooltip = GetValue(dbMessages, EnumLanguages.ClearTooltip, englishInd, "Clear");
            obj.Accounting.AddInvoiceTooltip = GetValue(dbMessages, EnumLanguages.AddInvoiceTooltip, englishInd, "Add another invoice");
            obj.Accounting.AttachmentTooltip = GetValue(dbMessages, EnumLanguages.AttachmentTooltip, englishInd, "Images, pdf, excel, and word files are allowed only and File size must be under 5MB!");
            obj.Accounting.GrossAmount = GetValue(dbMessages, EnumLanguages.GrossAmount, englishInd, "Gross");
            obj.Accounting.WageShareType = GetValue(dbMessages, EnumLanguages.WageShareType, englishInd, "Wage Share Type");
            obj.Accounting.EnergyWarningConsunption = GetValue(dbMessages, EnumLanguages.EnergyWarningConsunption, englishInd, "Please cross check consumption");
            obj.Accounting.EnergyWarningDate = GetValue(dbMessages, EnumLanguages.EnergyWarningDate, englishInd, "Please cross check Invoice Date");
            obj.Accounting.AddNewUserTooltip = GetValue(dbMessages, EnumLanguages.AddNewUserTooltip, englishInd, "Add New User");
            obj.Accounting.InterimReadingAccounting = GetValue(dbMessages, EnumLanguages.InterimReadingAccounting, englishInd, "interim reading");
            obj.Accounting.AccountingEnterCostData = GetValue(dbMessages, EnumLanguages.AccountingEnterCostData, englishInd, "Accounting - Enter Cost Data");
            obj.Accounting.AccountingEnterSummaryRelease = GetValue(dbMessages, EnumLanguages.AccountingEnterSummaryRelease, englishInd, "Accounting - Enter Summary & Release");
            obj.Accounting.AccountingPeriodAccountingSelector = GetValue(dbMessages, EnumLanguages.AccountingPeriodAccountingSelector, englishInd, "Accounting Period");
            obj.Accounting.UserEdited = GetValue(dbMessages, EnumLanguages.UserEdited, englishInd, "You have edited the user name");
            obj.Accounting.DtaActive = GetValue(dbMessages, EnumLanguages.DtaActive, englishInd, "If you would like to enter the cost data and / or the user data via the web portal, please contact us at 06252-9380033 or at abrechnung@teha-wd.de.");
            obj.Accounting.DtaDeactive = GetValue(dbMessages, EnumLanguages.DtaDeactive, englishInd, "If you would like to enter the cost data and / or the user data via the web portal, please contact us at 06252-9380033 or at abrechnung@teha-wd.de");
            obj.Accounting.YourTextForBilling = GetValue(dbMessages, EnumLanguages.YourTextForBilling, englishInd, "Your text for billing");
            obj.Accounting.InternalTehaInvoice = GetValue(dbMessages, EnumLanguages.InternalTehaInvoice, englishInd, "Internal TEHA invoice. Not editable.");
            obj.Accounting.YourComment = GetValue(dbMessages, EnumLanguages.YourComment, englishInd, "your comment");
            obj.Accounting.Von = GetValue(dbMessages, EnumLanguages.Von, englishInd, "of");
            obj.Accounting.AccountingBeenProcessed = GetValue(dbMessages, EnumLanguages.AccountingBeenProcessed, englishInd, "The accounting has been processed");
            obj.Accounting.AccountingInProgress = GetValue(dbMessages, EnumLanguages.AccountingInProgress, englishInd, "The accounting is in progress");
            obj.Accounting.AccountingNotStarted = GetValue(dbMessages, EnumLanguages.AccountingNotStarted, englishInd, "The Accounting is not started");
            obj.Accounting.CanEnterData = GetValue(dbMessages, EnumLanguages.CanEnterData, englishInd, "You can enter Data");
            obj.Accounting.FileSizeMsg = GetValue(dbMessages, EnumLanguages.FileSizeMsg, englishInd, "File size must under 5MB!");
            obj.Accounting.InvalidFormat = GetValue(dbMessages, EnumLanguages.InvalidFormat, englishInd, "Invalid format");
            obj.Accounting.AccountingAdminUserNo = GetValue(dbMessages, EnumLanguages.AccountingAdminUserNo, englishInd, "Admin User No.");
            obj.Accounting.AccountingTehaUserNo = GetValue(dbMessages, EnumLanguages.AccountingTehaUserNo, englishInd, "TEHA User No.");
            obj.Accounting.AccountingSaveErrorMessage = GetValue(dbMessages, EnumLanguages.AccountingSaveErrorMessage, englishInd, "There is an error in save, Please contact with administrator.");
            obj.Accounting.AdditionalArea = GetValue(dbMessages, EnumLanguages.AdditionalArea, englishInd, "Additional Area");
            obj.Accounting.ErrorExists = GetValue(dbMessages, EnumLanguages.ErrorExists, englishInd, "There is an validation issues, please fill all mandatory fields");
            obj.Accounting.ConsumptionAnalysis = GetValue(dbMessages, EnumLanguages.ConsumptionAnalysis, englishInd, "CONSUMPTION ANALYSIS");
            obj.Accounting.SelectOption = GetValue(dbMessages, EnumLanguages.SelectOption, englishInd, "   --Select--   ");
            obj.Accounting.RentDeletedSuccessfully = GetValue(dbMessages, EnumLanguages.RentDeletedSuccessfully, englishInd, "Rent Deleted Successfully");
            obj.Accounting.OnwerDeletedSuccessfully = GetValue(dbMessages, EnumLanguages.OnwerDeletedSuccessfully, englishInd, "Onwer Deleted Successfully");
            obj.Accounting.ConceptDeletedSuccessfully = GetValue(dbMessages, EnumLanguages.ConceptDeletedSuccessfully, englishInd, "Concept Deleted Successfully");
            obj.Accounting.EnergyCostMandatoryError = GetValue(dbMessages, EnumLanguages.EnergyCostMandatoryError, englishInd, "Energy Cost must be filled. It is required for submision");
            obj.Accounting.BillingInformation = GetValue(dbMessages, EnumLanguages.BillingInformation, englishInd, "Billing Information");
            obj.Accounting.AddNewOnwerTooltip = GetValue(dbMessages, EnumLanguages.AddNewOnwerTooltip, englishInd, "Add New owner");

            // admin
            // home
            obj.Admin.Code = GetValue(dbMessages, EnumLanguages.Code, englishInd, "Code");
            obj.Admin.Category = GetValue(dbMessages, EnumLanguages.Category, englishInd, "Category");
            obj.Admin.English = GetValue(dbMessages, EnumLanguages.English, englishInd, "English");
            obj.Admin.German = GetValue(dbMessages, EnumLanguages.German, englishInd, "German");
            obj.Admin.Actions = GetValue(dbMessages, EnumLanguages.Actions, englishInd, "Actions");
            obj.Admin.LanguageSettings = GetValue(dbMessages, EnumLanguages.LanguageSettings, englishInd, "Language Settings");
            obj.Admin.SystemSettings = GetValue(dbMessages, EnumLanguages.SystemSettings, englishInd, "System Settings");
            obj.Admin.Description = GetValue(dbMessages, EnumLanguages.Description, englishInd, "Description");
            obj.Admin.FilterByCategory = GetValue(dbMessages, EnumLanguages.FilterByCategory, englishInd, "Filter by category");
            obj.Admin.Edit = GetValue(dbMessages, EnumLanguages.Edit, englishInd, "Edit");
            obj.Admin.DisplayName = GetValue(dbMessages, EnumLanguages.DisplayName, englishInd, "Display Name");
            obj.Admin.Value = GetValue(dbMessages, EnumLanguages.Value, englishInd, "Value");
            obj.Admin.LangAdmin = GetValue(dbMessages, EnumLanguages.LangAdmin, englishInd, "Admin");
            obj.Admin.LangAccount = GetValue(dbMessages, EnumLanguages.LangAccount, englishInd, "Account");
            obj.Admin.LangInfo = GetValue(dbMessages, EnumLanguages.LangInfo, englishInd, "Info");
            obj.Admin.LngSearchPlaceholder = GetValue(dbMessages, EnumLanguages.LngSearchPlaceholder, englishInd, "Search (Code, Category, English, German)");

            // home
            obj.Home.LabelHeading = GetValue(dbMessages, EnumLanguages.LabelHeading, englishInd, "Are you sure you want to delete");
            obj.Home.OrdersinProgress = GetValue(dbMessages, EnumLanguages.OrdersinProgress, englishInd, "Orders in Progress");
            obj.Home.SmokeDetectorStatus = GetValue(dbMessages, EnumLanguages.SmokeDetectorStatus, englishInd, "Smoke Detector Status");
            obj.Home.InvoicesPending = GetValue(dbMessages, EnumLanguages.InvoicesPending, englishInd, "Invoices Pending");
            obj.Home.ContactPerson = GetValue(dbMessages, EnumLanguages.ContactPerson, englishInd, "Contact Person:");
            obj.Home.EmailFormatted = GetValue(dbMessages, EnumLanguages.EmailFormatted, englishInd, "E-mail:");
            obj.Home.Tel = GetValue(dbMessages, EnumLanguages.Tel, englishInd, "Tel:");
            obj.Home.MyContactPersons = GetValue(dbMessages, EnumLanguages.MyContactPersons, englishInd, "My Contact Persons  (General)");
            obj.Home.OfficeHours = GetValue(dbMessages, EnumLanguages.OfficeHours, englishInd, "Office Hours:");
            obj.Home.MountingEquipment = GetValue(dbMessages, EnumLanguages.MountingEquipment, englishInd, "Mounting And Measuring Equipment");
            obj.Home.Statements = GetValue(dbMessages, EnumLanguages.Statements, englishInd, "Statements");
            obj.Home.Reading = GetValue(dbMessages, EnumLanguages.Reading, englishInd, "Reading");
            obj.Home.EnergyPCertificate = GetValue(dbMessages, EnumLanguages.EnergyPCertificate, englishInd, "Energy Performance Certificate");
            obj.Home.OffersContracts = GetValue(dbMessages, EnumLanguages.OffersContracts, englishInd, "Offers & Contracts");
            obj.Home.Pending = GetValue(dbMessages, EnumLanguages.Pending, englishInd, "Pending");
            obj.Home.OK = GetValue(dbMessages, EnumLanguages.OK, englishInd, "OK");
            obj.Home.Plumbing = GetValue(dbMessages, EnumLanguages.Plumbing, englishInd, "Plumbing");
            obj.Home.Finalized = GetValue(dbMessages, EnumLanguages.Finalized, englishInd, "Finalized");
            obj.Home.OutOfOrder = GetValue(dbMessages, EnumLanguages.OutOfOrder, englishInd, "Out of Order");
            obj.Home.MissingData = GetValue(dbMessages, EnumLanguages.MissingData, englishInd, "Missing Data");
            obj.Home.AccountingStatusHome = GetValue(dbMessages, EnumLanguages.AccountingStatusHome, englishInd, "Accounting status");
            obj.Home.ReadingStatusHome = GetValue(dbMessages, EnumLanguages.ReadingStatusHome, englishInd, "Reading status");
            obj.Home.Dated = GetValue(dbMessages, EnumLanguages.Dated, englishInd, "Dated");
            obj.Home.ReferenceLink = GetValue(dbMessages, EnumLanguages.ReferenceLink, englishInd, "Reference Link");
            obj.Home.News = GetValue(dbMessages, EnumLanguages.News, englishInd, "News");

            // account
            obj.Account.NewMemberDetail = GetValue(dbMessages, EnumLanguages.NewMemberDetail, englishInd, "New Member Details");
            obj.Account.Assign = GetValue(dbMessages, EnumLanguages.Assign, englishInd, "Assign");
            obj.Account.Add = GetValue(dbMessages, EnumLanguages.Add, englishInd, "Add");
            obj.Account.ChangePassword = GetValue(dbMessages, EnumLanguages.ChangePassword, englishInd, "Change Password");
            obj.Account.SignIn = GetValue(dbMessages, EnumLanguages.SignIn, englishInd, "Sign In");
            obj.Account.Password = GetValue(dbMessages, EnumLanguages.Password, englishInd, "Password");
            obj.Account.Welcome = GetValue(dbMessages, EnumLanguages.Welcome, englishInd, "Welcome to the Customer Portal");
            obj.Account.Username = GetValue(dbMessages, EnumLanguages.Username, englishInd, "User name");
            obj.Account.NotAuser = GetValue(dbMessages, EnumLanguages.NotAuser, englishInd, "Not a user");
            obj.Account.ForgotPassword = GetValue(dbMessages, EnumLanguages.ForgotPassword, englishInd, "Forgot Password");
            obj.Account.Login = GetValue(dbMessages, EnumLanguages.Login, englishInd, "Log In");
            obj.Account.GetInTouch = GetValue(dbMessages, EnumLanguages.GetInTouch, englishInd, "Get in touch");
            obj.Account.Submit = GetValue(dbMessages, EnumLanguages.Submit, englishInd, "Submit");
            obj.Account.UsernamePlaceholder = GetValue(dbMessages, EnumLanguages.UsernamePlaceholder, englishInd, "Enter your register username");
            obj.Account.PersonalData = GetValue(dbMessages, EnumLanguages.PersonalData, englishInd, "Personal Data");
            obj.Account.NoOptionSelected = GetValue(dbMessages, EnumLanguages.NoOptionSelected, englishInd, "No option selected");

            // account (My Profile)
            obj.Account.DefectedSmokeStatement = GetValue(dbMessages, EnumLanguages.DefectedSmokeStatement, englishInd, "When do you want to be informed about defected smoke detectors");
            obj.Account.RemainingLettersStatement = GetValue(dbMessages, EnumLanguages.RemainingLettersStatement, englishInd, "How do you want to receive your remaining letters?");
            obj.Account.PlumbingReportsStatement = GetValue(dbMessages, EnumLanguages.PlumbingReportsStatement, englishInd, "How do you want to receive the plumbing reports?");
            obj.Account.PlumbingDatesStatement = GetValue(dbMessages, EnumLanguages.PlumbingDatesStatement, englishInd, "How do you want to be informed about the plumbing dates?");
            obj.Account.ReceiveAccountingStatement = GetValue(dbMessages, EnumLanguages.ReceiveAccountingStatement, englishInd, "How do you want to receive the accounting document?");
            obj.Account.ReceiveReadingReportStatement = GetValue(dbMessages, EnumLanguages.ReceiveReadingReportStatement, englishInd, "Do you want to receive a report after first reading attempt? If yes, then how?");
            obj.Account.NewInvoiceStatement = GetValue(dbMessages, EnumLanguages.NewInvoiceStatement, englishInd, "How do you want to be informed, if a new invoice is available in the Customer Portal ?");
            obj.Account.ReadingDatesStatement = GetValue(dbMessages, EnumLanguages.ReadingDatesStatement, englishInd, "How do you want to be informed about reading dates ?");
            obj.Account.ReceiveBillStatement = GetValue(dbMessages, EnumLanguages.ReceiveBillStatement, englishInd, "How do you want to receive bill/invoice ?");
            obj.Account.UsersNotAvailableStatement = GetValue(dbMessages, EnumLanguages.UsersNotAvailableStatement, englishInd, "When do you want to be informed about users being not available within readings?");
            obj.Account.MyTeam = GetValue(dbMessages, EnumLanguages.MyTeam, englishInd, "My Team");
            obj.Account.MyContracts = GetValue(dbMessages, EnumLanguages.MyContracts, englishInd, "My Contracts");
            obj.Account.AssignBuildings = GetValue(dbMessages, EnumLanguages.AssignBuildings, englishInd, "Assign Buildings");
            obj.Account.Notifications = GetValue(dbMessages, EnumLanguages.Notifications, englishInd, "Notifications");
            obj.Account.General = GetValue(dbMessages, EnumLanguages.General, englishInd, "General");
            obj.Account.Settings = GetValue(dbMessages, EnumLanguages.Settings, englishInd, "Settings");
            obj.Account.Cancel = GetValue(dbMessages, EnumLanguages.Cancel, englishInd, "Cancel");
            obj.Account.Save = GetValue(dbMessages, EnumLanguages.Save, englishInd, "Save");
            obj.Account.SaveForUser = GetValue(dbMessages, EnumLanguages.SaveForUser, englishInd, "Save For User");
            obj.Account.Fax = GetValue(dbMessages, EnumLanguages.Fax, englishInd, "Fax");
            obj.Account.Mobile = GetValue(dbMessages, EnumLanguages.Mobile, englishInd, "Mobile");
            obj.Account.Phone = GetValue(dbMessages, EnumLanguages.Phone, englishInd, "Phone");
            obj.Account.StreetAddress = GetValue(dbMessages, EnumLanguages.StreetAddress, englishInd, "Street Address");
            obj.Account.Name = GetValue(dbMessages, EnumLanguages.Name, englishInd, "Name");
            obj.Account.EndDate = GetValue(dbMessages, EnumLanguages.EndDate, englishInd, "End Date");
            obj.Account.StartDate = GetValue(dbMessages, EnumLanguages.StartDate, englishInd, "Start Date");
            obj.Account.ContractType = GetValue(dbMessages, EnumLanguages.ContractType, englishInd, "Contract Type");
            obj.Account.ConfirmPassword = GetValue(dbMessages, EnumLanguages.ConfirmPassword, englishInd, "Confirm Password");
            obj.Account.NewPassword = GetValue(dbMessages, EnumLanguages.NewPassword, englishInd, "New Password");
            obj.Account.CurrentPassword = GetValue(dbMessages, EnumLanguages.CurrentPassword, englishInd, "Current Password");
            obj.Account.CommunicationChannels = GetValue(dbMessages, EnumLanguages.CommunicationChannels, englishInd, "Communication Channels");
            obj.Account.AssignNewBuilding = GetValue(dbMessages, EnumLanguages.AssignNewBuilding, englishInd, "Assign New Building");
            obj.Account.AddNewTeamMember = GetValue(dbMessages, EnumLanguages.AddNewTeamMember, englishInd, "Add New Team Member");
            obj.Account.RequestTeamMember = GetValue(dbMessages, EnumLanguages.RequestTeamMember, englishInd, "Request Team Member");
            obj.Account.AssignPropertyData = GetValue(dbMessages, EnumLanguages.AssignPropertyData, englishInd, "Assign Property Data");
            obj.Account.Preferences = GetValue(dbMessages, EnumLanguages.Preferences, englishInd, "Preferences");
            obj.Account.LanguagePreference = GetValue(dbMessages, EnumLanguages.LanguagePreference, englishInd, "Language Preference");
            obj.Account.NumberOfRowsPage = GetValue(dbMessages, EnumLanguages.NumberOfRowsPage, englishInd, "Number of rows per page");
            obj.Account.SamePrimaryEmail = GetValue(dbMessages, EnumLanguages.SamePrimaryEmail, englishInd, "Same as Primary Email");
            obj.Account.Salutation = GetValue(dbMessages, EnumLanguages.Salutation, englishInd, "Salutation");
            obj.Account.SamePrimaryAddress = GetValue(dbMessages, EnumLanguages.SamePrimaryAddress, englishInd, "Same as Primary Address");
            obj.Account.EditTeamMember = GetValue(dbMessages, EnumLanguages.EditTeamMember, englishInd, "Edit Team Member");
            obj.Account.SaveForThisProperty = GetValue(dbMessages, EnumLanguages.SaveForThisProperty, englishInd, "Save For this Property");
            obj.Account.Update = GetValue(dbMessages, EnumLanguages.Update, englishInd, "Update");
            obj.Account.SaveNewConfigurations = GetValue(dbMessages, EnumLanguages.SaveNewConfigurations, englishInd, "Save New Configurations");
            obj.Account.ConfigurationsOverwriteMessage = GetValue(dbMessages, EnumLanguages.ConfigurationsOverwriteMessage, englishInd, "By clicking on YES, all individual building configurations will be overwritten. Do you want to Proceed?");
            obj.Account.OneAap = GetValue(dbMessages, EnumLanguages.OneAap, englishInd, "One Email for All");
            obj.Account.OneAep = GetValue(dbMessages, EnumLanguages.OneAep, englishInd, "One per Property");
            obj.Account.OnePi = GetValue(dbMessages, EnumLanguages.OnePi, englishInd, "One per Invoice");
            obj.Account.OneAapTooltip = GetValue(dbMessages, EnumLanguages.OneAapTooltip, englishInd, "One Email for All Invoices of All Properties");
            obj.Account.OneAepTooltip = GetValue(dbMessages, EnumLanguages.OneAepTooltip, englishInd, "One Email for All Invoices for each Property");
            obj.Account.OnePiTooltip = GetValue(dbMessages, EnumLanguages.OnePiTooltip, englishInd, "One Email for each Invoice");
            obj.Account.ConfigurationsOverwriteMessage = GetValue(dbMessages, EnumLanguages.ConfigurationsOverwriteMessage, englishInd, "By clicking on YES, all individual building configurations will be overwritten. Do you want to Proceed?");
            obj.Account.AppSearchBarMyTeams = GetValue(dbMessages, EnumLanguages.AppSearchBarMyTeams, englishInd, "Search (User Name, TEHA LG No., Admin LG No.)");
            obj.Account.AddNewEmail = GetValue(dbMessages, EnumLanguages.AddNewEmail, englishInd, "Add New Email Address");
            obj.Account.SecondaryHeading = GetValue(dbMessages, EnumLanguages.SecondaryHeading, englishInd, "Secondary Details");
            obj.Account.PrimaryHeading = GetValue(dbMessages, EnumLanguages.PrimaryHeading, englishInd, "Primary Details");
            obj.Account.AdditionalEmail = GetValue(dbMessages, EnumLanguages.AdditionalEmail, englishInd, "Additional Email");
            obj.Account.F = GetValue(dbMessages, EnumLanguages.F, englishInd, "After first reading attempt");
            obj.Account.S = GetValue(dbMessages, EnumLanguages.S, englishInd, "After second reading attempt");
            obj.Account.PersonalDataTabMsg = GetValue(dbMessages, EnumLanguages.PersonalDataTabMsg, englishInd, "Here you can view and change your personal data.");
            obj.Account.NotificationsTabMsg = GetValue(dbMessages, EnumLanguages.NotificationsTabMsg, englishInd, "You decide when and how you want to be informed about new bills or invoices, assemblies and readings.");
            obj.Account.PasswordTabMsg = GetValue(dbMessages, EnumLanguages.PasswordTabMsg, englishInd, "Change your current password here.");
            obj.Account.ContractsTabMsg = GetValue(dbMessages, EnumLanguages.ContractsTabMsg, englishInd, "Download your contracts in PDF format here and see more detailed information.");
            obj.Account.TeamsTabMsg = GetValue(dbMessages, EnumLanguages.TeamsTabMsg, englishInd, "Assign your managers to existing properties or expand your team here.");
            obj.Account.MyOffersTabMsg = GetValue(dbMessages, EnumLanguages.MyOffersTabMsg, englishInd, "Here you can see your offers and download the document.");
            obj.Account.MyPreferencesTabMsg = GetValue(dbMessages, EnumLanguages.MyPreferencesTabMsg, englishInd, "Here you can change language and page size of the application.");
            obj.Account.MyProfileEmailTooltip = GetValue(dbMessages, EnumLanguages.MyProfileEmailTooltip, englishInd, "All invoices will be sent to the selected emails");
            // stockOverview
            obj.StockOverview.TehaLgNo = GetValue(dbMessages, EnumLanguages.TehaLgNo, englishInd, "TEHA Lg No.");
            obj.StockOverview.InProgress = GetValue(dbMessages, EnumLanguages.InProgress, englishInd, "In Progress");
            obj.StockOverview.PropertyOverview = GetValue(dbMessages, EnumLanguages.PropertyOverview, englishInd, "Property Overview");
            obj.StockOverview.Flats = GetValue(dbMessages, EnumLanguages.Flats, englishInd, "Flats");
            obj.StockOverview.Buildings = GetValue(dbMessages, EnumLanguages.Buildings, englishInd, "Buildings");
            obj.StockOverview.Meters = GetValue(dbMessages, EnumLanguages.Meters, englishInd, "Meters");
            obj.StockOverview.BuildingsDefectSmokeDetectors = GetValue(dbMessages, EnumLanguages.BuildingsDefectSmokeDetectors, englishInd, "Building with Defect RWM");
            obj.StockOverview.Address = GetValue(dbMessages, EnumLanguages.Address, englishInd, "Address (Street, Postcode, City)");
            obj.StockOverview.OffersPending = GetValue(dbMessages, EnumLanguages.OffersPending, englishInd, "Offers Pending");
            obj.StockOverview.OpenLettersPending = GetValue(dbMessages, EnumLanguages.OpenLettersPending, englishInd, "Open Letters Pending");
            obj.StockOverview.AccountingPending = GetValue(dbMessages, EnumLanguages.AccountingPending, englishInd, "Accounting Pending");
            obj.StockOverview.CreateOrder = GetValue(dbMessages, EnumLanguages.CreateOrder, englishInd, "Create an Order");
            obj.StockOverview.OpenLetter = GetValue(dbMessages, EnumLanguages.OpenLetter, englishInd, "Open Letter");
            obj.StockOverview.StockOverviewLabel = GetValue(dbMessages, EnumLanguages.StockOverviewLabel, englishInd, "Stock Overview");
            obj.StockOverview.PlumbingStatus = GetValue(dbMessages, EnumLanguages.PlumbingStatus, englishInd, "Plumbing Status");
            obj.StockOverview.ReadingStatus = GetValue(dbMessages, EnumLanguages.ReadingStatus, englishInd, "Reading Status");
            obj.StockOverview.AccountingStatus = GetValue(dbMessages, EnumLanguages.AccountingStatus, englishInd, "Accounting Status");
            obj.StockOverview.AccountingPeriod = GetValue(dbMessages, EnumLanguages.AccountingPeriod, englishInd, "Accounting Period");
            obj.StockOverview.RwmStatus = GetValue(dbMessages, EnumLanguages.RwmStatus, englishInd, "RWM Status");
            obj.StockOverview.MeterStatus = GetValue(dbMessages, EnumLanguages.MeterStatus, englishInd, "Meter Status");
            obj.StockOverview.Floor = GetValue(dbMessages, EnumLanguages.Floor, englishInd, "Floor");
            obj.StockOverview.AdminLgNo = GetValue(dbMessages, EnumLanguages.AdminLgNo, englishInd, "Admin LG No.");
            obj.StockOverview.AdminUserNo = GetValue(dbMessages, EnumLanguages.AdminUserNo, englishInd, "Admin User No.");
            obj.StockOverview.TehaUserNo = GetValue(dbMessages, EnumLanguages.TehaUserNo, englishInd, "TEHA User No.");
            obj.StockOverview.Street = GetValue(dbMessages, EnumLanguages.Street, englishInd, "Street");
            obj.StockOverview.FlatOverviewLabel = GetValue(dbMessages, EnumLanguages.FlatOverviewLabel, englishInd, "Flat Overview");
            obj.StockOverview.Location = GetValue(dbMessages, EnumLanguages.Location, englishInd, "Location");
            obj.StockOverview.Select = GetValue(dbMessages, EnumLanguages.Select, englishInd, "Select");
            obj.StockOverview.MeterOverviewHeading = GetValue(dbMessages, EnumLanguages.MeterOverviewHeading, englishInd, "Meter Overview");
            obj.StockOverview.AllMetersHeading = GetValue(dbMessages, EnumLanguages.AllMetersHeading, englishInd, "All Meters");
            obj.StockOverview.MeterSerialNo = GetValue(dbMessages, EnumLanguages.MeterSerialNo, englishInd, "Meter Serial No.");
            obj.StockOverview.MeterType = GetValue(dbMessages, EnumLanguages.MeterType, englishInd, "Meter Type");
            obj.StockOverview.City = GetValue(dbMessages, EnumLanguages.City, englishInd, "City");
            obj.StockOverview.Postcode = GetValue(dbMessages, EnumLanguages.Postcode, englishInd, "Postcode");
            obj.StockOverview.Property = GetValue(dbMessages, EnumLanguages.Property, englishInd, "Property");
            obj.StockOverview.SeeAllMeters = GetValue(dbMessages, EnumLanguages.SeeAllMeters, englishInd, "See All Meters of the Building");
            obj.StockOverview.AppSearchBarFlat = GetValue(dbMessages, EnumLanguages.AppSearchBarFlat, englishInd, "Search (User No., Location)");
            obj.StockOverview.AppSearchBarMeter = GetValue(dbMessages, EnumLanguages.AppSearchBarMeter, englishInd, "Meter Serial No., Meter Type, Location");
            obj.StockOverview.AppSearchBarProperty = GetValue(dbMessages, EnumLanguages.AppSearchBarProperty, englishInd, "Meter Serial No., Meter Type, Location");
            obj.StockOverview.Dta = GetValue(dbMessages, EnumLanguages.Dta, englishInd, "DTA");
            obj.StockOverview.Activated = GetValue(dbMessages, EnumLanguages.Activated, englishInd, "Activated");
            obj.StockOverview.NotActivated = GetValue(dbMessages, EnumLanguages.NotActivated, englishInd, "Not Activated");
            obj.StockOverview.ShortOverview = GetValue(dbMessages, EnumLanguages.ShortOverview, englishInd, "Short Overview");
            obj.StockOverview.PlannedOn = GetValue(dbMessages, EnumLanguages.PlannedOn, englishInd, "Planned On");
            obj.StockOverview.PropertySearchPlaceholder = GetValue(dbMessages, EnumLanguages.PropertySearchPlaceholder, englishInd, "Search (Admin Lg No., Teha Lg No, etc)");
            obj.StockOverview.DefaultSearchPlaceholder = GetValue(dbMessages, EnumLanguages.DefaultSearchPlaceholder, englishInd, "Search (Admin User No., Location, etc)");
            obj.StockOverview.OnHoldTooltip = GetValue(dbMessages, EnumLanguages.OnHoldTooltip, englishInd, "The order is currently blocked due to missing feedback to open letters");
            obj.StockOverview.AccountingperiodUserLevel = GetValue(dbMessages, EnumLanguages.AccountingperiodUserLevel, englishInd, "Accounting period");
            obj.StockOverview.ReadingStatusUserLevel = GetValue(dbMessages, EnumLanguages.ReadingStatusUserLevel, englishInd, "Reading status");
            obj.StockOverview.PlumbingstatusMeterLevel = GetValue(dbMessages, EnumLanguages.PlumbingstatusMeterLevel, englishInd, "Plumbing status");
            obj.StockOverview.PlumbingStatusUserLevel = GetValue(dbMessages, EnumLanguages.PlumbingStatusUserLevel, englishInd, "Plumbing status");
            obj.StockOverview.ReadingPlannedOn = GetValue(dbMessages, EnumLanguages.ReadingPlannedOn, englishInd, "Planned On");

            // Order
            obj.Order.DrinkingWater = GetValue(dbMessages, EnumLanguages.DrinkingWater, englishInd, "Drinking Water");
            obj.Order.EnergyPerformance = GetValue(dbMessages, EnumLanguages.EnergyPerformance, englishInd, "Energy Performance");
            obj.Order.SmokeDetectorTest = GetValue(dbMessages, EnumLanguages.SmokeDetectorTest, englishInd, "Smoke Detector Test");
            obj.Order.InterimReading = GetValue(dbMessages, EnumLanguages.InterimReading, englishInd, "Interim Reading");
            obj.Order.EnterInterimReading = GetValue(dbMessages, EnumLanguages.EnterInterimReading, englishInd, "Enter Interim Reading");
            obj.Order.OrderReading = GetValue(dbMessages, EnumLanguages.OrderReading, englishInd, "Order Reading");
            obj.Order.OrderPlumbing = GetValue(dbMessages, EnumLanguages.OrderPlumbing, englishInd, "Order Plumbing");
            obj.Order.OrderType = GetValue(dbMessages, EnumLanguages.OrderType, englishInd, "Order Type");
            obj.Order.OrderStatus = GetValue(dbMessages, EnumLanguages.OrderStatus, englishInd, "Order Status");
            obj.Order.MyOrdersOverview = GetValue(dbMessages, EnumLanguages.MyOrdersOverview, englishInd, "My Orders -Overview");
            obj.Order.SmokeNotAvailTooltip = GetValue(dbMessages, EnumLanguages.SmokeNotAvailTooltip, englishInd, "This User does not have any Smoke Detectors Installed");
            obj.Order.SmokeNotAvailTooltipProperty = GetValue(dbMessages, EnumLanguages.SmokeNotAvailTooltipProperty, englishInd, "This Property does not have any Smoke Detectors Installed");

            obj.Order.BackToOrders = GetValue(dbMessages, EnumLanguages.BackToOrders, englishInd, "Back to Orders");
            obj.Order.OrderConfirmationMessage = GetValue(dbMessages, EnumLanguages.OrderConfirmationMessage, englishInd, "Your order has been confirmed.");
            obj.Order.ReceivedOrder = GetValue(dbMessages, EnumLanguages.ReceivedOrder, englishInd, "We have received your order, and will take care of it immediately.");
            obj.Order.EmailMessage = GetValue(dbMessages, EnumLanguages.EmailMessage, englishInd, "You will receive an order confirmation by email shortly.");
            obj.Order.TehaServiceTeam = GetValue(dbMessages, EnumLanguages.TehaServiceTeam, englishInd, "TEHA Service Team");
            obj.Order.Confirm = GetValue(dbMessages, EnumLanguages.Confirm, englishInd, "Confirm");
            obj.Order.DataProtectionMessage = GetValue(dbMessages, EnumLanguages.DataProtectionMessage, englishInd, "I have read the declaration on data protection and agree to the storage of data for the period specified by TEHA.");
            obj.Order.InterimReadingCostMessage = GetValue(dbMessages, EnumLanguages.InterimReadingCostMessage, englishInd, "There is a charge for ordering the interim meter reading. I storage of data for the period specified by TEHA.");
            obj.Order.TermsMessagePart1 = GetValue(dbMessages, EnumLanguages.TermsMessagePart1, englishInd, "I have read and understood the");
            obj.Order.TermsMessagePart2 = GetValue(dbMessages, EnumLanguages.TermsMessagePart2, englishInd, "Terms & Conditions, and the Cancellation Policy.");
            obj.Order.TermsMessagePart3 = GetValue(dbMessages, EnumLanguages.TermsMessagePart3, englishInd, ", and the");
            obj.Order.TermsMessagePart4 = GetValue(dbMessages, EnumLanguages.TermsMessagePart4, englishInd, "Cancellation Policy.");
            obj.Order.EmailAddress = GetValue(dbMessages, EnumLanguages.EmailAddress, englishInd, "Email");
            obj.Order.MobileNo = GetValue(dbMessages, EnumLanguages.MobileNo, englishInd, "Mobile No.");
            obj.Order.TelephoneNo = GetValue(dbMessages, EnumLanguages.TelephoneNo, englishInd, "Telephone No.");
            obj.Order.FirstName = GetValue(dbMessages, EnumLanguages.FirstName, englishInd, "First Name");
            obj.Order.LastName = GetValue(dbMessages, EnumLanguages.LastName, englishInd, "Last Name");
            obj.Order.AlternateUser = GetValue(dbMessages, EnumLanguages.AlternateUser, englishInd, "Alternate User");
            obj.Order.Comments = GetValue(dbMessages, EnumLanguages.Comments, englishInd, "Comments");
            obj.Order.AlternativeDateRange = GetValue(dbMessages, EnumLanguages.AlternativeDateRange, englishInd, "Alternative Date Range");
            obj.Order.To = GetValue(dbMessages, EnumLanguages.To, englishInd, "to");
            obj.Order.BestAccessibility = GetValue(dbMessages, EnumLanguages.BestAccessibility, englishInd, "Best Accessibility");
            obj.Order.LetterMail = GetValue(dbMessages, EnumLanguages.LetterMail, englishInd, "Letter (Mail)");
            obj.Order.NotifyThrough = GetValue(dbMessages, EnumLanguages.NotifyThrough, englishInd, "Notify Through");
            obj.Order.AppointmentDate = GetValue(dbMessages, EnumLanguages.AppointmentDate, englishInd, "Appointment Date");
            obj.Order.AppointmentDetails = GetValue(dbMessages, EnumLanguages.AppointmentDetails, englishInd, "Appointment Details");
            obj.Order.OrderReadingFormHeader = GetValue(dbMessages, EnumLanguages.OrderReadingFormHeader, englishInd, "Order Reading -- Enter Data");
            obj.Order.OrderSmokeDetectorFormHeader = GetValue(dbMessages, EnumLanguages.OrderSmokeDetectorFormHeader, englishInd, "Order Smoke Detector Test");
            obj.Order.UserMovingOut = GetValue(dbMessages, EnumLanguages.UserMovingOut, englishInd, "User Moving Out");
            obj.Order.MoveoutDate = GetValue(dbMessages, EnumLanguages.MoveoutDate, englishInd, "Move-out-Date");
            obj.Order.AppointmentRequestDate = GetValue(dbMessages, EnumLanguages.AppointmentRequestDate, englishInd, "Appointment Request Date");
            obj.Order.NewUser = GetValue(dbMessages, EnumLanguages.NewUser, englishInd, "New User");
            obj.Order.PriceList = GetValue(dbMessages, EnumLanguages.PriceList, englishInd, "price list.");
            obj.Order.SmokeDetectorCostMessage = GetValue(dbMessages, EnumLanguages.SmokeDetectorCostMessage, englishInd, "There is a charge for ordering the smoke detector test. I agree to pay those charges according to the ");
            obj.Order.ReadingCostMessage = GetValue(dbMessages, EnumLanguages.ReadingCostMessage, englishInd, "There is a charge for ordering reading. I agree to pay those charges according to the ");

            obj.Order.IRFormTitle = GetValue(dbMessages, EnumLanguages.IRFormTitle, englishInd, "Order Interim Reading");
            obj.Order.OrderSummary = GetValue(dbMessages, EnumLanguages.OrderSummary, englishInd, "Order Summary");
            obj.Order.SelectAFlat = GetValue(dbMessages, EnumLanguages.SelectAFlat, englishInd, "Select a Flat:");
            obj.Order.IRSummaryTitle = GetValue(dbMessages, EnumLanguages.IRSummaryTitle, englishInd, "You have ordered “Interim Meter Reading“ for the following flat(s):");
            obj.Order.ContinuetoUserData = GetValue(dbMessages, EnumLanguages.ContinuetoUserData, englishInd, "Continue to User Data");
            obj.Order.GotoAppointmentDetails = GetValue(dbMessages, EnumLanguages.GotoAppointmentDetails, englishInd, "Go to Appointment Details");
            obj.Order.ContinuetoMeters = GetValue(dbMessages, EnumLanguages.ContinuetoMeters, englishInd, "Continue to Meters");
            obj.Order.RSummaryTitle = GetValue(dbMessages, EnumLanguages.RSummaryTitle, englishInd, "You have ordered “Reading“ for the following flat:");

            obj.Order.InstalledLocation = GetValue(dbMessages, EnumLanguages.InstalledLocation, englishInd, "Installed Location");
            obj.Order.CounterReading = GetValue(dbMessages, EnumLanguages.CounterReading, englishInd, "Counter Reading");
            obj.Order.LastReading = GetValue(dbMessages, EnumLanguages.LastReading, englishInd, "Last Reading");
            obj.Order.EIRSummaryTitle = GetValue(dbMessages, EnumLanguages.EIRSummaryTitle, englishInd, "You have “Entered Interim Readings” for the following flat:");
            obj.Order.OrderConfirmation = GetValue(dbMessages, EnumLanguages.OrderConfirmation, englishInd, "Order Confirmation");
            obj.Order.AddressOnly = GetValue(dbMessages, EnumLanguages.AddressOnly, englishInd, "Address");
            obj.Order.AddressParts = GetValue(dbMessages, EnumLanguages.AddressParts, englishInd, "(Street, Postcode, City)");

            obj.Order.RequestaQuote = GetValue(dbMessages, EnumLanguages.RequestaQuote, englishInd, "Request a Quote");
            obj.Order.RequestaQuoteSummary = GetValue(dbMessages, EnumLanguages.RequestaQuoteSummary, englishInd, "Request a Quote -- Summary");
            obj.Order.CommentsQuestion = GetValue(dbMessages, EnumLanguages.CommentsQuestion, englishInd, "Is there anything you would like to add?");
            obj.Order.CommentsObservations = GetValue(dbMessages, EnumLanguages.CommentsObservations, englishInd, "Comments / Observations");
            obj.Order.Next = GetValue(dbMessages, EnumLanguages.Next, englishInd, "Next");
            obj.Order.ThankYouMsg = GetValue(dbMessages, EnumLanguages.ThankYouMsg, englishInd, "Thank you for filling the details to “Request a Quote”.");
            obj.Order.CheckMsg = GetValue(dbMessages, EnumLanguages.CheckMsg, englishInd, "Please check the following to complete your request:");
            obj.Order.TermsAndCondition = GetValue(dbMessages, EnumLanguages.TermsAndCondition, englishInd, "I have read and understood the Terms & Conditions, and the Cancellation Policy.");
            obj.Order.ConfirmEntriesMsg = GetValue(dbMessages, EnumLanguages.ConfirmEntriesMsg, englishInd, "I confirm that all entries are complete and correct.");
            obj.Order.PSOne = GetValue(dbMessages, EnumLanguages.PSOne, englishInd, "Please select one");
            obj.Order.MetersQuestion = GetValue(dbMessages, EnumLanguages.MetersQuestion, englishInd, "Are meters already installed?");
            obj.Order.Yes = GetValue(dbMessages, EnumLanguages.Yes, englishInd, "Yes");
            obj.Order.No = GetValue(dbMessages, EnumLanguages.No, englishInd, "No");
            obj.Order.IDWAMeter = GetValue(dbMessages, EnumLanguages.IDWAMeter, englishInd, "I don’t want a meter");
            obj.Order.OwnerOrManager = GetValue(dbMessages, EnumLanguages.OwnerOrManager, englishInd, "Are you the owner or property manager?");
            obj.Order.Owner = GetValue(dbMessages, EnumLanguages.Owner, englishInd, "Owner");
            obj.Order.PropertyManager = GetValue(dbMessages, EnumLanguages.PropertyManager, englishInd, "Property Manager");
            obj.Order.OtherTypeDescription = GetValue(dbMessages, EnumLanguages.OtherTypeDescription, englishInd, "Other Type Description");
            obj.Order.TypesOfServices = GetValue(dbMessages, EnumLanguages.TypesOfServices, englishInd, "Types of Services");
            obj.Order.SelectApply = GetValue(dbMessages, EnumLanguages.SelectApply, englishInd, "Please select all that apply");

            obj.Order.TypeOfBuilding = GetValue(dbMessages, EnumLanguages.TypeOfBuilding, englishInd, "Type of Building");
            obj.Order.Residential = GetValue(dbMessages, EnumLanguages.Residential, englishInd, "Residential");
            obj.Order.Commercial = GetValue(dbMessages, EnumLanguages.Commercial, englishInd, "Commercial");
            obj.Order.ResidentialCommercial = GetValue(dbMessages, EnumLanguages.ResidentialCommercial, englishInd, "Residential & Commercial");
            obj.Order.UserContactDetails = GetValue(dbMessages, EnumLanguages.UserContactDetails, englishInd, "User Contact Details");
            obj.Order.NewPropertyAddress = GetValue(dbMessages, EnumLanguages.NewPropertyAddress, englishInd, "New Property Address");
            obj.Order.NoOfFlats = GetValue(dbMessages, EnumLanguages.NoOfFlats, englishInd, "No. of flats");
            obj.Order.NoOfCommercialUnits = GetValue(dbMessages, EnumLanguages.NoOfCommercialUnits, englishInd, "No. of commercial units");

            obj.Order.Rent = GetValue(dbMessages, EnumLanguages.Rent, englishInd, "Rent");
            obj.Order.WarrantyMaintenance = GetValue(dbMessages, EnumLanguages.WarrantyMaintenance, englishInd, "Warranty Maintanence");
            obj.Order.Purchase = GetValue(dbMessages, EnumLanguages.Purchase, englishInd, "Purchase");

            obj.Order.SerialNumber = GetValue(dbMessages, EnumLanguages.SerialNumber, englishInd, "Serial Number");
            obj.Order.TestReason = GetValue(dbMessages, EnumLanguages.TestReason, englishInd, "Test Reason");
            obj.Order.SDTSTitle = GetValue(dbMessages, EnumLanguages.SDTSTitle, englishInd, "You have ordered “Smoke Detector Test“ for the following flat:");
            obj.Order.Amount = GetValue(dbMessages, EnumLanguages.Amount, englishInd, "Amount");
            obj.Order.Unit = GetValue(dbMessages, EnumLanguages.Unit, englishInd, "Unit");
            obj.Order.OrderEnergyCertificate = GetValue(dbMessages, EnumLanguages.OrderEnergyCertificate, englishInd, " Order Energy Certificate");
            obj.Order.YearOfConstruction = GetValue(dbMessages, EnumLanguages.YearOfConstruction, englishInd, "Year of Construction");
            obj.Order.YearOfHeating = GetValue(dbMessages, EnumLanguages.YearOfHeating, englishInd, "Year of Heating");
            obj.Order.RenewalOfHeating = GetValue(dbMessages, EnumLanguages.RenewalOfHeating, englishInd, "Renewal of Heating");
            obj.Order.HeatableArea = GetValue(dbMessages, EnumLanguages.HeatableArea, englishInd, "Heatable Area");
            obj.Order.Basementheated = GetValue(dbMessages, EnumLanguages.Basementheated, englishInd, "Basement heated");
            obj.Order.HeatingSystem = GetValue(dbMessages, EnumLanguages.HeatingSystem, englishInd, "Heating System");
            obj.Order.BuildingWithBasement = GetValue(dbMessages, EnumLanguages.BuildingWithBasement, englishInd, "Building with basement");
            obj.Order.MonumentProtection = GetValue(dbMessages, EnumLanguages.MonumentProtection, englishInd, "Monument Protection");
            obj.Order.IsBCool = GetValue(dbMessages, EnumLanguages.IsBCool, englishInd, "Is the building cooled");
            obj.Order.EnergySource = GetValue(dbMessages, EnumLanguages.EnergySource, englishInd, "Energy Source");
            obj.Order.FloorHeating = GetValue(dbMessages, EnumLanguages.FloorHeating, englishInd, "Floor Heating");
            obj.Order.CentralHeating = GetValue(dbMessages, EnumLanguages.CentralHeating, englishInd, "Central Heating");
            obj.Order.HeatingOil = GetValue(dbMessages, EnumLanguages.HeatingOil, englishInd, "Heating Oil");
            obj.Order.LiquidGas = GetValue(dbMessages, EnumLanguages.LiquidGas, englishInd, "Liquid Gas");
            obj.Order.DistrictHeating = GetValue(dbMessages, EnumLanguages.DistrictHeating, englishInd, "District Heating");
            obj.Order.Electricity = GetValue(dbMessages, EnumLanguages.Electricity, englishInd, "Electricity");
            obj.Order.Annex = GetValue(dbMessages, EnumLanguages.Annex, englishInd, "Annex");
            obj.Order.PCYCR = GetValue(dbMessages, EnumLanguages.PCYCR, englishInd, "Please cross check your counter reading");
            obj.Order.Vacant = GetValue(dbMessages, EnumLanguages.Vacant, englishInd, "Vacant");
            obj.Order.UserMovingIn = GetValue(dbMessages, EnumLanguages.UserMovingIn, englishInd, "User Moving In");
            obj.Order.MoveInDate = GetValue(dbMessages, EnumLanguages.MoveInDate, englishInd, "Move-in-Date");
            obj.Order.EIRReciveMsg = GetValue(dbMessages, EnumLanguages.EIRReciveMsg, englishInd, "We have received your enter Interim Meter Readings.");
            obj.Order.Partially = GetValue(dbMessages, EnumLanguages.Partially, englishInd, "Partially");
            obj.Order.NaturalGas = GetValue(dbMessages, EnumLanguages.NaturalGas, englishInd, "Natural Gas");
            obj.Order.Wood = GetValue(dbMessages, EnumLanguages.Wood, englishInd, "Wood");
            obj.Order.HeatPump = GetValue(dbMessages, EnumLanguages.HeatPump, englishInd, "Heat Pump");
            obj.Order.Period = GetValue(dbMessages, EnumLanguages.Period, englishInd, "Period");
            obj.Order.ConsumptionForTE = GetValue(dbMessages, EnumLanguages.ConsumptionForTE, englishInd, "Consumption for Thermal Energy");
            obj.Order.VacancyIn = GetValue(dbMessages, EnumLanguages.VacancyIn, englishInd, "Vacancy in");
            obj.Order.RenovationMeasure = GetValue(dbMessages, EnumLanguages.RenovationMeasure, englishInd, "Renovation Measures");
            obj.Order.FacadeInsulationYear = GetValue(dbMessages, EnumLanguages.FacadeInsulationYear, englishInd, "Facade Insulation Year");
            obj.Order.RoofInsulationYear = GetValue(dbMessages, EnumLanguages.RoofInsulationYear, englishInd, "Roof Insulation Year");
            obj.Order.SolarSystemYear = GetValue(dbMessages, EnumLanguages.SolarSystemYear, englishInd, "Solar System Installation Year");
            obj.Order.TheBuilding = GetValue(dbMessages, EnumLanguages.TheBuilding, englishInd, "The Building");
            obj.Order.NoResidentialUnits = GetValue(dbMessages, EnumLanguages.NoResidentialUnits, englishInd, "No. of Residential Units");
            obj.Order.TMFEnergyCertificate = GetValue(dbMessages, EnumLanguages.TMFEnergyCertificate, englishInd, "Thank you for filling details for “Energy Performace Certificate”.");
            obj.Order.AHWUsed = GetValue(dbMessages, EnumLanguages.AHWUsed, englishInd, "Amount of Hot Water Used");
            obj.Order.QuickActions = GetValue(dbMessages, EnumLanguages.QuickActions, englishInd, "Quick Actions");
            obj.Order.FloatRequestReadingProperty = GetValue(dbMessages, EnumLanguages.FloatRequestReadingProperty, englishInd, "Request Reading (Property)");
            obj.Order.FloatRequestReadingFlat = GetValue(dbMessages, EnumLanguages.FloatRequestReadingFlat, englishInd, "Request Reading (Flat)");
            obj.Order.RequestEnergyCertificate = GetValue(dbMessages, EnumLanguages.RequestEnergyCertificate, englishInd, "Request Energy Certificate");
            obj.Order.RequestDWA = GetValue(dbMessages, EnumLanguages.RequestDWA, englishInd, "Request Drinking Water Analysis");
            obj.Order.OrderSmokeDetectorTestFlat = GetValue(dbMessages, EnumLanguages.OrderSmokeDetectorTestFlat, englishInd, "Order Smoke Detector Test (Flat)");
            obj.Order.OrderSmokeDetectorTestMeter = GetValue(dbMessages, EnumLanguages.OrderSmokeDetectorTestMeter, englishInd, "Order Smoke Detector Test (Meter)");
            obj.Order.OfferRequest = GetValue(dbMessages, EnumLanguages.OfferRequest, englishInd, "Offer Request");
            obj.Order.CreateNewOrder = GetValue(dbMessages, EnumLanguages.CreateNewOrder, englishInd, "Create New Order");
            obj.Order.FloatRequestReadingMeter = GetValue(dbMessages, EnumLanguages.FloatRequestReadingMeter, englishInd, "Request Reading (Meter)");
            obj.Order.OrderPlumbingSummary = GetValue(dbMessages, EnumLanguages.OrderPlumbingSummary, englishInd, "Order Plumbing -- Summary");
            obj.Order.OrderReadingSummary = GetValue(dbMessages, EnumLanguages.OrderReadingSummary, englishInd, "Order Reading -- Summary");
            obj.Order.OrderSmokeDetectorTestSummary = GetValue(dbMessages, EnumLanguages.OrderSmokeDetectorTestSummary, englishInd, "Order Smoke Detector Test -- Summary");
            obj.Order.WhyInspectionQuestion = GetValue(dbMessages, EnumLanguages.WhyInspectionQuestion, englishInd, "Why is the system subject to inspection?");
            obj.Order.OrderNewBuilding = GetValue(dbMessages, EnumLanguages.OrderNewBuilding, englishInd, "Order Drinking Water Analysis - New Building");
            obj.Order.NoPreviousData = GetValue(dbMessages, EnumLanguages.NoPreviousData, englishInd, "Looks like there’s no previous order data available!");
            obj.Order.CreateAnOrder = GetValue(dbMessages, EnumLanguages.CreateAnOrder, englishInd, "Create an Order");
            obj.Order.SampleAvaliable = GetValue(dbMessages, EnumLanguages.SampleAvaliable, englishInd, "Are sampling valves available?");
            obj.Order.AdvanceInspection = GetValue(dbMessages, EnumLanguages.AdvanceInspection, englishInd, "Would you like an inspection in advance?");
            obj.Order.WhichApartment = GetValue(dbMessages, EnumLanguages.WhichApartment, englishInd, "Which apartment should be checked?");
            obj.Order.ExtractionPoints = GetValue(dbMessages, EnumLanguages.ExtractionPoints, englishInd, "Extraction Points");
            obj.Order.SelectTap = GetValue(dbMessages, EnumLanguages.SelectTap, englishInd, "Please select a tap.");
            obj.Order.YesFlow = GetValue(dbMessages, EnumLanguages.YesFlow, englishInd, "Yes, in flow");
            obj.Order.YesReturn = GetValue(dbMessages, EnumLanguages.YesReturn, englishInd, "Yes, on the return");
            obj.Order.NoValves = GetValue(dbMessages, EnumLanguages.NoValves, englishInd, "There are no valves");
            obj.Order.WaterSummary = GetValue(dbMessages, EnumLanguages.WaterSummary, englishInd, " Order Drinking Water Analysis - Summary");
            obj.Order.StorageValumeLiters = GetValue(dbMessages, EnumLanguages.StorageValumeLiters, englishInd, "Storage volume> 400 liters");
            obj.Order.LineLitters = GetValue(dbMessages, EnumLanguages.LineLitters, englishInd, "Line content> 3 liters");
            obj.Order.HotWaterGeneration = GetValue(dbMessages, EnumLanguages.HotWaterGeneration, englishInd, "Hot water generation included?");
            obj.Order.RequiredMeters = GetValue(dbMessages, EnumLanguages.RequiredMeters, englishInd, "Required Meters");
            obj.Order.CertificateCostMsg = GetValue(dbMessages, EnumLanguages.CertificateCostMsg, englishInd, "There is a charge for ordering the energy certificate . I agree to pay those charges according to the");
            obj.Order.MeasurementTake = GetValue(dbMessages, EnumLanguages.MeasurementTake, englishInd, "Measurement takes place via WWZ?");
            obj.Order.YouHaveOrder = GetValue(dbMessages, EnumLanguages.YouHaveOrder, englishInd, "You have ordered");
            obj.Order.RequestMeter = GetValue(dbMessages, EnumLanguages.RequestMeter, englishInd, "request for the following meter:");
            obj.Order.PlumbingReason = GetValue(dbMessages, EnumLanguages.PlumbingReason, englishInd, "Plumbing Reason");
            obj.Order.PlumbingCostIndMsg = GetValue(dbMessages, EnumLanguages.PlumbingCostIndMsg, englishInd, "We confirm that we will bear the costs, provided that the measuring device is not defective or there is no warranty claim.");
            obj.Order.DrinkingWaterPropertyMsg = GetValue(dbMessages, EnumLanguages.DrinkingWaterPropertyMsg, englishInd, "You have ordered “Drinking Water Analysis“ for the following property(s):");
            obj.Order.OrderDrinkingWaterAnalysis = GetValue(dbMessages, EnumLanguages.OrderDrinkingWaterAnalysis, englishInd, "Order Drinking Water Analysis");
            obj.Order.DrinkingWaterCostIndMsg = GetValue(dbMessages, EnumLanguages.DrinkingWaterCostIndMsg, englishInd, "The comissioning of the drinking water sampling is subject to a");
            obj.Order.Fee = GetValue(dbMessages, EnumLanguages.Fee, englishInd, "fee.");
            obj.Order.SelectAMeter = GetValue(dbMessages, EnumLanguages.SelectAMeter, englishInd, "Select a Meter");
            obj.Order.SelectAProperty = GetValue(dbMessages, EnumLanguages.SelectAProperty, englishInd, "Select a Property");
            obj.Order.ContinueToFlats = GetValue(dbMessages, EnumLanguages.ContinueToFlats, englishInd, "Continue to Flats");
            obj.Order.CouldNotCancel = GetValue(dbMessages, EnumLanguages.CouldNotCancel, englishInd, "Could Not Cancel");
            obj.Order.OrderCancelled = GetValue(dbMessages, EnumLanguages.OrderCancelled, englishInd, "Order Cancelled");
            obj.Order.SureCancelMsg = GetValue(dbMessages, EnumLanguages.SureCancelMsg, englishInd, "Are you sure you want to Cancel?");
            obj.Order.CancelOrder = GetValue(dbMessages, EnumLanguages.CancelOrder, englishInd, "Cancel Order?");
            obj.Order.AlternativeDateErrorMsg = GetValue(dbMessages, EnumLanguages.AlternativeDateErrorMsg, englishInd, "Alternative To date must be greater than From date");
            obj.Order.PrefillDataError = GetValue(dbMessages, EnumLanguages.PrefillDataError, englishInd, "Order prefill data error");
            obj.Order.OrderFailMsg = GetValue(dbMessages, EnumLanguages.OrderFailMsg, englishInd, "Could not place order!");
            obj.Order.SubmitFailMsg = GetValue(dbMessages, EnumLanguages.SubmitFailMsg, englishInd, "Request could not be submitted!");
            obj.Order.PlumbingSummaryFlatMsg = GetValue(dbMessages, EnumLanguages.PlumbingSummaryFlatMsg, englishInd, "request for the following flat");
            obj.Order.OrderPlumbingFlat = GetValue(dbMessages, EnumLanguages.OrderPlumbingFlat, englishInd, "Order Plumbing (Flat)");
            obj.Order.OrderPlumbingMeter = GetValue(dbMessages, EnumLanguages.OrderPlumbingMeter, englishInd, "Order Plumbing (Meter)");
            obj.Order.OrderDrinkingWaterAnalysisConfirmation = GetValue(dbMessages, EnumLanguages.OrderDrinkingWaterAnalysisConfirmation, englishInd, "Order Drinking Water Analysis -- Confirmation");
            obj.Order.OrderReadingConfirmation = GetValue(dbMessages, EnumLanguages.OrderReadingConfirmation, englishInd, "Order Reading -- Confirmation");
            obj.Order.Hello = GetValue(dbMessages, EnumLanguages.Hello, englishInd, "Hello");
            obj.Order.Building1 = GetValue(dbMessages, EnumLanguages.Building1, englishInd, "Detached Family House");
            obj.Order.Building2 = GetValue(dbMessages, EnumLanguages.Building2, englishInd, "Single-family Detached House");
            obj.Order.Building3 = GetValue(dbMessages, EnumLanguages.Building3, englishInd, "Two-sided Detached House");
            obj.Order.Building4 = GetValue(dbMessages, EnumLanguages.Building4, englishInd, "Detached Two-family House");
            obj.Order.Building5 = GetValue(dbMessages, EnumLanguages.Building5, englishInd, "Two-family House Built on One Side");
            obj.Order.Building6 = GetValue(dbMessages, EnumLanguages.Building6, englishInd, "Two-family House Built on Two Side");
            obj.Order.Building7 = GetValue(dbMessages, EnumLanguages.Building7, englishInd, "Apartment Building");
            obj.Order.Building8 = GetValue(dbMessages, EnumLanguages.Building8, englishInd, "Part of a mixed-use Building");
            obj.Order.PleaseEnterText = GetValue(dbMessages, EnumLanguages.PleaseEnterText, englishInd, "Please enter text");
            obj.Order.OrdersSearchPlacholder = GetValue(dbMessages, EnumLanguages.OrdersSearchPlacholder, englishInd, "Search (Teha LG No., Admin LG No., TEHA User & Admin User)");
            obj.Order.InsulationCeilingYear = GetValue(dbMessages, EnumLanguages.InsulationCeilingYear, englishInd, "Insulation Ceiling Year");
            obj.Order.AverageTemperature = GetValue(dbMessages, EnumLanguages.AverageTemperature, englishInd, "Hot Water Average Temperature");
            obj.Order.RenovationWindowsYear = GetValue(dbMessages, EnumLanguages.RenovationWindowsYear, englishInd, "Renovation Windows Year");
            obj.Order.UserValidationMsg = GetValue(dbMessages, EnumLanguages.UserValidationMsg, englishInd, "User moving in date must be greater or equal to user moving out.");
            obj.Order.BuildingImage = GetValue(dbMessages, EnumLanguages.BuildingImage, englishInd, "Building Images");
            obj.Order.AirCondition = GetValue(dbMessages, EnumLanguages.AirCondition, englishInd, "Air Condition");
            obj.Order.IsAirConditionAvailable = GetValue(dbMessages, EnumLanguages.IsAirConditionAvailable, englishInd, "Is there an air conditioner available?");
            obj.Order.NextServiceDate = GetValue(dbMessages, EnumLanguages.NextServiceDate, englishInd, "Next Service Date");
            obj.Order.ImagesMissingMsg = GetValue(dbMessages, EnumLanguages.ImagesMissingMsg, englishInd, "Please select 3 images of the building");
            obj.Order.ChooseImage = GetValue(dbMessages, EnumLanguages.ChooseImage, englishInd, "Please upload building image!");
            obj.Order.OrderDrinkingWater = GetValue(dbMessages, EnumLanguages.OrderDrinkingWater, englishInd, "Order Drinking Water Analysis");
            obj.Order.Service = GetValue(dbMessages, EnumLanguages.Service, englishInd, "Service");
            obj.Order.AttachImage = GetValue(dbMessages, EnumLanguages.AttachImage, englishInd, "Upload Image");
            obj.Order.Test_water = GetValue(dbMessages, EnumLanguages.Test_water, englishInd, "TEST_WATER");
            obj.Order.Test_rw = GetValue(dbMessages, EnumLanguages.Test_rw, englishInd, "TEST_RW");
            obj.Order.MyOffers = GetValue(dbMessages, EnumLanguages.MyOffers, englishInd, "My Offers");
            obj.Order.PCYEOPMR = GetValue(dbMessages, EnumLanguages.PCYEOPMR, englishInd, "The value is smaller than the last read value. Please check your entry or add a picture of the meter reading.");
            obj.Order.AllMoveOutReadingsTooltip = GetValue(dbMessages, EnumLanguages.AllMoveOutReadingsTooltip, englishInd, "The data has already entered for this period.");

            // DocumentArchives
            obj.DocumentArchives.Invoices = GetValue(dbMessages, EnumLanguages.Invoices, englishInd, "Invoices");
            obj.DocumentArchives.DownloadPdf = GetValue(dbMessages, EnumLanguages.DownloadPdf, englishInd, "Download PDF");
            obj.DocumentArchives.DownloadSepaStatement = GetValue(dbMessages, EnumLanguages.DownloadSepaStatement, englishInd, "Download Sepa Statement");
            obj.DocumentArchives.SepaDebitMandate = GetValue(dbMessages, EnumLanguages.SepaDebitMandate, englishInd, "SEPA Direct Debit Mandate");
            obj.DocumentArchives.AllDocuments = GetValue(dbMessages, EnumLanguages.AllDocuments, englishInd, "All Documents");
            obj.DocumentArchives.DrinkingWaterSamples = GetValue(dbMessages, EnumLanguages.DrinkingWaterSamples, englishInd, "Drinking Water Samples");
            obj.DocumentArchives.EnergyCertificates = GetValue(dbMessages, EnumLanguages.EnergyCertificates, englishInd, "Energy Certificates");
            obj.DocumentArchives.Download = GetValue(dbMessages, EnumLanguages.Download, englishInd, "Download");
            obj.DocumentArchives.Difference = GetValue(dbMessages, EnumLanguages.Difference, englishInd, "Difference");
            obj.DocumentArchives.Status = GetValue(dbMessages, EnumLanguages.Status, englishInd, "Status");
            obj.DocumentArchives.DateOfInvoice = GetValue(dbMessages, EnumLanguages.DateOfInvoice, englishInd, "Date Of Invoice");
            obj.DocumentArchives.InvoiceNumber = GetValue(dbMessages, EnumLanguages.InvoiceNumber, englishInd, "Invoice Number");
            obj.DocumentArchives.InvoiceAmount = GetValue(dbMessages, EnumLanguages.InvoiceAmount, englishInd, "Invoice Amount");
            obj.DocumentArchives.DescriptionDocument = GetValue(dbMessages, EnumLanguages.DescriptionDocument, englishInd, "Description Document");
            obj.DocumentArchives.CreationDate = GetValue(dbMessages, EnumLanguages.CreationDate, englishInd, "Creation Date");
            obj.DocumentArchives.DocumentCategory = GetValue(dbMessages, EnumLanguages.DocumentCategory, englishInd, "Document Category");
            obj.DocumentArchives.RentId = GetValue(dbMessages, EnumLanguages.RentId, englishInd, "Rent ID");
            obj.DocumentArchives.DownloadAllPropertyDocs = GetValue(dbMessages, EnumLanguages.DownloadAllPropertyDocs, englishInd, "Download All Property Documents");
            obj.DocumentArchives.DownloadAllFlatDocs = GetValue(dbMessages, EnumLanguages.DownloadAllFlatDocs, englishInd, "Download All Flat Documents");
            obj.DocumentArchives.DownloadAllMeterDocs = GetValue(dbMessages, EnumLanguages.DownloadAllMeterDocs, englishInd, "Download All Meter Documents");
            obj.DocumentArchives.DrinkingDoc = GetValue(dbMessages, EnumLanguages.DrinkingDoc, englishInd, "Drinking Samples");
            obj.DocumentArchives.EnergyDoc = GetValue(dbMessages, EnumLanguages.EnergyDoc, englishInd, "Energy Certificates");
            obj.DocumentArchives.PlumbingDoc = GetValue(dbMessages, EnumLanguages.PlumbingDoc, englishInd, "Plumbing");
            obj.DocumentArchives.ReadingDoc = GetValue(dbMessages, EnumLanguages.ReadingDoc, englishInd, "Reading");
            obj.DocumentArchives.AccountingDoc = GetValue(dbMessages, EnumLanguages.AccountingDoc, englishInd, "Accounting");
            obj.DocumentArchives.InvoiceDoc = GetValue(dbMessages, EnumLanguages.InvoiceDoc, englishInd, "Invoice");
            obj.DocumentArchives.RentNo = GetValue(dbMessages, EnumLanguages.RentNo, englishInd, "RentNo.");

            obj.DocumentArchives.Tab0 = GetValue(dbMessages, EnumLanguages.Tab0, englishInd, "Invoice Overview");
            obj.DocumentArchives.Tab1 = GetValue(dbMessages, EnumLanguages.Tab1, englishInd, "Accounting Documents");
            obj.DocumentArchives.Tab2 = GetValue(dbMessages, EnumLanguages.Tab2, englishInd, "Reading Documents");
            obj.DocumentArchives.Tab3 = GetValue(dbMessages, EnumLanguages.Tab3, englishInd, "Plumbing Documents");
            obj.DocumentArchives.Tab4 = GetValue(dbMessages, EnumLanguages.Tab4, englishInd, "Energy Certificate Documents");
            obj.DocumentArchives.Tab5 = GetValue(dbMessages, EnumLanguages.Tab5, englishInd, "Drinking Water Supply Documents");
            obj.DocumentArchives.Tab6 = GetValue(dbMessages, EnumLanguages.Tab6, englishInd, "All Documents");
            obj.DocumentArchives.Tab7 = GetValue(dbMessages, EnumLanguages.Tab7, englishInd, "SEPA Direct Debit Mandate");
            obj.DocumentArchives.Tab8 = GetValue(dbMessages, EnumLanguages.Tab8, englishInd, "Accounting Documents - Flat");
            obj.DocumentArchives.Paid = GetValue(dbMessages, EnumLanguages.Paid, englishInd, "Paid");
            obj.DocumentArchives.UnPaid = GetValue(dbMessages, EnumLanguages.UnPaid, englishInd, "UnPaid");
            obj.DocumentArchives.AccountingPeriodDoc = GetValue(dbMessages, EnumLanguages.AccountingPeriodDoc, englishInd, "Accounting period");
            obj.DocumentArchives.InvoiceOverviewAllBuildings = GetValue(dbMessages, EnumLanguages.InvoiceOverviewAllBuildings, englishInd, "Invoice Overview - All Buildings");
            obj.DocumentArchives.SeeAllInvoices = GetValue(dbMessages, EnumLanguages.SeeAllInvoices, englishInd, "Invoice Overview - All Buildings");

            // Lookups
            obj.Lookup.Email = GetValue(dbMessages, EnumLanguages.Email, englishInd, "Email");
            obj.Lookup.SMS = GetValue(dbMessages, EnumLanguages.SMS, englishInd, "SMS");
            obj.Lookup.Postal = GetValue(dbMessages, EnumLanguages.Postal, englishInd, "Postal");
            obj.Lookup.Web = GetValue(dbMessages, EnumLanguages.Web, englishInd, "Web");

            obj.Lookup.HCA = GetValue(dbMessages, EnumLanguages.HCA, englishInd, "HCA");
            obj.Lookup.Other = GetValue(dbMessages, EnumLanguages.Other, englishInd, "Other");
            obj.Lookup.ColdWater = GetValue(dbMessages, EnumLanguages.ColdWater, englishInd, "Cold Water");
            obj.Lookup.HeatMeter = GetValue(dbMessages, EnumLanguages.HeatMeter, englishInd, "Heat Meter");
            obj.Lookup.SmokeDetector = GetValue(dbMessages, EnumLanguages.SmokeDetector, englishInd, "Smoke Detector");
            obj.Lookup.HotWater = GetValue(dbMessages, EnumLanguages.HotWater, englishInd, "Hot Water");
            obj.Lookup.AHCHW = GetValue(dbMessages, EnumLanguages.AHCHW, englishInd, "Accounting (Heating Cost & Hot Water)");
            obj.Lookup.ACW = GetValue(dbMessages, EnumLanguages.ACW, englishInd, "Accounting (Cold Water)");
            obj.Lookup.SAC = GetValue(dbMessages, EnumLanguages.SAC, englishInd, "Settlement of Ancillary Costs");
            obj.Lookup.NSN = GetValue(dbMessages, EnumLanguages.NSN, englishInd, "No service necessary");

            obj.Lookup.OSVal0 = GetValue(dbMessages, EnumLanguages.OSVal0, englishInd, "OPEN");
            obj.Lookup.OSVal1 = GetValue(dbMessages, EnumLanguages.OSVal1, englishInd, "GENERATED");
            obj.Lookup.OSVal2 = GetValue(dbMessages, EnumLanguages.OSVal2, englishInd, "PLAN");
            obj.Lookup.OSVal3 = GetValue(dbMessages, EnumLanguages.OSVal3, englishInd, "CANCEL");
            obj.Lookup.OSVal4 = GetValue(dbMessages, EnumLanguages.OSVal4, englishInd, "FINISH");
            obj.Lookup.Cancel = GetValue(dbMessages, EnumLanguages.Cancel, englishInd, "CANCEL");
            obj.Lookup.TypedrinkingWaterSampling = GetValue(dbMessages, EnumLanguages.TypedrinkingWaterSampling, englishInd, "drinkingWaterSampling");
            obj.Lookup.TypeenergyCertificate = GetValue(dbMessages, EnumLanguages.TypeenergyCertificate, englishInd, "energyCertificate");
            obj.Lookup.TypeinterimReading = GetValue(dbMessages, EnumLanguages.TypeinterimReading, englishInd, "interimReading");
            obj.Lookup.Typeoffer = GetValue(dbMessages, EnumLanguages.Typeoffer, englishInd, "offer");
            obj.Lookup.Typeplumbing = GetValue(dbMessages, EnumLanguages.Typeplumbing, englishInd, "plumbing");
            obj.Lookup.TypepostInterimReading = GetValue(dbMessages, EnumLanguages.TypepostInterimReading, englishInd, "postInterimReading");
            obj.Lookup.Typereading = GetValue(dbMessages, EnumLanguages.Typereading, englishInd, "reading");
            obj.Lookup.TypesmokeDetectorTest = GetValue(dbMessages, EnumLanguages.TypesmokeDetectorTest, englishInd, "smokeDetectorTest");
            obj.Lookup.Ok = GetValue(dbMessages, EnumLanguages.OK, englishInd, "OK");
            obj.Lookup.Warning = GetValue(dbMessages, EnumLanguages.Warning, englishInd, "Warning");
            obj.Lookup.Error = GetValue(dbMessages, EnumLanguages.Error, englishInd, "Error");
            obj.Lookup.Not_pending = GetValue(dbMessages, EnumLanguages.Not_pending, englishInd, "NOT_PENDING");
            obj.Lookup.OPEN = GetValue(dbMessages, EnumLanguages.OPEN, englishInd, "OPEN");
            obj.Lookup.PLAN = GetValue(dbMessages, EnumLanguages.PLAN, englishInd, "PLAN");
            obj.Lookup.FINISHED = GetValue(dbMessages, EnumLanguages.FINISHED, englishInd, "FINISHED");
            obj.Lookup.Wait_data = GetValue(dbMessages, EnumLanguages.Wait_data, englishInd, "WAIT_DATA");
            obj.Lookup.In_preparation = GetValue(dbMessages, EnumLanguages.In_preparation, englishInd, "IN_PREPARATION");
            obj.Lookup.DOWNLOADED = GetValue(dbMessages, EnumLanguages.DOWNLOADED, englishInd, "DOWNLOADED");
            obj.Lookup.FINISH = GetValue(dbMessages, EnumLanguages.FINISH, englishInd, "FINISH");
            obj.Lookup.Not_started = GetValue(dbMessages, EnumLanguages.Not_started, englishInd, "NOT_STARTED");
            obj.Lookup.On_hold = GetValue(dbMessages, EnumLanguages.On_hold, englishInd, "ON_HOLD");
            obj.Lookup.EndPeriod = GetValue(dbMessages, EnumLanguages.EndPeriod, englishInd, "Annual reading");
            obj.Lookup.EndPeriod2At = GetValue(dbMessages, EnumLanguages.EndPeriod2At, englishInd, "Annual reading after date");
            obj.Lookup.EndPeriod3At = GetValue(dbMessages, EnumLanguages.EndPeriod3At, englishInd, "Payable late appointment");
            obj.Lookup.ChangeRent = GetValue(dbMessages, EnumLanguages.ChangeRent, englishInd, "Intermediate reading");
            obj.Lookup.Punctual = GetValue(dbMessages, EnumLanguages.Punctual, englishInd, "Special reading");
            obj.Lookup.Null = GetValue(dbMessages, EnumLanguages.Null, englishInd, string.Empty);
            obj.Lookup.MeterDefect = GetValue(dbMessages, EnumLanguages.MeterDefect, englishInd, "Meter Defect");
            obj.Lookup.NewRadiator = GetValue(dbMessages, EnumLanguages.NewRadiator, englishInd, "New Radiator");
            obj.Lookup.RemoveMeter = GetValue(dbMessages, EnumLanguages.RemoveMeter, englishInd, "Remove Meter");
            obj.Lookup.ReplaceRadiator = GetValue(dbMessages, EnumLanguages.ReplaceRadiator, englishInd, "ReplaceRadiator");
            obj.Lookup.CheckMeter = GetValue(dbMessages, EnumLanguages.CheckMeter, englishInd, "Check Meter");
            obj.Lookup.MeterMissing = GetValue(dbMessages, EnumLanguages.MeterMissing, englishInd, "Meter Missing");

            // Miscellaneous
            obj.Miscellaneous.Type = GetValue(dbMessages, EnumLanguages.Type, englishInd, "Type");
            obj.Miscellaneous.HelloCardWelcome = GetValue(dbMessages, EnumLanguages.HelloCardWelcome, englishInd, "How can we help you today?");
            obj.Miscellaneous.AddedSuccessfully = GetValue(dbMessages, EnumLanguages.AddedSuccessfully, englishInd, "Added Successfully");
            obj.Miscellaneous.ChangedSuccessfully = GetValue(dbMessages, EnumLanguages.ChangedSuccessfully, englishInd, "Changed Successfully");
            obj.Miscellaneous.CurrentPasswordWrong = GetValue(dbMessages, EnumLanguages.CurrentPasswordWrong, englishInd, "Current Password is Wrong");
            obj.Miscellaneous.CouldNotUpdate = GetValue(dbMessages, EnumLanguages.CouldNotUpdate, englishInd, "Could Not Update");
            obj.Miscellaneous.CurrentPasswordMatch = GetValue(dbMessages, EnumLanguages.CurrentPasswordMatch, englishInd, "Current Password should not match new Password");
            obj.Miscellaneous.FillAllFields = GetValue(dbMessages, EnumLanguages.FillAllFields, englishInd, "Please fill all fields");
            obj.Miscellaneous.PasswordsNotMatch = GetValue(dbMessages, EnumLanguages.PasswordsNotMatch, englishInd, "Passwords do not Match");
            obj.Miscellaneous.ChangesDiscarded = GetValue(dbMessages, EnumLanguages.ChangesDiscarded, englishInd, "Changes Discarded");
            obj.Miscellaneous.ChangeDataBeforeSaving = GetValue(dbMessages, EnumLanguages.ChangeDataBeforeSaving, englishInd, "Please change some data before saving");
            obj.Miscellaneous.UpdatedSuccessfully = GetValue(dbMessages, EnumLanguages.UpdatedSuccessfully, englishInd, "Updated Successfully");
            obj.Miscellaneous.PropertyDeletedSuccessfully = GetValue(dbMessages, EnumLanguages.PropertyDeletedSuccessfully, englishInd, "Property Deleted Successfully");
            obj.Miscellaneous.DeletePropertyQuestion = GetValue(dbMessages, EnumLanguages.DeletePropertyQuestion, englishInd, "Are you sure you want to delete the selected property?");
            obj.Miscellaneous.SelectValidProperty = GetValue(dbMessages, EnumLanguages.SelectValidProperty, englishInd, "Please Select Valid Property");
            obj.Miscellaneous.PropertyExists = GetValue(dbMessages, EnumLanguages.PropertyExists, englishInd, "Property already Exists");
            obj.Miscellaneous.AssignedSuccessfully = GetValue(dbMessages, EnumLanguages.AssignedSuccessfully, englishInd, "Assigned Successfully");
            obj.Miscellaneous.Home = GetValue(dbMessages, EnumLanguages.Home, englishInd, "Home");
            obj.Miscellaneous.AccountingOverview = GetValue(dbMessages, EnumLanguages.AccountingOverview, englishInd, "Accounting Overview");
            obj.Miscellaneous.MyOrders = GetValue(dbMessages, EnumLanguages.MyOrders, englishInd, "My Orders");
            obj.Miscellaneous.DocumentArchives = GetValue(dbMessages, EnumLanguages.DocumentArchives, englishInd, "Document Archives");
            obj.Miscellaneous.MyContactPeople = GetValue(dbMessages, EnumLanguages.MyContactPeople, englishInd, "My Contact People");
            obj.Miscellaneous.MyProfile = GetValue(dbMessages, EnumLanguages.MyProfile, englishInd, "My Profile");
            obj.Miscellaneous.Logout = GetValue(dbMessages, EnumLanguages.Logout, englishInd, "Log out");
            obj.Miscellaneous.Searchyourproperties = GetValue(dbMessages, EnumLanguages.Searchyourproperties, englishInd, "Search your properties");
            obj.Miscellaneous.CouldNotDownload = GetValue(dbMessages, EnumLanguages.CouldNotDownload, englishInd, "Could Not Download Document");
            obj.Miscellaneous.CouldNotCostData = GetValue(dbMessages, EnumLanguages.CouldNotCostData, englishInd, "Could Not Get Cost Data.");
            obj.Miscellaneous.SLDipl = GetValue(dbMessages, EnumLanguages.SLDipl, englishInd, "Computer Scientist");
            obj.Miscellaneous.SLIng = GetValue(dbMessages, EnumLanguages.SLIng, englishInd, "Ing.");
            obj.Miscellaneous.SLProfDr = GetValue(dbMessages, EnumLanguages.SLProfDr, englishInd, "Prof. Dr.");
            obj.Miscellaneous.SLProf = GetValue(dbMessages, EnumLanguages.SLProf, englishInd, "Prof.");
            obj.Miscellaneous.SLDr = GetValue(dbMessages, EnumLanguages.SLDr, englishInd, "Dr.");
            obj.Miscellaneous.SLDipIngFH = GetValue(dbMessages, EnumLanguages.SLDipIngFH, englishInd, "Dipl. Ing. (FH)");
            obj.Miscellaneous.SLDipIng = GetValue(dbMessages, EnumLanguages.SLDipIng, englishInd, "Dipl. Ing.");
            obj.Miscellaneous.SLAll = GetValue(dbMessages, EnumLanguages.SLAll, englishInd, "Mrs/Mr./Firm");
            obj.Miscellaneous.SLEhe = GetValue(dbMessages, EnumLanguages.SLEhe, englishInd, "Married Couple");
            obj.Miscellaneous.SLFamilie = GetValue(dbMessages, EnumLanguages.SLFamilie, englishInd, "Family");
            obj.Miscellaneous.SLMr = GetValue(dbMessages, EnumLanguages.SLMr, englishInd, "Mr.");
            obj.Miscellaneous.SLMrs = GetValue(dbMessages, EnumLanguages.SLMrs, englishInd, "Mrs.");
            obj.Miscellaneous.SLCmpny = GetValue(dbMessages, EnumLanguages.SLCmpny, englishInd, "Firm");
            obj.Miscellaneous.Discard = GetValue(dbMessages, EnumLanguages.Discard, englishInd, "Discard");
            obj.Miscellaneous.DiscardChanges = GetValue(dbMessages, EnumLanguages.DiscardChanges, englishInd, "Discard Changes?");
            obj.Miscellaneous.DiscardQuestion = GetValue(dbMessages, EnumLanguages.DiscardQuestion, englishInd, "You have unsaved changes, do you want to Discard?");
            obj.Miscellaneous.Delete = GetValue(dbMessages, EnumLanguages.Delete, englishInd, "Delete");
            obj.Miscellaneous.MiscellaneousLabel = GetValue(dbMessages, EnumLanguages.MiscellaneousLabel, englishInd, "Miscellaneous");
            obj.Miscellaneous.LookupLabel = GetValue(dbMessages, EnumLanguages.LookupLabel, englishInd, "Lookup");
            obj.Miscellaneous.HelloCardWelcomeForMyOrder = GetValue(dbMessages, EnumLanguages.HelloCardWelcomeForMyOrder, englishInd, "How can we help you today?");
        }

        /// <summary>
        /// load system messages from DB
        /// </summary>
        private static void Load()
        {
            List<Data.Models.Administration.Language> dbMessages = languageService.GetAll("all");

            if (dbMessages != null)
            {
                englishLanguageBase = new LanguageBase();
                SetValues(dbMessages, englishLanguageBase, true);
                germanLanguageBase = new LanguageBase();
                SetValues(dbMessages, germanLanguageBase, false);
            }
        }

        /// <summary>
        /// Find message by code
        /// </summary>
        /// <param name="list">list</param>
        /// <param name="code">Code</param>
        /// <param name="defaultValue">defaultValue</param>
        /// <returns>value</returns>
        private static string GetValue(List<Language> list, EnumLanguages code, bool englishInd, string defaultValue = "")
        {
            var item = list.FirstOrDefault(t => t.Code == code.ToString());
            if (item != null)
            {
                if (englishInd)
                {
                    return item.English;
                }
                else
                {
                    return item.German;
                }
            }

            return defaultValue;
        }
    }
}
