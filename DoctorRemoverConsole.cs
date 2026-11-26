using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АИС2
{
    public class DoctorRemoverConsole : IDoctorViewRemove
    {
        public event Action<int> RemoveDataEvent;
        IEnumerable<DoctorEventArgs> currentDoctors;

        public void RedrawForm(IEnumerable<DoctorEventArgs> e)
        {
            currentDoctors = e;
        }

        public void ShowDialogView()
        {
            if (!(0 >= currentDoctors.Count()))
            {
                int doctorNumInt = ValidatedConsoleInput.ValidateInt($"Введите номер врача\n{Program.AllDoctorEventArgs(currentDoctors)})", Program.DoctorIdsEventArgs(currentDoctors));
                RemoveDataEvent.Invoke(doctorNumInt);
            }
            else
            {
                Console.WriteLine("Недостаточно пациентов или врачей");
                Console.ReadKey();
            }
        }
    }
}
