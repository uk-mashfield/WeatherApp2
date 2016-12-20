namespace BaseUnitTests.Generic
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///     A base unit test context of type T.
    /// </summary>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ///
    /// <seealso cref="T:BaseUnitTests.BaseUnitTestContext"/>
    [ExcludeFromCodeCoverage]
    public abstract class BaseUnitTestContext<T> : BaseUnitTestContext
    {
        /// <summary>
        ///     The sut.
        /// </summary>
        protected T SUT;
    }
}