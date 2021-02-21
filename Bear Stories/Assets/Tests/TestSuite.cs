using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


//tutorial:
//https://www.raywenderlich.com/9454-introduction-to-unity-unit-testing

namespace Tests
{

    //WRITE TESTS HERE, use assert to test if things are working correctly
    //how do I know what kinds of things work correctly?  Great question, I don't know right now.
    //just keep practicing, this is a really good start!


    //example tests:
    //formatting the storybox
    //somehting with voice lines?
    //translating the book text
    //transistioning the voicelines between languages
    //animation stuff?
    //resizing the dropdowns
    //checking if we are at the end of book
    //checking if we are at the beginning of book

    public class TestSuite
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestSuiteSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestSuiteWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
