using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АИС2
{
    public class AppointmentConsole : IAppointmentView
    {
        public event Appoint ArrangeAnAppointmentEvent;
        IEnumerable<PatientEventArgs> Patients;
        IEnumerable<DoctorEventArgs> Doctors;

        public void RedrawForm(IEnumerable<PatientEventArgs> patients, IEnumerable<DoctorEventArgs> doctors)
        {
            Patients = patients;
            Doctors = doctors;
        }

        public void ShowDialogView()
        {
            Console.Clear();
            if (Patients.Count() > 0 && Doctors.Count() > 0)
            {
                int patientIdInt = ValidatedConsoleInput.ValidateInt($"Введите номер пациента которого вы хотите записать к врачу: \n{Program.AllPatientEventArgs(Patients)}", Program.PatientIdsEventArgs(Patients));
                int doctorIdInt = ValidatedConsoleInput.ValidateInt($"Введите номер доступного врача: {Program.AllDoctorEventArgs(Doctors)}", Program.DoctorIdsEventArgs(Doctors));
                Console.WriteLine(ArrangeAnAppointmentEvent.Invoke(patientIdInt, doctorIdInt));
            }
            else
            {
                Console.WriteLine("Нет доступных врачей или пациентов");
            }
            Console.ReadKey();
        }
    }
}
