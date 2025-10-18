using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleSystem : MonoBehaviour
{
    public enum EncounterState 
    {
        None,
        Start,
        PlayerAction,
        PlayerMove,
        EnemyTurn,
        Busy,
        Won,
        Lost
    }
    public EncounterState encounterState = EncounterState.None;
    
    [SerializeField] private EncounterUI encounterUI;
    [SerializeField] private BattleUnit playerUnit;
    [SerializeField] private BattleUnit enemyUnit;
    
    private ActionSlot[] actionSlots;
    private MoveSlot[] moveSlots;
    
    public Action OnBattleStart;

    private void OnEnable()
    {
        actionSlots = encounterUI.BattleDialogBox.ActionSelector.GetComponentsInChildren<ActionSlot>();
        foreach (var slot in actionSlots)
        {
            slot.OnActionOptionClicked += ActionSelected;
        }
        moveSlots = encounterUI.BattleDialogBox.MoveSelector.GetComponentsInChildren<MoveSlot>();
        foreach (var slot in moveSlots)
        {
            slot.OnMoveSlotOptionClicked += MoveSelected;
        }
    }

    private void BattleStart()
    {
        StartCoroutine(SetUpBattle());
        OnBattleStart?.Invoke();
    }

    private IEnumerator SetUpBattle()
    {
        playerUnit.SetUp();
        enemyUnit.SetUp();
        encounterUI.SetPlayerData(playerUnit.Pokemon);
        encounterUI.SetEnemyData(enemyUnit.Pokemon);
        
        encounterUI.BattleDialogBox.SetMoves(playerUnit.Pokemon.Moves);
        
        yield return encounterUI.BattleDialogBox.TypeDialog("A wild " + enemyUnit.Pokemon.Base.name + " appeared!");
        yield return new WaitForSeconds(1f);

        PlayerTurn();
    }

    private void ActionSelected(ActionSlot.ActionOptions actionOption)
    {
        switch (actionOption)
        {
            default:
            case ActionSlot.ActionOptions.Fight:
                PlayerMove();
                break;
            case ActionSlot.ActionOptions.Bag:
                OpenBag();
                break;
            case ActionSlot.ActionOptions.Pokemon:
                OpenPokemon();
                break;
            case ActionSlot.ActionOptions.Run:
                RunAway();
                break;
        }
    }
    
    private void MoveSelected(MoveSlot.MoveOptions moveOptions)
    {
        switch (moveOptions)
        {
            default:
            case MoveSlot.MoveOptions.Slot1:
                break;
            case MoveSlot.MoveOptions.Slot2:
                break;
            case MoveSlot.MoveOptions.Slot3:
                break;
            case MoveSlot.MoveOptions.Slot4:
                break;
        }
    }

    private void PlayerTurn()
    {
        EventSystem.current.SetSelectedGameObject(actionSlots[0].gameObject);
        
        encounterState = EncounterState.PlayerAction;
        encounterUI.BattleDialogBox.EnableActionSelector(true);
    }
    
    private void PlayerMove()
    {
        EventSystem.current.SetSelectedGameObject(moveSlots[0].gameObject);
        
        encounterState = EncounterState.PlayerMove;
        encounterUI.BattleDialogBox.EnableActionSelector(false);
        encounterUI.BattleDialogBox.EnableDialogText(false);
        encounterUI.BattleDialogBox.EnableMoveSelector(true);
    }
    
    private void OpenBag()
    {
        
    }

    private void OpenPokemon()
    {
        
    }
    
    private void RunAway()
    {
        
    }
}
