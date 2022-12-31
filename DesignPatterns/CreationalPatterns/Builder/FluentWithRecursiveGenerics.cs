namespace DesignPatterns.CreationalPatterns.Builder
{
    public class Person
    {
        public string Name;

        public string Position;

        public DateTime DateOfBirth;

        public int Salary { get; set; }




        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position},{nameof(Salary)}: {Salary}, {nameof(DateOfBirth)}: {DateOfBirth}";
        }
    }
    public class PersonBuilderDirector : PersonBirthDateBuilder<PersonBuilderDirector>
    {
        public static PersonBuilderDirector NewPerson => new PersonBuilderDirector();
    }
    //to make a new version
    public class PersonBuilderDirectorWithSalary : PersonSalaryBuilder<PersonBuilderDirectorWithSalary>
    {
        public static PersonBuilderDirectorWithSalary NewPerson => new PersonBuilderDirectorWithSalary();
    }

    public abstract class PersonBuilder
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }

    public class PersonInfoBuilder<SELF> : PersonBuilder
      where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }

    public class PersonJobBuilder<SELF>
      : PersonInfoBuilder<PersonJobBuilder<SELF>>
      where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAsA(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }

    // here's another inheritance level
    // note there's no PersonInfoBuilder<PersonJobBuilder<PersonBirthDateBuilder<SELF>>>!

    public class PersonBirthDateBuilder<SELF>
      : PersonJobBuilder<PersonBirthDateBuilder<SELF>>
      where SELF : PersonBirthDateBuilder<SELF>
    {
        public SELF Born(DateTime dateOfBirth)
        {
            person.DateOfBirth = dateOfBirth;
            return (SELF)this;
        }
    }
    public class PersonSalaryBuilder<SELF>
      : PersonBirthDateBuilder<PersonSalaryBuilder<SELF>>
      where SELF : PersonSalaryBuilder<SELF>
    {
        public SELF WithSalary(int salary)
        {
            person.Salary = salary;
            return (SELF)this;
        }
    }
}
