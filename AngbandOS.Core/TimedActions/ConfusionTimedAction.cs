namespace AngbandOS.Core.TimedActions;

[Serializable]
internal class ConfusionTimedAction : TimedAction
{
    public ConfusionTimedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void EffectStopped()
    {
        SaveGame.MsgPrint("You feel less confused now.");
    }
    protected override void EffectIncreased(int newRate, int currentRate)
    {
        SaveGame.MsgPrint("You are confused!");
    }
    protected override void Noticed()
    {
        SaveGame.RedrawConfusedFlaggedAction.Set();
        base.Noticed();
    }
}
