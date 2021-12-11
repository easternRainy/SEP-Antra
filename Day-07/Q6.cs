using System;
using System.Collections; 

namespace Q6
{
	public static class Program
	{

		public static void Main(String[] args)
		{
			Person person = new Person(10, (decimal)190.02);
			person.Age = 20;
			Console.WriteLine(person.Age);

		}

	}

	public class Person
	{
		private uint age;
		public uint Age
		{
			get { return this.age; }
			set { this.age = value; }
		}
		
		private decimal salary {get; set;}

		private ArrayList addresses;

		public ArrayList getAddresses()
		{
			return this.addresses;
		}

		public Person(uint age, decimal salary)
		{
			this.age = age;
			
			if (salary > 0)
			{
				this.salary = salary;
			}
			else 
			{
				this.salary = 0;
			}

			this.addresses = new ArrayList();
			
		}
	}

	public class Instructor
	{
		public Department dept;
		public bool isHead;
		public DateTime joinDate;

		public Instructor(Department dept, bool isHead, DateTime dt)
		{
			this.dept = dept;
			this.isHead = isHead;
			this.joinDate = dt;
		}

		public int getExperience()
		{
			DateTime today = DateTime.Now;
            int exp = (today - bd).Years;

            return exp;
		}

	}

	public class Student
	{
		public ArrayList courses;
		public ArrayList grades;


	}

	public class Course
	{
		public ArrayList students;

	}

	public class Department
	{
		public Instructor head;
		public decimal budget;
		public ArrayList Courses;

	}
}