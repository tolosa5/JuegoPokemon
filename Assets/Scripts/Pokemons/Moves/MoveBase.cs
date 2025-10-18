using UnityEngine;

[CreateAssetMenu(fileName = "MoveBase", menuName = "Moves/MoveBase")]
public class MoveBase : ScriptableObject
{
    [Header("Move Info")]
    [SerializeField] private string moveName;
    [TextArea]
    [SerializeField] private string moveDescription;
    
    [SerializeField] private PokemonTypes moveType;
    [SerializeField] private MoveCategory moveCategory;
    
    [SerializeField] private int power;
    [SerializeField] private int accuracy;
    [SerializeField] private int pp;
    
    // Properties
    public string MoveName => moveName;
    public string MoveDescription => moveDescription;
    public PokemonTypes MoveType => moveType;
    public MoveCategory MoveCategory => moveCategory;
    public int Power => power;
    public int Accuracy => accuracy;
    public int PP => pp;
}
