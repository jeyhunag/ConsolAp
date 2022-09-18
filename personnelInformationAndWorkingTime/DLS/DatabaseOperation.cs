using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EmployeesMenegment.Class;
using System.Linq;

namespace EmployeesMenegment.DLS
{

    public class EmplyoeeInformation
    {


        public static string SqlConnect = "Data Source=DESKTOP-FRTRI16;Initial Catalog='Employe data tracking working time';Integrated Security=True";
      
        public static void AddEmplyoeeInfor()
        {
            PersonnelInformation personnel = new PersonnelInformation();
            Console.WriteLine("İşçi nömrəsini daxil edin");
            int number = Convert.ToInt32(Console.ReadLine());

            DataOperations.PersonnelInformations = EmplyoeeInformation.WorkerInforM();
            var EmpNumber = DataOperations.PersonnelInformations.FirstOrDefault(p => p.WorkNumber == number);


        }
        public static List<PersonnelInformation> WorkerInforM()
        {
            List<PersonnelInformation> personnels = new List<PersonnelInformation>();
            SqlDataReader sqlDataReader;
            SqlConnection sqlConnection = new SqlConnection(SqlConnect);
            sqlConnection.Open();
            string query = "Select WorkNumber,Name,Surname,Position,DateOfEmployment,WageRate,MontlyWorkingTime from PersonelInfor;";



            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {

                PersonnelInformation personne3 = new PersonnelInformation();

                personne3.WorkNumber = (int)sqlDataReader.GetValue(0);
                personne3.Name = (string)sqlDataReader.GetValue(1);
                personne3.Surname = (string)sqlDataReader.GetValue(2);
                personne3.Position = (string)sqlDataReader.GetValue(3);
                personne3.DateOfEmployment = (DateTime)sqlDataReader.GetValue(4);
                personne3.WageRate = (Convert.ToSingle(sqlDataReader.GetValue(5)));
                personne3.MontlyWorkingTime = (int)(sqlDataReader.GetValue(6));
                personnels.Add(personne3);

            }
            sqlConnection.Close();
            return personnels;
        }
    }
    public class WorkingHoursInformation
    {
        public static string SqlConnect = "Data Source=DESKTOP-FRTRI16;Initial Catalog='Employe data tracking working time';Integrated Security=True";

        public static void AddWorkingHoursInfor()
        {
            Class.WorkTime work = new Class.WorkTime();
            Console.WriteLine("İşçi nömrəsini daxil edin");
            int EmpNumber1 = Convert.ToInt32(Console.ReadLine());

            DataOperations.WorkTimes = WorkingHoursInformation.WorkerInforM2();
            var EmpNumber = DataOperations.WorkTimes.FirstOrDefault(p => p.WorkerNumberr == EmpNumber1);


        }
        public static List<Class.WorkTime> WorkerInforM2()
        {
            List<Class.WorkTime> workTimes = new List<Class.WorkTime>();
            SqlDataReader sqlDataReader;
            SqlConnection sqlConnection = new SqlConnection(SqlConnect);
            sqlConnection.Open();
            string query = "Select WorkerNumberr,WorkDay,Introductionthour,IntroductionMinute,Exithour,ExitMinute from WorkTimeInformation;";



            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {

                Class.WorkTime work1 = new Class.WorkTime();

                work1.WorkerNumberr = (int)sqlDataReader.GetValue(0);
                work1.WorkDay = (int)sqlDataReader.GetValue(1);
                work1.Introductionthour = (int)sqlDataReader.GetValue(2);
                work1.IntroductionMinute = (int)sqlDataReader.GetValue(3);
                work1.Exithour = (int)sqlDataReader.GetValue(4);
                work1.ExitMinute = (int)sqlDataReader.GetValue(5);
                workTimes.Add(work1);
            }
            sqlConnection.Close();
            return workTimes;
        }
    }


}
