namespace AngbandOS.Core.TimedActions;

[Serializable]
internal class BlindnessTimedAction : TimedAction
{
    public BlindnessTimedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void EffectStopped()
    {
        SaveGame.MsgPrint("You can see again.");
    }
    protected override void EffectIncreased(int newRate, int currentRate)
    {
        SaveGame.MsgPrint("You are blind!");
    }
    protected override void Noticed()
    {
        SaveGame.RemoveLightFlaggedAction.Set();
        SaveGame.RemoveViewFlaggedAction.Set();
        SaveGame.UpdateLightFlaggedAction.Set();
        SaveGame.UpdateViewFlaggedAction.Set();
        SaveGame.UpdateMonstersFlaggedAction.Set();
        SaveGame.RedrawMapFlaggedAction.Set();
        SaveGame.RedrawBlindFlaggedAction.Set();
        base.Noticed();
    }
}
