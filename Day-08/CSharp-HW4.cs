using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HW4
{
	public class Program
	{
		public static void Main(String[] args)
		{
			MyStack<String> stack = new MyStack<String>();
			stack.Push("abc");
            stack.Pop();
			Console.WriteLine(stack.Count());
		}
	}

	// Q1
	public class MyStack<T>
	{
		T[] stack;
        private int max = 1000;
        private int top = -1;

		public MyStack()
		{
			this.stack = new T[this.max];
		}

		public int Count()
		{
			return this.top + 1;
		}

		public T Pop()
		{
			if (this.top < 0)
            {
                Console.WriteLine("Stack Empty");
                return default(T);
            }

            T val = this.stack[this.top];
            this.top -= 1;

            return val;	
		}

		public void Push(T item)
		{
			if (this.top >= this.max)
            {
                Console.WriteLine("Stack is full");
                return ;
            }

            this.top += 1;
            this.stack[this.top] = item;
		}
	}

    public class MyList<T>
    {
        private T[] arr;
        private int max = 1000;
        private int pointer = -1;

        public void Add(T elem)
        {
            if (this.pointer >= this.max)
            {
                Console.Write("List is full");
                return;
            }
            this.pointer += 1;
            this.arr[this.pointer] = elem;
        }

        public T Remove(int index)
        {
            if (index > this.pointer)
            {
                return default(T);
            }

            T returnVal = this.arr[index];

            for (int i = index+1; i<=this.pointer; i++)
            {
                this.arr[i-1] = this.arr[i];
            }

            this.pointer -= 1;

            return returnVal;
        }

        public bool Contains(T elem) 
        {
            for (int i=0; i<this.pointer; i++)
            {
                if (this.arr[i].Equals(elem))
                {
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            this.pointer = -1;
        }

        public void InsertAT(T elem, int index)
        {
            if (index >= this.max)
            {
                Console.WriteLine("Cannot insert out of range");
            }

            this.arr[index] = elem;

            if (index > this.pointer)
            {
                this.pointer = index;
            }
        }

        public void DeleteAt(int index)
        {
            if (index >= this.max)
            {
                Console.WriteLine("Cannot delete out of range");
            }

            this.arr[index] = default(T);
        }

        public T Find(int index)
        {   
            if (index >= this.max)
            {
                Console.WriteLine("Cannot find out of range");
            }

            return this.arr[index];
        }

        public interface IRepository<R> where R: class
        {
            void Add(R item);
            void Remove(R item);
            void Save(R item);
            IEnumerable<R> GetAll();
            T GetById(int id);
        }

        public class GenericRepository<T> : IRepository<T>
        {
            void Add(T item)
            {

            }
            void Remove(T item)
            {

            }
            void Save(T item)
            {

            }
            IEnumerable<T> GetAll()
            {

            }
            T GetById(int id)
            {

            }

        }
    }
}