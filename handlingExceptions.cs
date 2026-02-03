using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

class HandlingException
{
    public void Func1()
    {
        Console.WriteLine("Enter Func1...");
        Func2();
        Console.WriteLine("Exit Func1...");
    }
    public void Func2()
    {
        Console.WriteLine("Enter Func2...");
        try
        {
            Console.WriteLine("Entering try block...");
            throw new System.Exception();
            Console.WriteLine("Exiting try block...");
        }
        catch {
            Console.WriteLine("Exception caught and handled.");
        }
        Console.WriteLine("Exit Func2...");
    }
    public double DoDivide(double a, double b)
    {
        if (b == 0)
        {
            DivideByZeroException e = new DivideByZeroException();
            e.HelpLink = "http://www.libertyassociates.com";
            throw e;
        }
        if (a == 0)
        {
            ArithmeticException e = new ArithmeticException("mesaj cu ce ai facut prost");
            e.HelpLink = "link salvator";
            throw e;
        }
        if(b == 1)
        {
            MyCustomException e = new MyCustomException("de ce sa imparti la 1? btw custom exception");
            throw e;
        }
        return a / b;
    }
    public void DivideTest(double a, double b)
    {
        try
        {
            Console.WriteLine("{0}/{1} = {2}", a, b, DoDivide(a, b));
        }
        catch (System.DivideByZeroException e)
        {
            Console.WriteLine("DivideByZeroException caught!");
            Console.WriteLine("\nDivideByZeroException! Msg: {0}", e.Message);
            Console.WriteLine("\nHelpLink: {0}", e.HelpLink);
            Console.WriteLine("\nHere's a stack trace: {0}\n", e.StackTrace);
        }
        catch (System.ArithmeticException e)
        {
            Console.WriteLine("ArithmeticException caught!");
            Console.WriteLine("\nDivideByZeroException! Msg: {0}", e.Message);
            Console.WriteLine("\nHelpLink: {0}", e.HelpLink);
            Console.WriteLine("\nHere's a stack trace: {0}\n", e.StackTrace);
        }
        catch (MyCustomException e)
        {
            Console.WriteLine("Custom exception caught!");
            Console.WriteLine("\nCustom things! Msg: {0}", e.Message);
        }
        catch
        {
            Console.WriteLine("o exceptie noua");
        }
        finally
        {
            Console.WriteLine("FINALLY");
        }
    }
    public class MyCustomException : System.ApplicationException
    {
        public MyCustomException(string msg) : base(msg)
        {

        }
        public MyCustomException(string msg, Exception inner) : base(msg, inner)
        {

        }
    }
    public void TestFunc()
    {
        try
        {
            Dangerous1();
        }
        catch(MyCustomException e)
        {
            Console.WriteLine("\n{0}", e.Message);
            Console.WriteLine("Retrieving exception history...");
            Exception inner = e.InnerException;
            while (inner != null)
            {
                Console.WriteLine(inner.Message);
                inner = inner.InnerException;
            }
        }
    }
    public void Dangerous1()
    {
        try
        {
            Dangerous2();
        }
        catch(System.Exception e)
        {
            MyCustomException ex = new MyCustomException("E3 - Custom Exception Situation!", e);
            throw ex;
        }
    }
    public void Dangerous2()
    {
        try
        {
            Dangerous3();
        }
        catch(System.DivideByZeroException e)
        {
            Exception ex = new Exception("E2 - Func2 caught divide by zero", e);
            throw ex;
        }
    }
    public void Dangerous3()
    {
        try
        {
            Dangerous4();
        }
        catch (System.ArithmeticException)
        {
            throw;
        }
        catch (System.Exception)
        {
            Console.WriteLine("exceptia se rezolva aici");
        }
    }
    public void Dangerous4()
    {
        throw new DivideByZeroException("E1 - DivideByZero Exception");
    }
    public static void Main()
    {
        Console.WriteLine("Hello, wrold!");
        Console.WriteLine();
        Console.WriteLine("Enter Main...");
        HandlingException he = new HandlingException();
        he.Func1();
        Console.WriteLine("Exit Main...");
        Console.WriteLine();

        he.DivideTest(2, 3);
        he.DivideTest(2, 0);
        he.DivideTest(0, 4);
        he.DivideTest(2, 1);
        Console.WriteLine();

        he.TestFunc();              //ca sa intelegi ce se intampla, pune breakpoint aici si la fiecare dangerous + TestFunc si ruleaza in debugger
    }
}
