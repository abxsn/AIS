using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АИС2
{
    public class PatientsList : IPatientsListView
    {
        private IEnumerable<PatientEventArgs> currentPatients;
        public void RedrawForm(IEnumerable<PatientEventArgs> e)
        {
            currentPatients = e;
        }

        public void ShowDialogView()
        {
            Console.Clear();
            if (currentPatients.Count() > 0)
            {
                Console.WriteLine(Program.AllPatientEventArgs(currentPatients));
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Нет пациентов");
            }
        }
    }
}
