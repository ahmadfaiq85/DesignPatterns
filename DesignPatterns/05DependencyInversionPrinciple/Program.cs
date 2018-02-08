using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple
{
    //Definition: High level parts of the system should not depend on low level parts of the system,
    //instead they should depend on abstraction

    public class Person
    {
        public string Name { get; set; }
    }
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    public class Relationships : IRelationshipBrowser
    {
        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            throw new NotImplementedException();
        }
    }
    public class Research
    {
        public Research(IRelationshipBrowser browser)
        {
            foreach (var p in browser.FindAllChildrenOf("John"))
                Console.WriteLine($"John has child {p.Name}");
        } 
    }

    class Program
    {
        static void Main(string[] args)
        {
            var relationships = new Relationships();
            var research = new Research(relationships);
        }
    }
}
