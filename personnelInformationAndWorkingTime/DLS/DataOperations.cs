using EmployeesMenegment.Class;
using EmployeesMenegment.ServiceOpertions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesMenegment.DLS
{
    public class DataOperations
    {
        public static List<PersonnelInformation> PersonnelInformations { get; set; }

        public static List<Class.WorkTime> WorkTimes { get; set; }

        static DataOperations()
        {
            PersonnelInformations = new List<PersonnelInformation>();
            WorkTimes = new List<Class.WorkTime>();
        }
    }
}
