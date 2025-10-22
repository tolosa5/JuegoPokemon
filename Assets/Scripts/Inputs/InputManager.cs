using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Vector2 MovementInput {get; private set;}
    public static Action OnInteractionEvent;
    public static Action OnRunningEvent;
    public static Action<Vector2> OnNavigation;
    
    [SerializeField] private InputActionReference movementAction;
    [SerializeField] private InputActionReference interactAction;
    [SerializeField] private InputActionReference runAction;
    [SerializeField] private InputActionReference navigateAction;

    private void OnEnable()
    {
        movementAction.action.Enable();
        interactAction.action.Enable();
        runAction.action.Enable();
        navigateAction.action.Enable();
    }

    private void Update()
    {
        switch (GameStatesManager.instance.CurrentGameState)
        {
            default:
            case GameState.Main:
                MovementInput = movementAction.action.ReadValue<Vector2>();
                if (runAction.action.WasPerformedThisFrame())
                    OnRunningEvent?.Invoke();
                if (interactAction.action.WasPerformedThisFrame())
                    OnInteractionEvent?.Invoke();
                break;
            
            case GameState.Battle:
                if (navigateAction.action.WasPerformedThisFrame())
                {
                    Vector2 navigateValue = navigateAction.action.ReadValue<Vector2>();
                    OnNavigation?.Invoke(navigateValue);
                }
                break;
        }
    }
    
    /*
    public void SetInputMode(InputsMode inputsMode)
    {
        currentInputsMode = inputsMode;
        //Additional logic for different input modes can be added here
    }
    */

    private void OnDisable()
    {
        movementAction.action.Disable();
        interactAction.action.Disable();
        runAction.action.Disable();
        navigateAction.action.Disable();
    }
}
