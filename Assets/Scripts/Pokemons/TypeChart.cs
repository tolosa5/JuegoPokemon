
public class TypeChart
{
    private float[][] chart =
    {
        //                   NOR FIR WAT GRS ELK ICE FIG PSN GRD FLY PSY BUG RCK  GHO DRA DRK STL FRY
        /*Nm*/ new float[] { 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, .5f, 0f, 1f, 1f, .5f, 1 },
        /*Fr*/ new float[] { 1f, .5f, .5f, 2f, 1f, 2f, 1f, 1f, 1f, 1f, 1f, 2f, .5f, 1f, .5f, 1f, 2f, 1 },
        /*Wr*/ new float[] { 1f, 2f, .5f, .5f, 1f, 1f, 1f, 1f, 2f, 1f, 1f, 1f, 2f, 1f, .5f, 1f, 1f, 1 },
        /*Gr*/ new float[] { 1f, .5f, 2f, .5f, 1f, 1f, 1f, .5f, 2f, .5f, 1f, .5f, 2f, 1f, .5f, 1f, .5f, 1 },
        /*Ek*/ new float[] { 1f, 1f, 2f, .5f, .5f, 1f, 1f, 1f, 0f, 2f, 1f, 1f, 1f, 1f, .5f, 1f, 1f, 1 },
        /*Ic*/ new float[] { 1f, .5f, .5f, 2f, 1f, .5f, 1f, 1f, 2f, 2f, 1f, 1f, 1f, 1f, 2f, 1f, .5f, 1 },
        /*Fg*/ new float[] { 2f, 1f, 1f, 1f, 1f, 2f, 1f, .5f, 1f, .5f, .5f, .5f, 2f, 0f, 1f, 2f, 2f, .5f },
        /*Pn*/ new float[] { 1f, 1f, 1f, 2f, 1f, 1f, 1f, .5f, .5f, 1f, 1f, 1f, .5f, .5f, 1f, 1f, 0f, 2f },
        /*Gr*/ new float[] { 1f, 2f, 1f, .5f, 2f, 1f, 1f, 2f, 1f, 0f, 1f, .5f, 2f, 1f, 1f, 1f, 2f, 1 },
        /*Fl*/ new float[] { 1f, 1f, 1f, 2f, .5f, 1f, 2f, 1f, 1f, 1f, 1f, 2f, .5f, 1f, 1f, 1f, .5f, 1 },
        /*Ps*/ new float[] { 1f, 1f, 1f, 1f, 1f, 1f, 2f, 2f, 1f, 1f, .5f, 1f, 1f, 1f, 1f, 0f, .5f, 1 },
        /*Bg*/ new float[] { 1f, .5f, 1f, 2f, 1f, 1f, .5f, .5f, 1f, .5f, 2f, 1f, 1f, .5f, 1f, 2f, .5f, .5f },
        /*Rc*/ new float[] { 1f, 2f, 1f, 1f, 1f, 2f, .5f, 1f, .5f, 2f, 1f, 2f, 1f, 1f, 1f, 1f, .5f, 1 },
        //*Gh*/ new float[] { 0f, },
        //*Dr*/ new float[] { },
        //*Dr*/ new float[] {},
        //*St*/ new float[] {},
        //*Fy*/ new float[] {}
    };
    
    public static float GetEffectiveness(PokemonTypes attackType, PokemonTypes defenseType)
    {
        if (attackType == PokemonTypes.None || defenseType == PokemonTypes.None)
            return 1;
        
        int row = (int)attackType;
        int col = (int)defenseType;

        return new TypeChart().chart[row][col];
    }
}
