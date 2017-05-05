using NullGuard;

namespace RopDemo
{
    /// <summary>
    /// Idea from http://enterprisecraftsmanship.com/2015/03/13/functional-c-non-nullable-reference-types/
    /// 
    /// Requires NuGet package NullGuard.Fody
    /// 
    /// - Add the following to AssemblyInfo.cs:
    ///     [assembly: NullGuard(ValidationFlags.All)]
    /// 
    /// - Understand the difference between struct and class:
    ///     http://stackoverflow.com/a/13275
    /// 
    /// Naming: In F# this Monad is called 'Option'. 'Option' and 'Maybe' are synonyms!
    /// 
    /// </summary>
    public struct Maybe<T>
    {
        public T Value { get; }

        public bool HasValue => Value != null;

        public bool HasNoValue => !HasValue;

        private Maybe([AllowNull] T value)
        {
            Value = value;
        }

        public static implicit operator Maybe<T>([AllowNull] T value)
        {
            return new Maybe<T>(value);
        }
    }
}