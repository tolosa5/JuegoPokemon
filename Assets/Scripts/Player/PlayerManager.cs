using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    private PlayerMovement playerMovement;
    private PlayerInteraction playerInteraction;
    
    [SerializeField] private LayerMask grassLayer;
    
    public Action OnWildEncounter;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SystemsInitializer();
    }

    private void SystemsInitializer()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInteraction = GetComponent<PlayerInteraction>();
        
        EventCatcher();
    }
    
    private void HandleEncounterCheck()
    {
        RaycastHit hit;
        if (Physics2D.OverlapCircle(transform.position, .2f, grassLayer))
        {
            float encounterChance = UnityEngine.Random.Range(0f, 1f);
            if (!(encounterChance <= (Utils.encounterRate / 100))) // 8% chance
                return; 
            
            Debug.Log("A wild encounter has started!");
            OnWildEncounter?.Invoke();
        }
    }

    private void EventCatcher()
    {
        playerMovement.OnEncounterCheckEvent += HandleEncounterCheck;
    }
}
