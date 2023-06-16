namespace AngbandOS.Core.TimedActions;

[Serializable]
internal class BlessingTimedAction : TimedAction
{
    public BlessingTimedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void EffectStopped()
    {
        SaveGame.MsgPrint("The prayer has expired.");
    }
    protected override void EffectIncreased(int newRate, int currentRate)
    {
        SaveGame.MsgPrint("You feel righteous!");
    }
    protected override void Noticed()
    {
        SaveGame.UpdateBonusesFlaggedAction.Set();
        base.Noticed();
    }
}
