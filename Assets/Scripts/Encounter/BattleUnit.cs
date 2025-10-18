using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] public PokemonBase Base;
    [SerializeField] public int Level;
    [SerializeField] public bool isPlayerUnit;

    public Pokemon Pokemon;
    
    public void SetUp()
    {
        Pokemon = new Pokemon(Base, Level);
        GetComponent<Image>().sprite = isPlayerUnit ? Pokemon.Base.BackSprite : Pokemon.Base.PokemonSprite;
    }
}
