using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleInfo;

namespace TriangleInfoTests
{
    [TestClass]
    public class TriangleInfoFormIntegrationTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }

    public class TriangleInfoFormForTest : TriangleInfoForm
    {
        public string MsgInstruction { get { return INSTRUCTIONS; } }
        public string MsgInvalidInput { get { return ERR_INVALID_INPUT; } }
        public string MsgInvalidTriangle { get { return ERR_INVALID_TRIANGLE; } }
        public string MsgInstruction { get { return INSTRUCTIONS; } }
    }
}
