namespace String.Calculator.Tests
{
    [TestClass]
    public sealed class CalculatorTests
    {
        private CalculatorService _calculator = new CalculatorService();

        [TestMethod]
        public void Test_Empty_String_Returns_Zero()
        {
            var result = _calculator.Add("");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Test_Add_Numbers_Default_Delimeter()
        {
            var result = _calculator.Add("7,2");
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void Test_Add_Numbers_Including_NextLine_Is_Successfull()
        {
            var result = _calculator.Add("1\n2,3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Test_Add_Numbers_Different_Delimeter()
        {
            var result = _calculator.Add("//;\n1;2");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "negatives not allowed: -5; -8")]
        public void Test_Negative_Numbers_ThrowException()
        {
            var result = _calculator.Add("1,-5,-8");
        }
    }
}
