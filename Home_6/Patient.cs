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

    internal class Patient : Person
    {
        private static int patinetsCardIDCounter = 0;
        private static bool isCuredDefaultValue = false;

        public int PatientsCardId { get; set; }

        /// <summary>
        /// Dictionary of illnesses. Format: <illness, isTreated>
        /// </summary>

        public Dictionary<IllnessType, bool> PatientsIllnesses { get; set; }
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="patientsIllnesses"></param>

        public Patient(string name, Dictionary<IllnessType, bool> patientsIllnesses) : base(name)
        {
            PatientsCardId = ++patinetsCardIDCounter;
            Name = name;
            PatientsIllnesses = patientsIllnesses;
        }

        /// <summary>
        /// Overloaden constructor. If there's no illnesses given, they're generated randomly.
        /// </summary>
        /// <param name="name"></param>

        public Patient(string name) : base(name)
        {
            PatientsCardId = ++patinetsCardIDCounter;
            Name = name;

            IllnessType[] randomIllnesses = GenerateRandomArrayOfIllnesses();
            PatientsIllnesses = new Dictionary<IllnessType, bool>();

            foreach (IllnessType illness in randomIllnesses)
            {
                PatientsIllnesses.Add(illness, isCuredDefaultValue);
            }
        }

        /// <summary>
        /// Generating randomarray of illnesses.
        /// Don't mind the "random.Next(10, 39) / 10", should've done that to make "Other" value come out atleast sometimes, didn't work out with "random.Next(1, 3)."
        /// </summary>

        public static IllnessType[] GenerateRandomArrayOfIllnesses()
        {
            Random random = new Random();
            IllnessType[] arrayOfIllnesses = new IllnessType[random.Next(1, 3)];

            for (int i = 0; i < arrayOfIllnesses.Length; i++)
            {
                int randomIndexOfIllness = random.Next(10, 39) / 10;

                while (arrayOfIllnesses.Contains((IllnessType)randomIndexOfIllness))
                {
                    randomIndexOfIllness = random.Next(10, 39) / 10;
                }
                arrayOfIllnesses[i] = (IllnessType)randomIndexOfIllness;
            }

            return arrayOfIllnesses;
        }
    }
}
