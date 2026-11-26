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
    internal class Program
    {

        /// <summary>
        /// </summary>
        /// <returns>Строку пронумерованных специальностей</returns>
        public static string Specializations()
        {
            string s = string.Empty;
            int cnt = 0;
            foreach (string a in MedicalCatalog.AllPossibleComplaints.Keys.ToList())
            {
                cnt++;
                s += $"{cnt}. {a}\n";
            }
            return s;
        }
        public static List<int> PatientIdsEventArgs(IEnumerable<PatientEventArgs> e)
        {
            return e.Select(s => s.Id).ToList();
        }
        public static List<int> DoctorIdsEventArgs(IEnumerable<DoctorEventArgs> e)
        {
            return e.Select(s => s.Id).ToList();
        }
        /// <summary>
        /// </summary>
        /// <returns>Строковое представление списка всех возможных жалоб</returns>
        public static string AllComplaintsListed()
        {
            string result = string.Empty;
            int cnt = 0;
            var a = MedicalCatalog.AllPossibleComplaints.Values.SelectMany(s => s).ToList();
            foreach (string complaint in a)
            {
                cnt++;
                result += $"{cnt.ToString()}. {complaint}\n";
            }
            return result;
        }

        /// <summary>
        /// </summary>
        /// <returns>Строковое представление всех докторов и их свойств</returns>
        public static string AllPatients(IEnumerable<Patient> list)
        {
            string result = string.Empty;
            foreach (Patient patient in list)
            {
                result += $"{patient.Id}.\nИмя: {patient.Name}\nЖалобы: {patient.Complaints}\nПредварительный диагноз:{patient.DiagnosisName}\n";
            }
            return result;
        }
        /// <summary>
        /// </summary>
        /// <returns>Строковое представление всех dto пациентов и их свойств</returns>
        public static string AllPatientEventArgs(IEnumerable<PatientEventArgs> list)
        {
            string result = string.Empty;
            foreach (PatientEventArgs patient in list)
            {
                result += $"{patient.Id}.\nИмя: {patient.Name}\nЖалобы: {patient.Complaints}\nПредварительный диагноз:{patient.DiagnosisName}\n";
            }
            return result;
        }
        /// <summary>
        /// </summary>
        /// <returns>Строковое представление всех dto докторов и их свойств</returns>
        public static string AllDoctorEventArgs(IEnumerable<DoctorEventArgs> list)
        {
            string result = string.Empty;
            foreach (DoctorEventArgs doctor in list)
            {
                result += $"{doctor.Id}.\nИмя: {doctor.Name}\nСпециализация: {doctor.Specialization}\nОпыт врача:{doctor.ExperienceYears} лет\n";
            }
            return result;
        }
        /// <summary>
        /// </summary>
        /// <returns>Строковое представление всех докторов и их свойств</returns>
        public static string AllDoctors(IEnumerable<Doctor> list)
        {
            string result = string.Empty;
            foreach (Doctor doctor in list)
            {
                result += $"{doctor.Id}.\nИмя: {doctor.Name}\nСпециализация: {doctor.Specialization}\nОпыт врача:{doctor.ExperienceYears} лет\n";
            }
            return result;
        }
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Если пациенту не поставить правильный диагноз, он будет страдать и в итоге умрет.\nЗа каждым пациентом закрепляется строго один врач (но один врач может вести много пациентов), а диагноз ставится правильно, если специализация врача подходит жалобам пациента и его опыта достаточно для определения болезни. \n(чтобы продолжить нажмите enter)");
        //    Console.ReadKey();
        //    while (true)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Введите число");
        //        Console.WriteLine("Меню:\n1. Записать пациента к врачу\n2. Просмотреть список пациентов\n3. Изменить информацию о пациентах(или врачах)\n4. Выписать пациента/Уволить врача\n5. Добавить пациента\n6. Добавить врача\n7. Просмотреть список врачей\n8. Начать лечение пациента(последнего)\n");
        //        string num = Console.ReadLine();
        //        switch (num)
        //        {
        //            case "1":
        //                {
        //                    Console.Clear();
        //                    if (logic.PatientService.Count > 0 && logic.DoctorService.Count > 0)
        //                    {
        //                        int patientIdInt = ValidatedConsoleInput.ValidateInt($"Введите номер пациента которого вы хотите записать к врачу: \n{AllPatients(logic.PatientService.GetAll())}", logic.PatientService.GetExistingIds());
        //                        int doctorIdInt = ValidatedConsoleInput.ValidateInt($"Введите номер доступного врача: {AllDoctors(logic.DoctorService.GetAll())}", logic.DoctorService.GetExistingIds());
        //                        Console.WriteLine(logic.AppointmentService.ArrangeAnAppointment(patientIdInt, doctorIdInt));
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("Нет доступных врачей или пациентов");
        //                    }
        //                    Console.ReadKey();
        //                    break;
        //                }
        //            case "2":
        //                {
        //                    Console.Clear();
        //                    if (logic.PatientService.Count > 0)
        //                    {
        //                        Console.WriteLine(AllPatients(logic.PatientService.GetAll()));
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("Нет пациентов");
        //                    }
        //                    Console.ReadKey();
        //                    break;
        //                }
        //            case "3":
        //                {
        //                    Console.Clear();
        //                    int numInt = ValidatedConsoleInput.ValidateInt("Изменить информацию о пациентах или врачах?:\n1. О врачах\n2. О пациентах", 1, 2);
        //                    switch (numInt)
        //                    {
        //                        case 1:
        //                            {
        //                                if (!(0 >= logic.DoctorService.Count))
        //                                {
        //                                    int doctorNumInt = ValidatedConsoleInput.ValidateInt($"Введите номер врача\n{AllDoctors(logic.DoctorService.GetAll())}", logic.DoctorService.GetExistingIds());
        //                                    int numberInt = ValidatedConsoleInput.ValidateInt($"Введите номер характеристики, которую вы хотите изменить:\n1. Специализация\n2. Имя\n 3. Опыт работы", 1, 3);
        //                                    switch (numberInt)
        //                                    {
        //                                        case 2:
        //                                            {
        //                                                Console.WriteLine("Введите имя доктора");
        //                                                string doctorName = Console.ReadLine();
        //                                                logic.DoctorService.DoctorRedactor(doctorNumInt, 0, doctorName);
        //                                                break;
        //                                            }
        //                                        case 1:
        //                                            {
        //                                                int doctorSpecializationInt = ValidatedConsoleInput.ValidateInt($"Введите специализацию доктора: \n{Specializations()}", 1, logic.complaintsCount);
        //                                                logic.DoctorService.DoctorRedactor(doctorNumInt, 1, MedicalCatalog.AllPossibleComplaints.Keys.ToList()[doctorSpecializationInt - 1].ToString());
        //                                                break;
        //                                            }
        //                                        case 3:
        //                                            {
        //                                                int doctorExperienceInt = ValidatedConsoleInput.ValidateInt($"Введите опыт доктора: \n1. 1 год\n 2. 2 года\n3. 3 года\n4. 4 года\n5. 5 лет и более", 1, 5);
        //                                                logic.DoctorService.DoctorRedactor(doctorNumInt, 2, doctorExperienceInt.ToString());
        //                                                break;
        //                                            }

        //                                    }
        //                                    break;
        //                                }
        //                                else
        //                                {
        //                                    Console.WriteLine("Недостаточно врачей");
        //                                    Console.ReadKey();
        //                                    break;
        //                                }
        //                            }
        //                        case 2:
        //                            {
        //                                if (!(0 >= logic.PatientService.Count))
        //                                {
        //                                    int patientNumInt = ValidatedConsoleInput.ValidateInt($"Введите номер пациента\n{AllPatients(logic.PatientService.GetAll())}", logic.PatientService.GetExistingIds());
        //                                    int numberInt = ValidatedConsoleInput.ValidateInt($"Введите номер характеристики, которую вы хотите изменить:\n1. Жалоба\n2. Имя\n 3. Диагноз", 1, 3);
        //                                    switch (numberInt)
        //                                    {
        //                                        case 2:
        //                                            {
        //                                                Console.WriteLine("Введите имя пациента");
        //                                                string patientName = Console.ReadLine();
        //                                                logic.PatientService.PatientRedactor(patientNumInt, 0, patientName);
        //                                                break;
        //                                            }
        //                                        case 1:
        //                                            {
        //                                                int patientComplaintsInt = ValidatedConsoleInput.ValidateInt($"Введите жалобу пациента: {AllComplaintsListed()}", 1, logic.complaintsCount);
        //                                                logic.PatientService.PatientRedactor(patientNumInt, 1, MedicalCatalog.AllPossibleComplaints.Values.SelectMany(s => s).ToList()[patientComplaintsInt - 1].ToString());
        //                                                break;
        //                                            }
        //                                        case 3:
        //                                            {
        //                                                Console.WriteLine("Диагноз ставит доктор, а не вы");
        //                                                break;
        //                                            }
        //                                    }
        //                                    break;
        //                                }
        //                                else
        //                                {
        //                                    Console.WriteLine("Недостаточно пациентов");
        //                                    Console.ReadKey();
        //                                    break;
        //                                }
        //                            }
        //                    }
        //                    break;
        //                }
        //            case "4":
        //                {
        //                    Console.Clear();
        //                    if (0 >= logic.PatientService.Count || 0 >= logic.DoctorService.Count)
        //                    {
        //                        Console.WriteLine("Недостаточно пациентов или врачей");
        //                        Console.ReadKey();
        //                        break;
        //                    }
        //                    int numInt = ValidatedConsoleInput.ValidateInt("Уволить пациента или врача?\n1. Врача\n2. Пациента", 1, 2);
        //                    switch (numInt)
        //                    {
        //                        case 1:
        //                            {
        //                                int doctorNumInt = ValidatedConsoleInput.ValidateInt($"Введите номер врача\n{AllDoctors(logic.DoctorService.GetAll())})", logic.DoctorService.GetExistingIds());
        //                                logic.DoctorService.RemoveDoctor(doctorNumInt);
        //                                break;
        //                            }
        //                        case 2:
        //                            {
        //                                int patientNumInt = ValidatedConsoleInput.ValidateInt($"Введите номер пациента\n{AllPatients(logic.PatientService.GetAll())}", logic.PatientService.GetExistingIds());
        //                                logic.PatientService.RemovePatient(patientNumInt);
        //                                break;
        //                            }
        //                    }
        //                    break;
        //                }
        //            case "5":
        //                {
        //                    Console.Clear();
        //                    Console.WriteLine("Введите имя пациента");
        //                    string patientName = Console.ReadLine();
        //                    int patientComplaintsInt = ValidatedConsoleInput.ValidateInt($"Введите жалобу пациента:\n{AllComplaintsListed()}", 1, logic.complaintsCount);
        //                    logic.PatientService.AddPatient(patientName, patientComplaintsInt - 1);
        //                    break;
        //                }
        //            case "6":
        //                {
        //                    Console.Clear();
        //                    Console.WriteLine("Введите имя доктора");
        //                    string doctorName = Console.ReadLine();
        //                    int doctorExperienceInt = ValidatedConsoleInput.ValidateInt($"Введите опыт доктора: \n1. 1 год\n2. 2 года\n3. 3 года\n4. 4 года\n5. 5 лет и более", 1, 5);
        //                    Console.WriteLine("Доступные категории и болезни для диагностики:\n- Общие симптомы (Хроническая усталость, Авитаминоз, Переутомление)\n- Органы дыхания (ОРВИ, Острый бронхит, Пневмония, Ангина)\n- Нервная система (Мигрень, ВСД, Невралгия)\n- Сердечно-сосудистая система (Гипертония, Стенокардия, Аритмия)\n- ЖКТ (Острый гастрит, Язва желудка, Панкреатит, Пищевое отравление)\nесли прочитали нажмите enter");
        //                    Console.ReadKey();
        //                    int doctorSpecializationInt = ValidatedConsoleInput.ValidateInt($"Введите специализацию доктора: \n{Specializations()}", 1, logic.specializationsCount);
        //                    logic.DoctorService.AddDoctor(doctorName, doctorSpecializationInt - 1, doctorExperienceInt);
        //                    break;
        //                }
        //            case "8":
        //                {
        //                    Console.Clear();
        //                    Console.WriteLine(logic.TreatmentService.StartTreatment());
        //                    Console.ReadKey();
        //                    break;
        //                }
        //            case "7":
        //                {
        //                    Console.Clear();
        //                    if (logic.DoctorService.Count > 0)
        //                    {
        //                        Console.WriteLine(AllDoctors(logic.DoctorService.GetAll()));
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("Нет врачей");
        //                    }
        //                    Console.ReadKey();
        //                    break;
        //                }
        //        }
        //    }
        //}
    }

}
