﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Home_6
{
    internal class Therapist : Physician
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

        public Therapist(string name) : base(name)
        {
            Name = name;
            doctorsSpecialisation = IllnessType.Other;
        }

        public override void Treat(Patient patient)
        {
            Console.WriteLine($"Treating patient {patient.Name} by Therapist {this.Name} starts:");
            base.Treat(patient);
            Console.WriteLine($"Therapist {this.Name} has finished treating patient {patient.Name}.");
            Console.WriteLine();
        }
    }
}
