//-----------------------------------------------------------------------
// <copyright file="SQLConfig.cs" company="Rushkar">
//     Copyright Rushkar. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace AMH.Data
{
    /// <summary>
    /// SQL configuration class which holds stored procedure name.
    /// </summary>
    internal sealed class SQLConfig
    {


        #region AddressMaster
        public const string AddressMaster_Upsert = "AddressMaster_Upsert";
        public const string AddressMaster_All = "AddressMaster_All";
        public const string AddressMaster_ById = "AddressMaster_ById";
        public const string AddressMaster_ActInAct = "AddressMaster_ActInAct";
        public const string AddressMaster_Delete = "AddressMaster_Delete";
        public const string AddressMaster_ByUserId = "AddressMaster_ByUserId";
        public const string Users_ById = "Users_ById  ";
        #endregion

        #region Customer
        public const string Customer_Upsert = "Customer_Upsert";
        public const string Customer_All = "Customer_All";
        public const string MasterCountry_All = "MasterCountry_All";
        public const string MasterState_All = "MasterState_All";
        public const string MasterCity_All = "MasterCity_All";
        public const string Customer_ById = "Customer_ById";
        public const string Customer_ActInAct = "Customer_ActInAct";
        public const string Customer_Delete = "Customer_Delete";
        #endregion
        
        #region Student
        public const string Student_Upsert = "Student_Upsert";
        public const string Student_All = "Student_All";
        public const string Department_All = "Department_All";
        public const string Student_ById = "Student_ById";
        public const string Student_Delete = "Student_Delete";
        #endregion

        #region Employees
        public const string Employees_Upsert = "Employees_Upsert";
        public const string Employees_All = "Employees_All";
        public const string MasterEmCountry_All = "MasterCountry_All";
        public const string MasterEmState_All = "MasterState_All";
        public const string MasterEmCity_All = "MasterCity_All";
        public const string Employees_ById = "Employees_ById";
        public const string Employees_ActInAct = "Employees_ActInAct";
        public const string Employees_Delete = "Employees_Delete";
        #endregion

        #region Appointment
        public const string Appointment_Upsert = "Appointment_Upsert";
        public const string Appointment_All = "Appointment_All";
        public const string Appointment_ById = "Appointment_ById";
        public const string Appointment_StatusChange = "Appointment_StatusChange";
        public const string Appointment_ChangeDate = "Appointment_ChangeDate";
        public const string Appointment_Delete = "Appointment_Delete";
        public const string MasterAppointmentStatus_All = "MasterAppointmentStatus_All";
        #endregion

        #region CityMaster
        public const string CityMaster_ByStateMasterId = "CityMaster_ByStateMasterId";
        #endregion

        #region StateMaster
        public const string StateMaster_ByCountryMasterId = "StateMaster_ByCountryMasterId";
        #endregion

        #region CountryMaster
        public const string CountryMaster_All = "CountryMaster_All";
        #endregion

        #region Admin
        public const string Admin_SignOut = "Admin_SignOut";
        public const string Admin_SignIn = "Admin_SignIn";
        public const string Admin_ChangePassword = "Admin_ChangePassword";
        public const string Admin_Upsert = "Admin_Upsert";
        public const string Admin_ById = "Admin_ById";
        public const string Admin_All = "Admin_All";
        public const string Admin_ActInAct = "Admin_ActInAct";
        #endregion

        #region AdminType
        public const string AdminType_All = "AdminType_All";
        #endregion




    }
}
