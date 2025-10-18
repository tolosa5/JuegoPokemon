
public class Move
{
    public MoveBase Base;
    public int CurrentPP;
    
    public Move(MoveBase moveBase)
    {
        Base = moveBase;
        CurrentPP = moveBase.PP;
    }
}
