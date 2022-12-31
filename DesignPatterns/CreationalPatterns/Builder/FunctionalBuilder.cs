namespace DesignPatterns.CreationalPatterns.Builder
{
    public abstract class FunctionalBuilder<TSubject, TSelf>
       where TSelf : FunctionalBuilder<TSubject, TSelf>
       where TSubject : new()
    {
        private readonly List<Func<TSubject, TSubject>> actions = new List<Func<TSubject, TSubject>>();
        public TSelf Do(Action<TSubject> action)
        {
            actions.Add(p => { action(p); return p; });
            return (TSelf)this;
        }
        public TSubject Build()
            => actions.Aggregate(new TSubject(), (p, f) => f(p));

    }
    public class Man
    {
        public string Name, Position;
        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    public sealed class ManBuilder
        : FunctionalBuilder<Man, ManBuilder>
    {
        public ManBuilder Called(string name)
            => Do(p => p.Name = name);

    }

    public static class ManBuilderExtensions
    {
        public static ManBuilder WorksAsA
          (this ManBuilder builder, string position)
            => builder.Do(p => p.Position = position);

    }



}
