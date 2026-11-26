using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АИС2
{
    public class PatientRemoverConsole : IPatientViewRemove
    {
        public event Action<int> RemoveDataEvent;
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
                RemoveDataEvent.Invoke(patientNumInt);
            }
            else
            {
                Console.WriteLine("Недостаточно пациентов или врачей");
                Console.ReadKey();
            }
        }
    }
}
