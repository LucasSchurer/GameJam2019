using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public int playerNumber;
    public Image mainAbility;
    public Image secondaryAbility;
    private UIController controllerUI;

    private PlayerInfo playerInfo;
    private bool hasSecondaryAbility;

    // Start is called before the first frame update
    void Start()
    {
        controllerUI = GetComponentInParent<UIController>();
        playerInfo = controllerUI.playerInfo;

        UpdateMainAbility();

        if (playerInfo.players[playerNumber].availableActions.x != playerInfo.players[playerNumber].availableActions.y)
        {
            hasSecondaryAbility = true;
            UpdateSecondaryAbility();
        } 
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMainAbility();

        if (hasSecondaryAbility)
            UpdateSecondaryAbility();
    }

    private void UpdateMainAbility()
    {
        mainAbility.sprite = controllerUI.returnAbilitySprite((int)playerInfo.players[playerNumber].currentAction);
    }
    
    private void UpdateSecondaryAbility()
    {
        secondaryAbility.sprite = 
            controllerUI.returnAbilitySprite(
                (int)playerInfo.players[playerNumber].availableActions.x 
                == (int)playerInfo.players[playerNumber].currentAction 
                ? (int)playerInfo.players[playerNumber].availableActions.y 
                : (int)playerInfo.players[playerNumber].availableActions.x);
    }
}
