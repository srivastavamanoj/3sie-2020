using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpectatingAPI : MonoBehaviour
{
    SpectatingAPISoccer specApi;

    
    void Start()
    {
        specApi = GameObject.Find("SpectatingAPI").GetComponent<SpectatingAPISoccer>();

        // Subscribe to events on spectating API 
        SubscribeToAPIEvents();
    }


    private void OnDisable()
    {
        UnsubscribeToAPIEvents();
    }


    private void SubscribeToAPIEvents()
    {
        SpectatingAPISoccer.goalEvent += TestOnGoal;
        SpectatingAPISoccer.firstHalfStartedEvent += TestOnFirstHalfStarted;
        SpectatingAPISoccer.secondHalfStartedEvent += TestOnSecondHalfStarted;
        SpectatingAPISoccer.matchFinishedEvent += TestOnMatchFinished;
        SpectatingAPISoccer.throwInEvent += TestOnThrowIn;
        SpectatingAPISoccer.cornerEvent += TestOnCorner;
        SpectatingAPISoccer.passEvent += TestOnPass;
        SpectatingAPISoccer.shootEvent += TestOnShoot;
    }


    private void UnsubscribeToAPIEvents()
    {
        SpectatingAPISoccer.goalEvent -= TestOnGoal;
        SpectatingAPISoccer.firstHalfStartedEvent -= TestOnFirstHalfStarted;
        SpectatingAPISoccer.secondHalfStartedEvent -= TestOnSecondHalfStarted;
        SpectatingAPISoccer.matchFinishedEvent -= TestOnMatchFinished;
        SpectatingAPISoccer.throwInEvent -= TestOnThrowIn;
        SpectatingAPISoccer.cornerEvent -= TestOnCorner;
        SpectatingAPISoccer.passEvent -= TestOnPass;
        SpectatingAPISoccer.shootEvent -= TestOnShoot;
    }


    #region Testing Event Callbacks
    private void TestOnGoal()
    {
        GameObject aPlayer = specApi.GetLastPlayerWithBall();

        Debug.Log("A Goal was just scored... 000");
        Debug.Log("The name of the player that score is: " + aPlayer.name);
    }   


    private void TestOnFirstHalfStarted()
    {
        Debug.Log("First half started... 111");
    }


    private void TestOnSecondHalfStarted()
    {
        Debug.Log("Second half started... 222");
    }


    private void TestOnMatchFinished()
    {
        Debug.Log("Match has finished... 333");
    }


    private void TestOnThrowIn()
    {
        Debug.Log("Throw in event... 444");
    }


    private void TestOnCorner()
    {
        Debug.Log("Corner kick or goal kick event... 555");
    }


    private void TestOnPass()
    {
        //Debug.Log("A pass was made... 66");
    }


    private void TestOnShoot()
    {
        //Debug.Log("A shoot was made... 777");
    }

    #endregion
}
