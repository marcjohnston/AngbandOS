namespace AngbandOS.Core.TimedActions;

[Serializable]
internal class PoisonTimedAction : TimedAction
{
    public PoisonTimedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void EffectStopped()
    {
        SaveGame.MsgPrint("You are no longer poisoned.");
    }
    protected override void EffectIncreased(int newRate, int currentRate)
    {
        SaveGame.MsgPrint("You are poisoned!");
    }
    public override void ProcessWorld()
    {
        if (TurnsRemaining != 0)
        {
            int adjust = SaveGame.Player.AbilityScores[Ability.Constitution].ConRecoverySpeed + 1;
            AddTimer(-adjust);
        }
    }   
    protected override void Noticed()
    {
        SaveGame.RedrawPoisonedFlaggedAction.Set();
        base.Noticed();
    }
}
