using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GreenTileTestScript
    {
        // A Test behaves as an ordinary method
        [Test]
        public void GreenTileTestScriptSimplePasses()
        {
            PlayerGroup player = new PlayerGroup();

            Assert.AreEqual(0, player.CurrentMoneyAmount, "Players money is not equal to 0");

            player.GiveMoney(3);

            Assert.AreEqual(3, player.CurrentMoneyAmount, "Players money is not equal to 3");
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator GreenTileTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
