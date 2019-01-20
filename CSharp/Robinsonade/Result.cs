using System;

namespace Robinsonade
{
    public abstract class Result
    {
        public static Result Found(Price price)
        {
            return new Found(price);
        }

        public static Result NotFound(String invalidItemCode)
        {
            return new NotFound(invalidItemCode);
        }

        public abstract Result Map(Func<Price, Price> func);
    }

    internal class Found : Result
    {
        private readonly Price price;

        public Found(Price price)
            : base()
        {
            this.price = price;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            Found found = obj as Found;
            return found.price.Equals(price);
        }

        public override string ToString()
        {
            return "Found{" +
                   "price=" + price +
                   "} " + base.ToString();
        }

        public override int GetHashCode()
        {
            return price.GetHashCode();
        }

        public override Result Map(Func<Price, Price> func)
        {
            return Found(func(price));
        }
    }

    internal class NotFound : Result
    {
        private readonly string invalidItemCode;

        public NotFound(string invalidItemCode)
            : base()
        {
            this.invalidItemCode = invalidItemCode;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            NotFound notFound = obj as NotFound;
            return notFound.invalidItemCode.Equals(invalidItemCode);
        }

        public override string ToString()
        {
            return "NotFound{" +
                   "invalidItemCode='" + invalidItemCode + '\'' +
                   "} " + base.ToString();
        }

        public override int GetHashCode()
        {
            return invalidItemCode.GetHashCode();
        }

        public override Result Map(Func<Price, Price> func)
        {
            return this;
        }
    }

}
