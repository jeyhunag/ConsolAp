using EmployeesMenegment.Class;
using EmployeesMenegment.DLS;
using EmployeesMenegment.ServiceOpertions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personnelInformationAndWorkingTime.ServiceOpertions
{
    public class NewEmployeeManager
    {
        public static string SqlConnect = "Data Source=DESKTOP-FRTRI16;Initial Catalog='Employe data tracking working time';Integrated Security=True";

        public static void AddNewEmployee()
        {
            Console.WriteLine("İşçi nömrəsini daxil edin");
            int WorkNumber = Convert.ToInt32(Console.ReadLine());

            PersonnelInformation personnel = new PersonnelInformation();

            DataOperations.PersonnelInformations = EmplyoeeInformation.WorkerInforM();
            var employee = DataOperations.PersonnelInformations.FirstOrDefault(p => p.WorkNumber == WorkNumber);
            if (employee != null)
            {
                Console.WriteLine("Bu işçidən heyyətdə var-------------------------");

            }
            else
            {
                Random random = new Random();
                personnel.WorkNumber = random.Next(1, 100);
                Console.WriteLine("Adınızı daxil edin.");
                personnel.Name = Console.ReadLine().ToLower();
                Console.WriteLine("Soyadınızı daxil edin. ");
                personnel.Surname = Console.ReadLine().ToLower();
                Console.WriteLine("Qeydiyyat tarixinizi daxil edin (il.ay.gun formatinda)");
                personnel.DateOfEmployment = DateTime.Parse(DateTime.Parse(Console.ReadLine()).ToString("MM/dd/yyyy "));
                Console.WriteLine("Vəzifənizi daxil edin ");
                personnel.Position = Console.ReadLine().ToLower();
                Console.WriteLine("Əmək haqqı əmsalınızı daxil edin.");
                personnel.WageRate = float.Parse(Console.ReadLine());
                PersonalInformationManager.InsortData(personnel);
                DataOperations.PersonnelInformations.Add(personnel);

            }

        }
        public static void ShowNewEmployee()
        {
            foreach (var item in DataOperations.PersonnelInformations)
            {
                Console.WriteLine($"İşçi nömrəsi: {item.WorkNumber} ");
                Console.WriteLine($"Adı: {item.Name}");
                Console.WriteLine($"Soyadı: {item.Surname}");
                Console.WriteLine($"İşe giriş tarixi: {item.DateOfEmployment.ToShortDateString()}");
                Console.WriteLine($"Əmək haqqı əmsalı: {item.WageRate}");
                Console.WriteLine("----------------------------------------------------------");
            }
        }

    }
    //Yeni işçinin əlavə edilməsi.
    public class UpdatingEmployeInforManager
    {
        public static string SqlConnect = "Data Source=DESKTOP-FRTRI16;Initial Catalog='Employe data tracking working time';Integrated Security=True";

        public static void AddUpdatingEmpoye()
        {
            PersonnelInformation updatingEmp = new PersonnelInformation();

            Console.WriteLine("İşçi nömrəsini daxil edin");
            int WorkNumber = Convert.ToInt32(Console.ReadLine());

            DataOperations.PersonnelInformations = EmplyoeeInformation.WorkerInforM();
            var employee = DataOperations.PersonnelInformations.FirstOrDefault(p => p.WorkNumber == WorkNumber);
            if (employee != null)
            {
                Console.WriteLine("Adınızı daxil edin");
                updatingEmp.Name = Console.ReadLine().ToLower();
                Console.WriteLine("Əmək haqqı əmsalınızı daxil edin");
                updatingEmp.WageRate = float.Parse(Console.ReadLine());
                updatingEmp.WorkNumber = employee.WorkNumber;
                Console.WriteLine("Adınız: " + updatingEmp.Name);
                Console.WriteLine("Əmək haqqı əmsalınız: " + updatingEmp.WageRate);
                UpdatingEmployeInforManager.UpdateEmploye(updatingEmp);
            }
            else
            {
                Console.WriteLine("Bele bir işçi yoxdur");
            }

        }
        public static void UpdateEmploye(PersonnelInformation updatingEmp)
        {
            SqlConnection connection = new SqlConnection(SqlConnect);
            connection.Open();
            string sqlQuery = "Update  PersonelInfor set Name = @Name, WageRate = @WageRate Where WorkNumber = @WorkNumber";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection);
            sqlCommand.Parameters.AddWithValue("@Name", updatingEmp.Name);
            sqlCommand.Parameters.AddWithValue("@WageRate", updatingEmp.WageRate);
            sqlCommand.Parameters.AddWithValue("@WorkNumber", updatingEmp.WorkNumber);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
    //İşçi məlumatlarının yenilənməsi.
    public class DailyNotesManager
    {
        public static string SqlConnect = "Data Source=DESKTOP-FRTRI16;Initial Catalog='Employe data tracking working time';Integrated Security=True";

        public static void AddDailyNotes()
        {
            PersonnelInformation information = new PersonnelInformation();
            Console.WriteLine("iş gününü daxil edin");
            int WorkDay = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("İşçi nömrəsini daxil edin");
            int WorkNumber = Convert.ToInt32(Console.ReadLine());

            DataOperations.PersonnelInformations = EmplyoeeInformation.WorkerInforM();
            var employee = DataOperations.PersonnelInformations.FirstOrDefault(p => p.WorkNumber == WorkNumber);
            DataOperations.WorkTimes = WorkingHoursInformation.WorkerInforM2();
            var employee1 = DataOperations.WorkTimes.FirstOrDefault(p => p.WorkDay == WorkDay);

            if (employee1 != null && employee != null)
            {
                Console.WriteLine($"Giriş saatı: {employee1.Introductionthour}");
                Console.WriteLine($"Cıxış saatı: {employee1.Exithour}");
                Console.WriteLine($"Aylığ yeni iş saatınızı daxil edin");
                information.MontlyWorkingTime = Convert.ToInt32(Console.ReadLine());
                information.WorkNumber = employee.WorkNumber;
                Console.WriteLine($"Aylığ yeni iş saatınız: {information.MontlyWorkingTime}  saat");
                DailyNotesManager.DailyNotes(information);
            }
            else
            {
                Console.WriteLine("Belə bir gün və yaxud işçi  nömrəsi  yoxdur");
            }
        }
        public static void DailyNotes(PersonnelInformation information)
        {
            SqlConnection connection = new SqlConnection(SqlConnect);
            connection.Open();
            string sqlQuery = "Update  PersonelInfor set MontlyWorkingTime = @MontlyWorkingTime Where WorkNumber = @WorkNumber";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection);
            sqlCommand.Parameters.AddWithValue("@MontlyWorkingTime", information.MontlyWorkingTime);
            sqlCommand.Parameters.AddWithValue("@WorkNumber", information.WorkNumber);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
    //Müəyyən bir günün iş qeydlərinin əlavə edilməsi.
    public class DeletingEmployee_Data
    {
        public static string SqlConnect = "Data Source=DESKTOP-FRTRI16;Initial Catalog='Employe data tracking working time';Integrated Security=True";

        public static void AddDeleting_Employee()
        {
            PersonnelInformation Delete = new PersonnelInformation();
            Console.WriteLine("İşçi nömrəsini daxil edin");
            int Worknumber = Convert.ToInt32(Console.ReadLine());
            DataOperations.PersonnelInformations = EmplyoeeInformation.WorkerInforM();
            var employee = DataOperations.PersonnelInformations.FirstOrDefault(p => p.WorkNumber == Worknumber);
            if (employee != null)
            {
                Console.WriteLine("Bütün məlumatlar  silindi");
                Delete.WorkNumber = employee.WorkNumber;
                DeletingEmployee_Data.DeletingEmployee(Delete);
            }
            else
            {
                Console.WriteLine("Belə bir işçi nömrəsi yoxdur");
            }
        }
        public static void DeletingEmployee(PersonnelInformation Delete)
        {
            SqlConnection connection = new SqlConnection(SqlConnect);
            connection.Open();
            string sqlQuery = "delete PersonelInfor where WorkNumber=@WorkNumber;";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection);
            sqlCommand.Parameters.AddWithValue("@WorkNumber", Delete.WorkNumber);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
    //İşçi məlumatlarının dosyalardan silinməsi.
}
