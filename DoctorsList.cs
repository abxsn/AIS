using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АИС2
{
    public class DoctorsList : IDoctorsListView
    {
        IEnumerable<DoctorEventArgs> currentDoctors;
        public void RedrawForm(IEnumerable<DoctorEventArgs> e)
        {
            currentDoctors = e;
        }
        
        public void ShowDialogView()
        {
            Console.Clear();
            if (currentDoctors.Count() > 0)
            {
                Console.WriteLine(Program.AllDoctorEventArgs(currentDoctors));
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Нет врачей");
            }
        }
    }
}
