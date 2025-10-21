using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] private float letterPace = 60;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private GameObject actionSelector;
    [SerializeField] private GameObject moveSelector;
    [SerializeField] private GameObject moveDetails;
    
    [SerializeField] private List<TextMeshProUGUI> actionTexts;
    [SerializeField] private List<TextMeshProUGUI> moveTexts;
    
    [SerializeField] private TextMeshProUGUI ppText;
    [SerializeField] private TextMeshProUGUI typeText;
    
    public GameObject ActionSelector => actionSelector;
    public GameObject MoveSelector => moveSelector;

    public Action<int, Move> OnMoveSetEvent;
    
    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }
    
    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1 / letterPace);
        }
    }
    
    public void SetMoves(List<Move> moves)
    {
        for (int i = 0; i < moveTexts.Count; i++)
        {
            moveTexts[i].text = i < moves.Count ? 
                    moves[i].Base.name : "-";
            
            OnMoveSetEvent?.Invoke(i, moves[i]);
        }
    }
    
    public void SetMoveDetails(Move move)
    {
        ppText.text = $"PP {move.CurrentPP}/{move.Base.PP}";
        typeText.text = move.Base.MoveType.ToString();
    }
    
    public void EnableDialogText(bool enabled)
    {
        dialogText.enabled = enabled;
    }
    
    public void EnableActionSelector(bool enabled)
    {
        actionSelector.SetActive(enabled);
    }
    
    public void EnableMoveSelector(bool enabled)
    {
        moveSelector.SetActive(enabled);
        moveDetails.SetActive(enabled);
    }
}
