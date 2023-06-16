namespace AngbandOS.Core.TimedActions;

[Serializable]
internal class HallucinationsTimedAction : TimedAction
{
    public HallucinationsTimedAction(SaveGame saveGame) : base(saveGame) { }

    protected override void EffectStopped()
    {
        SaveGame.MsgPrint("You can see clearly again.");
    }
    protected override void EffectIncreased(int newRate, int currentRate)
    {
        SaveGame.MsgPrint("Oh, wow! Everything looks so cosmic now!");
    }
    protected override void Noticed()
    {
        SaveGame.RedrawMapFlaggedAction.Set();
        SaveGame.UpdateMonstersFlaggedAction.Set();
        base.Noticed();
    }
}
