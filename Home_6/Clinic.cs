using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_6
{

    /// <summary>
    /// Создать программу для имитации работы клиники. (Clinic)
    /// Пусть в клинике будет три врача: офтальмолог(ophthalmologist), терапевт(therapist) и стоматолог(dentist).
    /// Каждый врач имеет метод «лечить» Treat(), но каждый врач лечит по-своему.Так же предусмотреть класс «Пациент»(Patient) и enum «IlnessType» (Eyes, Teeth, Other) - (тип болезни, что человека беспокоит)
    /// Создать объект класса «Пациент».
    /// Так же создать метод в классе Клиника, который будет отправлять пациента к доктору.Далее доктор должен лечить пациента.
    /// Если план лечения == Eyes – назначить офтальмолога и выполнить метод лечить.
    /// Если план лечения == Teeth – назначить стоматолог и выполнить метод лечить.
    /// Если план лечения == Other – назначить терапевта и выполнить метод лечить.
    /// </summary>

    internal class Clinic
    {
        private int amountOfPatientsInClinic;

        public Patient[] Patients { get; set; }

        public Ophthalmologist ClinicsOphthalmologist { get; set; }

        public Therapist ClinicsTherapist { get; set; }

        public Dentist ClinicsDentist { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="inputPatients">Array of patients</param>

        public Clinic(Patient[] inputPatients)
        {
            ClinicsOphthalmologist = new Ophthalmologist(Home_3.Program.GenerateName(4));
            ClinicsTherapist = new Therapist(Home_3.Program.GenerateName(4));
            ClinicsDentist = new Dentist(Home_3.Program.GenerateName(4));
            Patients = inputPatients;
        }

        /// <summary>
        /// Overloaden constructor. If no patients given, clinic creates random ones.
        /// </summary>

        public Clinic()
        {
            Random random = new Random();
            amountOfPatientsInClinic = random.Next(1, 5);

            ClinicsOphthalmologist = new Ophthalmologist(Home_3.Program.GenerateName(4));
            ClinicsTherapist = new Therapist(Home_3.Program.GenerateName(4));
            ClinicsDentist = new Dentist(Home_3.Program.GenerateName(4));

            Patients = new Patient[amountOfPatientsInClinic];

            for (int i = 0; i < Patients.Length; i++)
            {
                Patients[i] = new(Home_3.Program.GenerateName(4));
            }
        }

        public void TreatmentOfAllPatients()
        {
            foreach (var patient in Patients)
            {
                foreach(var illness in patient.PatientsIllnesses)
                {
                    switch (illness.Key)
                    {
                        case IllnessType.Eyes:
                            ClinicsOphthalmologist.Treat(patient);
                            break;
                        case IllnessType.Other:
                            ClinicsTherapist.Treat(patient);
                            break;
                        case IllnessType.Teeth:
                            ClinicsDentist.Treat(patient);
                            break;
                    }
                }
            }
        }
    }
}
