//

namespace BaseUnitTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using NUnit.Framework;

    /// <summary>
    ///     A base unit test context.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public abstract class BaseUnitTestContext
    {
        /// <summary>
        ///     Gets the get disposable stub class.
        /// </summary>
        ///
        /// <value>
        ///     The get disposable stub class.
        /// </value>
        protected DisposableStubClass GetDisposableStubClass
        {
            get
            {
                return new DisposableStubClass();
            }
        }

        /// <summary>
        ///     A disposable stub class.
        /// </summary>
        ///
        /// <seealso cref="T:System.IDisposable"/>
        protected class DisposableStubClass : IDisposable
        {
            /// <summary>
            ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            ///
            /// <seealso cref="M:System.IDisposable.Dispose()"/>
            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        ///     Sets up the test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            SetContext();
            Because();
        }

        /// <summary>
        ///     Tear down this test instance.
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            Cleanup();
        }

        /// <summary>
        ///     Determine the 'because' clause.
        /// </summary>
        protected virtual void Because()
        {
        }

        /// <summary>
        ///     Cleanup this test instance.
        /// </summary>
        protected virtual void Cleanup()
        {
        }

        /// <summary>
        ///     Sets the test context.
        /// </summary>
        protected virtual void SetContext()
        {
        }
    }
}