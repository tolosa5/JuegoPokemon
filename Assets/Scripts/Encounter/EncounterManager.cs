using System;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{
    public BattleSystem.EncounterState encounterState = BattleSystem.EncounterState.None;
    private BattleSystem battleSystem = null;
    
    public BattleSystem BattleSystem => battleSystem;

    private void OnEnable()
    {
        SystemCatcher();
    }
    
    public void SystemCatcher()
    {
        battleSystem = FindAnyObjectByType<BattleSystem>();
    }

    public void BattleStart()
    {
        GameStatesManager.instance.SetGameState(GameState.Battle);
        battleSystem.BattleStart();
    }
}
