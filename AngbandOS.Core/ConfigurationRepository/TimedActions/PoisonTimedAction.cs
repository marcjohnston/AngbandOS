// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

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
            int adjust = SaveGame.AbilityScores[Ability.Constitution].ConRecoverySpeed + 1;
            AddTimer(-adjust);
        }
    }   
    protected override void Noticed()
    {
        SaveGame.SingletonRepository.FlaggedActions.Get<RedrawPoisonedFlaggedAction>().Set();
        base.Noticed();
    }
}
