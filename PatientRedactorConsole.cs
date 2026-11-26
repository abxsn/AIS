using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АИС2
{
    public class PatientRedactorConsole : IPatientViewRedactor
    {
        public event Action<int, int, string> EditDataEvent;
        IEnumerable<PatientEventArgs> currentPatients;
        public void RedrawForm(IEnumerable<PatientEventArgs> e)
        {
            currentPatients = e;
        }

        public void ShowDialogView()
        {
            if (!(0 >= currentPatients.Count()))
            {
                int patientNumInt = ValidatedConsoleInput.ValidateInt($"Введите номер пациента\n{Program.AllPatientEventArgs(currentPatients)}", Program.PatientIdsEventArgs(currentPatients));
                int numberInt = ValidatedConsoleInput.ValidateInt($"Введите номер характеристики, которую вы хотите изменить:\n1. Жалоба\n2. Имя\n 3. Диагноз", 1, 3);
                switch (numberInt)
                {
                    case 2:
                        {
                            Console.WriteLine("Введите имя пациента");
                            string patientName = Console.ReadLine();
                            EditDataEvent.Invoke(patientNumInt, 0, patientName);
                            break;
                        }
                    case 1:
                        {
                            int patientComplaintsInt = ValidatedConsoleInput.ValidateInt($"Введите жалобу пациента: {Program.AllComplaintsListed()}", 1, MedicalCatalog.AllPossibleComplaints.Values.SelectMany(s => s).Count());
                            EditDataEvent.Invoke(patientNumInt, 1, MedicalCatalog.AllPossibleComplaints.Values.SelectMany(s => s).ToList()[patientComplaintsInt - 1].ToString());
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Диагноз ставит доктор, а не вы");
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine("Недостаточно пациентов");
                Console.ReadKey();
            }
        }
    }
}