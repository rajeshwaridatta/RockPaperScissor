using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public void DetermineInputOfPlayer(int i)
    {

        switch (i)
        {
            case 0:
                GamePlayController.Instance.playerChoice = GameInputChoices.rock;
                break;
            case 1:
                GamePlayController.Instance.playerChoice = GameInputChoices.paper;

                break;
            case 2:
                GamePlayController.Instance.playerChoice = GameInputChoices.scissor;

                break;
            case 3:
                GamePlayController.Instance.playerChoice = GameInputChoices.lizard;

                break;
            case 4:
                GamePlayController.Instance.playerChoice = GameInputChoices.spock;

                break;
        }
        GamePlayController.Instance.playerInputGiven = true;
        GamePlayController.Instance.SetPlayerChoices();
    }
}
