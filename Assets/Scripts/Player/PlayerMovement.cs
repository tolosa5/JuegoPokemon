using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private LayerMask solidItemsLayer;

    #region Animator Strings

    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string LastX = "LastX";
    private const string LastY = "LastY";
    private const string Running = "Running";

    #endregion
    
    [SerializeField] private float walkingSpeed = 3f;
    [SerializeField] private float runningSpeed = 5f;

    private float currentPlayerSpeed;
    private bool isMoving;
    private bool isRunning;
    private Vector2 movement;

    public Action OnEncounterCheckEvent;

    private void OnEnable()
    {
        InputManager.OnRunningEvent += HandleRunningMovement;
    }

    private void Start()
    {
        currentPlayerSpeed = walkingSpeed;
    }

    private void Update()
    {
        if (GameStatesManager.instance.CurrentGameState != GameState.Main)
            return;
        
        HandlePlaneMovement();
    }

    private void HandlePlaneMovement()
    {
        if (isMoving) 
            return;

        movement = InputManager.MovementInput;
        
        anim.SetFloat(Horizontal, movement.x);
        anim.SetFloat(Vertical, movement.y);

        if (movement.x != 0)
            movement.y = 0;

        if (movement == Vector2.zero) 
            return;
        
        anim.SetFloat(LastX, movement.x);
        anim.SetFloat(LastY, movement.y);
        
        Vector3 targetPos = transform.position;
        targetPos.x += movement.x;
        targetPos.y += movement.y;

        if (!IsWalkable(targetPos)) 
            return;
        
        Debug.Log("Walkable");
        StartCoroutine(Move(targetPos));
    }

    private void HandleRunningMovement()
    {
        isRunning = !isRunning;
        anim.SetBool(Running, isRunning);
        if (isRunning)
            StartRunning();
        else
            StopRunning();
    }

    private IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(
                transform.position, targetPos, currentPlayerSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        
        isMoving = false;
        
        OnEncounterCheckEvent();
    }
    
    private bool IsWalkable(Vector3 targetPos)
    {
        return Physics2D.OverlapCircle(targetPos, .2f, solidItemsLayer) == null;
    }

    private void StartRunning()
    {
        currentPlayerSpeed = runningSpeed;
    }
    
    private void StopRunning()
    {
        currentPlayerSpeed = walkingSpeed;
    }
    
    private void OnDisable()
    {
        InputManager.OnRunningEvent -= HandleRunningMovement;
    }
}
