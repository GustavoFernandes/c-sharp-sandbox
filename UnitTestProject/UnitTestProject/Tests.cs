using Microsoft.VisualStudio.TestTools.UnitTesting;

using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTestProject
{
    [TestClass]
    public class Tests
    {
        #region Short Circuit

        private int shortCircuitTestCounter = 0;

        [TestMethod]
        public void ShortCircuit()
        {
            IncrementShortCircuitCounter();
            AreEqual(1, shortCircuitTestCounter);

            if (true && IncrementShortCircuitCounter()) { /* no-op */ }
            AreEqual(2, shortCircuitTestCounter);

            // short-circuits and doesn't increment
            if (false && IncrementShortCircuitCounter()) { /* no-op */ }
            AreEqual(2, shortCircuitTestCounter);

            if (IncrementShortCircuitCounter() && false) { /* no-op */ }
            AreEqual(3, shortCircuitTestCounter);
        }

        private bool IncrementShortCircuitCounter()
        {
            shortCircuitTestCounter++;
            return true;
        }

        #endregion
    }
}
