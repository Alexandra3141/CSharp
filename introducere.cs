//in acest cod se afla 2 main-uri care interfereaza unul cu altul asa ca am adaugat litera e devenind Maine, pentru a rula unul din main-uri
//trebuie sters e-ul
//ATENTIE!! nu se pot rula in acelasi timp 2 main-uri, nu uita sa adaugi e la final dupa ce rulezi una din parti
#define DEBUG
#undef DEBUG
using System;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Xml;

namespace Programming_C_Sharp
{
    namespace Programming_C_Sharp_Test
    {
        using System;
        class Test
        {
            public static void RunTest()
            {
                Console.WriteLine("acesta e un namespace de test");
            }
        }
    }
}
class Test
{
    public static void RunTest() => Console.WriteLine("asta nu e acelasi lucru cu namspace-ul creat");
}

#if DEBUG
class Debug
{
    public static void Run()
    {
        Console.WriteLine("debug e definit");
    }
}

#else
class Debug
{
    public static void Run()
    {
        Console.WriteLine("debug e undefined");
    }
}

#endif
class Program
{ 
    static void someMethods()
    {
        Console.WriteLine("hei");
    }

    static void Maine()             //trebuie modificat pentru a mai rula asta si comentate alte main-uri
    {
        Console.WriteLine("Hello, world!");

        int x = 2;
        Console.WriteLine("my int: {0}", x);
        someMethods();

        Console.WriteLine("introdu temperatura ");
        int temp = 0;
    repeat:
        //string input = Console.ReadLine();
        string input = "0";         //daca rulezi asta, decomenteaza ce e sus si sterge aici
        temp = int.Parse(input);
        if (temp < -20 || temp > 40)
        {
            Console.WriteLine("temperatura e irelevanta");
            goto repeat;
        }
        Console.WriteLine("{0}", temp);

        Console.WriteLine("introdu un caracter");
        string caracter = " ";          //daca rulezi asta, modifica aici si decomenteaza ce e jos
        while (caracter != " ")
        {
            //caracter = Console.ReadLine();
            if (caracter == "A")
            {
                Console.WriteLine("o luam iar de la capat");
                continue;
            }
            if (caracter == "B")
            {
                Console.WriteLine("ne oprim");
                break;
            }
            Console.WriteLine("o luam iar, chit ca nu e A");
        }

        Programming_C_Sharp.Programming_C_Sharp_Test.Test.RunTest();
        Test.RunTest();

        Debug.Run();
    }
}
public class Time
{
    private int day;
    private int month;
    private int year;
    private int hour;
    private int minute;
    private int second;
    public void GetTime()
    {
        System.DateTime now = new System.DateTime();
        now = System.DateTime.Now;
        Console.WriteLine("Debug Time:\t{0}/{1}/{2}\t{3}:{4}:{5}", now.Day, now.Month, now.Year, now.Hour, now.Minute, now.Second);
        Console.WriteLine("Time:\t\t{0}/{1}/{2}\t{3}:{4}:{5}", day, month, year, hour, minute, second);
    }

    public Time(System.DateTime now)
    {
        day = now.Day;
        month = now.Month;
        year = now.Year;
        hour = now.Hour;
        minute = now.Minute;
        second = now.Second;
    }

    public Time(int day, int month, int year, int hour, int minute, int second)
    {
        this.day = day;
        this.month = month;
        this.year = year;
        this.hour = hour;
        this.minute = minute;
        this.second = second;
    }

    public Time(Time timp)
    {
        this.day = timp.day;
        this.month = timp.month;
        this.year = timp.year;
        this.hour = timp.hour;
        this.minute = timp.minute;
        this.second = timp.second;
    }

    public void GetTimp(ref int h, ref int m, ref int s)
    {
        h = this.hour;
        m = this.minute;
        s = this.second;
    }
    public int Hour
    {
        get
        {
            return hour;
        }
        set
        {
            hour = Hour;
        }
    }
}
abstract public class Animal            //fiind clasa abstracta se poate declara numai vector de obiecte de acest tip
{
    abstract public void Specie();
}
public class Cat : Animal
{
    private static int nr = 0;
    private string nume;
    private bool areStapan;
    public Cat()
    {
        nume = "Tom";
        areStapan = false;
        nr++;
    }
    public Cat(string nume, bool areStapan)
    {
        this.nume = nume;
        this.areStapan = areStapan;
        nr++;
    }
    public static void HowManyCats()
    {
        Console.WriteLine("{0}", nr);
    }
    public void AfisareNume()
    {
        Console.WriteLine(nume);
    }
    public virtual void AfisareRasa()
    {
        Console.WriteLine("nu stim rasa");
    }
    public override void Specie()
    {
        Console.WriteLine("e pisica");
    }
}

public class British : Cat
{
    public British() :base()
    {
        varsta = 1;
    }
    public British(string nume, bool areStapan, int varsta) :base(nume, areStapan)
    {
        this.varsta = varsta;
    }
    public new void AfisareNume()
    {
        Console.WriteLine(varsta);
    }
    public override void AfisareRasa()
    {
        Console.WriteLine("British");
    }
    private int varsta;
    public override void Specie()
    {
        Console.Write("e pisica ");
        AfisareRasa();
    }
}
class Siameza : Cat
{
    public override void AfisareRasa()
    {
        Console.WriteLine("Siameza");
    }
    public override void Specie()               //nu e obligatoriu sa o adaugi
    {
        Console.Write("e pisica ");
        AfisareRasa();
    }
}
class Scotish : Cat
{
    public override void AfisareRasa()
    {
        base.AfisareRasa();         //se adauga doar daca vrei sa se execute si metoda din clasa de baza
        Console.WriteLine("Scotish");
    }
    public override void Specie()
    {
        Console.Write("e pisica ");
        AfisareRasa();
    }
}
sealed public class Caine
{
    //sealed anunta ca nu poti deriva alte clase din ea spre exemplu class Bishon : Caine va genera eroare
}

public class Operatori
{
    private int valoare;
    private string nume;

    public Operatori(int valoare, string nume)
    {
        this.valoare = valoare;
        this.nume = nume;
    }
    public override string ToString()
    {
        return valoare.ToString();
    }
}
public class Masina
{
    private int an;
    public Masina(int an)
    {
        this.an = an;
    }
    public override string ToString()
    {
        return String.Format("{0}", an);
    }
    internal class Masinuta
    {
        public void Afisare(Masina m)
        {
            Console.WriteLine("an: {0}", m.an);
        }
    }
    public override bool Equals(object obj)
    {
        if(!(obj is  Masina)) return false;
        return this == (Masina)obj;
    }
    public static implicit operator Masina(int valoare)
    {
        return new Masina(valoare);
    }
    public static explicit operator double(Masina masina) { 
        return masina.an;
    }
    public static bool operator==(Masina m1, Masina m2)
    {
        if(m1.an == m2.an) return true;
        return false;
    }
    public static bool operator!=(Masina m1, Masina m2)
    {
        return !(m1.an == m2.an);
    }
    public static Masina operator+(Masina m1, Masina m2)
    {
        int first = m1.an;
        int second = m2.an;
        return new Masina(first + second);
    }
}
public struct Locatie
{
    private int xval;
    private int yval;

    public Locatie(int xval, int yval)
    {
        this.xval = xval;
        this.yval = yval;
    }
    public int x
    {
        get 
        {
            return xval;
        }
        set
        {
            xval = value;
        }
    }
    public int y
    {
        get
        {
            return yval;
        }
        set
        {
            yval = value;
        }
    }
    public override string ToString()
    {
        return (String.Format("{0}, {1}", xval, yval));
    }
}

public class TestClase
{
    private int Dublu(int x)
    {
        return 2 * x;
    }
    private long Dublu(long x)
    {
        return 2 * x;
    }
    public void Test()
    {
        int x = 2;
        int y = Dublu(x);
        long lx = 4;
        long ly = Dublu(lx);
        Console.WriteLine("x = {0}\ny = {1}\nlx = {2}\nly = {3}", x, y, lx, ly);
    }
    public void FuncLoc(Locatie loc)
    {
        loc.x = 50;
        loc.y = 100;
        Console.WriteLine("locatie din functie: {0}", loc); 
    }
    static void Maine()                             //trebuie sters e si lasat Main pentru compilarea acestor secvente de cod
    {
        Console.WriteLine("Hello, world!");
        System.DateTime current = System.DateTime.Now;
        Time timp = new Time(current);
        timp.GetTime();
        timp = new Time(20, 9, 2008, 13, 56, 45);
        timp.GetTime();
        int h=0, m=0, s=0;
        timp.GetTimp(ref h, ref m, ref s);
        Console.WriteLine("{0}:{1}:{2}", h, m, s);
        int Hour = timp.Hour;
        Console.WriteLine("\nRetrieved the hour: {0}", Hour);
        Hour += 5;
        timp.Hour = Hour;
        Console.WriteLine("Updated the hour: {0}", Hour);
        Console.WriteLine();

        Cat pisica = new Cat();
        Cat.HowManyCats();
        Cat pisica1 = new Cat();
        Cat.HowManyCats();
        Cat pisica2 = new Cat();
        Cat.HowManyCats();
        Console.WriteLine();

        TestClase t = new TestClase();
        t.Test();
        Console.WriteLine();

        Cat pis = new Cat("Maria", true);
        British pisi = new British("Ana", true, 3);
        pis.AfisareNume();
        pisi.AfisareNume();
        pis.AfisareRasa();
        pisi.AfisareRasa();
        Cat dora = new Siameza();
        dora.AfisareRasa();
        Scotish scott = new Scotish();
        scott.AfisareRasa();
        Console.WriteLine("\ntestam si vector:");
        Cat[] pisici = new Cat[4];
        pisici[0] = pis;
        pisici[1] = pisi;
        pisici[2] = dora;
        pisici[3] = scott;
        for (int i = 0; i < 4; i++)
            pisici[i].AfisareRasa();
        Cat pisicatest = new Cat();
        pisicatest.Specie();
        pisicatest = new British();
        pisicatest.Specie();
        Console.WriteLine("\ntestam si vector:");
        Animal[] animale = new Animal[4];
        animale[0] = pis;
        animale[1] = pisi;
        animale[2] = dora;
        animale[3] = scott;
        for (int i = 0; i < 4; i++)
            animale[i].Specie();

        Console.WriteLine();
        Operatori op = new Operatori(2, "egal");
        Console.WriteLine("valoare = {0}", op.ToString());
        Console.WriteLine();

        Console.WriteLine("boxing and unboxing");       //faci din int, un obiect
        int intreg = 123;
        object o = intreg;       //boxing
        int j = (int)o;
        Console.WriteLine("{0}", j);
        Console.WriteLine();

        Masina masina = new Masina(2);
        Console.WriteLine("masina: {0}", masina.ToString());
        Masina.Masinuta masinuta = new Masina.Masinuta();
        masinuta.Afisare(masina);
        Console.WriteLine();

        Masina m1 = new Masina(2);
        Masina m2 = new Masina(2);
        if (m1 == m2)
            Console.WriteLine("m1 = m2");
        else
            Console.WriteLine("m1 nu = m2");
        if (m1 != m2)
            Console.WriteLine("m1 != m2");
        else
            Console.WriteLine("m1 nu != m2");
        Masina m3 = m1 + m2;
        Console.WriteLine("{0}", m3.ToString());
        Console.WriteLine();

        Locatie loc1 = new Locatie(1, 2);
        Console.WriteLine("Loc1 locatie: {0}", loc1);
        t = new TestClase();
        t.FuncLoc(loc1);
        Console.WriteLine("Loc1 location: {0}", loc1);
    }
}
