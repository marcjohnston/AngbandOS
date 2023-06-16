namespace AngbandOS.Core.TimedActions;

[Serializable]
internal class FearTimedAction : TimedAction
{
    public FearTimedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void EffectStopped()
    {
        SaveGame.MsgPrint("You feel bolder now.");
    }
    protected override void EffectIncreased(int newRate, int currentRate)
    {
        SaveGame.MsgPrint("You are terrified!");
    }
    protected override void Noticed()
    {
        SaveGame.RedrawAfraidFlaggedAction.Set();
        base.Noticed();
    }
}
