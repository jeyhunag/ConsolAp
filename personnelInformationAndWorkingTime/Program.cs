using EmployeesMenegment.Class;
using EmployeesMenegment.ServiceOpertions;
using personnelInformationAndWorkingTime.ServiceOpertions;

namespace EmployeesMenegment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Menu();
        }
        public static void Menu()
        {
            Console.WriteLine("1.--------------------İşçi əlavə etmək------------------------------||");
            Console.WriteLine("2.--------------------İş sahəsinə giriş-----------------------------||");
            Console.WriteLine("3.--------------------Sorğulama Menyusu-----------------------------||");
            Console.WriteLine("4.--------------------Yeniləmə  Menyusu-----------------------------||");
            Console.WriteLine("5. --------------------------Çıxış----------------------------------||");
            int secim = int.Parse(Console.ReadLine());
            switch (secim)
            {
                case 1:
                    PersonalInformationManager.AddPersonalInfor();
                    PersonalInformationManager.ShowPersonalInfor();
                    Menu();
                    break;
                case 2:
                    WorkTimeTrackingManager.AddWorkTime();
                    WorkTimeTrackingManager.ShowWorkTime();
                    Menu();
                    break;
                case 3:
                    Console.WriteLine("===================================================================");
                    Console.WriteLine("1. Bir işçinin məlumatlarının göstərilməsi.                      ||");
                    Console.WriteLine("2.  İşçi məlumatları və həmin ayin iş məlumatları                ||");
                    Console.WriteLine("3. Vəzifəyə görə axdarış                                         ||");
                    Console.WriteLine("4. İşə qəbul olunan işçilərin sayının illər üzrə bölgüsü         ||");
                    Console.WriteLine("5. İşə gec gələn işçilərin siyahısı                              ||");
                    Console.WriteLine("6. Müəyyən bir günün əlavə iş qeydlərinin sadalanması            ||");
                    Console.WriteLine("7. Çıxış                                                         ||");
                    Console.WriteLine("===================================================================");
                    int secim1 = int.Parse(Console.ReadLine());
                    switch (secim1)
                    {

                        case 1:
                            WorkerInforManager.AddWorkerInformation();
                            Menu();
                            break;
                        case 2:
                            WorkInforAndMonthInforManager.AddWorkandMonth();
                            Menu();
                            break;
                        case 3:
                            PositionManager.AddPositionManager();
                            Menu();
                            break;
                        case 4:
                            DistributionYears.AddDistribution();
                            Menu();
                            break;
                        case 5:
                            BeingLateWorkManager.AddBeingWork();
                            Menu();
                            break;
                        case 6:
                            listing_day_s_overtim__records.AddListingDay();
                            Menu();
                            break;
                        case 13:
                            return;
                        default:
                            break;
                    }
                    Menu();
                    break;
                case 4:
                    Console.WriteLine("====================================================================");
                    Console.WriteLine("1. Yeni işçinin əlavə edilməsi                                    ||");
                    Console.WriteLine("2. İşçi məlumatlarının yenilənməsi                                ||");
                    Console.WriteLine("3. Müəyyən bir günün iş qeydlərinin əlavə edilməsi                ||");
                    Console.WriteLine("4. İşçi məlumatlarının dosyalardan silinməsi                      ||");
                    Console.WriteLine("5. Çıxış                                                          ||");
                    Console.WriteLine("====================================================================");
                    int secim2 = int.Parse(Console.ReadLine());
                    switch (secim2)
                    {
                        case 1:
                            
                            NewEmployeeManager.AddNewEmployee();
                            NewEmployeeManager.ShowNewEmployee();
                            Menu();
                            break;
                        case 2:
                            UpdatingEmployeInforManager.AddUpdatingEmpoye();
                            Menu();
                            break;
                        case 3:
                            DailyNotesManager.AddDailyNotes();
                            Menu();
                            break;
                        case 4:
                            DeletingEmployee_Data.AddDeleting_Employee();
                            Menu();
                            break;
                        case 5:
                            return;
                        default:
                            break;
                    }
                    Menu();
                    break;
                case 5:                
                default:
                    break;
            }
        } //Menu
    }
}
