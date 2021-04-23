using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerTestScript
    {
        PlayerGroup Player;

        [SetUp]
        public void SetUp()
        {
            Player = new PlayerGroup();
        }


        // A Test behaves as an ordinary method
        [Test]
        public void Should_Succeed_When_GivingMoneyToThePlayer()
        {
            Assert.AreEqual(0, Player.CurrentMoneyAmount, $"Players money is not equal to 0 instead its {Player.CurrentMoneyAmount}");
            Player.GiveMoney(5);
            Assert.AreEqual(5, Player.CurrentMoneyAmount, $"Players money is not equal to 5 instead its {Player.CurrentMoneyAmount}");
        }

        [Test]
        public void Should_Succeed_When_SubtractingMoneyFromThePlayer()
        {
            Player.GiveMoney(20);
            Assert.AreEqual(20, Player.CurrentMoneyAmount, $"Players money is not equal to 20 instead its {Player.CurrentMoneyAmount}");

            Player.SubtractMoney(10);
            Assert.AreEqual(10, Player.CurrentMoneyAmount, $"Players money is not equal to 20 instead its {Player.CurrentMoneyAmount}");
        }


        [Test]
        public void Should_Fail_When_GivingMoneyToThePlayer()
        {
            Assert.AreEqual(0, Player.CurrentMoneyAmount, $"Players money is not equal to 0 instead its {Player.CurrentMoneyAmount}");
            Player.GiveMoney(-10);
            Assert.AreEqual(0, Player.CurrentMoneyAmount, $"Players money did increase its now: {Player.CurrentMoneyAmount}");

        }

        [Test]
        public void Should_Succeed_When_SubtracingTooManyMoneyFromThePlayer()
        {
            Player.GiveMoney(25);
            Assert.AreEqual(25, Player.CurrentMoneyAmount, $"Players money its not equal to 25 instead its: {Player.CurrentMoneyAmount}");

            Player.SubtractMoney(50);

            Assert.AreEqual(0, Player.CurrentMoneyAmount, $"Players money its not equal to 0 instead its: {Player.CurrentMoneyAmount}");
        }


        [Test]
        public void Should_Fail_When_SubstracingMoneyFromThePlayer()
        {
            Player.GiveMoney(25);
            Assert.AreEqual(25, Player.CurrentMoneyAmount, $"Players money its not equal to 25 instead its: {Player.CurrentMoneyAmount}");

            Player.SubtractMoney(-50);

            Assert.AreEqual(25, Player.CurrentMoneyAmount, $"Players money its not equal to 25 instead its: {Player.CurrentMoneyAmount}");
        }

        [Test]
        public void Should_Succeed_When_SubtractingTooMuchTaxFromThePlayer()
        {
            Player.GiveMoney(10);
            Assert.AreEqual(10, Player.CurrentMoneyAmount, $"Players money its not equal to 10 instead its: {Player.CurrentMoneyAmount}");

            Player.SubtractMoney(15);

            Assert.AreEqual(0, Player.CurrentMoneyAmount, $"Players money its not equal to 0 instead its: {Player.CurrentMoneyAmount}");

        }

        [Test]
        public void Should_Succeed_When_BuyingAStar()
        {
            Player.GiveMoney(25);
            Assert.AreEqual(25, Player.CurrentMoneyAmount, $"Players money its not equal to 25 instead its: {Player.CurrentMoneyAmount}");
            Assert.AreEqual(0, Player.CurrentAmountOfStars, $"Players stars its not equal to 0 instead its: {Player.CurrentAmountOfStars}");

            int Amount = Player.CurrentMoneyAmount / 5;
            Player.GainStar(Amount);
            Player.SubtractMoney(Amount * 5);

            Assert.AreEqual(0, Player.CurrentMoneyAmount, $"Players money its not equal to 0 instead its: {Player.CurrentMoneyAmount}");
            Assert.AreEqual(Amount, Player.CurrentAmountOfStars, $"Players stars its not equal to {Amount} instead its: {Player.CurrentAmountOfStars}");
        }

        [Test]
        public void Should_fail_WhenBuyingAStar()
        {
            int Amount = 0;
            Player.GiveMoney(3);
            Assert.AreEqual(3, Player.CurrentMoneyAmount, $"Players money its not equal to 3 instead its: {Player.CurrentMoneyAmount}");
            Assert.AreEqual(0, Player.CurrentAmountOfStars, $"Players stars its not equal to 0 instead its: {Player.CurrentAmountOfStars}");

            if(Player.CurrentMoneyAmount >= 5)
            {
                Amount = Player.CurrentMoneyAmount / 5;
                Player.GainStar(Amount);
                Player.SubtractMoney(Amount * 5);
            }
            
            Assert.AreEqual(3, Player.CurrentMoneyAmount, $"Players money its not equal to 3 instead its: {Player.CurrentMoneyAmount}");
            Assert.AreEqual(Amount, Player.CurrentAmountOfStars, $"Players stars its not equal to {Amount} instead its: {Player.CurrentAmountOfStars}");
        }

        [Test]
        public void Should_fail_WhenGivingNegtiveStars()
        {
            int Amount = 0;
            Player.GiveMoney(15);
            Assert.AreEqual(15, Player.CurrentMoneyAmount, $"Players money its not equal to 15 instead its: {Player.CurrentMoneyAmount}");
            Assert.AreEqual(0, Player.CurrentAmountOfStars, $"Players stars its not equal to 0 instead its: {Player.CurrentAmountOfStars}");

            if (Player.CurrentMoneyAmount >= 5)
            {
                Amount = Player.CurrentMoneyAmount / 5;
                Player.GainStar(-Amount);
                Player.SubtractMoney(Amount * 5);
            }

            Assert.AreEqual(0, Player.CurrentMoneyAmount, $"Players money its not equal to 0 instead its: {Player.CurrentMoneyAmount}");
            Assert.AreEqual(Amount, Player.CurrentAmountOfStars, $"Players stars its not equal to {Amount} instead its: {Player.CurrentAmountOfStars}");
        }

        [Test]
        public void Should_Fail_When_GivingMoneyToPlayer()
        {

            Assert.AreEqual(0, Player.CurrentMoneyAmount, $"Players money is not equal to 0 instead its {Player.CurrentMoneyAmount}");

            if (int.TryParse("C", out int testNumber))
            {
                Player.GiveMoney(testNumber);
            }

            Assert.AreEqual(0, Player.CurrentMoneyAmount, $"Players money is not equal to 9 instead its {Player.CurrentMoneyAmount}");
        }

        [Test]
        public void Should_Fail_When_GivingMoneyToPlayerWithADec()
        {

            Assert.AreEqual(0, Player.CurrentMoneyAmount, $"Players money is not equal to 0 instead its {Player.CurrentMoneyAmount}");

            if (int.TryParse("19,2", out int testNumber))
            {
                Player.GiveMoney(testNumber);
            }

            Assert.AreEqual(0, Player.CurrentMoneyAmount, $"Players money is not equal to 9 instead its {Player.CurrentMoneyAmount}");
        }

        [Test]
        public void Should_fail_WhenGettingAStarWithDecMoney()
        {
            int Amount = 0;

            if (int.TryParse("19,2", out int testNumber))
            {
                Player.GiveMoney(testNumber);
            }

            Assert.AreEqual(0, Player.CurrentMoneyAmount, $"Players money its not equal to 0 instead its: {Player.CurrentMoneyAmount}");
            Assert.AreEqual(0, Player.CurrentAmountOfStars, $"Players stars its not equal to 0 instead its: {Player.CurrentAmountOfStars}");

            if (Player.CurrentMoneyAmount >= 5)
            {
                Amount = Player.CurrentMoneyAmount / 5;
                Player.GainStar(Amount);
                Player.SubtractMoney(Amount * 5);
            }

            Assert.AreEqual(0, Player.CurrentMoneyAmount, $"Players money its not equal to 0 instead its: {Player.CurrentMoneyAmount}");
            Assert.AreEqual(Amount, Player.CurrentAmountOfStars, $"Players stars its not equal to {Amount} instead its: {Player.CurrentAmountOfStars}");
        }


        [Test]
        public void Should_fail_WhenGettingAStarWithString()
        {
            int Amount = 0;

            if (int.TryParse("DDWE", out int testNumber))
            {
                Player.GiveMoney(testNumber);
            }

            Assert.AreEqual(0, Player.CurrentMoneyAmount, $"Players money its not equal to 0 instead its: {Player.CurrentMoneyAmount}");
            Assert.AreEqual(0, Player.CurrentAmountOfStars, $"Players stars its not equal to 0 instead its: {Player.CurrentAmountOfStars}");

            if (Player.CurrentMoneyAmount >= 5)
            {
                Amount = Player.CurrentMoneyAmount / 5;
                Player.GainStar(Amount);
                Player.SubtractMoney(Amount * 5);
            }

            Assert.AreEqual(0, Player.CurrentMoneyAmount, $"Players money its not equal to 0 instead its: {Player.CurrentMoneyAmount}");
            Assert.AreEqual(Amount, Player.CurrentAmountOfStars, $"Players stars its not equal to {Amount} instead its: {Player.CurrentAmountOfStars}");
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator PlayerTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
