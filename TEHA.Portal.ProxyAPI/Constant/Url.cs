// <copyright file="Url.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.ProxyAPI.Constant
{
    /// <summary>
    /// Contains Constants of endpoint rout
    /// </summary>
    public static class Url
    {
        /// <summary>
        /// meters measurs
        /// </summary>
        public const string StockOverviewGet = "/API/StockOverview/Get";

        /// <summary>
        /// Stock Overview Summary
        /// </summary>
        public const string StockOverviewSummary = "/API/StockOverview/GetSummary";

        /// <summary>
        /// Stock Overview Properties
        /// </summary>
        public const string StockOverviewProperties = "/API/StockOverview/GetProperties";

        /// <summary>
        /// Stock Overview Get Flats
        /// </summary>
        public const string StockOverviewGetFlats = "/API/StockOverview/GetFlats";

        /// <summary>
        /// Stock Overview Get Open Letter
        /// </summary>
        public const string StockOverviewGetOpenLetter = "/API/StockOverview/GetOpenLetter";

        /// <summary>
        /// Stock Overview Get All Meters
        /// </summary>
        public const string StockOverviewGetAllMeters = "/API/StockOverview/GetAllMeters";

        /// <summary>
        /// Athentication
        /// </summary>
        public const string AccountLogin = "/API/Account/Login";

        /// <summary>
        /// Stock Overview Properties
        /// </summary>
        public const string AccountingGetAccountingPeriods = "/API/Accounting/GetAccountingPeriods";

        /// <summary>
        /// Accounting Get
        /// </summary>
        public const string AccountingGetCosts = "/API/Accounting/GetCosts";

        /// <summary>
        /// Accounting Get Flat Current User Info
        /// </summary>
        public const string AccountingGetFlatUsers = "/API/Accounting/GetFlatUsers";

        /// <summary>
        /// Accounting Delete Concept
        /// </summary>
        public const string AccountingDeleteConcept = "/API/Accounting/DeleteConcept";

        /// <summary>
        /// Accounting Delete Cost
        /// </summary>
        public const string AccountingDeleteCost = "/API/Accounting/DeleteCost";

        /// <summary>
        /// Accounting Submit
        /// </summary>
        public const string AccountingSubmit = "/API/Accounting/Submit";

        /// <summary>
        /// Accounting Save Costs
        /// </summary>
        public const string AccountingSaveCosts = "/API/Accounting/SaveCosts";

        /// <summary>
        /// Accounting Save Flat Users
        /// </summary>
        public const string AccountingSaveFlatUsers = "/API/Accounting/SaveFlatUsers";

        /// <summary>
        /// Athentication
        /// </summary>
        public const string UserContactInformation = "/API/Account/GetUserContactInformation";

        /// <summary>
        /// Get All Documents with type
        /// </summary>
        public const string DocumentArchivesAll = "/API/DocumentArchives/GetDocuments";

        /// <summary>
        /// Get Invoices
        /// </summary>
        public const string DocumentArchivesGetInvoices = "/API/DocumentArchives/GetInvoices";

        /// <summary>
        /// Get Document content
        /// </summary>
        public const string DocumentArchivesGetContent = "/API/DocumentArchives/GetDocumentContent";

        /// <summary>
        /// Get SEPA document
        /// </summary>
        public const string DocumentArchivesGetSEPA = "/API/DocumentArchives/GetSEPADocument";

        /// <summary>
        /// Get All SEPA documents
        /// </summary>
        public const string DocumentArchivesAllSEPA = "/API/DocumentArchives/GetAllSEPADocuments";

        /// <summary>
        /// Get All SEPA documents
        /// </summary>
        public const string DocumentArchivesGetAccountingDocumentByFlat = "/API/DocumentArchives/GetAccountingDocumentByFlat";

        /// <summary>
        /// Get All SEPA documents
        /// </summary>
        public const string DocumentArchivesGetAccountingFlatDocumentContent = "/API/DocumentArchives/GetAccountingFlatDocumentContent";

        /// <summary>
        /// Order Send Request for plumbing
        /// </summary>
        public const string OrderRequestPlumbing = "/API/Order/RequestPlumbing";

        /// <summary>
        /// Order Send Request for Reading
        /// </summary>
        public const string OrderRequestReading = "/API/Order/RequestReading";

        /// <summary>
        /// Order Send Request for SmokeDetectorTest
        /// </summary>
        public const string OrderRequestSmokeDetectorTest = "/API/Order/RequestSmokeDetectorTest";

        /// <summary>
        /// Order Send Request for RequestOffer
        /// </summary>
        public const string OrderRequestOffer = "/API/Order/RequestOffer";

        /// <summary>
        /// Order Send Request for DrinkingWaterSampling
        /// </summary>
        public const string OrderRequestDrinkingWaterSampling = "/API/Order/RequestDrinkingWaterSampling";

        /// <summary>
        /// Order Send Request for EnergyPerformanceCertificate
        /// </summary>
        public const string OrderRequestEnergyPerformanceCertificate = "/API/Order/RequestEnergyPerformanceCertificate";

        /// <summary>
        /// Order Send Request for EnergyPerformanceCertificate
        /// </summary>
        public const string GetEnergyCertificatePreFillData = "/API/Order/GetEnergyCertificatePreFillData";

        /// <summary>
        /// Order Send Request for InterimReading
        /// </summary>
        public const string OrderRequestInterimReading = "/API/Order/RequestInterimReading";

        /// <summary>
        /// Order Send Request for InterimReading user moving out
        /// </summary>
        public const string GetInterimReadingUserMovingOut = "/API/Order/GetInterimReadingUserMovingOut";

        /// <summary>
        /// Order Send Request for PostInterimReading
        /// </summary>
        public const string OrderPostInterimReading = "/API/Order/PostInterimReading";

        /// <summary>
        /// Order Send Request for orders list
        /// </summary>
        public const string OrderGet = "/API/Order/Get";

        /// <summary>
        /// Get plumbing order data for editing
        /// </summary>
        public const string OrderGetEditPlumbing = "/API/Order/GetEditPlumbing";

        /// <summary>
        /// Get Performance order data for editing
        /// </summary>
        public const string OrderGetEditEnergyPerformance = "/API/Order/GetEditEnergyPerformance";

        /// <summary>
        /// Get Offer Request order data for editing
        /// </summary>
        public const string OrderGetEditOfferRequest = "/API/Order/GetEditOfferRequest";

        /// <summary>
        /// Get InterimReadingSelf order data for editing
        /// </summary>
        public const string OrderGetEditInterimReadingSelf = "/API/Order/GetEditInterimReadingSelf";

        /// <summary>
        /// Get InterimReading order data for editing
        /// </summary>
        public const string OrderGetEditInterimReading = "/API/Order/GetEditInterimReading";

        /// <summary>
        /// Get SmokeDetectorTest order data for editing
        /// </summary>
        public const string OrderGetEditSmokeDetectorTest = "/API/Order/GetEditSmokeDetectorTest";

        /// <summary>
        /// Get Reading order data for editing
        /// </summary>
        public const string OrderGetEditReading = "/API/Order/GetEditReading";

        /// <summary>
        /// Order Send Request for open orders count
        /// </summary>
        public const string OrderGetOpenOrderCount = "/API/Order/GetOpenOrderCount";

        /// <summary>
        /// Order Send Request for cancellation
        /// </summary>
        public const string OrderCancel = "/API/Order/Cancel";

        /// <summary>
        /// Order Get Last Reading
        /// </summary>
        public const string OrderGetLastReading = "/API/Order/GetLastReading";

        /// <summary>
        /// Detail
        /// </summary>
        public const string Detail = "/API/Account/Detail";

        /// <summary>
        /// GetGeneralSetting
        /// </summary>
        public const string GetGeneralSetting = "/API/Account/GetGeneralSetting";

        /// <summary>
        /// Update General etting
        /// </summary>
        public const string UpdateGeneralSetting = "/API/Account/UpdateGeneralSetting";

        /// <summary>
        /// Edit Team Member
        /// </summary>
        public const string EditTeamMember = "/API/Account/EditTeamMember";

        /// <summary>
        /// Change Password
        /// </summary>
        public const string ChangePassword = "/API/Account/ChangePassword";

        /// <summary>
        /// Change Password
        /// </summary>
        public const string AddTeamMember = "/API/Account/AddTeamMember";

        /// <summary>
        /// Update Member Properties
        /// </summary>
        public const string UpdateMemberProperties = "/API/Account/UpdateMemberProperties";

        /// <summary>
        /// Forgot Password
        /// </summary>
        public const string ForgotPassword = "/API/Account/ForgotPassword";

        /// <summary>
        /// Update Contact Infomation
        /// </summary>
        public const string UpdateContactInfomation = "/API/Account/UpdateContactInformation";

        /// <summary>
        /// Order Send Request for cancellation
        /// </summary>
        public const string InfoGetContactPersons = "/API/Info/GetContactPersons";

        /// <summary>
        /// Order Send Request for cancellation
        /// </summary>
        public const string InfoGetPayrollYear = "/API/Info/GetPayRollYear";

        /// <summary>
        /// Get Contracts
        /// </summary>
        public const string ContractGet = "/API/Contract/Get";

        /// <summary>
        /// Get contract document
        /// </summary>
        public const string ContractGetDocument = "/API/Contract/GetContractDocument";

        /// <summary>
        /// Get Dashboard Infomation
        /// </summary>
        public const string DashboardGet = "/API/Dashboard/Get";

        /// <summary>
        /// Get Lookups
        /// </summary>
        public const string LookupGet = "/API/Lookup/Get";

        /// <summary>
        /// Accounting Get Last Updated Dates
        /// </summary>
        public const string AccountingGetLastUpdatedDates = "/API/Accounting/GetLastUpdatedDates";

        /// <summary>
        /// Accounting Get Summary And Release Info
        /// </summary>
        public const string AccountingGetSummaryAndReleaseInfo = "/API/Accounting/GetSummaryAndReleaseInfo";

        /// <summary>
        /// Accounting Set Summary And Release Info
        /// </summary>
        public const string AccountingSetSummaryAndReleaseInfo = "/API/Accounting/SetSummaryAndReleaseInfo";

        /// <summary>
        /// Order Send Request for Accounting PostInterimReading
        /// </summary>
        public const string AccountingPostInterimReading = "/API/Accounting/SaveReadings";

        /// <summary>
        /// Get list of offers
        /// </summary>
        public const string GetOffers = "/API/Order/GetOffers";

        /// <summary>
        /// Get offer document
        /// </summary>
        public const string GetOfferDocument = "/API/Order/GetOfferDocument";

        /// <summary>
        /// Accounting Delete Onwer
        /// </summary>
        public const string AccountingDeleteOnwer = "/API/Accounting/DeleteOnwer";

        /// <summary>
        /// Accounting Delete Rent
        /// </summary>
        public const string AccountingDeleteRent = "/API/Accounting/DeleteRent";
    }
}
