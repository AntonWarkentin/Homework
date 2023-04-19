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

    internal class Person
    {
        public string? Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }
    }
}
