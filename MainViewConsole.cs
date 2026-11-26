using Entities;
using LogicToData;
using Ninject;
using Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АИС2
{
    public class MainViewConsole : IMainForm
    {
        public List<int> DoctorIds {  get; set; }
        public List<int> PatientIds {  get; set; }

        public event Action AddPatient;
        public event Action RemovePatient;
        public event Action RedactPatient;
        public event Action AddDoctor;
        public event Action RemoveDoctor;
        public event Action RedactDoctor;
        public event Action ArrangeAnAppointment;
        public event Action StartTreatment;
        public event Action OpenPatientList;
        public event Action OpenDoctorList;
        public void Run()
        {
            Console.WriteLine("Если пациенту не поставить правильный диагноз, он будет страдать и в итоге умрет.\nЗа каждым пациентом закрепляется строго один врач (но один врач может вести много пациентов), а диагноз ставится правильно, если специализация врача подходит жалобам пациента и его опыта достаточно для определения болезни. \n(чтобы продолжить нажмите enter)");
            Console.ReadKey();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите число");
                Console.WriteLine("Меню:\n1. Записать пациента к врачу\n2. Просмотреть список пациентов\n3. Изменить информацию о пациентах(или врачах)\n4. Выписать пациента/Уволить врача\n5. Добавить пациента\n6. Добавить врача\n7. Просмотреть список врачей\n8. Начать лечение пациента(последнего)\n");
                string num = Console.ReadLine();
                switch (num)
                {
                    case "1":
                        {
                            ArrangeAnAppointment.Invoke();
                            break;
                        }
                    case "2":
                        {
                            OpenPatientList.Invoke();
                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            int numInt = ValidatedConsoleInput.ValidateInt("Изменить информацию о пациентах или врачах?:\n1. О врачах\n2. О пациентах", 1, 2);
                            switch (numInt)
                            {
                                case 1:
                                    {
                                        RedactPatient.Invoke(); break;
                                    }
                                case 2:
                                    {
                                        RedactDoctor.Invoke(); break;
                                    }
                            }
                            break;
                        }
                    case "4":
                        {
                            Console.Clear();
                            int numInt = ValidatedConsoleInput.ValidateInt("Уволить пациента или врача?\n1. Врача\n2. Пациента", 1, 2);
                            switch (numInt)
                            {
                                case 1:
                                    {
                                        RemoveDoctor.Invoke();
                                        break;
                                    }
                                case 2:
                                    {
                                        RemovePatient.Invoke();
                                        break;
                                    }
                            }
                            break;
                        }
                    case "5":
                        {
                            AddPatient.Invoke();
                            break;
                        }
                    case "6":
                        {
                            AddDoctor.Invoke();
                            break;
                        }
                    case "8":
                        {
                            StartTreatment.Invoke();
                            break;
                        }
                    case "7":
                        {
                            OpenDoctorList.Invoke();
                            break;
                        }
                }
            }
        }
    }

}
