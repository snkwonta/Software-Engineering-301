//Created by Sodienye Nkwonta and Aidan Kelly

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Frontend2.Hardware;
using System.Collections.Generic;
using Frontend2;

namespace UnitTest_Good_Scripts_
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GoodTestScript1()
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
            canCosts.Add(205);
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

            //makes the coins
            Coin coin1 = new Coin(100);
            vend.CoinSlot.AddCoin(coin1);
            Coin coin2 = new Coin(100);
            vend.CoinSlot.AddCoin(coin2);
            Coin coin3 = new Coin(25);
            vend.CoinSlot.AddCoin(coin3);
            Coin coin4 = new Coin(25);
            vend.CoinSlot.AddCoin(coin4);

            //makes a selection
            vend.SelectionButtons[0].Press();

            IDeliverable[] removed = vend.DeliveryChute.RemoveItems();
            PopCan p = new PopCan("Coke");
            Assert.AreEqual(p, removed[0]);

            //check money
            List<Coin> coinList = vend.StorageBin.Unload();
            int moneyCount = 0;
            foreach (Coin c in coinList)
            {
                moneyCount += c.Value;
            }
            Assert.AreEqual(moneyCount, 0);

            //check pops
            int change = 0;
            foreach (CoinRack cr in vend.CoinRacks)
            {
                List<Coin> checkcheck = cr.Unload();
                foreach (Coin c in checkcheck)
                {
                    change += c.Value;
                }
            }
            Assert.AreEqual(change, 315);

            List<PopCan> water = vend.PopCanRacks[1].Unload();
            PopCan waterCan = new PopCan("Water");
            Assert.AreEqual(water[0], waterCan);

            List<PopCan> stuff = vend.PopCanRacks[2].Unload();
            PopCan stuffCan = new PopCan("stuff");
            Assert.AreEqual(stuff[0], stuffCan);


        }

        [TestMethod]
        public void GoodTestScript2()
        {
            //makes vm
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
            canCosts.Add(205);
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

            //adds coins
            Coin coin1 = new Coin(100);
            vend.CoinSlot.AddCoin(coin1);
            Coin coin2 = new Coin(100);
            vend.CoinSlot.AddCoin(coin2);
            Coin coin3 = new Coin(100);
            vend.CoinSlot.AddCoin(coin3);

            //makes selection
            vend.SelectionButtons[0].Press();
            IDeliverable[] removed = vend.DeliveryChute.RemoveItems();
            PopCan p = new PopCan("Coke");
            Assert.AreEqual(p, removed[0]);

            //checks for proper change
            Coin c = (Coin)removed[1];
            Coin c1 = (Coin)removed[2];
            int changeCount = c.Value + c1.Value;
            Assert.AreEqual(changeCount, 50);

            //checks for proper money in storage bin
            List<Coin> coinList = vend.StorageBin.Unload();
            int moneyCount = 0;
            foreach (Coin c7 in coinList)
            {
                moneyCount += c7.Value;
            }
            Assert.AreEqual(moneyCount, 0);

            //check for proper money in coin racks
            int change = 0;
            foreach (CoinRack cr in vend.CoinRacks)
            {
                List<Coin> checkcheck = cr.Unload();
                foreach (Coin c8 in checkcheck)
                {
                    change += c8.Value;
                }
            }
            Assert.AreEqual(change, 315);

            List<PopCan> water = vend.PopCanRacks[1].Unload();
            PopCan waterCan = new PopCan("Water");
            Assert.AreEqual(water[0], waterCan);

            List<PopCan> stuff = vend.PopCanRacks[2].Unload();
            PopCan stuffCan = new PopCan("stuff");
            Assert.AreEqual(stuff[0], stuffCan);

        }


        [TestMethod]
        public void GoodTestScript3()
        {
            //makes vm
            List<int> list1 = new List<int>();
            list1.Add(5);
            list1.Add(10);
            list1.Add(25);
            list1.Add(100);
            int[] array1 = list1.ToArray();
            VendingMachine vend = new VendingMachine(array1, 3, 2, 10, 10);
            VendingMachineLogic logic = new VendingMachineLogic(vend);

            //Press & Extract & Check delivery

            IDeliverable[] removing = vend.DeliveryChute.RemoveItems();
            bool check = false;
            if (removing.Length == 0)
            {
                check = true;
            }
            Assert.AreEqual(check, true);

            //checks for proper money in storage bin
            List<Coin> coinList = vend.StorageBin.Unload();
            int moneyCount = 0;
            foreach (Coin c7 in coinList)
            {
                moneyCount += c7.Value;
            }
            Assert.AreEqual(moneyCount, 0);

            //check for proper money in coin racks
            int change = 0;
            foreach (CoinRack cr in vend.CoinRacks)
            {
                List<Coin> checkcheck = cr.Unload();
                foreach (Coin c8 in checkcheck)
                {
                    change += c8.Value;
                }
            }
            Assert.AreEqual(change, 0);
        }
        [TestMethod]
        public void GoodTestScript4()
        {
            //makes vm
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
            canCosts.Add(205);
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

            //Press & Extract & Check delivery

            vend.SelectionButtons[0].Press();
            IDeliverable[] removing = vend.DeliveryChute.RemoveItems();
            bool check = false;
            if (removing.Length == 0)
            {
                check = true;
            }
            Assert.AreEqual(check, true);


            //checks for proper money in storage bin
            List<Coin> coinList = vend.StorageBin.Unload();
            int moneyCount = 0;
            foreach (Coin c7 in coinList)
            {
                moneyCount += c7.Value;
            }
            Assert.AreEqual(moneyCount, 0);

            //check for proper money in coin racks
            int change = 0;
            foreach (CoinRack cr in vend.CoinRacks)
            {
                List<Coin> checkcheck = cr.Unload();
                foreach (Coin c8 in checkcheck)
                {
                    change += c8.Value;
                }
            }
            Assert.AreEqual(change, 65);

            List<PopCan> coke = vend.PopCanRacks[0].Unload();
            PopCan cokeCan = new PopCan("Coke");
            Assert.AreEqual(coke[0], cokeCan);

            List<PopCan> water = vend.PopCanRacks[1].Unload();
            PopCan waterCan = new PopCan("Water");
            Assert.AreEqual(water[0], waterCan);

            List<PopCan> stuff = vend.PopCanRacks[2].Unload();
            PopCan stuffCan = new PopCan("stuff");
            Assert.AreEqual(stuff[0], stuffCan);
        }



        [TestMethod]
        public void GoodTestScript5()
        {
            //makes vm
            List<int> list1 = new List<int>();
            list1.Add(100);
            list1.Add(5);
            list1.Add(25);
            list1.Add(10);
            int[] array1 = list1.ToArray();
            VendingMachine vend = new VendingMachine(array1, 3, 2, 10, 10);
            VendingMachineLogic logic = new VendingMachineLogic(vend);

            //configs vm
            List<string> canNames = new List<string>();
            canNames.Add("Coke");
            canNames.Add("Water");
            canNames.Add("stuff");
            List<int> canCosts = new List<int>();
            canCosts.Add(250);
            canCosts.Add(250);
            canCosts.Add(205);
            vend.Configure(canNames, canCosts);

            //loads coins
            List<int> coinsToLoad = new List<int>();
            coinsToLoad.Add(0);
            coinsToLoad.Add(1);
            coinsToLoad.Add(2);
            coinsToLoad.Add(1);
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

            //Press & Extract & Check delivery

            vend.SelectionButtons[0].Press();
            IDeliverable[] removing = vend.DeliveryChute.RemoveItems();
            bool check = false;
            if (removing.Length == 0)
            {
                check = true;
            }
            Assert.AreEqual(check, true);

            //adds coins
            Coin coin1 = new Coin(100);
            vend.CoinSlot.AddCoin(coin1);
            Coin coin2 = new Coin(100);
            vend.CoinSlot.AddCoin(coin2);
            Coin coin3 = new Coin(100);
            vend.CoinSlot.AddCoin(coin3);

            //makes selection
            vend.SelectionButtons[0].Press();
            IDeliverable[] removed = vend.DeliveryChute.RemoveItems();
            PopCan p = new PopCan("Coke");
            Assert.AreEqual(p, removed[0]);

            //checks for proper change
            Coin c = (Coin)removed[1];
            Coin c1 = (Coin)removed[2];
            int changeCount = c.Value + c1.Value;
            Assert.AreEqual(changeCount, 50);

            //checks for proper money in storage bin
            List<Coin> coinList = vend.StorageBin.Unload();
            int moneyCount = 0;
            foreach (Coin c7 in coinList)
            {
                moneyCount += c7.Value;
            }
            Assert.AreEqual(moneyCount, 100);

            //check for proper money in coin racks
            int change = 0;
            foreach (CoinRack cr in vend.CoinRacks)
            {
                List<Coin> checkcheck = cr.Unload();
                foreach (Coin c8 in checkcheck)
                {
                    change += c8.Value;
                }
            }
            Assert.AreEqual(change, 215);

            List<PopCan> water = vend.PopCanRacks[1].Unload();
            PopCan waterCan = new PopCan("Water");
            Assert.AreEqual(water[0], waterCan);

            List<PopCan> stuff = vend.PopCanRacks[2].Unload();
            PopCan stuffCan = new PopCan("stuff");
            Assert.AreEqual(stuff[0], stuffCan);
        }

        [TestMethod]
        public void GoodTestScript6()
        {
            //makes vm
            List<int> list1 = new List<int>();
            list1.Add(100);
            list1.Add(5);
            list1.Add(25);
            list1.Add(10);
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
            canCosts.Add(205);
            vend.Configure(canNames, canCosts);

            //loads coins
            List<int> coinsToLoad = new List<int>();
            coinsToLoad.Add(0);
            coinsToLoad.Add(1);
            coinsToLoad.Add(2);
            coinsToLoad.Add(1);
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

            //Press & Extract & Check delivery

            vend.SelectionButtons[0].Press();
            IDeliverable[] removing = vend.DeliveryChute.RemoveItems();
            bool check = false;
            if (removing.Length == 0)
            {
                check = true;
            }
            Assert.AreEqual(check, true);

            //adds coins
            Coin coin1 = new Coin(100);
            vend.CoinSlot.AddCoin(coin1);
            Coin coin2 = new Coin(100);
            vend.CoinSlot.AddCoin(coin2);
            Coin coin3 = new Coin(100);
            vend.CoinSlot.AddCoin(coin3);

            IDeliverable[] removing1 = vend.DeliveryChute.RemoveItems();
            bool check1 = false;
            if (removing1.Length == 0)
            {
                check1 = true;
            }
            Assert.AreEqual(check1, true);

            //checks for proper money in storage bin
            List<Coin> coinList = vend.StorageBin.Unload();
            int moneyCount = 0;
            foreach (Coin c7 in coinList)
            {
                moneyCount += c7.Value;
            }
            Assert.AreEqual(moneyCount, 0);

            //check for proper money in coin racks
            int change = 0;
            foreach (CoinRack cr in vend.CoinRacks)
            {
                List<Coin> checkcheck = cr.Unload();
                foreach (Coin c8 in checkcheck)
                {
                    change += c8.Value;
                }
            }
            Assert.AreEqual(change, 65);

            List<PopCan> coke = vend.PopCanRacks[0].Unload();
            PopCan cokeCan = new PopCan("Coke");
            Assert.AreEqual(coke[0], cokeCan);

            List<PopCan> water = vend.PopCanRacks[1].Unload();
            PopCan waterCan = new PopCan("Water");
            Assert.AreEqual(water[0], waterCan);

            List<PopCan> stuff = vend.PopCanRacks[2].Unload();
            PopCan stuffCan = new PopCan("stuff");
            Assert.AreEqual(stuff[0], stuffCan);
        }

        [TestMethod]
        public void GoodTestScript7()
        {
            //makes vm
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
            canNames.Add("A");
            canNames.Add("B");
            canNames.Add("C");
            List<int> canCosts = new List<int>();
            canCosts.Add(5);
            canCosts.Add(10);
            canCosts.Add(25);
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

            List<string> canNames1 = new List<string>();
            canNames1.Add("Coke");
            canNames1.Add("Water");
            canNames1.Add("stuff");
            List<int> canCosts1 = new List<int>();
            canCosts1.Add(250);
            canCosts1.Add(250);
            canCosts1.Add(205);
            vend.Configure(canNames1, canCosts1);

            //Press & Extract & Check delivery

            vend.SelectionButtons[0].Press();
            IDeliverable[] removing = vend.DeliveryChute.RemoveItems();
            bool check = false;
            if (removing.Length == 0)
            {
                check = true;
            }
            Assert.AreEqual(check, true);

            //adds coins
            Coin coin1 = new Coin(100);
            vend.CoinSlot.AddCoin(coin1);
            Coin coin2 = new Coin(100);
            vend.CoinSlot.AddCoin(coin2);
            Coin coin3 = new Coin(100);
            vend.CoinSlot.AddCoin(coin3);

            //makes selection
            vend.SelectionButtons[0].Press();
            IDeliverable[] removed = vend.DeliveryChute.RemoveItems();
            PopCan p = new PopCan("A");
            Assert.AreEqual(p, removed[0]);

            //checks for proper change
            Coin c = (Coin)removed[1];
            Coin c1 = (Coin)removed[2];
            int changeCount = c.Value + c1.Value;
            Assert.AreEqual(changeCount, 50);


            //checks for proper money in storage bin
            List<Coin> coinList = vend.StorageBin.Unload();
            int moneyCount = 0;
            foreach (Coin c7 in coinList)
            {
                moneyCount += c7.Value;
            }
            Assert.AreEqual(moneyCount, 0);

            //check for proper money in coin racks
            int change = 0;
            foreach (CoinRack cr in vend.CoinRacks)
            {
                List<Coin> check1 = cr.Unload();
                foreach (Coin c8 in check1)
                {
                    change += c8.Value;
                }
            }
            Assert.AreEqual(change, 315);


            List<PopCan> water = vend.PopCanRacks[1].Unload();
            PopCan waterCan = new PopCan("B");
            Assert.AreEqual(water[0], waterCan);

            List<PopCan> stuff = vend.PopCanRacks[2].Unload();
            PopCan stuffCan = new PopCan("C");
            Assert.AreEqual(stuff[0], stuffCan);


            //loads coins
            List<int> coinsToLoad1 = new List<int>();
            coinsToLoad1.Add(1);
            coinsToLoad1.Add(1);
            coinsToLoad1.Add(2);
            coinsToLoad1.Add(0);
            int[] coinsToLoadArray1;
            coinsToLoadArray1 = coinsToLoad1.ToArray();
            vend.LoadCoins(coinsToLoadArray1);

            //loads pops
            List<int> popsToLoad1 = new List<int>();
            popsToLoad1.Add(1);
            popsToLoad1.Add(1);
            popsToLoad1.Add(1);
            int[] popsToLoadArray1;
            popsToLoadArray1 = popsToLoad1.ToArray();
            vend.LoadPopCans(popsToLoadArray1);

            Coin coin4 = new Coin(100);
            vend.CoinSlot.AddCoin(coin4);
            Coin coin5 = new Coin(100);
            vend.CoinSlot.AddCoin(coin5);
            Coin coin6 = new Coin(100);
            vend.CoinSlot.AddCoin(coin6);

            //makes selection
            vend.SelectionButtons[0].Press();
            IDeliverable[] removed1 = vend.DeliveryChute.RemoveItems();
            PopCan p1 = new PopCan("Coke");
            Assert.AreEqual(p1, removed1[0]);

            //checks for proper change
            Coin c2 = (Coin)removed1[1];
            Coin c3 = (Coin)removed1[2];
            int changeCount1 = c2.Value + c3.Value;
            Assert.AreEqual(changeCount1, 50);

            //checks for proper money in storage bin
            List<Coin> coinList1 = vend.StorageBin.Unload();
            int moneyCount1 = 0;
            foreach (Coin c9 in coinList)
            {
                moneyCount1 += c9.Value;
            }
            Assert.AreEqual(moneyCount1, 0);

            //check for proper money in coin racks
            int change1 = 0;
            foreach (CoinRack cr in vend.CoinRacks)
            {
                List<Coin> check2 = cr.Unload();
                foreach (Coin c10 in check2)
                {
                    change1 += c10.Value;
                }
            }
            Assert.AreEqual(change1, 315);

            List<PopCan> water1 = vend.PopCanRacks[1].Unload();
            PopCan waterCan1 = new PopCan("Water");
            Assert.AreEqual(water1[0], waterCan1);

            List<PopCan> stuff1 = vend.PopCanRacks[2].Unload();
            PopCan stuffCan1 = new PopCan("stuff");
            Assert.AreEqual(stuff1[0], stuffCan1);

        }

        [TestMethod]
        public void GoodTestScript8()
        {
            //makes vm
            List<int> list1 = new List<int>();
            list1.Add(5);
            list1.Add(10);
            list1.Add(25);
            list1.Add(100);
            int[] array1 = list1.ToArray();
            VendingMachine vend = new VendingMachine(array1, 1, 10, 10, 10);
            VendingMachineLogic logic = new VendingMachineLogic(vend);

            //configs vm
            List<string> canNames = new List<string>();
            canNames.Add("stuff");
            List<int> canCosts = new List<int>();
            canCosts.Add(140);
            vend.Configure(canNames, canCosts);

            //loads coins
            List<int> coinsToLoad = new List<int>();
            coinsToLoad.Add(0);
            coinsToLoad.Add(5);
            coinsToLoad.Add(1);
            coinsToLoad.Add(1);
            int[] coinsToLoadArray;
            coinsToLoadArray = coinsToLoad.ToArray();
            vend.LoadCoins(coinsToLoadArray);

            //loads pops
            List<int> popsToLoad = new List<int>();
            popsToLoad.Add(1);
            int[] popsToLoadArray;
            popsToLoadArray = popsToLoad.ToArray();
            vend.LoadPopCans(popsToLoadArray);

            //adds coins
            Coin coin1 = new Coin(100);
            vend.CoinSlot.AddCoin(coin1);
            Coin coin2 = new Coin(100);
            vend.CoinSlot.AddCoin(coin2);
            Coin coin3 = new Coin(100);
            vend.CoinSlot.AddCoin(coin3);

            //makes selection
            vend.SelectionButtons[0].Press();
            IDeliverable[] removed = vend.DeliveryChute.RemoveItems();
            PopCan p = new PopCan("stuff");
            Assert.AreEqual(p, removed[0]);

            //checks for proper change
            Coin c = (Coin)removed[1];
            Coin c1 = (Coin)removed[2];
            Coin c2 = (Coin)removed[3];
            Coin c3 = (Coin)removed[4];
            Coin c4 = (Coin)removed[5];
            int changeCount = c.Value + c1.Value + c2.Value + c3.Value + c4.Value;
            Assert.AreEqual(changeCount, 155);

            //checks for proper money in storage bin
            List<Coin> coinList = vend.StorageBin.Unload();
            int moneyCount = 0;
            foreach (Coin c7 in coinList)
            {
                moneyCount += c7.Value;
            }
            Assert.AreEqual(moneyCount, 0);

            //check for proper money in coin racks
            int change = 0;
            foreach (CoinRack cr in vend.CoinRacks)
            {
                List<Coin> checkcheck = cr.Unload();
                foreach (Coin c8 in checkcheck)
                {
                    change += c8.Value;
                }
            }
            Assert.AreEqual(change, 320);




        }

        [TestMethod]
        public void GoodTestScript9()
        {
            //makes vm
            List<int> list1 = new List<int>();
            list1.Add(5);
            list1.Add(10);
            list1.Add(25);
            list1.Add(100);
            int[] array1 = list1.ToArray();
            VendingMachine vend = new VendingMachine(array1, 1, 10, 10, 10);
            VendingMachineLogic logic = new VendingMachineLogic(vend);

            //configs vm
            List<string> canNames = new List<string>();
            canNames.Add("stuff");
            List<int> canCosts = new List<int>();
            canCosts.Add(140);
            vend.Configure(canNames, canCosts);

            //loads coins
            List<int> coinsToLoad = new List<int>();
            coinsToLoad.Add(1);
            coinsToLoad.Add(6);
            coinsToLoad.Add(1);
            coinsToLoad.Add(1);
            int[] coinsToLoadArray;
            coinsToLoadArray = coinsToLoad.ToArray();
            vend.LoadCoins(coinsToLoadArray);

            //loads pops
            List<int> popsToLoad = new List<int>();
            popsToLoad.Add(1);
            int[] popsToLoadArray;
            popsToLoadArray = popsToLoad.ToArray();
            vend.LoadPopCans(popsToLoadArray);

            //adds coins
            Coin coin1 = new Coin(100);
            vend.CoinSlot.AddCoin(coin1);
            Coin coin2 = new Coin(100);
            vend.CoinSlot.AddCoin(coin2);
            Coin coin3 = new Coin(100);
            vend.CoinSlot.AddCoin(coin3);

            //makes selection
            vend.SelectionButtons[0].Press();
            IDeliverable[] removed = vend.DeliveryChute.RemoveItems();
            PopCan p = new PopCan("stuff");
            Assert.AreEqual(p, removed[0]);

            //checks for proper change
            Coin c = (Coin)removed[1];
            Coin c1 = (Coin)removed[2];
            Coin c2 = (Coin)removed[3];
            Coin c3 = (Coin)removed[4];
            Coin c4 = (Coin)removed[5];
            Coin c5 = (Coin)removed[6];
            int changeCount = c.Value + c1.Value + c2.Value + c3.Value + c4.Value + c5.Value;
            Assert.AreEqual(changeCount, 160);

            //check for proper money in coin racks
            int change = 0;
            foreach (CoinRack cr in vend.CoinRacks)
            {
                List<Coin> checkcheck = cr.Unload();
                foreach (Coin c8 in checkcheck)
                {
                    change += c8.Value;
                }
            }
            Assert.AreEqual(change, 330);

            //checks for proper money in storage bin
            List<Coin> coinList = vend.StorageBin.Unload();
            int moneyCount = 0;
            foreach (Coin c7 in coinList)
            {
                moneyCount += c7.Value;
            }
            Assert.AreEqual(moneyCount, 0);
        }

        [TestMethod]
        public void GoodTestScript10()
        {
            //makes vm
            List<int> list1 = new List<int>();
            list1.Add(5);
            list1.Add(10);
            list1.Add(25);
            list1.Add(100);
            int[] array1 = list1.ToArray();
            VendingMachine vend = new VendingMachine(array1, 1, 10, 10, 10);
            VendingMachineLogic logic = new VendingMachineLogic(vend);

            //configs vm
            List<string> canNames = new List<string>();
            canNames.Add("stuff");
            List<int> canCosts = new List<int>();
            canCosts.Add(140);
            vend.Configure(canNames, canCosts);

            //loads coins
            List<int> coinsToLoad = new List<int>();
            coinsToLoad.Add(1);
            coinsToLoad.Add(6);
            coinsToLoad.Add(1);
            coinsToLoad.Add(1);
            int[] coinsToLoadArray;
            coinsToLoadArray = coinsToLoad.ToArray();
            vend.LoadCoins(coinsToLoadArray);

            //loads pops
            List<int> popsToLoad = new List<int>();
            popsToLoad.Add(1);
            int[] popsToLoadArray;
            popsToLoadArray = popsToLoad.ToArray();
            vend.LoadPopCans(popsToLoadArray);

            //adds coins
            Coin coin1 = new Coin(1);
            vend.CoinSlot.AddCoin(coin1);
            Coin coin2 = new Coin(139);
            vend.CoinSlot.AddCoin(coin2);

            //makes selection
            vend.SelectionButtons[0].Press();
            IDeliverable[] removed = vend.DeliveryChute.RemoveItems();

            //checks for proper change
            Coin c = (Coin)removed[0];
            Coin c1 = (Coin)removed[1];
            int changeCount = c.Value + c1.Value;
            Assert.AreEqual(changeCount, 140);

            //check for proper money in coin racks
            int change = 0;
            foreach (CoinRack cr in vend.CoinRacks)
            {
                List<Coin> checkcheck = cr.Unload();
                foreach (Coin c8 in checkcheck)
                {
                    change += c8.Value;
                }
            }
            Assert.AreEqual(change, 190);

            //checks for proper money in storage bin
            List<Coin> coinList = vend.StorageBin.Unload();
            int moneyCount = 0;
            foreach (Coin c7 in coinList)
            {
                moneyCount += c7.Value;
            }
            Assert.AreEqual(moneyCount, 0);

            //checks for leftover pop
            List<PopCan> pop = vend.PopCanRacks[0].Unload();
            PopCan waterCan = new PopCan("stuff");
            Assert.AreEqual(pop[0], waterCan);


        }

        [TestMethod]
        public void GoodTestScript11()
        {
            //makes vm
            List<int> list1 = new List<int>();
            list1.Add(100);
            list1.Add(5);
            list1.Add(25);
            list1.Add(10);
            int[] array1 = list1.ToArray();
            VendingMachine vend = new VendingMachine(array1, 3, 10, 10, 10);
            VendingMachineLogic logic = new VendingMachineLogic(vend);

            //configs vm
            List<string> canNames = new List<string>();
            canNames.Add("Coke");
            canNames.Add("water");
            canNames.Add("stuff");
            List<int> canCosts = new List<int>();
            canCosts.Add(250);
            canCosts.Add(250);
            canCosts.Add(205);
            vend.Configure(canNames, canCosts);

            //loads coins
            List<int> coinsToLoad = new List<int>();
            coinsToLoad.Add(0);
            coinsToLoad.Add(1);
            coinsToLoad.Add(2);
            coinsToLoad.Add(1);
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

            //makes a selection
            vend.SelectionButtons[0].Press();
            IDeliverable[] removed = vend.DeliveryChute.RemoveItems();
            bool check = false;
            if (removed.Length == 0)
            {
                check = true;
            }
            Assert.AreEqual(check, true);

            //inserts coins
            Coin coin1 = new Coin(100);
            vend.CoinSlot.AddCoin(coin1);
            Coin coin2 = new Coin(100);
            vend.CoinSlot.AddCoin(coin2);
            Coin coin3 = new Coin(100);
            vend.CoinSlot.AddCoin(coin3);

            //checks delivery
            IDeliverable[] removed2 = vend.DeliveryChute.RemoveItems();
            bool check2 = false;
            if (removed2.Length == 0)
            {
                check2 = true;
            }
            Assert.AreEqual(check2, true);

            //check for proper money in coin racks
            int change = 0;
            foreach (CoinRack cr in vend.CoinRacks)
            {
                List<Coin> checkcheck = cr.Unload();
                foreach (Coin c8 in checkcheck)
                {
                    change += c8.Value;
                }
            }
            Assert.AreEqual(change, 65);

            //checks for proper money in storage bin
            List<Coin> coinList = vend.StorageBin.Unload();
            int moneyCount = 0;
            foreach (Coin c7 in coinList)
            {
                moneyCount += c7.Value;
            }
            Assert.AreEqual(moneyCount, 0);

            //checks for leftover pop
            List<PopCan> cokes = vend.PopCanRacks[0].Unload();
            PopCan cokeCan = new PopCan("Coke");
            Assert.AreEqual(cokes[0], cokeCan);
            Assert.AreEqual(cokes.Count, 1);

            List<PopCan> waters = vend.PopCanRacks[1].Unload();
            PopCan waterCan = new PopCan("water");
            Assert.AreEqual(waters[0], waterCan);
            Assert.AreEqual(waters.Count, 1);

            List<PopCan> stuffs = vend.PopCanRacks[2].Unload();
            PopCan stuffCan = new PopCan("stuff");
            Assert.AreEqual(stuffs[0], stuffCan);
            Assert.AreEqual(stuffs.Count, 1);

            //loads coins
            List<int> coinsToLoad2 = new List<int>();
            coinsToLoad2.Add(0);
            coinsToLoad2.Add(1);
            coinsToLoad2.Add(2);
            coinsToLoad2.Add(1);
            int[] coinsToLoadArray2;
            coinsToLoadArray2 = coinsToLoad2.ToArray();
            vend.LoadCoins(coinsToLoadArray2);

            //loads pops
            List<int> popsToLoad2 = new List<int>();
            popsToLoad2.Add(1);
            popsToLoad2.Add(1);
            popsToLoad2.Add(1);
            int[] popsToLoadArray2;
            popsToLoadArray2 = popsToLoad2.ToArray();
            vend.LoadPopCans(popsToLoadArray2);

            //makes selection
            vend.SelectionButtons[0].Press();
            IDeliverable[] removed3 = vend.DeliveryChute.RemoveItems();

            PopCan p = new PopCan("Coke");
            Assert.AreEqual(removed3[0], p);

            Coin c1 = (Coin)removed3[1];
            Coin c2 = (Coin)removed3[2];
            int changeCount = 0;
            changeCount = c1.Value + c2.Value;
            Assert.AreEqual(changeCount, 50);

            //check for proper money in coin racks
            int change2 = 0;
            foreach (CoinRack cr in vend.CoinRacks)
            {
                List<Coin> checkcheck = cr.Unload();
                foreach (Coin c8 in checkcheck)
                {
                    change2 += c8.Value;
                }
            }
            Assert.AreEqual(change2, 315);

            //checks for proper money in storage bin
            List<Coin> coinList2 = vend.StorageBin.Unload();
            int moneyCount2 = 0;
            foreach (Coin c7 in coinList2)
            {
                moneyCount2 += c7.Value;
            }
            Assert.AreEqual(moneyCount2, 0);

            //checks leftover pop
            List<PopCan> waters2 = vend.PopCanRacks[1].Unload();
            PopCan waterCan2 = new PopCan("water");
            Assert.AreEqual(waters2[0], waterCan2);
            Assert.AreEqual(waters2.Count, 1);

            List<PopCan> stuffs2 = vend.PopCanRacks[2].Unload();
            PopCan stuffCan2 = new PopCan("stuff");
            Assert.AreEqual(stuffs2[0], stuffCan2);
            Assert.AreEqual(stuffs2.Count, 1);

            //sets up second vending machine
            List<int> list2 = new List<int>();
            list2.Add(100);
            list2.Add(5);
            list2.Add(25);
            list2.Add(10);
            int[] array2 = list2.ToArray();
            VendingMachine vend2 = new VendingMachine(array2, 3, 10, 10, 10);
            VendingMachineLogic logic2 = new VendingMachineLogic(vend2);

            //configs vm
            List<string> canNames2 = new List<string>();
            canNames2.Add("Coke");
            canNames2.Add("water");
            canNames2.Add("stuff");
            List<int> canCosts2 = new List<int>();
            canCosts2.Add(250);
            canCosts2.Add(250);
            canCosts2.Add(205);
            vend2.Configure(canNames2, canCosts2);

            //configs vm
            List<string> canNames3 = new List<string>();
            canNames3.Add("A");
            canNames3.Add("B");
            canNames3.Add("C");
            List<int> canCosts3 = new List<int>();
            canCosts3.Add(5);
            canCosts3.Add(10);
            canCosts3.Add(25);
            vend2.Configure(canNames3, canCosts3);

            //check for proper money in coin racks
            int change3 = 0;
            foreach (CoinRack cr in vend2.CoinRacks)
            {
                List<Coin> checkcheck = cr.Unload();
                foreach (Coin c8 in checkcheck)
                {
                    change3 += c8.Value;
                }
            }
            Assert.AreEqual(change3, 0);

            //checks for proper money in storage bin
            List<Coin> coinList3 = vend2.StorageBin.Unload();
            int moneyCount3 = 0;
            foreach (Coin c7 in coinList3)
            {
                moneyCount3 += c7.Value;
            }
            Assert.AreEqual(moneyCount3, 0);

            //loads coins
            List<int> coinsToLoad3 = new List<int>();
            coinsToLoad3.Add(0);
            coinsToLoad3.Add(1);
            coinsToLoad3.Add(2);
            coinsToLoad3.Add(1);
            int[] coinsToLoadArray3;
            coinsToLoadArray3 = coinsToLoad3.ToArray();
            vend2.LoadCoins(coinsToLoadArray3);

            //loads pops
            List<int> popsToLoad3 = new List<int>();
            popsToLoad3.Add(1);
            popsToLoad3.Add(1);
            popsToLoad3.Add(1);
            int[] popsToLoadArray3;
            popsToLoadArray3 = popsToLoad3.ToArray();
            vend2.LoadPopCans(popsToLoadArray3);

            //inserts coins
            Coin coin4 = new Coin(10);
            vend2.CoinSlot.AddCoin(coin4);
            Coin coin5 = new Coin(5);
            vend2.CoinSlot.AddCoin(coin5);
            Coin coin6 = new Coin(10);
            vend2.CoinSlot.AddCoin(coin6);

            vend2.SelectionButtons[2].Press();
            IDeliverable[] removed4 = vend2.DeliveryChute.RemoveItems();

            PopCan cCan = new PopCan("C");
            Assert.AreEqual(removed4[0], cCan);
            Assert.AreEqual(removed4.Length, 1);

            int change4 = 0;
            foreach (CoinRack cr in vend2.CoinRacks)
            {
                List<Coin> checkcheck = cr.Unload();
                foreach (Coin c8 in checkcheck)
                {
                    change4 += c8.Value;
                }
            }
            Assert.AreEqual(change4, 90);

            //checks for proper money in storage bin
            List<Coin> coinList4 = vend2.StorageBin.Unload();
            int moneyCount4 = 0;
            foreach (Coin c7 in coinList4)
            {
                moneyCount4 += c7.Value;
            }
            Assert.AreEqual(moneyCount4, 0);

            List<PopCan> As = vend2.PopCanRacks[0].Unload();
            PopCan aCan = new PopCan("A");
            Assert.AreEqual(As[0], aCan);
            Assert.AreEqual(As.Count, 1);

            List<PopCan> Bs = vend2.PopCanRacks[1].Unload();
            PopCan bCan = new PopCan("B");
            Assert.AreEqual(Bs[0], bCan);
            Assert.AreEqual(Bs.Count, 1);

        }
        [TestMethod]
        public void GoodTestScript12()
        {
            List<int> list1 = new List<int>();
            list1.Add(5);
            list1.Add(10);
            list1.Add(25);
            list1.Add(100);
            int[] array1 = list1.ToArray();
            VendingMachine vend = new VendingMachine(array1, 1, 10, 10, 10);
            VendingMachineLogic logic = new VendingMachineLogic(vend);

            //configs vm
            List<string> canNames = new List<string>();
            canNames.Add("stuff");
            List<int> canCosts = new List<int>();
            canCosts.Add(140);
            vend.Configure(canNames, canCosts);

            //loads coins
            List<int> coinsToLoad = new List<int>();
            coinsToLoad.Add(0);
            coinsToLoad.Add(5);
            coinsToLoad.Add(1);
            coinsToLoad.Add(1);
            int[] coinsToLoadArray;
            coinsToLoadArray = coinsToLoad.ToArray();
            vend.LoadCoins(coinsToLoadArray);

            //loads pops
            List<int> popsToLoad = new List<int>();
            popsToLoad.Add(1);
            int[] popsToLoadArray;
            popsToLoadArray = popsToLoad.ToArray();
            vend.LoadPopCans(popsToLoadArray);

            Coin coin1 = new Coin(100);
            vend.CoinSlot.AddCoin(coin1);
            Coin coin2 = new Coin(100);
            vend.CoinSlot.AddCoin(coin2);
            Coin coin3 = new Coin(100);
            vend.CoinSlot.AddCoin(coin3);

            vend.SelectionButtons[0].Press();
            IDeliverable[] removed = vend.DeliveryChute.RemoveItems();

            PopCan p = new PopCan("stuff");
            Assert.AreEqual(removed[0], p);

            Coin c1 = new Coin(100);
            Coin c2 = new Coin(25);
            Coin c3 = new Coin(10);
            Coin c4 = new Coin(10);
            Coin c5 = new Coin(10);
            int changeCount = c1.Value + c2.Value + c3.Value + c4.Value + c5.Value;
            Assert.AreEqual(changeCount, 155);
            Assert.AreEqual(removed.Length, 6);

            //checks for proper money in coin racks
            int change = 0;
            foreach (CoinRack cr in vend.CoinRacks)
            {
                List<Coin> checkcheck = cr.Unload();
                foreach (Coin c8 in checkcheck)
                {
                    change += c8.Value;
                }
            }
            Assert.AreEqual(change, 320);

            //checks for proper money in storage bin
            List<Coin> coinList = vend.StorageBin.Unload();
            int moneyCount = 0;
            foreach (Coin c7 in coinList)
            {
                moneyCount += c7.Value;
            }
            Assert.AreEqual(moneyCount, 0);

            List<int> coinsToLoad2 = new List<int>();
            coinsToLoad2.Add(10);
            coinsToLoad2.Add(10);
            coinsToLoad2.Add(10);
            coinsToLoad2.Add(10);
            int[] coinsToLoadArray2;
            coinsToLoadArray2 = coinsToLoad2.ToArray();
            vend.LoadCoins(coinsToLoadArray2);

            //loads pops
            List<int> popsToLoad2 = new List<int>();
            popsToLoad2.Add(1);
            int[] popsToLoadArray2;
            popsToLoadArray2 = popsToLoad2.ToArray();
            vend.LoadPopCans(popsToLoadArray2);

            Coin coin4 = new Coin(25);
            vend.CoinSlot.AddCoin(coin4);
            Coin coin5 = new Coin(100);
            vend.CoinSlot.AddCoin(coin5);
            Coin coin6 = new Coin(10);
            vend.CoinSlot.AddCoin(coin6);

            vend.SelectionButtons[0].Press();
            IDeliverable[] removed2 = vend.DeliveryChute.RemoveItems();

            PopCan p2 = new PopCan("stuff");
            Assert.AreEqual(removed2[0], p2);
            Assert.AreEqual(removed2.Length, 1);

            //checks for proper money in coin racks
            int change2 = 0;
            foreach (CoinRack cr in vend.CoinRacks)
            {
                List<Coin> checkcheck = cr.Unload();
                foreach (Coin c8 in checkcheck)
                {
                    change2 += c8.Value;
                }
            }
            Assert.AreEqual(change2, 1400);

            //checks for proper money in storage bin
            List<Coin> coinList2 = vend.StorageBin.Unload();
            int moneyCount2 = 0;
            foreach (Coin c7 in coinList2)
            {
                moneyCount2 += c7.Value;
            }
            Assert.AreEqual(moneyCount2, 135);
            Assert.AreEqual(vend.PopCanRacks[0].Count, 0);
        }

        [TestMethod]
        public void GoodTestScript13()
        {
            List<int> list1 = new List<int>();
            list1.Add(5);
            list1.Add(10);
            list1.Add(25);
            list1.Add(100);
            int[] array1 = list1.ToArray();
            VendingMachine vend = new VendingMachine(array1, 1, 10, 10, 10);
            VendingMachineLogic logic = new VendingMachineLogic(vend);

            //configs vm
            List<string> canNames = new List<string>();
            canNames.Add("stuff");
            List<int> canCosts = new List<int>();
            canCosts.Add(135);
            vend.Configure(canNames, canCosts);

            //loads coins
            List<int> coinsToLoad = new List<int>();
            coinsToLoad.Add(10);
            coinsToLoad.Add(10);
            coinsToLoad.Add(10);
            coinsToLoad.Add(10);
            int[] coinsToLoadArray;
            coinsToLoadArray = coinsToLoad.ToArray();
            vend.LoadCoins(coinsToLoadArray);

            //loads pops
            List<int> popsToLoad = new List<int>();
            popsToLoad.Add(1);
            int[] popsToLoadArray;
            popsToLoadArray = popsToLoad.ToArray();
            vend.LoadPopCans(popsToLoadArray);

            Coin coin1 = new Coin(25);
            vend.CoinSlot.AddCoin(coin1);
            Coin coin2 = new Coin(100);
            vend.CoinSlot.AddCoin(coin2);
            Coin coin3 = new Coin(10);
            vend.CoinSlot.AddCoin(coin3);

            vend.SelectionButtons[0].Press();
            IDeliverable[] removed = vend.DeliveryChute.RemoveItems();

            PopCan p = new PopCan("stuff");
            Assert.AreEqual(removed[0], p);
            Assert.AreEqual(removed.Length, 1);

            int change = 0;
            foreach (CoinRack cr in vend.CoinRacks)
            {
                List<Coin> checkcheck = cr.Unload();
                foreach (Coin c8 in checkcheck)
                {
                    change += c8.Value;
                }
            }
            Assert.AreEqual(change, 1400);

            //checks for proper money in storage bin
            List<Coin> coinList = vend.StorageBin.Unload();
            int moneyCount = 0;
            foreach (Coin c7 in coinList)
            {
                moneyCount += c7.Value;
            }
            Assert.AreEqual(moneyCount, 135);

        }

    }
}
