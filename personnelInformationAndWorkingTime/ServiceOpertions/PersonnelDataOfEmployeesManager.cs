using EmployeesMenegment.Class;
using EmployeesMenegment.DLS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personnelInformationAndWorkingTime.ServiceOpertions
{
    public class PersonalInformationManager
    {
        public static string SqlConnect = "Data Source=DESKTOP-FRTRI16;Initial Catalog='Employe data tracking working time';Integrated Security=True";
        public static void AddPersonalInfor()
        {
            PersonnelInformation personnel = new PersonnelInformation();

            Random random = new Random();
            personnel.WorkNumber = random.Next(1, 100);
            Console.WriteLine("Adınızı daxil edin:");
            personnel.Name = Console.ReadLine().ToLower();
            Console.WriteLine("Soyadınızı daxil edin: ");
            personnel.Surname = Console.ReadLine().ToLower();
            Console.WriteLine("Vəzifənizi daxil edin: ");
            personnel.Position = Console.ReadLine().ToLower();
            Console.WriteLine("Qeydiyyat tarixinizi daxil edin (il.ay.gun formatinda)");
            personnel.DateOfEmployment = DateTime.Parse(DateTime.Parse(Console.ReadLine()).ToString("MM/dd/yyyy "));
            Console.WriteLine("Əmək haqqı əmsalınızı daxil edin: ");
            personnel.WageRate = float.Parse(Console.ReadLine());
            Console.WriteLine("Aylığ iş saatınızı daxil edin: ");
            personnel.MontlyWorkingTime = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            PersonalInformationManager.InsortData(personnel);
            DataOperations.PersonnelInformations.Add(personnel);
        }
        public static void ShowPersonalInfor()
        {
            foreach (var item in DataOperations.PersonnelInformations)
            {
                Console.WriteLine($"İşçi nömrəsi: {item.WorkNumber} ");
                Console.WriteLine($"Adı : {item.Name}");
                Console.WriteLine($"Soyadı: {item.Surname}");
                Console.WriteLine($"İşe giriş tarixi: {item.DateOfEmployment.ToShortDateString()}");
                Console.WriteLine($" Vəzifəsi: {item.Position}");
                Console.WriteLine($"Əmək haqqı əmsalı: {item.WageRate}");
                Console.WriteLine($"Aylığ iş saatı: {item.MontlyWorkingTime}  saat ");
                Console.WriteLine("----------------------------------------------------------");
            }
        }
        public static void InsortData(PersonnelInformation personnel)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(SqlConnect);
                sqlConnection.Open();
                string sqlQuery = "insert into PersonelInfor(WorkNumber,Name,Surname,Position,DateOfEmployment,WageRate,MontlyWorkingTime) values(@WorkNumber,@Name,@Surname,@Position,@DateOfEmployment,@WageRate,@MontlyWorkingTime); ";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@WorkNumber", personnel.WorkNumber);
                sqlCommand.Parameters.AddWithValue("@Name", personnel.Name);
                sqlCommand.Parameters.AddWithValue("@Surname", personnel.Surname);
                sqlCommand.Parameters.AddWithValue("@Position", personnel.Position);
                sqlCommand.Parameters.AddWithValue("@DateOfEmployment", personnel.DateOfEmployment.ToShortDateString());
                sqlCommand.Parameters.AddWithValue("@WageRate", personnel.WageRate);
                sqlCommand.Parameters.AddWithValue("@MontlyWorkingTime", personnel.MontlyWorkingTime);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("xeta bas verdi" + ex.Message);
           
            }
       
        }

    }
    //İşçilərin kadr məlumatları.
}
