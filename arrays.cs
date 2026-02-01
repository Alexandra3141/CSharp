using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Buton : IComparable
{
    public Buton(int nr)
    {
        Console.WriteLine("am creat un buton");
        this.nr = nr;
    }
    public override string ToString()
    {
        return "id: " + nr.ToString() + " years: " + years.ToString();
    }
    public int Numar
    {
        get
        {
            return nr;
        }
        set
        {
            nr = value;
        }
    }
    public int CompareTo(object obj)
    {
        Buton but = (Buton)obj;
        return this.nr.CompareTo(but.nr);
    }
    public Buton(int nr, int years)
    {
        this.nr = nr;
        this.years = years;
    }
    public static ButonComparer GetComparer()
    {
        return new Buton.ButonComparer();
    }
    public int CompareTo(Buton obj, Buton.ButonComparer.ComparasionType type)
    {
        switch (type)
        {
            case Buton.ButonComparer.ComparasionType.nr: return this.nr.CompareTo(obj.nr);
            case Buton.ButonComparer.ComparasionType.years: return this.years.CompareTo(obj.years);
        }
        return 0;
    }
    public class ButonComparer : IComparer
    {
        public enum ComparasionType
        {
            nr,
            years
        }
        public int Compare(object obj, object obje)
        {
            Buton but = (Buton)obj;
            Buton buto = (Buton)obje;
            return but.CompareTo(buto, TypeComparasion);
        }
        public Buton.ButonComparer.ComparasionType TypeComparasion
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        private Buton.ButonComparer.ComparasionType type;
    }
    private int nr;
    private int years = 1;
}
public class ListBox : IEnumerable
{
    private string[] strings;
    private int crt = 0;
    public ListBox(params string[] strings)
    {
        this.strings = new string[8];
        foreach (string s in strings)
            this.strings[crt++] = s;
    }
    public void Add(string s)
    {
        if (crt >= strings.Length)
        {
            //eroare
        }
        else
            strings[crt++] = s;
    }
    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= strings.Length)
            {
                //eroare
            }
            return strings[index];
        }
        set
        {
            if (index >= strings.Length)
            {
                //eroare
            }
            else
                strings[index] = value;
        }
    }
    public int GetNrStringuri()
    {
        return crt;
    }
    private int FindString(string start)
    {
        for (int i = 0; i < strings.Length; i++)
        {
            if (strings[i].StartsWith(start))
                return i;
        }
        return -1;
    }
    public string this[string index]
    {
        get
        {
            if (index.Length == 0)
            {
                //eroare
            }
            return strings[FindString(index)];
        }
        set
        {
            strings[FindString(index)] = value;
        }
    }
    private class ListBoxEnumerator : IEnumerator
    {
        private ListBox lb;
        int index;
        public ListBoxEnumerator(ListBox lb)
        {
            this.lb = lb;
            index = -1;
        }
        public bool MoveNext()
        {
            index++;
            if (index >= lb.strings.Length) return false;
            return true;
        }
        public void Reset()
        {
            index = -1;
        }
        public object Current
        {
            get
            {
                return lb[index];
            }
        }
    }
    public IEnumerator GetEnumerator()
    {
        return (IEnumerator)new ListBoxEnumerator(this);
    }
}
class Prog
{
    public void AfisareValori(params int[] intVal)
    {
        foreach (int val in intVal)
        {
            Console.WriteLine("{0}", val);
        }
    }
    public static void PrintValue(IEnumerable myCollection)
    {
        IEnumerator myEnumerator = myCollection.GetEnumerator();
        while (myEnumerator.MoveNext())
        {
            Console.Write("{0}, ", myEnumerator.Current);
        }
        Console.WriteLine();
    }
    public static void PrintKeysAndValues(Hashtable table)
    {
        IDictionaryEnumerator myEnumerator = table.GetEnumerator();
        while (myEnumerator.MoveNext())
        {
            Console.WriteLine("{0}\t{1}\n", myEnumerator.Key, myEnumerator.Value);
        }
    }
    static void Main()
    {
        Console.WriteLine("Hello, world!");
        Console.WriteLine();

        Console.WriteLine("Array");
        Buton[] butoane = new Buton[4];
        for (int i = 0; i < butoane.Length; i++)
            butoane[i] = new Buton(i + 1);
        foreach(Buton i in butoane)
            Console.WriteLine(i.ToString());
        Prog p = new Prog();
        p.AfisareValori(1, 2, 3, 4);
        Console.WriteLine();
        int[] val = new int[5] { 4, 5, 6, 7, 8 };
        p.AfisareValori(val);
        Console.WriteLine();

        int[,] matrice = new int[3, 4];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 4; j++)
                matrice[i,j] = i + j;
        for(int i = 0; i < 3; i++)
        {
            for(int j=0;j<4;j++)
                Console.Write(matrice[i,j]);
            Console.WriteLine();
        }
        int[,] mat ={ { 1, 2 }, { 2, 3 }, { 3, 4 } };
        Console.WriteLine();

        int[][] jagged = new int[3][];
        for (int i = 0; i < 3; i++)
            jagged[i] = new int[i + 1];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < jagged[i].Length; j++)
                jagged[i][j] = i + j;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < jagged[i].Length; j++)
                Console.Write(matrice[i, j]);
            Console.WriteLine();
        }
        Console.WriteLine();

        ListBox lb = new ListBox("Hello", "World", "!");
        lb.Add("hei");
        lb.Add("buna");
        string str = "ceva";
        lb[3] = str;
        lb[9] = str;
        for (int i = 0; i < lb.GetNrStringuri(); i++)
            Console.Write("{0} ", lb[i]);
        Console.WriteLine();
        Console.WriteLine("{0}", lb["Hell"]);
        Console.WriteLine();

        ListBox lbt = new ListBox("Hello", "World");
        lbt.Add("Who");
        lbt.Add("Is");
        lbt.Add("John");
        lbt.Add("Galt");
        string subst = "Universe";
        lbt[1] = subst;
        foreach (string s in lbt)
        {
            Console.WriteLine("Value: {0}", s);
        }
        Console.WriteLine();

        Console.WriteLine("Array List");
        ArrayList but = new ArrayList();
        ArrayList array = new ArrayList();
        for(int i = 0; i < 5; i++)
        {
            but.Add(new Buton(i*10));
            array.Add(i + 1);
        }
        for (int i = 0; i < array.Count; i++)
            Console.Write("{0}; ", array[i].ToString());
        Console.WriteLine();
        for (int i = 0; i < but.Count; i++)
            Console.Write("{0}; ", but[i].ToString());
        Console.WriteLine();
        Console.WriteLine("capacitate but: {0}", but.Capacity);
        Console.WriteLine();

        but = new ArrayList();
        array = new ArrayList();
        Random r = new Random();
        for(int i = 0; i < 5; i++)
        {
            but.Add(new Buton(r.Next(10)));
            array.Add(r.Next(40));
        }
        for (int i = 0; i < array.Count; i++)
            Console.Write("{0}; ", array[i].ToString());
        Console.WriteLine();
        for (int i = 0; i < but.Count; i++)
            Console.Write("{0}; ", but[i].ToString());
        Console.WriteLine();
        array.Sort(); 
        for (int i = 0; i < array.Count; i++)
            Console.Write("{0}; ", array[i].ToString());
        Console.WriteLine();
        but.Sort();
        for (int i = 0; i < but.Count; i++)
            Console.Write("{0}; ", but[i].ToString());
        Console.WriteLine();
        Console.WriteLine();

        but = new ArrayList();
        for (int i = 0; i < 5; i++)
            but.Add(new Buton(r.Next(10),r.Next(20)));
        for (int i = 0; i < but.Count; i++)
            Console.Write("{0}; ", but[i].ToString());
        Console.WriteLine();
        Buton.ButonComparer type = Buton.GetComparer();
        type.TypeComparasion = Buton.ButonComparer.ComparasionType.nr;
        but.Sort(type);
        for (int i = 0; i < but.Count; i++)
            Console.Write("{0}; ", but[i].ToString());
        Console.WriteLine();
        type.TypeComparasion = Buton.ButonComparer.ComparasionType.years;
        but.Sort(type);
        for (int i = 0; i < but.Count; i++)
            Console.Write("{0}; ", but[i].ToString());
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Queue");
        Queue queue = new Queue();
        for (int i = 0; i < 5; i++)
            queue.Enqueue(r.Next(30));
        PrintValue(queue);
        for (int i = 0; i < queue.Count; i++)
        {
            queue.Dequeue();
            PrintValue(queue);
        }
        Console.WriteLine("{0}", queue.Peek());
        Console.WriteLine();

        Console.WriteLine("Stack");
        Stack stack = new Stack();
        for (int i = 0; i < 5; i++)
            stack.Push(r.Next(40));
        PrintValue(stack);
        for(int i = 0; i < stack.Count; i++)
        {
            stack.Pop();
            PrintValue(stack);
        }
        Console.WriteLine("{0}", stack.Peek());
        Array arr = Array.CreateInstance(typeof(int), 5);
        for (int i = 0; i < 5; i++)
            arr.SetValue(r.Next(40), i);
        PrintValue(arr);
        stack.CopyTo(arr, 3);
        PrintValue(arr);
        Object[] myArray = stack.ToArray();
        PrintValue(myArray);
        Console.WriteLine();

        Console.WriteLine("HashTable");
        Hashtable hashTable = new Hashtable();
        hashTable.Add("000440312", "Jesse Liberty");
        hashTable.Add("000123933", "Stacey Liberty");
        hashTable.Add("000145938", "John Galt");
        hashTable.Add("000773394", "Ayn Rand");
        PrintValue(hashTable);
        Console.WriteLine("HashTable [\"000145938\"]: {0}", hashTable["000145938"]);
        Console.WriteLine();
        ICollection keys = hashTable.Keys;
        ICollection values = hashTable.Values;
        PrintValue(keys);
        PrintValue(values);
        PrintKeysAndValues(hashTable);
    }
}
