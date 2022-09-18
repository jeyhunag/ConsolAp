using EmployeesMenegment.Class;
using EmployeesMenegment.DLS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace EmployeesMenegment.ServiceOpertions
{
    public class WorkTimeTrackingManager
    {
        public static string SqlConnect = "Data Source=DESKTOP-FRTRI16;Initial Catalog='Employe data tracking working time';Integrated Security=True";
        public static void AddWorkTime()
        {
            Class.WorkTime workTime = new Class.WorkTime();

            Console.WriteLine("İşçi nömrəsini daxil edin");
            int WorkerNumberr = Convert.ToInt32(Console.ReadLine());
            DataOperations.PersonnelInformations = EmplyoeeInformation.WorkerInforM();
            var employee = DataOperations.PersonnelInformations.FirstOrDefault(p => p.WorkNumber == WorkerNumberr);

            if (employee != null)
            {
                workTime.WorkerNumberr = employee.WorkNumber;
                Console.WriteLine("İşə giriş günüvüzü daxil edin");
                workTime.WorkDay = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Giriş saatınızı daxil edin");
                workTime.Introductionthour = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Giriş  dəqiqənizi daxil edin");
                workTime.IntroductionMinute = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Çıxış saatınızı daxil edin");
                workTime.Exithour = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Çıxış dəqiqənizi daxil edin");
                workTime.ExitMinute = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                WorkTimeTrackingManager.WorkData(workTime);
                DataOperations.WorkTimes.Add(workTime);
            }
            else
            {
                Console.WriteLine("daxil etdiyiniz nömrədə işçi yoxdur");
            }

        }
        public static void ShowWorkTime()
        {
            foreach (var item in DataOperations.WorkTimes)
            {
                Console.WriteLine($"İşçi nömrəsi: {item.WorkerNumberr}");
                Console.WriteLine($"İşə giriş günü: {item.WorkDay}");
                Console.WriteLine($"İşə giriş vaxtı: saat {item.Introductionthour}:{item.IntroductionMinute} ");
                Console.WriteLine($"İşdən çıxış vaxtı:  saat {item.Exithour}:{item.ExitMinute} ");
            }
        }
        public static void WorkData(Class.WorkTime workTime)
        {
            SqlConnection sqlConnection = new SqlConnection(SqlConnect);
            sqlConnection.Open();
            string sqlQuery = "insert into WorkTimeInformation(WorkerNumberr,WorkDay,Introductionthour,IntroductionMinute,Exithour,ExitMinute) values(@WorkerNumberr,@WorkDay,@Introductionthour,@IntroductionMinute,@Exithour,@ExitMinute);";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@WorkerNumberr", workTime.WorkerNumberr);
            sqlCommand.Parameters.AddWithValue("@WorkDay", workTime.WorkDay);
            sqlCommand.Parameters.AddWithValue("@Introductionthour", workTime.Introductionthour);
            sqlCommand.Parameters.AddWithValue("@IntroductionMinute", workTime.IntroductionMinute);
            sqlCommand.Parameters.AddWithValue("@Exithour", workTime.Exithour);
            sqlCommand.Parameters.AddWithValue("@ExitMinute", workTime.ExitMinute);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
    // İşçilərin iş vaxtının izlənməsi.
}
