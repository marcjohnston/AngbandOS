namespace AngbandOS.Core.TimedActions;

[Serializable]
internal class SuperHeroismTimedAction : TimedAction
{
    public SuperHeroismTimedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void EffectStopped()
    {
        SaveGame.MsgPrint("You feel less Berserk.");
    }
    protected override void EffectIncreased(int newRate, int currentRate)
    {
        SaveGame.MsgPrint("You feel like a killing machine!");
    }
    protected override void Noticed()
    {
        SaveGame.UpdateBonusesFlaggedAction.Set();
        SaveGame.UpdateHealthFlaggedAction.Set();
        base.Noticed();
    }
}
