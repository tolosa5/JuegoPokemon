using System;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{
    public BattleSystem.EncounterState encounterState = BattleSystem.EncounterState.None;
    private BattleSystem battleSystem = null;

    private void OnEnable()
    {
        //battleSystem = FindAnyObjectByType(BattleSystem battleSystem)
    }
}
