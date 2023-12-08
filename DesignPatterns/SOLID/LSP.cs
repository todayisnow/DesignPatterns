//3.Liskov Substitution Principle(LSP):

//    Summary: Objects of a superclass should be replaceable with objects of a subclass without affecting the correctness of the program.
//    Real-life Example: If you have a class representing shapes, any subclass (like Circle or Square) should be interchangeable without causing issues in the program's logic.
namespace DesignPatterns.SOLID
{
    // using a classic example
    public class Rectangle
    {
        //public int Width { get; set; }
        //public int Height { get; set; }

        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle()
        {

        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        public Square()
        {

        }
        public Square(int width) : base(width, width)
        {

        }
        //public new int Width// nasty side effects
        //{
        //  set { base.Width = base.Height = value; }
        //}

        //public new int Height
        //{ 
        //  set { base.Width = base.Height = value; }
        //}

        public override int Width
        {
            set { base.Width = base.Height = value; }
        }

        public override int Height
        {
            set { base.Width = base.Height = value; }
        }
    }
}
