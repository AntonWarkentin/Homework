﻿using static System.Net.Mime.MediaTypeNames;

namespace Home_6
{
    internal class Program
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

        static void Main(string[] args)
        {
            Clinic clinic1 = new Clinic();
            clinic1.TreatmentOfAllPatients();

            Patient alex = new Patient("Alex", new Dictionary<IllnessType, bool>() { { IllnessType.Other, false } });
            Patient andrei = new Patient("Andrei", new Dictionary<IllnessType, bool>() { { IllnessType.Eyes, false }, { IllnessType.Other, false }, { IllnessType.Teeth, false } });
            Patient[] patientsOfClinic2 = new Patient[2] { alex, andrei };
            Clinic clinic2 = new Clinic(patientsOfClinic2);
            clinic2.TreatmentOfAllPatients();
        }
    }
}