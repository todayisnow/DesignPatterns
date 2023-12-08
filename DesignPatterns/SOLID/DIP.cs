//5.Dependency Inversion Principle(DIP):

//    Summary: High - level modules should not depend on low-level modules. Both should depend on abstractions. Abstractions should not depend on details; details should depend on abstractions.
//    Real-life Example: Instead of a high-level module depending on the details of a database implementation, it should depend on an abstraction (interface), allowing flexibility in using different database implementations.

//These principles collectively form the SOLID principles, guiding developers to create maintainable, scalable, and flexible software systems.
using static System.Console;
namespace DesignPatterns.SOLID
{
    // hl modules should not depend on low-level; both should depend on abstractions
    // abstractions should not depend on details; details should depend on abstractions

    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Human
    {
        public string Name;
        // public DateTime DateOfBirth;

    }

    public interface IRelationshipBrowser
    {
        IEnumerable<Human> FindAllChildrenOf(string name);
    }

    public class Relationships : IRelationshipBrowser // low-level
    {
        private List<(Human, Relationship, Human)> relations
          = new List<(Human, Relationship, Human)>();

        public void AddParentAndChild(Human parent, Human child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        //public List<(Person, Relationship, Person)> Relations => relations;

        public IEnumerable<Human> FindAllChildrenOf(string name)
        {
            return relations
              .Where(x => x.Item1.Name == name
                          && x.Item2 == Relationship.Parent).Select(r => r.Item3);
        }
    }

    public class Research
    {
        //public Research(Relationships relationships)
        //{
        //    //high - level: find all of john's children
        //    var relations = relationships.Relations;
        //    foreach (var r in relations
        //      .Where(x => x.Item1.Name == "John"
        //                  && x.Item2 == Relationship.Parent))
        //    {
        //        WriteLine($"John has a child called {r.Item3.Name}");
        //    }
        //}

        public Research(IRelationshipBrowser browser, string ParentName)
        {
            foreach (var p in browser.FindAllChildrenOf(ParentName))
            {
                WriteLine($"{ParentName} has a child called {p.Name}");
            }
        }

    }
}
