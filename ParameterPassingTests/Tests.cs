using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParameterPassingTests
{
    [TestClass]
    public class Tests
    {
        // http://www.leerichardson.com/2007/01/parameter-passing-in-c.html

        [TestMethod]
        public void Value_Types()
        {
            int i = 5;
            int j = i;

            j = 10;

            Console.WriteLine(i); // 5
        }

        [TestMethod]
        public void Reference_Types()
        {
            StringBuilder sb1 = new StringBuilder("hello");
            StringBuilder sb2 = sb1;

            sb2.Append(" world");

            Console.WriteLine(sb1.ToString()); // hello world
        }

        [TestMethod]
        public void Immutable_Reference_Types()
        {
            string s1 = "hello";
            string s2 = s1;

            s2 = s2 + " world";

            Console.WriteLine(s1); // hello
        }

        [TestMethod]
        public void Value_Types_Passed_By_Value()
        {
            int i = 5;
            Change1(i);
            Console.WriteLine(i); // 5
        }

        private void Change1(int j)
        {
            j = 10;
        }

        [TestMethod]
        public void Reference_Types_Passed_By_Value()
        {
            StringBuilder sb1 = new StringBuilder("hello");
            Change2(sb1);
            Console.WriteLine(sb1.ToString()); // hello world
        }

        private void Change2(StringBuilder sb2)
        {
            sb2.Append(" world");
            sb2 = null;
        }

        [TestMethod]
        public void Value_Types_Passed_By_Reference()
        {
            int i = 5;

            Change3(ref i);
            Console.WriteLine(i); // 10
        }

        private void Change3(ref int j)
        {
            j = 10;
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Reference_Types_Passed_By_Reference()
        {
            StringBuilder sb1 = new StringBuilder("hello");
            Change4(ref sb1);
            Console.WriteLine(sb1.ToString()); // NullReferenceException
        }

        private void Change4(ref StringBuilder sb2)
        {
            sb2.Append(" world");
            sb2 = null;
        }

    }
}
