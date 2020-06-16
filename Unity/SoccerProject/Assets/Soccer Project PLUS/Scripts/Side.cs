using UnityEngine;

public class Side : MonoBehaviour
{
    #region Public Fields

    public Ball ball;
    public InGame inGame;

    #endregion Public Fields

    #region Private Methods

    private void OnTriggerEnter(Collider other)
    {
        if (inGame.state == InGame.InGameState.PLAYING)
        {
            // Detect if Ball is outside
            if (other.gameObject.CompareTag("Ball") && inGame.state == InGame.InGameState.PLAYING)
            {
                Ball.owner = null;
                inGame.timeToChangeState = Globals.periodToChangeState;
                inGame.state = InGame.InGameState.THROW_IN;
                inGame.positionSide = ball.transform.position;
            }
            else
            {
                var player = other.GetComponent<Player>();
                if (player)
                {
                    if (player != Ball.owner)
                    {
                        player.temporallyUnselectable = true;
                        player.timeToBeSelectable = Globals.periodToBeSelectable;
                        player.animator.SetTrigger(Player.Run);
                        player.go_origin = true;
                    }
                }
            }
        }
    }

    // Use this for initialization
    private void Start()
    {
        ball = (Ball)GameObject.FindObjectOfType(typeof(Ball));
    }

    #endregion Private Methods
}