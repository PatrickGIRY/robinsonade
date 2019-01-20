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
    }

    internal class NotFound : Result
    {
        private readonly String invalidItemCode;

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
    }

}
