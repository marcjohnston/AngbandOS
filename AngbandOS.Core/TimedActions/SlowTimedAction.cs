namespace AngbandOS.Core.TimedActions;

[Serializable]
internal class SlowTimedAction : TimedAction
{
    public SlowTimedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void EffectStopped()
    {
        SaveGame.MsgPrint("You feel yourself speed up.");
    }
    protected override void EffectIncreased(int newRate, int currentRate)
    {
        SaveGame.MsgPrint("You feel yourself moving slower!");
    }
    protected override void Noticed()
    {
        SaveGame.UpdateBonusesFlaggedAction.Set();
        base.Noticed();
    }
}
