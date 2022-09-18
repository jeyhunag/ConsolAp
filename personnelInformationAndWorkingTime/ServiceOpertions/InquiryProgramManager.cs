using EmployeesMenegment.Class;
using EmployeesMenegment.DLS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Text;

namespace EmployeesMenegment.ServiceOpertions
{
    public class WorkerInforManager
    {
        public static void AddWorkerInformation()
        {
            PersonnelInformation personnel = new PersonnelInformation();
            Console.WriteLine("İşçi nömrəsini daxil edin");
            int EmpNumber1 = Convert.ToInt32(Console.ReadLine());

            DataOperations.PersonnelInformations = EmplyoeeInformation.WorkerInforM();
            var EmpNumber = DataOperations.PersonnelInformations.FirstOrDefault(p => p.WorkNumber == EmpNumber1);

            if (EmpNumber != null)
            {
                Console.WriteLine($"İşçi nömrəsi: {EmpNumber.WorkNumber}");
                Console.WriteLine($"Ad: {EmpNumber.Name}");
                Console.WriteLine($"Soyad: {EmpNumber.Surname}");
                Console.WriteLine($"İşe giriş tarixi: {EmpNumber.DateOfEmployment.ToShortDateString()}");
                Console.WriteLine($"Vəzifəsi: {EmpNumber.Position}");
                Console.WriteLine($"Əmək haqqı əmsalı: {EmpNumber.WageRate}");
            }
            else
            {
                Console.WriteLine("Bele bir işçi yoxdur");
            }
        }     
    }
    //İşçi nömrəsinə görə məlumatların göstərilməsi
    public class WorkInforAndMonthInforManager
    {
        public static void AddWorkandMonth()
        {
            Console.WriteLine("İşçi nömrəsini daxil edin");
            int number1 = Convert.ToInt32(Console.ReadLine());
            DataOperations.PersonnelInformations = EmplyoeeInformation.WorkerInforM();
            var employee = DataOperations.PersonnelInformations.FirstOrDefault(p => p.WorkNumber == number1);
            DataOperations.WorkTimes = WorkingHoursInformation.WorkerInforM2();
            var employeeWorkTime = DataOperations.WorkTimes.FirstOrDefault(p => p.WorkerNumberr == number1);
            if (employee != null)
            {
                Console.WriteLine($"İşçi nömrəniz: {employee.WorkNumber}");
                Console.WriteLine($"Ad: {employee.Name}");
                Console.WriteLine($"Soyad: {employee.Surname}");
                Console.WriteLine($"İşe giriş tarixi: {employee.DateOfEmployment.ToShortDateString()}");
                float TotalWages = (employee.MontlyWorkingTime * 10) * employee.WageRate;
                Console.WriteLine($"Ümumi əmək haqqı:" + TotalWages + "Azn");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"İşə giriş günü: {employeeWorkTime.WorkDay}");
                Console.WriteLine($"İşə girişı: {employeeWorkTime.Introductionthour}");
                Console.WriteLine($"İşdən çıxış saatı: {employeeWorkTime.Exithour}");
            }
            else
            {
                Console.WriteLine("Daxil etdiyiniz nömrədə işçi yoxdur.");
            }
        }
    }
    //Bir işçinin məlumatlarının göstərilməsi və həmin ay üzrə iş məlumatların göstərilməsi.
    public class PositionManager
    {
        public static void AddPositionManager()
        {
            Console.WriteLine("Görmək istədiyiniz vəzifəni daxil edin.");
            string Position = Console.ReadLine().ToLower();

             DataOperations.PersonnelInformations = EmplyoeeInformation.WorkerInforM();
            var EmpNumber = DataOperations.PersonnelInformations.Where(p => p.Position == Position).ToList();
            foreach (var item in EmpNumber)
            {
                if (item != null)
                {
                    Console.WriteLine("--------------------------------------------------------------");
                    Console.WriteLine($"İşçi nömrəsi: {item.WorkNumber}");
                    Console.WriteLine($"Adı: {item.Name}");
                    Console.WriteLine($"Soyadı: {item.Surname}");
                    Console.WriteLine($"İşe giriş tarixi: {item.DateOfEmployment.ToShortDateString()}");
                    Console.WriteLine($"Əmək haqqı əmsalı: {item.WageRate}");
                    Console.WriteLine("--------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("Daxil etdiyiniz vəzifədə işçi yoxdur");

                }
            }
        }
    }
    //Müəyyən bir vəzifəyə görə işçilərin siyahısının görüntülənməsi.
    public class DistributionYears
    {
        public static void AddDistribution()
        {
            Console.WriteLine("ili daxil edin");
            string number = Console.ReadLine();
            int count = 0;
            DataOperations.PersonnelInformations = EmplyoeeInformation.WorkerInforM();
            var EmployeeYear = DataOperations.PersonnelInformations.Where(p => p.DateOfEmployment.ToString().Substring(5, 4) == number).ToList();
            foreach (var item in EmployeeYear)
            {
                if (item.DateOfEmployment.ToString().Substring(5, 4) == number)
                {
                    Console.Clear();
                    Console.WriteLine($"il: {number}");
                    Console.WriteLine($"işçi sayı: {count + 1}");
                    count++;
                }
                else
                {
                    Console.WriteLine("daxil etdiyiniz ilde işə giriş olmayib:");
                }
            }
        }
    }
    //İşə qəbul olunan işçilərin sayının illər üzrə bölgüsünün görüntülənməsi.
    public class BeingLateWorkManager
    {
        public static void AddBeingWork()
        {
            Console.WriteLine("İşçi nömrəsini daxil edi");
            int number = Convert.ToInt32(Console.ReadLine());
            int num = 0;

            DataOperations.WorkTimes = WorkingHoursInformation.WorkerInforM2();
            var employeeWorkTime = DataOperations.WorkTimes.Where(p => p.WorkerNumberr == number).ToList();

            foreach (var item in employeeWorkTime)
            {
                if (item.Introductionthour > 9 || (item.Introductionthour == 9 && item.IntroductionMinute > 0))
                {
                    Console.Clear();
                    Console.WriteLine($"İşçi nömrəsi: {item.WorkerNumberr}");
                    Console.WriteLine($" Gecikme sayi: {num + 1}");
                    num++;
                }
            }
        }
    }
    //İşə gec gələn işçilərin siyahısı
    public class listing_day_s_overtim__records
    {
        public static void AddListingDay()
        {
            Console.WriteLine("Görmək istədiyiniz günü daxil edin");
            int number2 = Convert.ToInt32(Console.ReadLine());
           
            DataOperations.WorkTimes = WorkingHoursInformation.WorkerInforM2();
            var employee1 = DataOperations.WorkTimes.Where(p => p.WorkDay == number2).ToList();
            
            DataOperations.PersonnelInformations = EmplyoeeInformation.WorkerInforM().ToList();
            var employee = DataOperations.PersonnelInformations;
            foreach (var item1 in employee1)
            {
                
                foreach (var item in employee.Where(p=>p.WorkNumber==item1.WorkerNumberr).Distinct())
                {
                    if (item1 != null)
                    {
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.WriteLine($"İşçi nömrəsi: {item.WorkNumber}");
                        Console.WriteLine($"Adı: {item.Name}");
                        Console.WriteLine($"Soyadı: {item.Surname}");
                        Console.WriteLine($"Giriş saatı: {item1.Introductionthour}");
                        Console.WriteLine($"Çıxış saatı: {item1.Exithour}");
                        int Hours = item1.Exithour - item1.Introductionthour;
                        int Seconds = item1.ExitMinute - item1.IntroductionMinute;
                        Console.WriteLine($"iş vaxtı: {Hours}  saat {Seconds}  dəqiqə");
                        Console.WriteLine("-----------------------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("Daxil etdiyiniz iş günündə işçi yoxdur.");
                    }
                }
               
            }

           

        }
    }
    //Müəyyən bir günün əlavə iş qeydlərinin sadalanması

}
