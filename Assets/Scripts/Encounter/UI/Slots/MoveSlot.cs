using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MoveSlot : MonoBehaviour
{
    public Action<MoveOptions> OnMoveSlotOptionClicked;
    private Button myButton;

    public enum MoveOptions
    {
        Slot1,
        Slot2,
        Slot3,
        Slot4
    }
    public MoveOptions moveOptions;

    protected void Awake()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(Click);
    }

    private void Click()
    {
        OnMoveSlotOptionClicked?.Invoke(moveOptions);
    }

    private void OnDestroy()
    {
        myButton.onClick.RemoveListener(Click);
    }
}
