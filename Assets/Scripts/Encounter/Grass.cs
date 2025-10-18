using System;
using UnityEngine;

public class Grass : MonoBehaviour
{
    [SerializeField] private float encounterRate = 8f; // 8% chance
    
    public Action OnWildEncounter;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float encounterChance = UnityEngine.Random.Range(0f, 1f);
            if (!(encounterChance <= (encounterRate / 100))) // 8% chance
                return; 
            
            Debug.Log("A wild encounter has started!");
            OnWildEncounter?.Invoke();
        }
    }
}
