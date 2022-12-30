using ConsoleApp2.SOILD;
using static System.Console;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region SOILD

            #region Single Responsibility Principle
            //Single Responsibility Principle
            //A class should have only one reason to change.
            //A class should have only one job.
            var j = new Journal();
            j.AddEntry("I cried today.");
            j.AddEntry("I ate a bug.");
            WriteLine(j);
            var p = new Persistence();
            var filename = @"c:\temp\journal.txt";
            p.SaveToFile(j, filename, true);


            #endregion

            #region Open Closed Principle
            //Open Closed Principle
            //Software entities should be open for extension, but closed for modification.
            //A class should be open for extension but closed for modification.

            #endregion

            #region Liskov Substitution Principle
            //Liskov Substitution Principle
            //Objects in a program should be replaceable with instances of their subtypes without altering the correctness of that program.
            //Derived classes must be substitutable for their base classes.

            #endregion

            #region Interface Segregation Principle
            //Interface Segregation Principle
            //Many client-specific interfaces are better than one general-purpose interface.

            #endregion

            #region Dependency Inversion Principle
            //Dependency Inversion Principle
            //Depend upon abstractions. Do not depend upon concrete classes.

            #endregion

            #endregion

            #region Design Patterns

            #region Structural Design Patterns

            #region Builder Pattern
            //Builder Pattern
            //Separate the construction of a complex object from its representation so that the same construction process can create different representations.

            #endregion

            #endregion

            #region Creational Design Patterns

            #endregion

            #region Behavioral Design Patterns
            #endregion

            #endregion



        }
    }
}