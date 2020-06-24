using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class SpectatingAPISoccer : MonoBehaviour
{

    public struct MatchTimer
    {
        public int mins;
        public int secs;
    }

    private InGame inGame;
    private ScorerTimeHUD scorerTimeHUD;
    private GameObject ball;
    private Ball ballScript;
    
    // Delegates and events
    public delegate void OnGoalDelegate();    
    public delegate void OnPassDelegate();
    public delegate void OnShootDelegate();
    public delegate void OnFirstHalfStartedDelegate();
    public delegate void OnSecondHalfStartedDelegate();
    public delegate void OnMatchFinishedDelegate();
    public delegate void OnThrowInDelegate();
    public delegate void OnCornerDelegate();

    public static event OnGoalDelegate goalEvent;
    public static event OnPassDelegate passEvent;
    public static event OnShootDelegate shootEvent;
    public static event OnFirstHalfStartedDelegate firstHalfStartedEvent;
    public static event OnSecondHalfStartedDelegate secondHalfStartedEvent;
    public static event OnMatchFinishedDelegate matchFinishedEvent;
    public static event OnThrowInDelegate throwInEvent;
    public static event OnCornerDelegate cornerEvent;


    void Start()
    {
        inGame = GameObject.Find("GameManager").GetComponent<InGame>();
        scorerTimeHUD = GameObject.Find("Time").GetComponent<ScorerTimeHUD>();
        ball = GameObject.Find("soccer_ball");
        ballScript = ball.GetComponent<Ball>();

        //Subscribe to different events 
        SubscribeToEvents();
    }


    private void OnDisable()
    {
        UnsubscribeToEvents();
    }


    private void SubscribeToEvents()
    {
        Goal.goalEvent += OnGoal;
        InGame.firstHalfStartedEvent += OnFirstHalfStarted;
        InGame.secondHalfStartedEvent += OnSecondHalfStarted;
        InGame.matchFinishedEvent += OnMatchFinished;
        Side.throwInEvent += OnThrowIn;
        Corner.cornerEvent += OnCorner;
        Player.passEvent += OnPass;
        Player.shootEvent += OnShoot;
    }


    private void UnsubscribeToEvents()
    {
        Goal.goalEvent -= OnGoal;
        InGame.firstHalfStartedEvent -= OnFirstHalfStarted;
        InGame.secondHalfStartedEvent -= OnSecondHalfStarted;
        InGame.matchFinishedEvent -= OnMatchFinished;
        Side.throwInEvent -= OnThrowIn;
        Corner.cornerEvent -= OnCorner;
        Player.passEvent -= OnPass;
        Player.shootEvent -= OnShoot;
    }


    #region Accessing Game Data
    // Returns the state of the game
    public InGame.InGameState GetGameState()
    {
        return inGame.state;
    }


    // Returns the elapsed time of the soccer match in seconds (increases as time passes)
    public float GetMatchElapsedTime()
    {
        return scorerTimeHUD.timeMatch;
    }


    // Returns a structure wiht the time of the match (minutes and seconds)
    public void GetMatchClock()
    {
        MatchTimer matchTimer = new MatchTimer();
        matchTimer.mins = scorerTimeHUD.minutes;
        matchTimer.secs = scorerTimeHUD.seconds;
    }


    // Returns the number of goals by the visiting team (team 2)
    public int GetScoreVisitingTeam()
    {
        return inGame.scoreVisiting;
    }


    // Returns the number of goals by the local team (team 1)
    public int GetScoreLocalTeam()
    {
        return inGame.scoreVisiting;
    }


    // Returns a number that represents the half of the match (0 = match not started; 1 = first half; 2 = second half)
    public int GetMatchHalf()
    {
        return inGame.firstHalf;
    }


    // Returns the ball transform (position, rotation and game object can be obtained from the transform)
    public Transform GetBallTransform()
    {
        return ball.transform;
    }


    // Returns game object of player who last touched the ball
    public GameObject GetLastPlayerWithBall()
    {
        return inGame.lastTouched.gameObject;
    }


    // Returns game object of player that currently owns the ball or null if nobody owns the ball
    public GameObject GetBallOwner()
    {
        return Ball.owner.gameObject;
    }
    #endregion


    #region Game Event Callbacks
    private void OnGoal()
    {
        goalEvent();
    }   


    private void OnFirstHalfStarted()
    {
        firstHalfStartedEvent?.Invoke();
    }


    private void OnSecondHalfStarted()
    {
        secondHalfStartedEvent?.Invoke();
    }


    private void OnMatchFinished()
    {
        matchFinishedEvent?.Invoke();
    }


    private void OnCorner()
    {
        cornerEvent?.Invoke();
    }


    private void OnThrowIn()
    {
        throwInEvent?.Invoke();
    }


    private void OnPass()
    {
        passEvent?.Invoke();
    }


    private void OnShoot()
    {
        shootEvent?.Invoke();
    }

    #endregion
}
