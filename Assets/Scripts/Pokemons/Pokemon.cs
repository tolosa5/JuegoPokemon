using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    public PokemonBase Base { get; private set; }
    public int Level {get; private set;}

    public int Hp;

    public List<Move> Moves { get; private set; }

    public Pokemon(PokemonBase pBase, int pLevel)
    {
        Base = pBase;
        Level = pLevel;
        Hp = MaxHp;
        
        //Moves inizialization
        Moves = new List<Move>();
        foreach (PokemonBase.LearnableMove learnableMove in Base.LearnableMoves)
        {
            if (learnableMove.level <= Level)
                Moves.Add(new Move(learnableMove.moveBase));

            if (Moves.Count >= 4)
                break;
        }
    }
    
    public int MaxHp => Mathf.FloorToInt((Base.MaxHp * Level) / 100f) + 10;
    public int Attack => Mathf.FloorToInt((Base.Attack * Level) / 100f) + 5;
    public int Defense => Mathf.FloorToInt((Base.Defense * Level) / 100f) + 5;
    public int SpecialAttack => Mathf.FloorToInt((Base.SpecialAttack * Level) / 100f) + 5;
    public int SpecialDefense => Mathf.FloorToInt((Base.SpecialDefense * Level) / 100f) + 5;
    public int Speed => Mathf.FloorToInt((Base.Speed * Level) / 100f) + 5;
}
