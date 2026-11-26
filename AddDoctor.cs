using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АИС2
{
    public class AddDoctor : IDoctorViewAdd
    {
        public event Action<DoctorEventArgs> AddDataEvent;

        public void ShowDialogView()
        {
            Console.Clear();
            Console.WriteLine("Введите имя доктора");
            string doctorName = Console.ReadLine();
            int doctorExperienceInt = ValidatedConsoleInput.ValidateInt($"Введите опыт доктора: \n1. 1 год\n2. 2 года\n3. 3 года\n4. 4 года\n5. 5 лет и более", 1, 5);
            Console.WriteLine("Доступные категории и болезни для диагностики:\n- Общие симптомы (Хроническая усталость, Авитаминоз, Переутомление)\n- Органы дыхания (ОРВИ, Острый бронхит, Пневмония, Ангина)\n- Нервная система (Мигрень, ВСД, Невралгия)\n- Сердечно-сосудистая система (Гипертония, Стенокардия, Аритмия)\n- ЖКТ (Острый гастрит, Язва желудка, Панкреатит, Пищевое отравление)\nесли прочитали нажмите enter");
            Console.ReadKey();
            int doctorSpecializationInt = ValidatedConsoleInput.ValidateInt($"Введите специализацию доктора: \n{Program.Specializations()}", 1, MedicalCatalog.AllPossibleDiagnosis.Keys.Count);
            AddDataEvent.Invoke(new DoctorEventArgs { Name = doctorName, Specialization = MedicalCatalog.AllPossibleDiagnosis.Keys.ToList()[doctorSpecializationInt - 1], ExperienceYears = doctorExperienceInt });
        }
    }
}
