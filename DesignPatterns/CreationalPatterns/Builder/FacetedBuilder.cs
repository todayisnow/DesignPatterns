namespace DesignPatterns.CreationalPatterns.Builder
{
    public class Woman
    {
        // address
        public string StreetAddress, Postcode, City;

        // employment
        public string CompanyName, Position;

        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    public class WomanBuilder // facade 
    {
        // the object we're going to build
        protected Woman Woman = new Woman(); // this is a reference!

        public WomanAddressBuilder Lives => new WomanAddressBuilder(Woman);
        public WomanJobBuilder Works => new WomanJobBuilder(Woman);

        public static implicit operator Woman(WomanBuilder pb)
        {
            return pb.Woman;
        }
    }



    public class WomanJobBuilder : WomanBuilder
    {
        public WomanJobBuilder(Woman Woman)
        {
            this.Woman = Woman;
        }

        public WomanJobBuilder At(string companyName)
        {
            Woman.CompanyName = companyName;
            return this;
        }

        public WomanJobBuilder AsA(string position)
        {
            Woman.Position = position;
            return this;
        }

        public WomanJobBuilder Earning(int annualIncome)
        {
            Woman.AnnualIncome = annualIncome;
            return this;
        }
    }

    public class WomanAddressBuilder : WomanBuilder
    {
        // might not work with a value type!
        public WomanAddressBuilder(Woman Woman)
        {
            this.Woman = Woman;
        }

        public WomanAddressBuilder At(string streetAddress)
        {
            Woman.StreetAddress = streetAddress;
            return this;
        }

        public WomanAddressBuilder WithPostcode(string postcode)
        {
            Woman.Postcode = postcode;
            return this;
        }

        public WomanAddressBuilder In(string city)
        {
            Woman.City = city;
            return this;
        }

    }


}