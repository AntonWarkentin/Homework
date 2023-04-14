using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_5
{
    internal class School
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

        private static int amountOfGroupsInSchool = 3;
        
        public StudentsGroup[] SchoolGroups { get; set; }
        
        public School()
        {
            StudentsGroup[] groupsAllTogether = new StudentsGroup[amountOfGroupsInSchool];

            for (int i = 0; i < groupsAllTogether.Length; i++)
            {
                groupsAllTogether[i] = new StudentsGroup();
            }

            SchoolGroups = groupsAllTogether;
        }
        
        public void bestMarksInEachGroup()
        {
            foreach (StudentsGroup studentsGroup in this.SchoolGroups)
            {
                Student bestMathMarkStudent = studentsGroup.BestMathMarkInGroup();
                Student bestPhysicalEducationMark = studentsGroup.BestPhysicalEducationMarkInGroup();
                Student bestBiologyMarkStudent = studentsGroup.BestBiologyMarkInGroup();

                Console.WriteLine($"Group{studentsGroup.GroupNumber}:");
                Console.WriteLine($"Best Math mark: {bestMathMarkStudent.Name}, Mark: {bestMathMarkStudent.MathMark}");
                Console.WriteLine($"Best Physical Education mark: {bestPhysicalEducationMark.Name}, Mark: {bestPhysicalEducationMark.PhysicalEducationMark}");
                Console.WriteLine($"Best Biology mark: {bestBiologyMarkStudent.Name}, Mark: {bestBiologyMarkStudent.BiologyMark}\n");

                RewardProvision(bestMathMarkStudent);
                RewardProvision(bestPhysicalEducationMark);
                RewardProvision(bestBiologyMarkStudent);
                Console.WriteLine();
            }
        }

        public void averageMarksInEachGroup()
        {
            foreach (StudentsGroup studentsGroup in this.SchoolGroups)
            {
                Console.WriteLine($"Group{studentsGroup.GroupNumber}:");
                Console.WriteLine($"Average Math mark: {studentsGroup.AverageMathMark()}");
                Console.WriteLine($"Average Physical Education mark: {studentsGroup.AveragePhysicalEducationMark()}");
                Console.WriteLine($"Average Biology mark: {studentsGroup.AverageBiologyMark()}");
                Console.WriteLine($"Average mark of Group{studentsGroup.GroupNumber} - Math, PhysicalEducation, Biology: {studentsGroup.averageAllDisciplinesMark():N2}\n");
            }
        }

        public StudentsGroup GroupWithBiggestAverageMark()
        {
            StudentsGroup studentsGroupWithBiggestAverageMark = this.SchoolGroups[0];

            foreach (StudentsGroup studentsGroup in this.SchoolGroups)
            {
                double averageMark = studentsGroup.averageAllDisciplinesMark();
                if (averageMark > studentsGroupWithBiggestAverageMark.averageAllDisciplinesMark())
                {
                    studentsGroupWithBiggestAverageMark = studentsGroup;
                }
            }

            return studentsGroupWithBiggestAverageMark;
        }

        public void RewardToGroupWithBiggestAverageMark()
        {
            StudentsGroup groupWithBiggestAverageMark = this.GroupWithBiggestAverageMark();
            Console.WriteLine($"Providing reward to all members of Group{groupWithBiggestAverageMark.GroupNumber} for biggest average mark.");

            foreach (Student student in groupWithBiggestAverageMark.Students)
            {
                RewardProvision(student);
            }
        }

        public void StudentsWithBiggestReward()
        {
            List<Student> listOfStudentsWithBiggestReward = new List<Student>();
            int biggestReward = 0;

            foreach (StudentsGroup studentsGroup in this.SchoolGroups)
            {
                foreach (Student student in studentsGroup.Students)
                {
                    if (student.Reward > biggestReward)
                    {
                        listOfStudentsWithBiggestReward.Clear();
                        listOfStudentsWithBiggestReward.Add(student);
                        biggestReward = student.Reward;
                    }
                    else if (student.Reward == biggestReward)
                    {
                        listOfStudentsWithBiggestReward.Add(student);
                    }
                }
            }

            Console.WriteLine("\nStudent(s) with biggest reward:");
            foreach (Student student in listOfStudentsWithBiggestReward)
            {
                Console.WriteLine($"{student.Name} from Group{student.Group} with reward: {student.Reward}");
            }
        }

        private void RewardProvision(Student studentToReward)
        {
            Random random = new Random();
            int randomReward = random.Next(1, 100);

            Console.WriteLine($"Rewarding {studentToReward.Name} from Group{studentToReward.Group} with amount: {randomReward}");
            studentToReward.Reward = randomReward;
        }
    }
}
