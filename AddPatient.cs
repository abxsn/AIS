using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АИС2
{
    public class AddPatient : IPatientViewAdd
    {
        public event Action<PatientEventArgs> AddDataEvent;

        public void ShowDialogView()
        {
            Console.Clear();
            Console.WriteLine("Введите имя пациента");
            string patientName = Console.ReadLine();
            int patientComplaintsInt = ValidatedConsoleInput.ValidateInt($"Введите жалобу пациента:\n{Program.AllComplaintsListed()}", 1, MedicalCatalog.AllPossibleComplaints.Values.SelectMany(s => s).ToList().Count());
            AddDataEvent.Invoke(new PatientEventArgs { Name = patientName, Complaints = MedicalCatalog.AllPossibleComplaints.Values.SelectMany(s => s).ToList()[patientComplaintsInt - 1] });
        }
    }
}
