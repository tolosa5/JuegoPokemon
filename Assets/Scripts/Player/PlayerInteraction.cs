using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform interactTransform;
    [SerializeField] private LayerMask layerMask;
    
    private void OnEnable()
    {
        InputManager.OnInteractionEvent += HandleInteraction;
    }
    
    private void HandleInteraction()
    {
        // Implement interaction logic here
        IInteractable interactable = GetInteractableObject();
        interactable?.Interact();
        Debug.Log("Player interacted with an object.");
    }
    
    private IInteractable GetInteractableObject()
    {
        Collider[] interactableColls = Physics.OverlapSphere(
            interactTransform.position, 0.5f, layerMask);

        if (interactableColls.Length <= 0) 
            return null;
        
        return interactableColls[0].gameObject.TryGetComponent(
            out IInteractable interactable) ? interactable : null;
    }

    private void OnDisable()
    {
        InputManager.OnInteractionEvent -= HandleInteraction;
    }
}
