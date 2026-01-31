using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
interface IStorable
{
    void Read();
    void Write();
    int NrBytes { get; set; }
}
interface ICompressible
{
    void Compress();
    void Decompress();
    int Status { get; set; }
}
interface ILoggedCompressible : ICompressible
{
    void LogSavedBytes();
}
interface IStorableCompressible : IStorable, ILoggedCompressible
{
    void LogOriginalSize();
}
interface IEncryptable
{
    void Encrypt();
    void Decrypt();
}
interface Extra
{
    void Extra();
}
public class Document : IStorableCompressible, IEncryptable
{
    public Document(string s)
    {
        Console.WriteLine(s);
    }
    public void Read()
    {
        Console.WriteLine("metoda read pentru IStorable");
    }
    public void Write()
    {
        Console.WriteLine("metoda write pentru IStorable");
    }
    public int NrBytes
    {
        get
        {
            return nrBytes;
        }
        set
        {
            nrBytes = value;
        }
    }
    public void Compress()
    {
        Console.WriteLine("metoda compress");
    }
    public void Decompress()
    {
        Console.WriteLine("metoda decompress");
    }
    public int Status
    {
        get
        {
            return status;
        }
        set
        {
            status = value;
        }
    }
    private int nrBytes = 0;
    private int status = 0;
    public void LogSavedBytes()
    {
        Console.WriteLine("Implementing LogSavedBytes");
    }
    public void LogOriginalSize()
    {
        Console.WriteLine("Implementing LogOriginalSize");
    }
    public void Encrypt()
    {
        Console.WriteLine("Implementing Encrypt");
    }
    public void Decrypt()
    {
        Console.WriteLine("Implementing Decrypt");
    }
}
public class Email : IStorable
{
    public Email()
    {
        Console.WriteLine("Email");
    }
    public virtual void Read()
    {
        Console.WriteLine("email read");
    }
    public void Write()
    {
        Console.WriteLine("email write");
    }
    public int NrBytes
    {
        get
        {
            return nrBytes;
        }
        set
        {
            nrBytes= value;
        }
    }
    int nrBytes = 0;
}
class Text : Email
{
    public Text()
    {
        Console.WriteLine("text");
    }
    public override void Read()
    {
        Console.WriteLine("text read override");
    }
    public new void Write()
    {
        Console.WriteLine("write text");
    }
}
public struct MyStruct : IStorable
{
    public MyStruct()
    {
        Console.WriteLine("s-a creat un struct");
    }
    public void Read()
    {
        Console.WriteLine("read din struct");
    }
    public void Write()
    {
        Console.WriteLine("write din struct");
    }
    public int NrBytes
    {
        get
        {
            return nrBytes;
        }
        set
        {
            nrBytes = value;
        }
    }
    private int nrBytes = 0;
}
class Teste
{
    static void Main()
    {
        Console.WriteLine("Hello, world!");
        Console.WriteLine();
        Console.WriteLine("interfete : \t\t\t is vs as");
        Document doc = new Document("Test Document");
        if (doc is IStorable)
        {
            IStorable isDoc = doc as IStorable;
            if (isDoc != null)
            {
                isDoc.Read();
                isDoc.Write();
            }
            else
                Console.WriteLine("IStorable not supported");
        }
        ICompressible icDoc = doc as ICompressible;
        if (icDoc != null)
        {
            icDoc.Compress();
            icDoc.Decompress();
        }
        else
            Console.WriteLine("Compressible not supported");
        ILoggedCompressible ilcDoc = doc as ILoggedCompressible;
        if (ilcDoc != null)
        {
            ilcDoc.LogSavedBytes();
            ilcDoc.Compress();
        }
        else
            Console.WriteLine("LoggedCompressible not supported");
        IStorableCompressible isc = doc as IStorableCompressible;
        if (isc != null)
        {
            isc.LogOriginalSize(); // IStorableCompressible
            isc.LogSavedBytes(); // ILoggedCompressible
            isc.Compress(); // ICompressible
            isc.Read(); // IStorable
        }
        else
            Console.WriteLine("StorableCompressible not supported");
        IEncryptable ie = doc as IEncryptable;          //mai eficient 
        if (ie != null)
        {
            ie.Encrypt();
            ie.Decrypt();
        }
        else
            Console.WriteLine("Encryptable not supported");
        if(doc is Extra)            //mai ineficient
        {
            Extra dex = (Extra)doc;
            dex.Extra();
        }
        else 
            Console.WriteLine("doc nu e Extra");

        Console.WriteLine();
        Email email = new Text();
        IStorable es = email as IStorable;
        if(es != null)
        {
            es.Read();
            es.Write();
        }
        email.Read();
        email.Write();
        Text txt = new Text();
        IStorable ts = txt as IStorable;
        if(ts!= null)
        {
            ts.Read();
            ts.Write();
        }
        txt.Read();
        txt.Write();

        Console.WriteLine();
        MyStruct mstr = new MyStruct();
        Console.WriteLine("initial: {0}", mstr.NrBytes);
        mstr.NrBytes = 3;
        Console.WriteLine("dupa: {0}", mstr.NrBytes);
        IStorable isstr = (IStorable)mstr;
        Console.WriteLine("initial: str: {0}; interf: {1}", mstr.NrBytes, isstr.NrBytes);
        isstr.NrBytes = 9;
        Console.WriteLine("modif interf: str: {0}; interf: {1}", mstr.NrBytes, isstr.NrBytes);
        mstr.NrBytes = 7;
        Console.WriteLine("modif str: str: {0}; interf: {1}", mstr.NrBytes, isstr.NrBytes);
    }
}
