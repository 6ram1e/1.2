using System;
using System.Collections.Generic;

public class Student
{
    // Имя студента.
    public string Name { get; set; }

    // Фамилия студента.
    public string Surname { get; set; }

    // Группа, к которой принадлежит студент.
    public string Group { get; set; }

    // Конструктор класса Student для инициализации объекта.
    public Student(string name, string surname, string group)
    {
        Name = name;
        Surname = surname;
        Group = group;
    }
}

// Класс для представления группы.
public class Group
{
    // Название группы.
    public string Name { get; set; }

    // Список студентов в группе.
    public List<Student> Students { get; set; }

    // Студент-староста группы.
    public Student Leader { get; set; }

    // Конструктор класса Group для инициализации объекта.
    public Group(string name)
    {
        Name = name;
        Students = new List<Student>();
    }
}

// Класс для отображения данных о студенте/группе без возможности редактирования.
public class ViewStudentGroup
{
    // Отображение информации о студенте.
    public void ShowStudent(Student student)
    {
        Console.WriteLine("Имя: {0}", student.Name);
        Console.WriteLine("Фамилия: {0}", student.Surname);
        Console.WriteLine("Группа: {0}", student.Group);
    }

    // Отображение информации о группе и ее студентах.
    public void ShowGroup(Group group)
    {
        Console.WriteLine("Название группы: {0}", group.Name);
        Console.WriteLine("Список студентов:");
        foreach (Student student in group.Students)
        {
            ShowStudent(student);
        }
    }
}

// Класс для редактирования данных о студенте/группе.
public class EditStudentGroup
{
    // Редактирование информации о студенте.
    public void EditStudent(Student student)
    {
        Console.WriteLine("Имя: {0}", student.Name);
        Console.WriteLine("Введите новое имя: ");
        string newName = Console.ReadLine();
        if (!string.IsNullOrEmpty(newName))
        {
            student.Name = newName;
        }

        Console.WriteLine("Фамилия: {0}", student.Surname);
        Console.WriteLine("Введите новую фамилию: ");
        string newSurname = Console.ReadLine();
        if (!string.IsNullOrEmpty(newSurname))
        {
            student.Surname = newSurname;
        }

        Console.WriteLine("Группа: {0}", student.Group);
        Console.WriteLine("Введите новую группу: ");
        string newGroup = Console.ReadLine();
        if (!string.IsNullOrEmpty(newGroup))
        {
            student.Group = newGroup;
        }
    }

    // Редактирование информации о группе.
    public void EditGroup(Group group)
    {
        Console.WriteLine("Название группы: {0}", group.Name);
        Console.WriteLine("Введите новое название группы: ");
        string newName = Console.ReadLine();
        if (!string.IsNullOrEmpty(newName))
        {
            group.Name = newName;
        }

        Console.WriteLine("Список студентов:");
        foreach (Student student in group.Students)
        {
            EditStudent(student);
        }

        Console.WriteLine("Введите нового старосту группы: ");
        string newLeader = Console.ReadLine();
        if (!string.IsNullOrEmpty(newLeader))
        {
            // Необходимо использовать объект типа Student для установки нового старосты.
            // group.Leader = newLeader; 
        }
    }
}

// Класс-наследник для отображения данных о студенте/группе в режиме редактирования.
public class EditViewStudentGroup : ViewStudentGroup
{
    // Переопределенный метод для отображения информации о студенте в режиме редактирования.
    public void ShowStudent(Student student)
    {
        base.ShowStudent(student);
        Console.WriteLine("Выберите действие:");
        Console.WriteLine("1. Редактировать имя");
        Console.WriteLine("2. Редактировать фамилию");
        Console.WriteLine("3. Редактировать группу");
        int action = Convert.ToInt32(Console.ReadLine());
        switch (action)
        {
            case 1:
                EditName(student);
                break;
            case 2:
                EditSurname(student);
                break;
            case 3:
                EditGroup(student);
                break;
            default:
                Console.WriteLine("Неверное действие.");
                break;
        }
    }

    // Переопределенные методы редактирования имени, фамилии и группы студента.
    public void EditName(Student student)
    {
        Console.WriteLine("Введите новое имя: ");
        string newName = Console.ReadLine();
        if (!string.IsNullOrEmpty(newName))
        {
            student.Name = newName;
        }
    }

    public void EditSurname(Student student)
    {
        Console.WriteLine("Введите новую фамилию: ");
        string newSurname = Console.ReadLine();
        if (!string.IsNullOrEmpty(newSurname))
        {
            student.Surname = newSurname;
        }
    }

    public void EditGroup(Student student)
    {
        Console.WriteLine("Введите новую группу: ");
        string newGroup = Console.ReadLine();
        if (!string.IsNullOrEmpty(newGroup))
        {
            student.Group = newGroup;
        }
    }
    class Program
    {
        static void Main()
        {
         
            Student student1 = new Student("Иван", "Иванов", "Группа1");
            Student student2 = new Student("Петр", "Петров", "Группа1");
            Student student3 = new Student("Мария", "Сидорова", "Группа2");

            Group group1 = new Group("Группа1");
            Group group2 = new Group("Группа2");

            group1.Students.Add(student1);
            group1.Students.Add(student2);
            group2.Students.Add(student3);

            group1.Leader = student1;

            // Создаем объекты для отображения и редактирования данных
            ViewStudentGroup viewStudentGroup = new ViewStudentGroup();
            EditStudentGroup editStudentGroup = new EditStudentGroup();
            EditViewStudentGroup editViewStudentGroup = new EditViewStudentGroup();

            // Выбираем студента для редактирования
            Console.WriteLine("\nВыберите номер студента для редактирования (1-{0}): ", group1.Students.Count);
            int studentIndex = Convert.ToInt32(Console.ReadLine()) - 1;

            // Проверяем, что введен корректный номер студента
            if (studentIndex >= 0 && studentIndex < group1.Students.Count)
            {
                Student selectedStudent = group1.Students[studentIndex];

                // Отображаем и редактируем информацию о выбранном студенте
                Console.WriteLine("\nОтображение и редактирование информации о студенте:");
                editViewStudentGroup.ShowStudent(selectedStudent);

                // Отображаем информацию о студенте и группе
                Console.WriteLine("Информация о студенте:");
                viewStudentGroup.ShowStudent(selectedStudent);

            }
            else
            {
                Console.WriteLine("Неверный номер студента.");
            }

            // Пауза для просмотра результатов
            Console.ReadLine();
        }
    }
}
