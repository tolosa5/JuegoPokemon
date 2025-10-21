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

    private GameObject selectedMoveSlot;
    
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

        encounterUI.BattleDialogBox.OnMoveSetEvent += SetMoveData;

        InputManager.OnNavigation += UpdateMoveSelection;
    }

    private void Start()
    {
        //Debug
        BattleStart();
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

        PlayerAction();
    }

    private void SetMoveData(int index, Move move)
    {
        moveSlots[index].SetMove(move);
    }

    private void UpdateMoveSelection(Vector2 pos)
    {
        selectedMoveSlot = EventSystem.current.currentSelectedGameObject;
        if (selectedMoveSlot.TryGetComponent(out MoveSlot moveSlot))
        {
            encounterUI.BattleDialogBox.SetMoveDetails(moveSlot.Move);
        }
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
    
    private void MoveSelected(MoveSlot.MoveOptions moveOptions, Move move)
    {
        encounterUI.BattleDialogBox.EnableMoveSelector(false);
        encounterUI.BattleDialogBox.EnableDialogText(true);

        StartCoroutine(PerformPlayerMove(move));
    }
    
    private IEnumerator PerformPlayerMove(Move move)
    {
        encounterState = EncounterState.Busy;
        
        yield return encounterUI.BattleDialogBox.TypeDialog(
            playerUnit.Pokemon.Base.name + " used " + move.Base.name);
        
        DamageDetails damageDetails = enemyUnit.Pokemon.TakeDamage(move, playerUnit.Pokemon);
        yield return encounterUI.UpdateHP(playerUnit.Pokemon, enemyUnit.Pokemon);
        yield return ShowDamageDetails(damageDetails);
        if (damageDetails.Fainted)
            yield return encounterUI.BattleDialogBox.TypeDialog(enemyUnit.Pokemon.Base.name + " fainted");
        else
            StartCoroutine(EnemyTurn());
    }
    
    private IEnumerator EnemyTurn()
    {
        //TO-DO: Enemy move selection and logic
        encounterState = EncounterState.EnemyTurn;
        Move move = enemyUnit.Pokemon.GetRandomMove();
        
        yield return encounterUI.BattleDialogBox.TypeDialog(
            enemyUnit.Pokemon.Base.name + " used " + move.Base.name);
        
        DamageDetails damageDetails = playerUnit.Pokemon.TakeDamage(move, playerUnit.Pokemon);
        yield return encounterUI.UpdateHP(playerUnit.Pokemon, enemyUnit.Pokemon);
        yield return ShowDamageDetails(damageDetails);
        if (damageDetails.Fainted)
            yield return encounterUI.BattleDialogBox.TypeDialog(playerUnit.Pokemon.Base.name + " fainted");
        else
            PlayerAction();
        
        //Return to player turn
        PlayerAction();
    }
    
    private IEnumerator ShowDamageDetails(DamageDetails damageDetails)
    {
        if (damageDetails.Critical > 1f)
            yield return encounterUI.BattleDialogBox.TypeDialog("A critical hit!");
        
        if (damageDetails.TypeEffectiveness > 1f)
            yield return encounterUI.BattleDialogBox.TypeDialog("It's super effective!");
        else if (damageDetails.TypeEffectiveness < 1f)
            yield return encounterUI.BattleDialogBox.TypeDialog("It's not very effective");
    }

    private void PlayerAction()
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
