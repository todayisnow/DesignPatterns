using ConsoleApp2.SOLID;
using DesignPatterns.CreationalPatterns.Builder;
using DesignPatterns.SOLID;
using System.Text;
using static System.Console;

namespace ConsoleApp2
{
    internal class Program
    {
        static public int Area(Rectangle r) => r.Width * r.Height;

        static void Main(string[] args)
        {
            WriteLine("1- For Soild");
            WriteLine("2- For Creartional Pattern - BUILDER");
            WriteLine("3- For Creartional Pattern - Factory");
            var t = 3;// int.Parse( ReadLine());


            #region SOLID
            if (t == 1)
            {
                #region Single Responsibility Principle
                //Single Responsibility Principle
                //A class should have only one reason to change.
                //A class should have only one job.
                WriteLine("Single Responsibility Principle");
                var j = new Journal();
                j.AddEntry("I cried today.");
                j.AddEntry("I ate a bug.");
                WriteLine(j);
                var pe = new Persistence();
                var filename = @"c:\temp\journal.txt";
                pe.SaveToFile(j, filename, true);

                WriteLine("================");
                #endregion

                #region Open Closed Principle
                //Open Closed Principle
                //Software entities should be open for extension, but closed for modification.
                //
                WriteLine("Open Closed Principle");
                var apple = new Product("Apple", Color.Green, Size.Small);
                var tree = new Product("Tree", Color.Green, Size.Large);
                var house = new Product("House", Color.Blue, Size.Large);

                Product[] products = { apple, tree, house };

                var pf = new ProductFilter();
                WriteLine("Green products (old):");
                foreach (var p in pf.FilterByColor(products, Color.Green))
                    WriteLine($" - {p.Name} is green");

                // ^^ BEFORE

                // vv AFTER
                var bf = new BetterFilter();
                WriteLine("Green products (new):");
                foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
                    WriteLine($" - {p.Name} is green");

                WriteLine("Large products");
                foreach (var p in bf.Filter(products, new SizeSpecification(Size.Large)))
                    WriteLine($" - {p.Name} is large");

                WriteLine("Large blue items");
                foreach (var p in bf.Filter(products,
                  new AndSpecification<Product>(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Large)))
                )
                {
                    WriteLine($" - {p.Name} is big and blue");
                }
                WriteLine("House that is Large blue items");
                foreach (var p in bf.Filter(products,
                  new AndSpecification<Product>(
                      new AndSpecification<Product>(
                          new ColorSpecification(Color.Blue),
                          new SizeSpecification(Size.Large)),
                      new NameSpecification("House")))

                )
                {
                    WriteLine($" - {p.Name} is big and blue and a house");
                }
                WriteLine("================");
                #endregion

                #region Liskov Substitution Principle
                //Liskov Substitution Principle
                //Objects in a program should be replaceable with instances of their subtypes without altering the correctness of that program.
                //Derived classes must be substitutable for their base classes.
                WriteLine("Liskov Substitution Principle");

                Rectangle rc = new Rectangle(2, 3);
                WriteLine($"{rc} has area {Area(rc)}");

                // should be able to substitute a base type for a subtype
                /*Square*/
                Rectangle sq = new Square(4);
                //sq.Width = 4;
                WriteLine($"{sq} has area {Area(sq)}");

                WriteLine("================");

                #endregion

                #region Interface Segregation Principle
                //Interface Segregation Principle
                //Many client-specific interfaces are better than one general-purpose interface.
                WriteLine("Interface Segregation Principle");
                var s = new MultiFunctionMachine(new Printer(), new Scanner());

                s.Print(new Document());
                s.Scan(new Document());



                WriteLine("================");
                #endregion

                #region Dependency Inversion Principle
                //Dependency Inversion Principle
                //Depend upon abstractions. Do not depend upon concrete classes. so we can easly change low level code without effecting high end
                //high-level modules should not depend on low-level; both should depend on abstractions
                WriteLine("Dependency Inversion Principle");


                var parent = new Human { Name = "John" };
                var child1 = new Human { Name = "Chris" };
                var child2 = new Human { Name = "Matt" };

                // low-level module
                var relationships = new Relationships();
                relationships.AddParentAndChild(parent, child1);
                relationships.AddParentAndChild(parent, child2);

                new Research(relationships, "John");

                #endregion
                WriteLine();
                WriteLine("**********************************");
                WriteLine();
            }
            #endregion


            #region Design Patterns

            #region Structural Design Patterns
            //  explain how to assemble objects and classes into larger structures, while keeping these structures flexible and efficient.

            #region Builder Pattern
            //Builder Pattern
            //Separate the construction of a complex object from its representation so that the same construction process can create different representations.

            #endregion

            #endregion

            #region Creational Design Patterns
            // Creational design patterns provide various object creation mechanisms, which increase flexibility and reuse of existing code.
            if (t == 2)
            {
                #region Builder Design Pattern
                // Lets you construct complex objects step by step. The pattern allows you to produce different types and representations of an object using the same construction code.
                // if you want to build a simple HTML paragraph using StringBuilder
                WriteLine("Fluent Builder");
                //var hello = "hello";
                var sb = new StringBuilder();
                //sb.Append("<p>");
                //sb.Append(hello);
                //sb.Append("</p>");
                //WriteLine(sb);

                //// now I want an HTML list with 2 words in it
                //var words = new[] { "hello", "world" };
                //sb.Clear();
                //sb.Append("<ul>");
                //foreach (var word in words)
                //{
                //    sb.AppendFormat("<li>{0}</li>", word);
                //}
                //sb.Append("</ul>");
                //WriteLine(sb);

                // ordinary non-fluent builder
                var builder = new HtmlBuilder("ul");
                builder.AddChild("li", "hello");
                builder.AddChild("li", "world");
                WriteLine(builder.ToString());

                // fluent builder
                sb.Clear();
                builder.Clear(); // disengage builder from the object it's building, then...
                builder.AddChildFluent("li", "hello").AddChildFluent("li", "world");
                WriteLine(builder);
                WriteLine("================");
                WriteLine("Fluent Builder With Recursive Generics");

                var me = PersonBuilderDirectorWithSalary.NewPerson
                           .Called("Dmitri")
                           .WorksAsA("Quant")
                           .Born(DateTime.UtcNow)
                           .WithSalary(100)
                           .Build();
                Console.WriteLine(me);
                WriteLine("================");
                WriteLine("Stepwise Builder");
                var car = CarBuilder.Create()
                   .OfType(CarType.Crossover)
                   .WithWheels(18)
                   .Build();
                Console.WriteLine(car);
                WriteLine("================");


                WriteLine("Functional Builder");
                var pb1 = new ManBuilder();
                var Man = pb1.Called("Dmitri").WorksAsA("Programmer").Build();
                WriteLine(Man);
                WriteLine("================");
                WriteLine("Faceted Builder");
                var pb = new WomanBuilder();
                Woman Woman = pb
                  .Lives
                    .At("123 London Road")
                    .In("London")
                    .WithPostcode("SW12BC")
                  .Works
                    .At("Fabrikam")
                    .AsA("Engineer")
                    .Earning(123000);

                WriteLine(Woman);
                WriteLine("================");
                var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
                Console.WriteLine(cb);
                #endregion
            }
            if (t == 3)
            {
                #region Factory Design Pattern

                #endregion
            }

            #endregion

            #region Behavioral Design Patterns
            // take care of effective communication and the assignment of responsibilities between objects.
            #endregion

            #endregion



        }
    }
}