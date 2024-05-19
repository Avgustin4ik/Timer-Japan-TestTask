using System;
using System.Collections;
using System.Collections.Generic;
using Code.Core;
using Code.Core.Models;
using Code.Core.Panel.View;
using Code.Core.Views;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

public class TimerTestScript
{
    private TimerModel _timer;

    [SetUp]
    public void Setup()
    {
        _timer = new TimerModel();
    }

    #region editor

    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScriptSimplePasses()
    {
        _timer = new TimerModel();
        // Use the Assert class to test conditions
        Assert.That(_timer.IsElapsed.Value, Is.False);
    }

    [Test]
    public void TimerGetRightValue()
    {
        //act
        var delay = 2;
        var setTime = TimeSpan.FromSeconds(delay);
        _timer.Run(setTime);
        //assert
        Assert.IsTrue(_timer.IsElapsed.Value == false);
    }

    [Test]
    public void TimerWithoutInput()
    {
        _timer.Run();
        Assert.AreEqual(TimeSpan.Zero.TotalSeconds, _timer.GetCurrentTime().TotalSeconds, 0.005d);
    }

    [Test]
    public void TimerWrongInput()
    {
        var wrongInput = -2399f;
        var seconds = TimeSpan.FromSeconds(wrongInput);
        _timer.Run(seconds);
        Assert.AreEqual(TimeSpan.Zero.TotalSeconds, _timer.GetCurrentTime().TotalSeconds, 0.005d);
    }

    #endregion

    #region runtime

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.

    [UnityTest]
    public IEnumerator WaitExactTimeOnTimer()
    {
        //act
        var delay = 2;
        var setTime = TimeSpan.FromSeconds(delay);
        _timer.Run(setTime);
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(delay);
        //assert
        Assert.AreEqual(TimeSpan.Zero.TotalSeconds, _timer.GetCurrentTime().TotalSeconds, 0.005d);
    }

    [UnityTest]
    public IEnumerator WaitLongerThanTimer()
    {
        //act
        var delay = 2;
        var setTime = TimeSpan.FromSeconds(delay);
        _timer.Run(setTime);

        var offset = 1;
        yield return new WaitForSeconds(delay + offset);
        //assert
        Assert.IsTrue(_timer.IsElapsed.Value);
    }


    [UnityTest]
    public IEnumerator WaitShorterThanTimer()
    {
        //act
        var delay = 2;
        var setTime = TimeSpan.FromSeconds(delay);
        _timer.Run(setTime);
        var offset = 1;
        yield return new WaitForSeconds(delay - offset);
        //assert
        Assert.IsFalse(_timer.IsElapsed.Value);
    }

    #endregion
}

public class StopWatchTest
{
    private StopwatchModel _stopwatch;

    [SetUp]
    public void Setup()
    {
        _stopwatch = new StopwatchModel();
    }

    #region editor

    [Test]
    public void StopWatchGetRightValue()
    {
        //act
        _stopwatch.Run();
        _stopwatch.LapStopwatch();
        //assert
        Assert.AreEqual(TimeSpan.Zero.TotalSeconds, _stopwatch.GetLapTimes()[^1].Global, 0.005d);
    }


    [Test]
    public void ResetAfterFewRuns()
    {
        //act
        _stopwatch.Run();
        _stopwatch.LapStopwatch();
        _stopwatch.LapStopwatch();
        _stopwatch.LapStopwatch();
        _stopwatch.LapStopwatch();

        _stopwatch.Reset();
        //assert
        Assert.AreEqual(0, _stopwatch.GetLapTimes().Count);
    }

    #endregion

    #region runtime

    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.

    [UnityTest]
    public IEnumerator WaitExactTimeOnStopwatchAndCompare()
    {
        //act
        var delay = 2;
        _stopwatch.Run();
        yield return new WaitForSeconds(delay);
        //assert
        Assert.AreEqual(TimeSpan.FromSeconds(delay).TotalSeconds, _stopwatch.GetCurrentTime().TotalSeconds, 0.005d);
    }

    [UnityTest]
    public IEnumerator WaitLongerThanStopwatch()
    {
        //act
        var delay = 2;
        _stopwatch.Run();
        yield return new WaitForSeconds(delay);
        _stopwatch.LapStopwatch();
        var offset = 1;
        yield return new WaitForSeconds(delay + offset);
        //assert
        Assert.IsTrue(_stopwatch.GetCurrentTime().TotalSeconds > delay);
    }

    [UnityTest]
    public IEnumerator LapStopwatch()
    {
        //act
        var delay = 2;
        _stopwatch.Run();
        yield return new WaitForSeconds(delay);
        _stopwatch.LapStopwatch();
        var offset = 1;
        yield return new WaitForSeconds(delay);
        _stopwatch.LapStopwatch();
        //assert
        Assert.AreEqual(2, _stopwatch.GetLapTimes().Count);
    }

    [UnityTest]
    public IEnumerator ResetStopwatch()
    {
        //act
        var delay = 2;
        _stopwatch.Run();
        yield return new WaitForSeconds(delay);
        _stopwatch.LapStopwatch();
        var offset = 1;
        yield return new WaitForSeconds(delay);
        _stopwatch.LapStopwatch();
        _stopwatch.Reset();
        //assert
        Assert.AreEqual(0, _stopwatch.GetLapTimes().Count);
    }

    #endregion
}