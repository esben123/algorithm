using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm;

namespace Tester
{
    [TestClass]
    public class UnitTestLists
    {
        //Test linked list add
        [TestMethod]
        public void TestLinkedList()
        {
            //Arrange
            SmarterLinkedList<int> test1 = new SmarterLinkedList<int>();
            //Act
            test1.Add(1);
            test1.Add(2);
            test1.Add(3);
            test1.Add(4);
            test1.Add(5);

            //Assert
            Assert.IsTrue(test1.Count == 5);
           
            
        }

        //Test empty linked list
        [TestMethod]
        public void TestLinkedListEmpty()
        {
            //Arrange
            SmarterLinkedList<int> test2 = new SmarterLinkedList<int>();
            //Act

            //Assert
            Assert.IsTrue(test2.Count == 0);
        }
        //Test linked list Remove first method
        [TestMethod]
        public void TestLinkedListRemoveFirst()
        {
            //Arrange
            SmarterLinkedList<int> test3 = new SmarterLinkedList<int>();

            //Act
            test3.Add(1);
            test3.Add(2);
         
            test3.RemoveFirst();
            //Assert

            Assert.IsTrue(test3.Count == 1);
        }

        //Test linked list Remove last method
        [TestMethod]
        public void TestLinkedListRemoveLast()
        {
            //Arrange
            SmarterLinkedList<int> test4 = new SmarterLinkedList<int>();

            //Act
            test4.Add(1);
            test4.Add(2);

            test4.RemoveLast();
            //Assert

            Assert.IsTrue(test4.Count == 1);
        }

        //Test linked list Remove method
        [TestMethod]
        public void TestLinkedListRemove()
        {
            //Arrange
            SmarterLinkedList<int> test5 = new SmarterLinkedList<int>();

            //Act
            test5.Add(1);
            test5.Add(2);

            test5.Remove(1);
            //Assert

            Assert.IsTrue(test5.Count == 1);
        }

        //Test linked list Remove followed by use of add method
        [TestMethod]
        public void TestLinkedListRemoveAdd()
        {
            //Arrange
            SmarterLinkedList<int> test5 = new SmarterLinkedList<int>();

            //Act
            test5.Add(1);
            test5.Add(2);

            test5.Remove(1);
            test5.Add(3);

            //Assert

            Assert.IsTrue(test5.Count == 2);
            
        }
        //Test linked list negativ
        [TestMethod]
        public void TestLinkedListNegativ()
        {
            //Arrange
            SmarterLinkedList<int> test6 = new SmarterLinkedList<int>();
            //Act
            test6.Add(-1);
            test6.Add(-2);
            test6.Add(-3);
            test6.Add(-4);
            test6.Add(-5);

            //Assert
            Assert.IsTrue(test6.Count == 5);


        }
    }
}
