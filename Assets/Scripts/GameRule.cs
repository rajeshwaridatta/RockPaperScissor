using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRule : MonoBehaviour
{
    private Dictionary<string, List<ItemAction>> itemToWinListMap = new Dictionary<string, List<ItemAction>>(){
    {"rock", new List<ItemAction> {new ItemAction("scissor","crushes"), new ItemAction("lizard", "crushes") }},

    {"paper", new List<ItemAction> {new ItemAction("rock","covers"), new ItemAction("spock", "disproves") }},

    {"scissor", new List<ItemAction> {new ItemAction("paper","cuts"), new ItemAction("lizard", "decapitates") }},

    {"lizard", new List<ItemAction> {new ItemAction("paper","eats"), new ItemAction("spock", "poisons") }},

    {"spock", new List<ItemAction> {new ItemAction("rock","vaporises"), new ItemAction("scissor", "smashes") }}
};


    private string winActionPhrase;
    private string loseActionPhrase;
    public bool IfFirstWinsOverSecond(GameInputChoices playerChoice, GameInputChoices botChoice)
    {
        string botChoiceValue = botChoice.ToString();
        string playerChoiceKey = playerChoice.ToString();
        
        List <ItemAction> winList = itemToWinListMap[playerChoiceKey];
        foreach (ItemAction  item in winList)
        {
            if (item.itemName == botChoiceValue)
            {
                winActionPhrase = playerChoiceKey +" " + item.action + " " + botChoiceValue;
                GamePlayController.Instance.uiController.winInfoText.text = winActionPhrase;
                return true;
            }
        }
        List<ItemAction> loseList = itemToWinListMap[botChoiceValue];
        foreach (ItemAction item in loseList)
        {
            if (item.itemName == playerChoiceKey)
            {
                loseActionPhrase = botChoiceValue + " " + item.action + " " + playerChoiceKey;
                GamePlayController.Instance.uiController.loseInfoText.text = loseActionPhrase;
                return false;
            }
        }

        return false;

    }
    public string GetTheWinPhrase(bool playerWon)
    {

        if(playerWon)
        {
            return winActionPhrase;
        }
        return loseActionPhrase;

    }
}
public class ItemAction
{
    public string itemName { get; set; }
    public string action { get; set; }
    public ItemAction(string _itemName, string _action)
    {
        itemName = _itemName;
        action = _action;
    }
}