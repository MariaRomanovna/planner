using Microsoft.VisualStudio.TestTools.UnitTesting;
using planner;

using System;

namespace AutorizeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodforAuthorize_true()
        {
            var login = "Guzel";
            var pass = "11111";
            var result = true;
            var required = true;
            if (login.Length < 5) 
                result = false;
            if (pass.Length < 5)
                result = false;
            Assert.AreEqual(required, result);
        }

        [TestMethod]
        public void TestMethodforAuthorize_false()
        {
            var login = "Guzel";
            var pass = "1111";
            var result = true;
            var required = false;
            if (login.Length < 5)
                result = false;
            if (pass.Length < 5)
                result = false;
            Assert.AreEqual(required, result);
        }

        [TestMethod]
        public void TestMethodforRegistration_true()
        {
            var login = "Guzel";
            var pass = "11111";
            var pass1 = "11111";
            var result = true;
            var required = true;
            if (login.Length < 5)
                result = false;
            if (pass.Length < 5)
                result = false;
            if (pass != pass1)
                result = false;
            Assert.AreEqual(required, result);
        }

        [TestMethod]
        public void TestMethodforRegistration_false()
        {
            var login = "Guzel";
            var pass = "11111";
            var pass1 = "1111";
            var result = true;
            var required = false;
            if (login.Length < 5)
                result = false;
            if (pass.Length < 5)
                result = false;
            if (pass != pass1)
                result = false;
            Assert.AreEqual(required, result);
        }
    }
}
