using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpectatingAPI : MonoBehaviour
{
    SpectatingAPISoccer specApi;

    
    void Start()
    {
        specApi = GameObject.Find("SpectatingAPI").GetComponent<SpectatingAPISoccer>();

        // Subscription to events on spectating API 
        SpectatingAPISoccer.goalEvent += TestOnGoal;
        SpectatingAPISoccer.passEvent += TestOnPass;
        SpectatingAPISoccer.shootEvent += TestOnShoot;
        SpectatingAPISoccer.firstHalfStartedEvent += TestOnFirstHalfStarted;
        SpectatingAPISoccer.secondHalfStartedEvent += TestOnSecondHalfStarted;
        SpectatingAPISoccer.matchFinishedEvent += TestOnMatchFinished;
    }

    
    void Update()
    {
        
    }


    private void TestOnGoal()
    {
        GameObject aPlayer = specApi.GetLastPlayerWithBall();

        Debug.Log("A Goal was just scored... 000");
        Debug.Log("The name of the player that score is: " + aPlayer.name);
    }


    private void TestOnPass()
    {
        //Debug.Log("A pass was made... 111");
    }


    private void TestOnShoot()
    {
        //Debug.Log("A shoot was made... 222");
    }


    private void TestOnFirstHalfStarted()
    {
        Debug.Log("First half started...");
    }


    private void TestOnSecondHalfStarted()
    {
        Debug.Log("Second half started...");
    }


    private void TestOnMatchFinished()
    {
        Debug.Log("Match has finished...");
    }
}
