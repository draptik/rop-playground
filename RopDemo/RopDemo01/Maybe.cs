using System;

namespace RopDemo01
{
    public class Maybe<T> where T : class
    {
        private readonly T _value;

        public Maybe(T someValue)
        {
            _value = someValue ?? throw new ArgumentNullException(nameof(someValue));
        }

        private Maybe()
        {
        }

        public Maybe<TO> Bind<TO>(Func<T, Maybe<TO>> func) where TO : class
        {
            return _value != null ? func(_value) : Maybe<TO>.None();
        }

        public static Maybe<T> None()
        {
            return new Maybe<T>();
        }
    }
}