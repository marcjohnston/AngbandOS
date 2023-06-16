namespace AngbandOS.Core.TimedActions;

[Serializable]
internal class HeroismTimedAction : TimedAction
{
    public HeroismTimedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void EffectStopped()
    {
        SaveGame.MsgPrint("The heroism wears off.");
    }
    protected override void EffectIncreased(int newRate, int currentRate)
    {
        SaveGame.MsgPrint("You feel like a hero!");
    }
    protected override void Noticed()
    {
        SaveGame.UpdateBonusesFlaggedAction.Set();
        SaveGame.UpdateHealthFlaggedAction.Set();
        base.Noticed();
    }
}
