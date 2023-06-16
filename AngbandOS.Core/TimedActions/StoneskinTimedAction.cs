namespace AngbandOS.Core.TimedActions;

[Serializable]
internal class StoneskinTimedAction : TimedAction
{
    public StoneskinTimedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void EffectStopped()
    {
        SaveGame.MsgPrint("Your skin returns to normal.");
    }
    protected override void EffectIncreased(int newRate, int currentRate)
    {
        SaveGame.MsgPrint("Your skin turns to stone.");
    }
    protected override void Noticed()
    {
        SaveGame.UpdateBonusesFlaggedAction.Set();
        base.Noticed();
    }
}
