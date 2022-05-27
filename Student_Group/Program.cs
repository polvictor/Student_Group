using System;
using System.Collections;

namespace Student_Group
{
    class Date
    {
        protected int day;
        protected int month;
        protected int year;

        public Date(int d, int m, int y)
        {
            int LeapYear = year % 4;
            if (d < 1 || d > 31 || m < 1 || m > 12
                || (m == 2 && d > 29 - LeapYear) || d > 30 + m % 2)
            {
                Console.WriteLine("ERROR - Incorrect date!!!");
            }
            else
            {
                day = d;
                month = m;
                year = y;
            }
        }
        public void SetDay(int day)
        {
            this.day = day;
        }
        public void SetMonth(int month)
        { 
            this.month = month; 
        }
        public void SetYear(int year)
        { 
            this.year = year; 
        }
        public int GetDay()
        {
            return day;
        }
        public int GetMonth()
        {
            return month;
        }
        public int GetYear()
        {
            return year;
        }        
    }

    class Student : IComparable<Student>
    {
        private string surname;
        private string name;
        private string fathername;
        private Date birthday;
        private string address;
        private int phonenumber;
        public int[] zachet;
        public int[] coursework;
        public int[] exam;

        public Student() { }
        public Student(string surname, string name, string fathername)
        {
            this.surname = surname;
            this.name = name;
            this.fathername = fathername;
        }
        public Student(string surname, string name, string fathername, Date birthday, string address, int phonenumber)
        {
            this.surname = surname;
            this.name = name;
            this.fathername = fathername;
            this.birthday = birthday;
            this.address = address;
            this.phonenumber = phonenumber;
        }
        public Student(string surname, string name, string fathername, Date birthday, string address, int phonenumber, 
            int[] zachetRate, int[] courseworkRate, int[] examRate)
        {
            this.surname = surname;
            this.name = name;
            this.fathername = fathername;
            this.birthday = birthday;
            this.address = address;
            this.phonenumber = phonenumber;
            zachet = new int[zachetRate.Length];
            for (int i = 0; i < zachetRate.Length; i++)
            {
                zachet[i] = zachetRate[i];
            }
            coursework = new int[courseworkRate.Length];
            for (int i = 0; i < courseworkRate.Length; i++)
            {
                coursework[i] = courseworkRate[i];
            }
            exam = new int[examRate.Length];
            for (int i = 0; i < examRate.Length; i++)
            {
                exam[i] = examRate[i];
            }
        }
        public void SetSurname(string surname)
        { 
            this.surname = surname; 
        }
        public string GetSurname()
        { 
            return surname; 
        }
        public void SetName(string name)
        {
            this.name = name; 
        }
        public string GetName()
        { 
            return name;
        }
        public void SetFathername(string fathername)
        {
            this.fathername = fathername;
        }
        public string GetFathername()
        { 
            return fathername;          
        }        
        public void SetBirthday(int day, int month, int year)
        {            
            birthday.SetDay(day);
            birthday.SetMonth(month);
            birthday.SetYear(year);
        }
        public string Address 
        { 
            get { return address; }
            set { this.address = value; }
        }
        public int Phonenumber 
        { 
            get { return phonenumber; }
            set { this.phonenumber = value; }
        }
        public void SetCourseWork(int courseworkRate, int index)
        {
            coursework = new int[index];
            coursework[0] = courseworkRate;
            if ((index < 0) || (index > coursework.Length - 1))
            {
                return;
            }
            else
            {
                coursework[index] = courseworkRate;
            }
        }
        public int GetCourseWork(int index)
        {
            if ((index < 0) || (index > coursework.Length - 1))
            {
                return 0;
            }
            else
            {
                return coursework[index];
            }
        }
        public void SetZachet(int zachetRate, int index)
        {
            zachet[0] = zachetRate;
            if ((index < 0) || (index > zachet.Length - 1))
            {
                return;
            }
            else
            {
                zachet[index] = zachetRate;
            }
        }
        public int GetZachet(int index)
        {
            if ((index < 0) || (index > zachet.Length - 1))
            {
                return 0;
            }
            else
            {
                return zachet[index];
            }
        }
        public void SetExam(int examRate, int index)
        {
            exam = new int[index];
            exam[0] = examRate;
            if ((index < 0) || (index > exam.Length - 1))
            {
                return;
            }
            else
            {
                exam[index] = examRate;
            }
        }
        public int GetExam(int index)
        {
            if ((index < 0) || (index > exam.Length - 1))
            {
                return 0;
            }
            else
            {
                return exam[index];
            }
        }
        public void ShowStudent()
        {
            Console.WriteLine("Surname: " + surname);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Fathername: " + fathername);
            Console.WriteLine("Date of birth: " + birthday.GetDay() + "/" + birthday.GetMonth() + "/" + birthday.GetYear());
            Console.WriteLine("Address: " + address);
            Console.WriteLine("Phone: " + phonenumber);  
            ShowRates();
        }
        public void ShowRates(params int[] courseWork)
        {
            Console.WriteLine("\n Student's Rates:");
            Console.WriteLine("Zachet: ");
            for (int i = 0; i < zachet.Length; i++)
            {
                Console.Write($"{zachet[i]}" + ", ");
            }
            Console.WriteLine();
            Console.Write("Course Work: ");
            for (int i = 0; i < coursework.Length; i++)
            {
                Console.Write($"{coursework[i]}" + ", ");
            }
            Console.WriteLine();
            Console.Write("Exam: ");
            for (int i = 0; i < exam.Length; i++)
            {
                Console.Write($"{exam[i]}" + ", ");
            }
            Console.WriteLine();
        }
        public void EditStudent(Student student, string Surname, string Name, string Fathername) // редактирование данных студента
        {
            student.surname = surname;
            student.name = name;
            student.fathername = fathername;
        }

        public int CompareTo(Student other)
        {
            double avg1 = this.exam.Average();
            double avg2 = other.exam.Average();

            if (avg1 == avg2) return 0;
            else if (avg1 > avg2) return 1;
            else return -1;
        }

        public class Surname : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                if (x == y)
                { return 0; }
                if (x == null || y == null)
                { return -1; }
                if (x.GetSurname() == y.GetSurname())
                { return 1; }
                return x.GetSurname().CompareTo(y.GetSurname());
            }
        }
        public class Exam : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                int avg1 = x.CompareTo(y);
                int avg2 = y.CompareTo(x);
                if (avg1 == avg2) return 0;
                if (avg1 > avg2) return 1;
                return -1;
            }
        }
    }

    class Group : IEnumerable
    {
        protected string groupname;
        protected string specialization;
        protected int coursenumber;
        protected int quantitystudent;
        protected Student[] student;
        protected readonly Random r = new Random();

        public void SetGroupName(String groupname)
        {
            this.groupname = groupname;
        }
        public string GetGroupName()
        {
            return groupname;
        }
        public void SetSpecialization(string specialization)
        {
            this.specialization = specialization;
        }
        public string GetSpecialization()
        {
            return specialization;
        }
        public void SetCourseNumber(int coursenumber)
        {
            this.coursenumber = coursenumber;
        }
        public int GetCourseNumber()
        {
            return coursenumber;
        }
        public void ShowGroup()
        {
            Console.WriteLine("Group Name: " + GetGroupName());
            Console.WriteLine("Specialization: " + GetSpecialization());
            Console.WriteLine("Course Number: " + GetCourseNumber());
            Console.WriteLine();
            Console.WriteLine("List of Students: ");
            for (int i = 0; i < student.Length; i++)
            {
                Console.WriteLine((i + 1).ToString() + ". " + student[i].GetSurname() + " " + student[i].GetName() + " " 
                    + student[i].GetFathername());
            }
        }
        public Group(string groupname, string specialization, int coursenumber, int quantitystudent)
        {
            this.groupname = groupname;
            this.specialization = specialization;
            this.coursenumber = coursenumber;
            this.quantitystudent = quantitystudent;
        }
        public Group(string groupname, string specialization, int coursenumber, params Student[] quantitystudent)
        {
            this.groupname = groupname;
            this.specialization = specialization;
            this.coursenumber = coursenumber;
            student = new Student[quantitystudent.Length];
            for (int i = 0; i < quantitystudent.Length; i++)
            {
                student[i] = quantitystudent[i];
            }
        }
        public Group() // Конструктор на 10 студентов
        {
            ShowGroup();
            for (int i = 0; i < 10; i++)
            {
                Console.Write((i + 1) + ".");
                ShowStudent();
            }
        }
        public Group(int quantitystudent)
        {
            ShowGroup();
            for (int i = 0; i < quantitystudent; i++)
            {
                Console.Write((i + 1) + ".");
                ShowStudent();
            }            
        } 
        public int StudentSize
        {
            get { return student.Length; }
        }
        public Student GetStudent(int n)
        {
            if (n >= 0 || n < student.Length)
            {
                return student[n];
            }
            else
            {
                return student[0];
            }
        }
        public void AddStudent(Student new_student) // добавление студента
        {
            Student[] s = this.student;
            student[quantitystudent] = new_student;
            quantitystudent++;
        }
        public void DeleteStudent(int n) // удаление студента
        {
            if (n < 0 || n > student.Length - 1)
                return;

            Student[] s = this.student;
            student = new Student[quantitystudent - 1];
            int count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (i == n)
                {
                    count++;
                }
                student[i - count] = s[i];
            }
            quantitystudent--;
        }
        public void RelocationStudent(int n, Group add)
        {
            DeleteStudent(n);
            AddStudent(GetStudent(n));
        }
        public Group CopyGroup(Group C)
        {
            Group other = (Group)this.MemberwiseClone();
            other.groupname = this.groupname;
            other.specialization = this.specialization;
            other.coursenumber = this.coursenumber;
            other.quantitystudent = this.quantitystudent;            
            other.student = this.student;

            return other;
        }
        public void ShowStudent()
        {
            string[] surnames = { "Ivanov", "Petrov", "Sidorov", "Fedorov", "Malinov", "Isayev" };
            string[] names = { "Ivan", "Petr", "Viktor", "Fedor", "Vasiliy", "Igor", "Alex" };
            string[] fathernames = { "Ivanovich", "Petrovich", "Fedorovich", "Viktorovich", "Igorovich" };            
            int index_surnames = r.Next(0, surnames.Length);
            int index_names = r.Next(0, names.Length);            
            int index_fathernames = r.Next(0, fathernames.Length);
            int age = r.Next(20, 55);

            Console.WriteLine(surnames[index_surnames] + " " + names[index_names] + " " + fathernames[index_fathernames] + ", " + age + ".");
        }
        
        public void EditGroup(Group group, string Name, string specalization, int course) // редактирование группы
        {
            group.groupname = groupname;
            group.specialization = specialization;
            group.coursenumber = coursenumber;
        }

        public IEnumerator GetEnumerator()
        {
            return student.GetEnumerator();
        }

        public void Print()
        {
            Student[] gs = new Student[quantitystudent];
            Group student_list = new Group();
            foreach (Student s in student_list)
                Console.WriteLine(s.GetSurname() + " " + s.GetName() + " " + s.GetFathername());
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Ввод данных студента:");
                Console.Write("Введите фамилию: ");
                string surname = Console.ReadLine();
                Console.Write("Введите имя : ");
                string name = Console.ReadLine();
                Console.Write("Введите отчество: ");
                string fathername = Console.ReadLine();
                Console.Write("День рождения: ");
                int day = Convert.ToInt32(Console.ReadLine());
                Console.Write("Месяц рождения: ");
                int month = Convert.ToInt32(Console.ReadLine());
                Console.Write("Год рождения: ");
                int year = Convert.ToInt32(Console.ReadLine());
                Console.Write("Адрес: ");
                string address = Console.ReadLine();
                Console.Write("Номер телефона: ");
                int phonenumber = Convert.ToInt32(Console.ReadLine());
                                
                int[] zachet = { 7, 8, 9, 10, 11, 12 };
                int[] coursework = { 12, 11, 10 };
                int[] exam = { 8, 9, };

                Date d = new Date(day, month, year);
                Student st = new Student(surname, name, fathername, d, address, phonenumber, zachet, coursework, exam);
                Console.WriteLine();
                st.ShowStudent();
                Console.WriteLine();

                Student st1 = new Student("Ivanov", "Ivan", "Ivanovich");
                Student st2 = new Student("Petrov", "Petr", "Petrovich");
                Student st3 = new Student("Fedorov", "Vasiliy", "Ivanovich");
                
                Group g1 = new Group("SPU-121", "Programming", 1, 12);
                g1.AddStudent(st1);
                g1.AddStudent(st2);
                g1.AddStudent(st3);
                g1.ShowGroup();                
                Console.WriteLine();
            }
        }
    }
}
