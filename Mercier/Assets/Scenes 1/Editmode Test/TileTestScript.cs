using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEditor.SceneManagement;
using System;
using System.Linq;

namespace Tests
{
    public class TileTestScript
    {

        [SetUp]
        public void SetUP()
        {
            //EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        }

        // A Test behaves as an ordinary method
        [Test]
        public void Should_Succeed_When_CheckingIfTilesHasStars()
        {
            var scene = EditorSceneManager.OpenScene(GetSceneNamePath("TileDesign"));

            List<GameObject> gameObjects = new List<GameObject>();
            List<object> objects = new List<object>();
            scene.GetRootGameObjects(gameObjects);

            bool noStar = false;
            string tileName = "";
            getDifferentTiles(gameObjects, objects);

            foreach(Transform child in objects)
            {
                if(child.name.Contains("Tiles"))
                {
                    foreach(Transform tiles in child)
                    {
                        var star = tiles.transform.Find("Star");
                        if (star == null)
                        {
                            noStar = true;
                            tileName = tiles.name;
                            break;
                        }
                    }
                }
            }
            Assert.AreEqual(false, noStar, $"A tile without a star has been found at: {tileName}");
        }

        private static void getDifferentTiles(List<GameObject> gameObjects, List<object> objects)
        {
            foreach (var gameObj in gameObjects)
            {
                if (gameObj.transform.childCount >= 5)
                {
                    foreach (object obj in gameObj.transform)
                    {
                        objects.Add(obj);
                    }
                }
            }
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TileTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }

        static string GetSceneNamePath(string sceneName)
        {
            //A quick function to search the scene path
            foreach (var scene in EditorBuildSettings.scenes)
            {
                if(scene.path.Contains(sceneName))
                {
                    return scene.path;
                }
            }

            //No need for fancy error handling
            //If its doesnt find the scene than it should return empty and fail
            return "";
        }
    }
}
