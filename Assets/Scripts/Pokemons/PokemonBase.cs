using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PokemonBase", menuName = "Pokemons/New Pokemon")]
public class PokemonBase : ScriptableObject
{
    [Header("Basic Info")]
    [SerializeField] private int nationalPokedexNumber;
    [SerializeField] private string pokemonName;
    
    [TextArea]
    [SerializeField] private string pokemonDescription;

    //[SerializeField] private EggGroups eggGroup;
    [SerializeField] private Sprite pokemonSprite;
    [SerializeField] private Sprite backSprite;
    
    [SerializeField] private PokemonTypes pokemonType1;
    [SerializeField] private PokemonTypes pokemonType2;
    
    [Header ("Abilities")]
    //[SerializeField] private Abilities ability1;
    //[SerializeField] private Abilities ability2;
    //[SerializeField] private Abilities hiddenAbility;

    [SerializeField] private bool evolves;
    [SerializeField] private PokemonBase nextEvolve;
    
    
    [Header ("Base Stats")]
    [SerializeField] private int maxHp;
    [SerializeField] private int attack;
    [SerializeField] private int defense;
    [SerializeField] private int specialAttack;
    [SerializeField] private int specialDefense;
    [SerializeField] private int speed;
    
    
    [Header ("Move Sets")]
    [SerializeField] private List<LearnableMove> learnableMoves;
    
    [Serializable]
    public class LearnableMove
    {
        [SerializeField] public MoveBase moveBase;
        [SerializeField] public int level;
    }
    
    //--------------------------------------------------------------------------------
    
    // Properties
    public int NationalPokedexNumber => nationalPokedexNumber;
    public string PokemonName => pokemonName;
    public string PokemonDescription => pokemonDescription;
    
    //public EggGroups EggGroup => eggGroup;
    
    public Sprite PokemonSprite => pokemonSprite;
    public Sprite BackSprite => backSprite;
    
    public PokemonTypes PokemonType1 => pokemonType1;
    public PokemonTypes PokemonType2 => pokemonType2;
    
    //public Abilities Ability1 => ability1;
    //public Abilities Ability2 => ability2;
    //public Abilities HiddenAbility => hiddenAbility;
    
    public bool Evolves => evolves;
    public PokemonBase NextEvolve => nextEvolve;
    
    public int MaxHp => maxHp;
    public int Attack => attack;
    public int Defense => defense;
    public int SpecialAttack => specialAttack;
    public int SpecialDefense => specialDefense;
    public int Speed => speed;
    
    public List<LearnableMove> LearnableMoves => learnableMoves;
}
