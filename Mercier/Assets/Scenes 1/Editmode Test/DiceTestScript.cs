using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class DiceTestScript
    {
        Random rnd;
        int minDice;
        int maxDice;

        [SetUp]
        public void SetUp()
        {
            rnd = new Random();
            minDice = 1;
            maxDice = 6;
        }

        // A Test behaves as an ordinary method
        [Test]
        public void Should_Succeed_When_ThrowhingADice()
        {
            int rnd = Random.Range(minDice, maxDice);

            Assert.That(rnd, Is.GreaterThan(0), "Dice tthrow is bigger than 0, It is: " + rnd);
            Assert.That(rnd, Is.LessThan(7), "Dice tthrow is less than 6, It is: " + rnd);
        }

        [Test]
        public void Should_Succeed_When_ThrowhingADiceWithDividedBy2()
        {
            maxDice /= 2;

            int rnd = Random.Range(minDice, maxDice);

            Assert.That(rnd, Is.GreaterThan(0), "Dice tthrow is bigger than 0, It is: " + rnd);
            Assert.That(rnd, Is.LessThan(4), "Dice tthrow is less than 3, It is: " + rnd);
        }

        [Test]
        public void Should_Succeed_WhenThrowningADiceWithTimes2Multipler()
        {
            minDice *= 2;
            maxDice *= 2;

            int rnd = Random.Range(minDice, maxDice);

            Assert.That(rnd, Is.GreaterThan(1), "Dice tthrow is bigger than 2, It is: " + rnd);
            Assert.That(rnd, Is.LessThan(13), "Dice tthrow is less than 12, It is: " + rnd);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator DiceTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
