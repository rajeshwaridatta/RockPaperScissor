using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameInputChoices
{
    none,
    rock,
    paper,
    scissor,
    lizard,
    spock
}
public class GamePlayController : MonoBehaviour
{
    #region private variables
    private static GamePlayController instance;
    GameInputChoices inputChoices;
    [SerializeField]
    private  int playerScore;
    [SerializeField]
    private BotHandler botHandler;
    [SerializeField]
    private PlayerHandler playerHandler;
    [SerializeField]
    private Timer timer;


    #endregion

    #region public variables
    public static GamePlayController Instance { get { return instance; } }
    public UIController uiController;
    public ChoiceItem[] choiceItemArr;
    public GameRule gameRule;
    
    public GameInputChoices playerChoice = GameInputChoices.none, botChoice = GameInputChoices.none;
    public bool playerWins;

    public bool playerInputGiven;
    #endregion

    
        #region Unity methods
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
       
    }
   
    private void OnEnable()
    {
        Timer.onTimerOver += CheckOnTimerOver;
      
    }
    private void OnDisable()
    {
        Timer.onTimerOver -= CheckOnTimerOver;

    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        inputChoices = GameInputChoices.none;
        playerWins = false;
        playerInputGiven = false;
        InitPlayerScore();
        uiController.InactivePlayerButton(false, choiceItemArr);
        Invoke("StartTheGame", 2);
    }

    private void Update()
    {
        //handling back button in android
        if (Input.GetKey(KeyCode.Escape))
        {
            LoadMainScene();
        }
    }

    #endregion

    
    private void InitPlayerScore()
    {
        uiController.UpdatePlayerScoreUI(playerScore);           
    }
 
   public void SetPlayerChoices()
    {
        uiController.SetPlayerChoiceUI(playerChoice);     
        WinLogic();
    }
    public void StartTheGame()
    {
        botHandler.SetBotChoice();
        uiController.SetBotChoiceUI(botChoice);
        timer.timerIsRunning = true;
        uiController.InactivePlayerButton(true, choiceItemArr);
    }
    public void CheckOnTimerOver()
    {
        if(!playerInputGiven )
        {
            GamePlayController.Instance.uiController.loseInfoText.text = "Out of time! Try again";
            ResetGameSession();
            return;
            
        }
        playerInputGiven = false;
    }
    private void WinLogic()
    {
        if (playerChoice == botChoice)
        {
            PlayerWinSituation();
            GamePlayController.Instance.uiController.winInfoText.text = "Its a Draw!!";
            return;
        }
       if(gameRule.IfFirstWinsOverSecond(playerChoice,botChoice) )
        {
            PlayerWinSituation();
        }
        else
        {
             ResetGameSession();
        }
    }
    private void PlayerWinSituation()
    {
        UpdatePlayerScore();
        playerWins = true;
        uiController.InactivePlayerButton(false, choiceItemArr);
        Invoke("StartTheGame", 2);
        uiController.SetPlayerWinUI();
    }
    private void UpdatePlayerScore()
    {
        playerScore++;
        uiController.UpdatePlayerScoreUI(playerScore);
        if(PlayerPrefs.GetInt("highscore") < playerScore)
        {
            PlayerPrefs.SetInt("highscore", playerScore);
            PlayerPrefs.Save();
        }
    }
    private void ResetGameSession()
    {
        // take back to Main page
        playerWins = false;
        uiController.SetBotWinUI();
        StartCoroutine(GameOver());
    }
    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2);
        uiController.RemoveGameOverPanel();
        LoadMainScene();
    }
    public void LoadMainScene()
    {
        SceneManager.LoadSceneAsync("main");
    }
}
