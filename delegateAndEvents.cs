using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace learning_c_
{
    public enum comparison
    {
        theFirstComesFirst = 1,
        theSeconComesFirst = 2
    }
    public class Pair
    {
        private object[] thePair = new object[2];
        public Pair(object firstObject, object secondObject)
        {
            thePair[0] = firstObject;
            thePair[1] = secondObject;
        }
        public override string ToString()
        {
            return thePair[0].ToString() + ", " + thePair[1].ToString();
        }
        public delegate comparison WhichIsFirst(object firstObject, object secondObject);
        public void Sort(WhichIsFirst theDelegate)
        {
            if (theDelegate(thePair[0], thePair[1]) == comparison.theSeconComesFirst)
            {
                object aux = thePair[0];
                thePair[0] = thePair[1];
                thePair[1] = aux;
            }
        }
        public void ReverseSort(WhichIsFirst theDelegate)
        {
            if (theDelegate(thePair[0], thePair[1]) == comparison.theFirstComesFirst)
            {
                object aux = thePair[0];
                thePair[0] = thePair[1];
                thePair[1] = aux;
            }
        }
    }
    public class Student
    {
        private string name;
        public Student(string name)
        {
            this.name = name;
        }
        public override string ToString()
        {
            return name;
        }
        public static comparison WhichIsFirst(object obj1, object obj2)
        {
            Student stud1 = (Student)obj1;
            Student stud2 = (Student)obj2;
            if (String.Compare(stud1.name, stud2.name) < 0)
                return comparison.theFirstComesFirst;
            return comparison.theSeconComesFirst;
        }
        public static readonly Pair.WhichIsFirst OrderStudents = new Pair.WhichIsFirst(Student.WhichIsFirst);
        public static Pair.WhichIsFirst OrderStudent
        {
            get
            {
                return new Pair.WhichIsFirst(Student.WhichIsFirst);
            }
        }
    }
    public class Dog
    {
        private int weight;
        public Dog(int weight)
        {
            this.weight = weight;
        }
        public override string ToString()
        {
            return weight.ToString();
        }
        public static comparison WhichIsFirst(object obj1, object obj2)
        {
            Dog dog1 = (Dog)obj1;
            Dog dog2 = (Dog)obj2;
            if (dog1.weight > dog2.weight)
                return comparison.theSeconComesFirst;
            return comparison.theFirstComesFirst;
        }
        public static readonly Pair.WhichIsFirst OrderDogs = new Pair.WhichIsFirst(Dog.WhichIsFirst);
        public static Pair.WhichIsFirst OrderDog
        {
            get
            {
                return new Pair.WhichIsFirst(Dog.WhichIsFirst);
            }
        }
    }
    public class Image
    {
        public Image()
        {
            Console.WriteLine("An image created");
        }
    }
    public class ImageProcessor
    {
        public ImageProcessor(Image image)
        {
            this.image = image;
            arrayEffects = new DoEffect[10];
        }
        public delegate void DoEffect();
        public static void Blur()
        {
            Console.WriteLine("Blurring image");
        }
        public static void Filter()
        {
            Console.WriteLine("Filtering image");
        }
        public static void Sharpen()
        {
            Console.WriteLine("Sharpening image");
        }
        public static void Rotate()
        {
            Console.WriteLine("Rotating image");
        }
        public void AddToEffects(DoEffect effect)
        {
            if (nrEffects >= 10)
                throw new Exception("Prea multe efecte");
            arrayEffects[nrEffects++] = effect;
        }
        public void ProcessImage()
        {
            for (int i = 0; i < nrEffects; i++)
                arrayEffects[i]();
        }
        public DoEffect BlurEffect = new DoEffect(Blur);
        public DoEffect SharpenEffect = new DoEffect(Sharpen);
        public DoEffect FilterEffect = new DoEffect(Filter);
        public DoEffect RotateEffect = new DoEffect(Rotate);

        private DoEffect[] arrayEffects;
        private Image image;
        private int nrEffects = 0;
    }
    public class MyClassWithDelegate
    {
        public delegate void StringDelegate(string s);
    }
    public class MyImplementingClass
    {
        public MyImplementingClass()
        {

        }
        public static void WriteString(string s)
        {
            Console.WriteLine("Writing string {0}", s);
        }
        public static void LogString(string s)
        {
            Console.WriteLine("Logging string {0}", s);
        }
        public static void TransmitString(string s)
        {
            Console.WriteLine("Transmitting string {0}", s);
        }
    }
    public class TimeInfoEventArgs : EventArgs
    {
        public TimeInfoEventArgs(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
        public readonly int hour;
        public readonly int minute;
        public readonly int second;
    }
    public class Clock
    {
        private int hour;
        private int minute;
        private int second;
        public delegate void SecondChangeHandler(object clock, TimeInfoEventArgs timeInformation);
        public event SecondChangeHandler OnSecondChange;
        public void Run()
        {
            for(; ; )
            {
                Thread.Sleep(10);
                System.DateTime dt = System.DateTime.Now;
                if (dt.Second != second)
                {
                    TimeInfoEventArgs timeInformation = new TimeInfoEventArgs(dt.Hour, dt.Minute, dt.Second);
                    if (OnSecondChange != null)
                    {
                        OnSecondChange(this, timeInformation);
                    }
                }
                this.second = dt.Second;
                this.minute = dt.Minute;
                this.hour = dt.Hour;
            }
        }
    }
    public class DisplayClock
    {
        public void TimeHasChanged(object obj, TimeInfoEventArgs ti)
        {
            Console.WriteLine("Current time: {0}:{1}:{2}", ti.hour.ToString(), ti.minute.ToString(), ti.second.ToString());
        }
        public void Subscribe(Clock clock)
        {
            clock.OnSecondChange += new Clock.SecondChangeHandler(TimeHasChanged);
        }
    }
    public class LogCurrentTime
    {
        public void WriteLogEntry(object obj, TimeInfoEventArgs ti)
        {
            Console.WriteLine("Logging file: {0}:{1}:{2}", ti.hour.ToString(), ti.minute.ToString(), ti.second.ToString());
        }
        public void Subscribe(Clock clock)
        {
            clock.OnSecondChange += new Clock.SecondChangeHandler(WriteLogEntry);
        }
    }
    class Test
    {
        public static void Main()
        {
            Console.WriteLine("Hello, wrold!");
            Console.WriteLine();

            Student Jesse = new Student("Jesse");
            Student Stacey = new Student("Stacey");
            Dog Milo = new Dog(65);
            Dog Fred = new Dog(12);
            Pair studentPair = new Pair(Jesse, Stacey);
            Pair dogPair = new Pair(Milo, Fred);
            Console.WriteLine("studentPair\t\t\t: {0}", studentPair.ToString());
            Console.WriteLine("dogPair\t\t\t\t: {0}", dogPair.ToString());
            Pair.WhichIsFirst theStudentDelegate = new Pair.WhichIsFirst(Student.WhichIsFirst);
            Pair.WhichIsFirst theDogDelegate = new Pair.WhichIsFirst(Dog.WhichIsFirst);
            // sort using the delegates
            studentPair.Sort(theStudentDelegate);
            Console.WriteLine("After Sort studentPair\t\t: {0}", studentPair.ToString());
            studentPair.ReverseSort(theStudentDelegate);
            Console.WriteLine("After ReverseSort studentPair\t: {0}", studentPair.ToString());
            dogPair.Sort(theDogDelegate);
            Console.WriteLine("After Sort dogPair\t\t: {0}", dogPair.ToString());
            dogPair.ReverseSort(theDogDelegate);
            Console.WriteLine("After ReverseSort dogPair\t: {0}", dogPair.ToString());

            Console.WriteLine();
            studentPair.Sort(Student.OrderStudents);
            Console.WriteLine("After Sort studentPair\t\t: {0}", studentPair.ToString());
            studentPair.ReverseSort(Student.OrderStudents);
            Console.WriteLine("After ReverseSort studentPair\t: {0}", studentPair.ToString());
            dogPair.Sort(Dog.OrderDogs);
            Console.WriteLine("After Sort dogPair\t\t: {0}", dogPair.ToString());
            dogPair.ReverseSort(Dog.OrderDogs);
            Console.WriteLine("After ReverseSort dogPair\t: {0}", dogPair.ToString());

            Console.WriteLine();
            Image image = new Image();
            ImageProcessor theProc = new ImageProcessor(image);
            theProc.AddToEffects(theProc.BlurEffect);
            theProc.AddToEffects(theProc.FilterEffect);
            theProc.AddToEffects(theProc.RotateEffect);
            theProc.AddToEffects(theProc.SharpenEffect);
            theProc.ProcessImage();

            Console.WriteLine();
            MyClassWithDelegate.StringDelegate Writer, Logger, Transmitter;
            MyClassWithDelegate.StringDelegate myMultcastDelegate;
            Writer = new MyClassWithDelegate.StringDelegate(MyImplementingClass.WriteString);
            Logger = new MyClassWithDelegate.StringDelegate(MyImplementingClass.LogString);
            Transmitter = new MyClassWithDelegate.StringDelegate(MyImplementingClass.TransmitString);
            Writer("String passed to Writer\n");
            Logger("String passed to Logger\n");
            Transmitter("String passed to Transmitter\n");
            myMultcastDelegate = Writer + Logger;
            myMultcastDelegate("am combinar writer si logger");
            myMultcastDelegate += Transmitter;
            myMultcastDelegate("am adaugat si transmitter");
            myMultcastDelegate -= Logger;
            myMultcastDelegate("am scos logger");

            Console.WriteLine();
            Console.WriteLine("Events-----------------");
            Console.WriteLine();
            Clock clock = new Clock();
            DisplayClock dc = new DisplayClock();
            dc.Subscribe(clock);
            LogCurrentTime lct = new LogCurrentTime();
            lct.Subscribe(clock);
            clock.Run();
        }
    }
}
