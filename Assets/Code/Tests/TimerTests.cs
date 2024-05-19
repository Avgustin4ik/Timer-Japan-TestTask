using System;
using System.Collections;
using System.Collections.Generic;
using Code.Core.Panel.View;
using Code.Core.Views;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

public class NewTestScript
{
 
    ScreenView _timerScreen;
    [SetUp]
    public void Setup()
    {
        _timerScreen = Object.Instantiate(Resources.Load<GameObject>("Content/Prefabs/Ui/Screens/Screen-Timer")).GetComponent<ScreenView>();
    }
    
    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        
        //act
        
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        //assert
        yield return null;
    }
}
