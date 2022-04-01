using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordFrequency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFrequency.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        private TestContext testContext;

        public TestContext TestContext
        {
            get { return testContext; }
            set { testContext = value; }
        }
       
        [TestMethod()]
        [TestCategory("Sample")]
        
        public void AddTest()
        {
            
            
            System.Diagnostics.Debug.WriteLine("Debug :This is sample log");
           // Assert.Fail();
        }

        [TestMethod()]
        public void SubstractTest()
        {
            TestContext.WriteLine("TextContext: Message");
           // Assert.Fail();
        }
    }
}