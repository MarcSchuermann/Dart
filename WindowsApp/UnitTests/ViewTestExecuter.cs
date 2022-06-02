using System;
using System.Threading;
using FluentAssertions;

namespace UnitTests
{
    internal class ViewTestExecuter
    {
        #region Private Fields

        private static ViewTestExecuter instance;

        private Semaphore semaphore;

        #endregion Private Fields

        #region Public Constructors

        public ViewTestExecuter()
        {
            semaphore = new Semaphore(initialCount: 1, maximumCount: 1);
        }

        #endregion Public Constructors

        #region Public Properties

        public static ViewTestExecuter Instance
        {
            get
            {
                if (instance == null)
                    instance = new ViewTestExecuter();
                return instance;
            }
        }

        #endregion Public Properties

        #region Public Methods

        public void Run(Action test)
        {
            semaphore.WaitOne();

            try
            {
                Execute(test);
            }
            finally
            {
                semaphore.Release();
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void Execute(Action test)
        {
            var success = false;
            var myThread = new Thread(() =>
            {
                try
                {
                    test();
                    success = true;
                }
                catch (Exception)
                {
                    success = false;
                }
            });

            myThread.SetApartmentState(ApartmentState.STA);
            myThread.Start();
            myThread.Join();

            success.Should().BeTrue();
        }

        #endregion Private Methods
    }
}