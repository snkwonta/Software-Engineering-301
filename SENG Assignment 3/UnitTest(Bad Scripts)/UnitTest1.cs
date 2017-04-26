//Created by Sodienye Nkwonta and Aidan Kelly

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Frontend2.Hardware;
using System.Collections.Generic;
using Frontend2;

namespace UnitTest_Bad_Scripts_
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void TestScript1()
        {
            Assert.Fail("BOOM");

            //configs vm

            List<string> canNames = new List<string>();
            canNames.Add("Coke");
            canNames.Add("Water");
            canNames.Add("stuff");
            List<int> canCosts = new List<int>();
            canCosts.Add(250);
            canCosts.Add(250);
            canCosts.Add(205);

            

            //creates the vending machine
            List<int> list1 = new List<int>();
            list1.Add(5);
            list1.Add(10);
            list1.Add(25);
            list1.Add(100);
            int[] array1 = list1.ToArray();
            VendingMachine vend = new VendingMachine(array1, 3, 10, 10, 10);
            VendingMachineLogic logic = new VendingMachineLogic(vend);

            //loads coins
            List<int> coinsToLoad = new List<int>();
            coinsToLoad.Add(1);
            coinsToLoad.Add(1);
            coinsToLoad.Add(2);
            coinsToLoad.Add(0);
            int[] coinsToLoadArray;
            coinsToLoadArray = coinsToLoad.ToArray();
            vend.LoadCoins(coinsToLoadArray);

            //loads pops
            List<int> popsToLoad = new List<int>();
            popsToLoad.Add(1);
            popsToLoad.Add(1);
            popsToLoad.Add(1);
            int[] popsToLoadArray;
            popsToLoadArray = popsToLoad.ToArray();
            vend.LoadPopCans(popsToLoadArray);

            IDeliverable[] removing = vend.DeliveryChute.RemoveItems();
            bool check = false;
            if (removing.Length == 0)
            {
                check = true;
            }
            Assert.AreEqual(check, true);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void BadTestScript2()
        {
            //creates the vending machine
            List<int> list1 = new List<int>();
            list1.Add(5);
            list1.Add(10);
            list1.Add(25);
            list1.Add(100);
            int[] array1 = list1.ToArray();
            VendingMachine vend = new VendingMachine(array1, 3, 10, 10, 10);
            VendingMachineLogic logic = new VendingMachineLogic(vend);

            //configs vm
            List<string> canNames = new List<string>();
            canNames.Add("Coke");
            canNames.Add("Water");
            canNames.Add("stuff");
            List<int> canCosts = new List<int>();
            canCosts.Add(250);
            canCosts.Add(250);
            canCosts.Add(0);
            vend.Configure(canNames, canCosts);

            //loads coins
            List<int> coinsToLoad = new List<int>();
            coinsToLoad.Add(1);
            coinsToLoad.Add(1);
            coinsToLoad.Add(2);
            coinsToLoad.Add(0);
            int[] coinsToLoadArray;
            coinsToLoadArray = coinsToLoad.ToArray();
            vend.LoadCoins(coinsToLoadArray);

            //loads pops
            List<int> popsToLoad = new List<int>();
            popsToLoad.Add(1);
            popsToLoad.Add(1);
            popsToLoad.Add(1);
            int[] popsToLoadArray;
            popsToLoadArray = popsToLoad.ToArray();
            vend.LoadPopCans(popsToLoadArray);

            IDeliverable[] removing = vend.DeliveryChute.RemoveItems();
            bool check = false;
            if (removing.Length == 0)
            {
                check = true;
            }
            Assert.AreEqual(check, true);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void BadTestScript3()
        {
            //creates the vending machine
            List<int> list1 = new List<int>();
            list1.Add(5);
            list1.Add(10);
            list1.Add(25);
            list1.Add(100);
            int[] array1 = list1.ToArray();
            VendingMachine vend = new VendingMachine(array1, 3, 10, 10, 10);
            VendingMachineLogic logic = new VendingMachineLogic(vend);

            //configs vm
            List<string> canNames = new List<string>();
            canNames.Add("Coke");
            canNames.Add("Water");
            List<int> canCosts = new List<int>();
            canCosts.Add(250);
            canCosts.Add(250);
            vend.Configure(canNames, canCosts);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void BadTestScript4()
        {
            List<int> list1 = new List<int>();
            list1.Add(1);
            list1.Add(1);
            int[] array1 = list1.ToArray();
            VendingMachine vend = new VendingMachine(array1, 1, 10, 10, 10);
            VendingMachineLogic logic = new VendingMachineLogic(vend);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void BadTestScript5()
        {
            List<int> list1 = new List<int>();
            list1.Add(0);
            int[] array1 = list1.ToArray();
            VendingMachine vend = new VendingMachine(array1, 1, 10, 10, 10);
            VendingMachineLogic logic = new VendingMachineLogic(vend);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void BadTestScript6()
        {
            List<int> list1 = new List<int>();
            list1.Add(5);
            list1.Add(10);
            list1.Add(25);
            list1.Add(100);
            int[] array1 = list1.ToArray();
            VendingMachine vend = new VendingMachine(array1, 3, 10, 10, 10);
            VendingMachineLogic logic = new VendingMachineLogic(vend);
            vend.SelectionButtons[3].Press();

        }

        [TestMethod]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void BadTestScript7()
        {
            List<int> list1 = new List<int>();
            list1.Add(5);
            list1.Add(10);
            list1.Add(25);
            list1.Add(100);
            int[] array1 = list1.ToArray();
            VendingMachine vend = new VendingMachine(array1, 3, 10, 10, 10);
            VendingMachineLogic logic = new VendingMachineLogic(vend);
            vend.SelectionButtons[-1].Press();
        }

        [TestMethod]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void BadTestScript8()
        {
            List<int> list1 = new List<int>();
            list1.Add(5);
            list1.Add(10);
            list1.Add(25);
            list1.Add(100);
            int[] array1 = list1.ToArray();
            VendingMachine vend = new VendingMachine(array1, 3, 10, 10, 10);
            VendingMachineLogic logic = new VendingMachineLogic(vend);
            vend.SelectionButtons[4].Press();
        }
    }
}
