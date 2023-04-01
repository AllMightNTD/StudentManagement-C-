
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;

namespace qlsv
{
    public class Programs
    {
        static List<Student> studentList = new List<Student>();

        static void Main(string[] args)
        {
            Console.WriteLine("Enter your choice ..");
            Console.WriteLine("Add student : 1");
            Console.WriteLine("List student : 2");
            Console.WriteLine("Delete student : 3");
            Console.WriteLine("Fix student : 4");
            Console.WriteLine("Search student : 5");
            Console.WriteLine("Exit the main : 6");
            int select = 0;
            while(true)
            {
                Console.WriteLine("Your choice  :...");
                select = int.Parse(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        ListStudent();
                        break;
                    case 3:
                        DeleteStudent();
                        break;
                    case 4:
                        FixStudent();
                        break;
                    case 5:
                        SearchStudent();
                        break;
                    case 6:
                        Console.WriteLine("Exit success");
                        return;
                    default:
                        Console.WriteLine("Program error");
                        break;


                }
            }
        }

        static void AddStudent()
        {
            Console.WriteLine("Add student:");
            Console.WriteLine("Code student");
            string code = Console.ReadLine();

            // Any : kiểm tra xem trong list có chứa bất kỳ phần tử nào thỏa mãn một điều kiện hay không
            while(studentList.Any(s => s.code == code))
            {
                Console.WriteLine("Duplicate student code, re-enter required !!!");
                code = Console.ReadLine();
            }
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Gender: ");
            string gender = Console.ReadLine();
            Console.Write("Department: ");
            string department = Console.ReadLine();
            Console.Write("CodeDepartment: ");
            string codeDepartment = Console.ReadLine();

            Student student = new Student(code, name, age, gender, department, codeDepartment); // Tạo đối tượng sinh viên mới
            studentList.Add(student); // Thêm đối tượng sinh viên vào danh sách

            Console.WriteLine("Đã thêm sinh viên thành công!");
        }

        static void ListStudent()
        {
            Console.WriteLine("Hiển thị sinh viên");
            Console.WriteLine(studentList.Count);
            for(int i = 0; i < studentList.Count; i++)
            {
                Console.WriteLine(studentList[i].ToString());
            }
        }

        static void DeleteStudent()
        {
            Console.WriteLine("Delete Student:");
            Console.Write("Enter the student code to delete: ");
            string code = Console.ReadLine();

            bool isRemoved = false;
            for (int i = 0; i < studentList.Count; i++)
            {
                if (studentList[i].code == code)
                {
                    studentList.RemoveAt(i); // Xóa đối tượng sinh viên khỏi danh sách
                    Console.WriteLine("Successfully deleted student!");
                    isRemoved = true;
                    break;
                }
            }
            if (!isRemoved)
            {
                Console.WriteLine("No student found to delete!");
            }
        }

        static void SearchStudent()
        {
            Console.WriteLine("Enter the student code you need to search for ....");
            string code = Console.ReadLine();
            Console.WriteLine("List of students can be found...");
            for(int i = 0; i < studentList.Count; i++)
            {
                if(code == studentList[i].code)
                {
                    Console.WriteLine(studentList[i].ToString());
                }
            }
        }
        static void FixStudent()
        {
            Console.WriteLine("Nhập mã sinh viên cần sửa");
            string code = Console.ReadLine();
            bool isUpdate = false;
            for (int i = 0; i < studentList.Count; i++)
            {
                if (studentList[i].code == code)
                {
                    Console.WriteLine("Nhap ten chuan sinh vien");
                    string name = Console.ReadLine();
                    Console.WriteLine("Nhap tuoi chuan sinh vien");
                    int age = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nhap gioi tinh sinh vien");
                    string gender = Console.ReadLine();
                    Console.WriteLine("Nhap khoa sinh vien");
                    string department = Console.ReadLine();
                    Console.WriteLine("Nhap ma khoa sinh vien");
                    string codeDepartment = Console.ReadLine();
                    Student student = new Student(code, name, age, gender, department, codeDepartment);
                    studentList[i] = student;
                    Console.WriteLine("Sua sinh vien thanh cong");
                    isUpdate = true;
                }
            }
            if (!isUpdate)
            {
                Console.WriteLine("Không tìm thấy sinh viên cần xóa!");
            }
        }
     
    }

    public class Student
    {
        public string code;
        public string name;
        public int age;
        public string gender;
        public string department;
        public string codeDepartment;

        public Student(string code , string name, int age, string gender , string department , string codeDepartment)
        {
            this.code = code;
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.department = department;
            this.codeDepartment = codeDepartment;
        }
        public override string ToString()
        {
            return $"Code: {code}, Name: {name}, Age: {age}, Gender: {gender}, Department: {department}, Code Department: {codeDepartment}";
        }
    }
}