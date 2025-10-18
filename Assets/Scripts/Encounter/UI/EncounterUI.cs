using TMPro;
using UnityEngine;

public class EncounterUI : MonoBehaviour
{
    [System.Serializable]
    public class EntityData
    {
        [SerializeField] public TextMeshProUGUI nameText;
        [SerializeField] public TextMeshProUGUI lvlText;
        [SerializeField] public HPBar hpBar;
    }
    [SerializeField] public EntityData playerData;
    [SerializeField] public EntityData enemyData;
    
    [Space(10)]
    
    [SerializeField] private BattleDialogBox battleDialogBox;
    public BattleDialogBox BattleDialogBox => battleDialogBox;
    
    public void SetPlayerData(Pokemon pokemon)
    {
        playerData.nameText.text = pokemon.Base.name;
        playerData.lvlText.text = "Lvl " + pokemon.Level;
        playerData.hpBar.SetHp((float)pokemon.Hp / pokemon.MaxHp);
    }
    
    public void SetEnemyData(Pokemon pokemon)
    {
        enemyData.nameText.text = pokemon.Base.name;
        enemyData.lvlText.text = "Lvl " + pokemon.Level;
        enemyData.hpBar.SetHp((float)pokemon.Hp / pokemon.MaxHp);
    }
}
