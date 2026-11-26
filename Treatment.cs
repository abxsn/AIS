using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АИС2
{
    public class Treatment : ITreatmentView
    {
        public event Func<string> TreatmentRequired;

        public void ShowDialogView()
        {
            Console.Clear();
            Console.WriteLine(TreatmentRequired.Invoke());
            Console.ReadKey();
        }
    }
}
