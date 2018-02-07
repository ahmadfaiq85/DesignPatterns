using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple
{
    //Definition: A class should be open for extension but closed for modification

    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, XLarge
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            Name = name;
            Color = color;
            Size = size;
        }
    }

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        private Color color;
        public ColorSpecification(Color color)
        {
            this.color = color;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }
    }

    public class SizeSpecificiation : ISpecification<Product>
    {
        private Size Size;

        public SizeSpecificiation(Size size)
        {
            Size = size;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Size == Size;
        }
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> First, Second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            First = first;
            Second = second;
        }

        public bool IsSatisfied(T t)
        {
            return First.IsSatisfied(t) && Second.IsSatisfied(t);
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var i in items)
                if (spec.IsSatisfied(i))
                    yield return i;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Red, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Medium);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };

            var bf = new BetterFilter();
            Console.WriteLine("Green Products: ");
            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
                Console.WriteLine($" - {p.Name} is green");

            Console.WriteLine("Large Products: ");
            foreach (var p in bf.Filter(products, new SizeSpecificiation(Size.Large)))
                Console.WriteLine($" - {p.Name} is large");

            Console.WriteLine("Large Blue Products: ");
            foreach (var p in bf.Filter(products,
                new AndSpecification<Product>(
                    new ColorSpecification(Color.Blue),
                    new SizeSpecificiation(Size.Large))))
            {
                Console.WriteLine($" - {p.Name} is large and blue");
            }

        }
    }
}