using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public void SetBotChoice()
    {
        int randomNum = Random.Range(0, 4);
        switch (randomNum)
        {
            case 0:
                GamePlayController.Instance.botChoice = GameInputChoices.rock;
                break;
            case 1:
                GamePlayController.Instance.botChoice = GameInputChoices.paper;
                break;
            case 2:
                GamePlayController.Instance.botChoice = GameInputChoices.scissor;
                break;
            case 3:
                GamePlayController.Instance.botChoice = GameInputChoices.lizard;
                break;
            case 4:
                GamePlayController.Instance.botChoice = GameInputChoices.spock;
                break;
        }
    }
}
