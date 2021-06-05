using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image playerChoiceImg;
    public Image botChoiceImage;
    public Sprite choiceDefaultImg;
    public Text playerScore;
    public GameObject gameOverPanel;
    public Text loseInfoText;
    public GameObject winPanel;
    public Text winInfoText;
    public Slider timerFg;
   
    public void UpdatePlayerScoreUI(int score)
    {
        playerScore.text = score.ToString();   
    }
    public void SetPlayerChoiceUI(GameInputChoices choices)
    {
        playerChoiceImg.sprite = GamePlayController.Instance.choiceItemArr[(int)choices-1].itemImage;
    }
    public void SetBotChoiceUI(GameInputChoices choices)
    {
        botChoiceImage.sprite = GamePlayController.Instance.choiceItemArr[(int)choices-1].itemImage;
    }
    public void SetPlayerWinUI()
    {
        GamePlayController.Instance.playerWins = false;
        winPanel.SetActive(true);
        StartCoroutine(RemoveWinPanel());  
    }
    public void SetBotWinUI()
    {
        GamePlayController.Instance.playerWins = false;
        gameOverPanel.SetActive(true);  
    }
    IEnumerator RemoveWinPanel()
    {
        yield return new WaitForSeconds(1.5f);
        winPanel.SetActive(false);
        playerChoiceImg.sprite = choiceDefaultImg;
        botChoiceImage.sprite = choiceDefaultImg;
    }
    public void RemoveGameOverPanel()
    {
        gameOverPanel.SetActive(false);
        playerChoiceImg.sprite = choiceDefaultImg;
        botChoiceImage.sprite = choiceDefaultImg;
    }
    public void SetTimerUI(float progress, float maxtime)
    {
        timerFg.value = Mathf.Lerp(0, 1, maxtime - progress);
    }
    public void ResetTimerUI()
    {
        timerFg.value = 0;
    }
    public void InactivePlayerButton(bool on, ChoiceItem[] arr)
    {
        foreach (ChoiceItem item in arr)
        {
            if (on)
            {
                item.GetComponent<Button>().interactable = true;
            }
            else
            {
                item.GetComponent<Button>().interactable = false;
            }
        }
    }

}
