using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace week3.Week3HelloWorld
{
    public class Week3Hello
    {
        public String GetHello()
        {
            return "Hello World!";
        }
    }

    public class Car
    {
        public String Color { get; set; }
        public int Year_made { get; set; }
        public String Size { get; set; }
        public String Model { get; set; }

        public Car(String color, int year_made, String size, String model)
        {
            Color = color;
            Year_made = year_made;
            Size = size;
            Model = model;
        }

        public String Display()
        {
            Console.WriteLine("Color: ", Color);
            Console.WriteLine("Year Made: ", Year_made);
            Console.WriteLine("Size: ", Size);
            Console.WriteLine("Model: ", Model);

            return Color + " " + Year_made + " " + Size + " " + Model;
        }
    }

    public class Sedan : Car
    {
        public Dealer dealer { get; set; }
        public Sedan(String color, int year_made, String size, String model) : base(color, year_made, size, model)
        { }

        public void Set_Dealer(Dealer d)
        {
            dealer = d;
        }

        public String Display_Dealer()
        {
            String str = dealer.Display();
            return str;
        }
    }

    public class Dealer
    {
        public String Name { get; set; }
        public String Company { get; set; }
        public String Address { get; set; }

        public Dealer(String name, String company, String address)
        {
            Name = name;
            Company = company;
            Address = address;
        }
        public String Display()
        {
            Console.WriteLine("Dealer Name: ", Name);
            Console.WriteLine("Dealer Comapny: ", Company);
            Console.WriteLine("Dealer Address: ", Address);
            return Name + " " + Company + " " + Address;
        }
    }
    public class Student
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Student(String name, String phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }

    public class ExampleDictionary
    {
        public void Example()
        {
            Dictionary<int, Student> studentDictionary = new Dictionary<int,
           Student>();
            Student s1 = new Student("Alex", "0431170991");
            Student s2 = new Student("Kim", "0431170992");
            studentDictionary.Add(1, s1);
            studentDictionary.Add(2, s2);
            Student result = new Student("", "");

            studentDictionary.TryGetValue(1, out result);
        }
    }
}