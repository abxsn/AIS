using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АИС2
{
    public class DoctorRedactorConsole : IDoctorViewRedactor
    {
        public event Action<int, int, string> EditDataEvent;
        IEnumerable<DoctorEventArgs> currentDoctors;

        public void RedrawForm(IEnumerable<DoctorEventArgs> e)
        {
            currentDoctors = e;
        }

        public void ShowDialogView()
        {

            if (!(0 >= currentDoctors.Count()))
            {
                int doctorNumInt = ValidatedConsoleInput.ValidateInt($"Введите номер врача\n{Program.AllDoctorEventArgs(currentDoctors)}", Program.DoctorIdsEventArgs(currentDoctors));
            int numberInt = ValidatedConsoleInput.ValidateInt($"Введите номер характеристики, которую вы хотите изменить:\n1. Специализация\n2. Имя\n 3. Опыт работы", 1, 3);
                switch (numberInt)
                {
                    case 2:
                        {
                            Console.WriteLine("Введите имя доктора");
                            string doctorName = Console.ReadLine();
                            EditDataEvent.Invoke(doctorNumInt, 0, doctorName);
                            break;
                        }
                    case 1:
                        {
                            int doctorSpecializationInt = ValidatedConsoleInput.ValidateInt($"Введите специализацию доктора: \n{Program.Specializations()}", 1, MedicalCatalog.AllPossibleDiagnosis.Keys.Count);
                            EditDataEvent.Invoke(doctorNumInt, 1, MedicalCatalog.AllPossibleComplaints.Keys.ToList()[doctorSpecializationInt - 1].ToString());
                            break;
                        }
                    case 3:
                        {
                            int doctorExperienceInt = ValidatedConsoleInput.ValidateInt($"Введите опыт доктора: \n1. 1 год\n 2. 2 года\n3. 3 года\n4. 4 года\n5. 5 лет и более", 1, 5);
                            EditDataEvent.Invoke(doctorNumInt, 2, doctorExperienceInt.ToString());
                            break;
                        }
                }

            }
            else
            {
                Console.WriteLine("Недостаточно врачей");
                Console.ReadKey();
            }
        }
    }
}
