using System;
using WpfApp2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GanProjectTest
{
    
    [TestClass]
    public class UnitTest1
    {
        InsertWpf IWF = new InsertWpf();
        OperationsWithWork oww = new OperationsWithWork();
        [TestMethod]
        public void CreateIntMassForStringTest()
        {
            int[] result = new int[] { 1, 2, 3, 4, 5, 6 };
            string forresult = "1 2 3 4 5 6";
            CollectionAssert.AreEqual(result,IWF.insertlow(forresult));
        }
        [TestMethod]
        public void CreateIntMassForStringValueTest()
        {
            string forresult = "1 2 3 4 5 6";
            CollectionAssert.AllItemsAreUnique(IWF.insertlow(forresult));
        }
        [TestMethod]
        public void CreateIntMasssecondlvlForStringValueTest()
        {
            int[,] result = new int[,] {{ 1, 2, 3, 4 }, { 1,2,3,4} };
            string forresult = "1 2 3 4 1 2 3 4";
            CollectionAssert.AreEqual(result, IWF.insert(forresult,2,4));
        }
        [TestMethod]
        public void CreateIntMassSecondLvlForStringValueTest()
        {
            string forresult = "1 2 3 4 51 42 13 24";
            CollectionAssert.AllItemsAreUnique(IWF.insert(forresult,2,4));
        }
        [TestMethod]
        public void TestTransporMatrix()
        {
            int[,] result = new int[,] { { 1, 2, 3, 4 }, { 1, 2, 3, 4 } };
            int[,] send = new int[,] { { 1, 1 }, { 2, 2 }, { 3, 3 }, { 4, 4 } };
            CollectionAssert.AreEqual(result,oww.ArrayTrans(send));
        }
        [TestMethod]
        public void TestScalarMatrix()
        {
            int[,] send = new int[,] { { 1, 2, 3, 4 }, { 1, 2, 3, 4 } };
            int[,] result = new int[,] { { 5, 10, 15, 20 }, { 5, 10, 15, 20 } };
            int sendscal=5;
            CollectionAssert.AreEqual(result, oww.matrixxscalar(send, sendscal));
        }
        [TestMethod]
        public void TestMoveStroks()
        {
            int[,] send = new int[,] { { 1, 2, 3, 4 }, { 2, 3, 4, 5 }, {3,4,5,6},{4,5,6,7} };
            int[,] result = new int[,] { { 3, 4, 5, 6 }, { 2, 3, 4, 5 }, { 1, 2, 3, 4 }, { 4, 5, 6, 7 } };
            int sendscal = 1,sendsec = 3;
            CollectionAssert.AreEqual(result, oww.movestroks(send, sendscal,sendsec));
        }
        [TestMethod]
        public void TestMathOpcase1()
        {
            int[,] send = new int[,] { { 1, 2, 3, 4 }, { 2, 3, 4, 5 }, { 3, 4, 5, 6 }, { 4, 5, 6, 7 } };
            int[,] second = new int[,] { { 3, 4, 5, 6 }, { 2, 3, 4, 5 }, { 1, 2, 3, 4 }, { 4, 5, 6, 7 } };
            int[,] result = new int[,] { { 4, 6, 8, 10 }, { 4, 6, 8, 10 }, { 4, 6, 8, 10 }, { 8, 10, 12, 14 } };
            CollectionAssert.AreEqual(result, oww.MatOp(send, second, 1));
        }
        [TestMethod]
        public void TestMathOpcase2()
        {
            int[,] send = new int[,] { { 1, 2, 3, 4 }, { 2, 3, 4, 5 }, { 3, 4, 5, 6 }, { 4, 5, 6, 7 } };
            int[,] second = new int[,] { { 3, 4, 5, 6 }, { 2, 3, 4, 5 }, { 1, 2, 3, 4 }, { 4, 5, 6, 7 } };
            int[,] result = new int[,] { { -2, -2, -2, -2 }, { 0, 0, 0,0 }, { 2, 2, 2, 2 }, { 0, 0, 0, 0 } };
            CollectionAssert.AreEqual(result, oww.MatOp(send, second, 2));
        }
        [TestMethod]
        public void TestMathOpOnTransMat()
        {
            int[,] send = new int[,] { { 1, 2, 3, 4 }, { 1, 2, 3, 4 } };
            int[,] result = new int[,] { { 30, 30 }, { 30, 30 }};
            CollectionAssert.AreEqual(result, oww.MatrixUmScalar(send));
        }
    }
}
