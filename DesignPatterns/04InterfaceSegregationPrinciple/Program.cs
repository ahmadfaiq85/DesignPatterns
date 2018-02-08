using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrinciple
{
    //Definition: Interfaces should be segregated so that nobody who implements 
    //our interface has to implement functions he doesn't need
    public class Document
    {
        public string Name { get; set; }
    }

    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }

    public interface IFax
    {
        void Fax(Document d);
    }

    public interface IMultifunction : IPrinter, IScanner, IFax
    {

    }

    public class Photocopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            //Print
        }

        public void Scan(Document d)
        {
            //Scan
        }
    }

    public class MultiFunctionPrinter : IMultifunction
    {
        public void Print(Document d)
        {
            //Print
        }

        public void Scan(Document d)
        {
            //Scan
        }

        public void Fax(Document d)
        {
            //Fax
        }
    }



    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
