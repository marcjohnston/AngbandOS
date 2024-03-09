// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.TimedActions;

[Serializable]
internal class StunTimedAction : TimedAction
{
    private StunTimedAction(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    protected override void EffectStopped()
    {
        SaveGame.MsgPrint("You are no longer stunned.");
    }
    protected override void EffectIncreased(int newRate, int currentRate) 
    {
        switch (newRate)
        {
            case 1:
                SaveGame.MsgPrint("You have been stunned.");
                break;

            case 2:
                SaveGame.MsgPrint("You have been heavily stunned.");
                break;

            case 3:
                SaveGame.MsgPrint("You have been knocked out.");
                break;
        }
        if (SaveGame.DieRoll(1000) < newRate || SaveGame.DieRoll(16) == 1)
        {
            SaveGame.MsgPrint("A vicious Attack hits your head.");
            if (SaveGame.DieRoll(3) == 1)
            {
                if (!SaveGame.HasSustainIntelligence)
                {
                    SaveGame.TryDecreasingAbilityScore(Ability.Intelligence);
                }
                if (!SaveGame.HasSustainWisdom)
                {
                    SaveGame.TryDecreasingAbilityScore(Ability.Wisdom);
                }
            }
            else if (SaveGame.DieRoll(2) == 1)
            {
                if (!SaveGame.HasSustainIntelligence)
                {
                    SaveGame.TryDecreasingAbilityScore(Ability.Intelligence);
                }
            }
            else
            {
                if (!SaveGame.HasSustainWisdom)
                {
                    SaveGame.TryDecreasingAbilityScore(Ability.Wisdom);
                }
            }
        }
    }
    public override void ProcessWorld()
    {
        if (TurnsRemaining != 0)
        {
            int adjust = SaveGame.AbilityScores[Ability.Constitution].ConRecoverySpeed + 1;
            AddTimer(-adjust);
        }
    }
    protected override int GetRate(int turns)
    {
        if (turns > 100)
        {
            return 3;
        }
        else if (turns > 50)
        {
            return 2;
        }
        else if (turns > 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    protected override void Noticed()
    {
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawStunFlaggedAction)).Set();
        base.Noticed();
    }
}
