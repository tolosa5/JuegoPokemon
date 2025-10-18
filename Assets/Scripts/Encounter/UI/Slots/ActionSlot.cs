using System;
using UnityEngine;
using UnityEngine.UI;

public class ActionSlot : MonoBehaviour
{
    public Action<ActionOptions> OnActionOptionClicked;
    private Button myButton;

    public enum ActionOptions
    {
        Fight,
        Bag,
        Pokemon,
        Run
    }
    public ActionOptions actionOption;

    protected void Awake()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(Click);
    }

    private void Click()
    {
        OnActionOptionClicked?.Invoke(actionOption);
    }

    private void OnDestroy()
    {
        myButton.onClick.RemoveListener(Click);
    }
}
