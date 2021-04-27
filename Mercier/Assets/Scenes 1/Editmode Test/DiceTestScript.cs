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

        [SetUp]
        public void SetUp()
        {
             rnd = new Random();
        }

        // A Test behaves as an ordinary method
        [Test]
        public void Should_Succeed_When_TrowhingADice()
        {
            
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
