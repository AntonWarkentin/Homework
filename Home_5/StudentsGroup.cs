using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_5
{
    internal class StudentsGroup
    {

        /// <summary>
        /// 1. Coздайте класс Student, в классе используйте поля Id, Name, Age, Group, MathMark (Оценка по математике от 1 до 10 включительно), PhysicalEducationMark (Оценка по физкультуре от 1 до 10), 
        /// BiologyMark (Оценка по биологии от 1 до 10), Reward (денежное вознаграждение за хорошую учебу)
        /// Допустим есть 3 группы(Group1, Group2, Group3). Создайте 3 массива студентов по 5 в каждой группе.Оценки по дисциплинам задайте с использованием Random
        /// Создайте метод вывода в консоль студента из каждой группы с наилучшей оценкой по Математике.Если существуют студенты с одинаковыми наилучшими оценками - выведите любого из них. 
        /// (ex: Anton, Math mark: 10)
        /// Создайте метод вывода в консоль студента из каждой группы с наилучшей оценкой по Физкультуре.Если существуют студенты с одинаковыми наилучшими оценками - выведите любого из них.
        /// Создайте метод вывода в консоль студента из каждой группы с наилучшей оценкой по Биологии. Если существуют студенты с одинаковыми наилучшими оценками - выведите любого из них.
        /// Установите каждому из лучших студентов выше - денежное вознаграждение в рублях - reward (rand: 0 - 100) (предусмотрите, чтобы нельзя было установить значение reward< 1 рубля)
        /// Создайте методы подсчета и вывода среднего балла группы студентов по каждой из дисциплин и вывода этой информации в консоль (разные методы) (ex: Group1, avarage mark math: 8.3)
        /// Создайте метод расчета среднего балла группы студентов по всем 3 дисциплинам(средняя оценка группы по каждой дисциплине / количество дисциплин) и выведите эту информацию в консоль.
        /// (Avearage mark of Group1 - Math, PhysicalEducation, Biology - 8.3)
        /// Добавьте каждому студенту из группы с наибольшим средним баллом по всем дисциплинам произвольный reward.
        /// Выведите на экран студента с наибольшим reward. Если таких студентов несколько - выведите их всех.
        /// </summary>

        static private int groupSize = 5;
        static private int amountOfDisciplines = 3;
        static private int groupNumberCounter = 0;

        public int GroupNumber { get; set; }
        
        public Student[] Students { get; set; }

        public StudentsGroup()
        {
            Student[] students = new Student[groupSize];
            Random random = new Random();
            GroupNumber = ++groupNumberCounter;

            for (int i = 0; i < students.Length; i++)
            {
                students[i] = new(Home_3.Program.GenerateName(6), random.Next(16, 100), GroupNumber, random.Next(1, 10), random.Next(1, 10), random.Next(1, 10));
            }

            Students = students;
        }

        public Student BestMathMarkInGroup()
        {
            Student bestMathStudent = this.Students[0];

            foreach (Student student in this.Students)
            {
                if (student.MathMark > bestMathStudent.MathMark)
                {
                    bestMathStudent = student;
                }
            }

            return bestMathStudent;
        }
        
        public Student BestPhysicalEducationMarkInGroup()
        {
            Student bestPhysicalEducationStudent = this.Students[0];

            foreach (Student student in this.Students)
            {
                if (student.PhysicalEducationMark > bestPhysicalEducationStudent.PhysicalEducationMark)
                {
                    bestPhysicalEducationStudent = student;
                }
            }

            return bestPhysicalEducationStudent;
        }
        
        public Student BestBiologyMarkInGroup()
        {
            Student bestBiologyStudent = this.Students[0];

            foreach (Student student in this.Students)
            {
                if (student.BiologyMark > bestBiologyStudent.BiologyMark)
                {
                    bestBiologyStudent = student;
                }
            }

            return bestBiologyStudent;
        }
        
        public double AverageMathMark()
        {
            double sum = 0;

            foreach (Student student in this.Students)
            {
                sum += student.MathMark;
            }    

            return sum / this.Students.Length;
        }
        
        public double AveragePhysicalEducationMark()
        {
            double sum = 0;

            foreach (Student student in this.Students)
            {
                sum += student.PhysicalEducationMark;
            }    

            return sum / this.Students.Length;
        }
        
        public double AverageBiologyMark()
        {
            double sum = 0;

            foreach (Student student in this.Students)
            {
                sum += student.BiologyMark;
            }    

            return sum / this.Students.Length;
        }

        public double averageAllDisciplinesMark()
        {
            double sum = 0;

            sum += this.AverageMathMark();
            sum += this.AveragePhysicalEducationMark();
            sum += this.AverageBiologyMark();

            return sum / amountOfDisciplines;
        }
    }
}
