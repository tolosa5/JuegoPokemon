using System;
using UnityEngine;
using UnityEngine.UI;

public class PokemonSlot : MonoBehaviour
{
    public Action<PokemonOptions> OnPokemonOptionClicked;
    private Button myButton;

    public enum PokemonOptions
    {
        Pokemon1,
        Pokemon2,
        Pokemon3,
        Pokemon4,
        Pokemon5,
        Pokemon6
    }
    public PokemonOptions pokemonOption;

    protected void Awake()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(Click);
    }

    private void Click()
    {
        OnPokemonOptionClicked?.Invoke(pokemonOption);
    }

    private void OnDestroy()
    {
        myButton.onClick.RemoveListener(Click);
    }
}
