using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Vector2 MovementInput {get; private set;}
    public static Action OnInteractionEvent;
    public static Action OnRunningEvent;
    
    [SerializeField] private InputActionReference movementAction;
    [SerializeField] private InputActionReference interactAction;
    [SerializeField] private InputActionReference runAction;

    private void OnEnable()
    {
        movementAction.action.Enable();
        interactAction.action.Enable();
        runAction.action.Enable();
    }

    private void Update()
    {
        MovementInput = movementAction.action.ReadValue<Vector2>();
        if (runAction.action.WasPerformedThisFrame())
            OnRunningEvent?.Invoke();
        
        if (interactAction.action.WasPerformedThisFrame())
            OnInteractionEvent?.Invoke();
    }

    private void OnDisable()
    {
        movementAction.action.Disable();
        interactAction.action.Disable();
        runAction.action.Disable();
    }
}
