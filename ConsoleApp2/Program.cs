using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*ListDates date = new ListDates(new Dates(11, 12, 13));
            date.Next = new ListDates(new Dates(9, 3, 24));
            date.date.Print();
            date = date.Next;
            date.date.Print();
            date.Next = new ListDates(new Dates(2, 4, 4));
            date = date.Next;
            date.date.Print();
            date = date.head;
            date.date.Print();*/
            Graphics.Read();
            Console.ReadKey();
            return ;
        }
    }

    public class ListDates
    {
        public Dates date { get; set; }
        public ListDates head { get; protected set; }
        public ListDates(Dates date)
        {
            this.date = date;
            head = this;
        }
        protected ListDates next;
        public ListDates Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
                next.head = this.head;
            }
        }
    }

    public class Dates
    {
        private int day;
        public int Day
        {
            get
            {
                return day;
            }
            set
            {
                if ((value >= 1) && (value <= 30))
                    day = value;
            }
        }

        private int month;
        public int Month
        {
            get
            {
                return month;
            }
            set
            {
                if ((value >= 1) && (value <= 12))
                    month = value;
            }
        }

        private int year;
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if ((value >= 0) && (value < 100))
                    year = value;
            }
        }

        public Dates()
        {

        }
        public Dates(int day, int month, int year)
        {
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }

        public static Dates operator +(Dates date_1, Dates date_2)
        {
            Dates date = new Dates();
            if ((date_1.Day + date_2.Day) <= 30)
                date.Day = date_1.Day + date_2.Day;
            else
            {
                date.Day = date_1.Day + date_2.Day - 30;
                date.Month++;
            }
            if ((date_1.Month + date_2.Month + date.Month) <= 12)
                date.Month += date_1.Month + date_2.Month;
            else
            {
                date.Month += date_1.Month + date_2.Month - 12;
                date.Year++;
            }
            if ((date_1.Year + date_2.Year + date.Year) < 100)
                date.Year += date_1.Year + date_2.Year;
            else
                date.Year += date_1.Year + date_2.Year - 100;
            return date;
        }
        public static Dates operator -(Dates date_1, Dates date_2)
        {
            Dates date = new Dates();
            bool month = false;
            bool year = false;
            if ((date_1.Day - date_2.Day) >= 0)
                date.Day = date_1.Day - date_2.Day;
            else
            {
                date.Day = date_1.Day - date_2.Day + 30;
                month = true;
            }

            if ((date_1.Month - date_2.Month - (month ? 1 : 0)) > 0)
            {
                date.Month = date_1.Month - date_2.Month - (month ? 1 : 0);
            }
            else
            {
                date.Month = date_1.Month - date_2.Month - (month ? 1 : 0) + 12;
                year = true;
            }
            if ((date_1.Year - date_2.Year - (year ? 1 : 0)) >= 0)
            {
                date.Year = date_1.Year - date_2.Year - (year ? 1 : 0);
            }
            else
            {
                date.Year = date_1.Year - date_2.Year - (year ? 1 : 0) + 100;
            }
            return date;
            
        }

        public static implicit operator Dates(string str)
        {
            string[] st = str.Split('.');
            new Dates(Convert.ToInt32(st[0]), Convert.ToInt32(st[1]), Convert.ToInt32(st[2]));
            return new Dates(Convert.ToInt32(st[0]), Convert.ToInt32(st[1]), Convert.ToInt32(st[2]));
        }

        public static implicit operator string(Dates date)
        {
            return date.Day + "." + date.Month + "." +date.Year;
        }

        public void Print()
        {
            Console.WriteLine($"{Day}.{Month}.{Year}");
        }
    }

    public class Graphics
    {
        public static void Read()
        {
            string str;
            str = Console.ReadLine();
            string[] st = str.Split(' ');
            if (!st[0].Contains('.') && !st[2].Contains('.'))
                PrintInt(Convert.ToInt32(st[0]), Convert.ToInt32(st[2]), Convert.ToChar(st[1][0]));
            else
            {
                Dates date_1 = st[0];
                Dates date_2 = st[2];
                Dates date_3;
                switch (st[1])
                {
                    case "-":
                        date_3 = date_1 - date_2;
                        date_3.Print();
                        break;
                    case "+":
                        date_3 = date_1 + date_2;
                        date_3.Print();
                        break;

                }
            }
        }
        protected static void PrintInt(int val_1, int val_2, char s)
        {
            int result;
            switch (s)
            {
                case '-':
                    result = MathematicalOperations.Subtraction(val_1, val_2);
                    break;
                case '+':
                    result = MathematicalOperations.Summ(val_1, val_2);
                    break;
                case '*':
                    result = MathematicalOperations.Multiplication(val_1, val_2);
                    break;
                case '/':
                    result = MathematicalOperations.Division(val_1, val_2);
                    break;
                default:
                    Console.WriteLine("недопустимое действие");
                    return;
            }
            Console.WriteLine($"{val_1} {s} {val_2} = {result}");
        }
        protected static void PrintInt(string val_1, string val_2, char s)
        {

        }
    }

    public class MathematicalOperations
    {
        public static int Summ(int num_1, int num_2)
        {
            return num_1 + num_2;
        }

        public static float Summ(float num_1, float num_2)
        {
            return num_1 + num_2;
        }

        public static int Multiplication(int num_1, int num_2)
        {
            return num_1 * num_2;
        }

        public static float Multiplication(float num_1, float num_2)
        {
            return num_1 * num_2;
        }

        public static int Division(int num_1, int num_2)
        {
            return num_1 / num_2;
        }

        public static float Division(float num_1, float num_2)
        {
            return num_1 / num_2;
        }

        public static int Subtraction(int num_1, int num_2)
        {
            return num_1 - num_2;
        }

        public static float Subtraction(float num_1, float num_2)
        {
            return num_1 - num_2;
        }
    }
}
