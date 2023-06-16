namespace AngbandOS.Core.TimedActions;

[Serializable]
internal class InfravisionTimedAction : TimedAction
{
    public InfravisionTimedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void EffectStopped()
    {
        SaveGame.MsgPrint("Your eyes stop tingling.");
    }
    protected override void EffectIncreased(int newRate, int currentRate)
    {
        SaveGame.MsgPrint("Your eyes begin to tingle!");
    }
    protected override void Noticed()
    {
        SaveGame.UpdateBonusesFlaggedAction.Set();
        SaveGame.UpdateMonstersFlaggedAction.Set();
        base.Noticed();
    }
}
