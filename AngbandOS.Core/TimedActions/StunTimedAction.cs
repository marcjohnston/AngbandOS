namespace AngbandOS.Core.TimedActions;

[Serializable]
internal class StunTimedAction : TimedAction
{
    public StunTimedAction(SaveGame saveGame) : base(saveGame) { }
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
        if (Program.Rng.DieRoll(1000) < newRate || Program.Rng.DieRoll(16) == 1)
        {
            SaveGame.MsgPrint("A vicious Attack hits your head.");
            if (Program.Rng.DieRoll(3) == 1)
            {
                if (!SaveGame.Player.HasSustainIntelligence)
                {
                    SaveGame.Player.TryDecreasingAbilityScore(Ability.Intelligence);
                }
                if (!SaveGame.Player.HasSustainWisdom)
                {
                    SaveGame.Player.TryDecreasingAbilityScore(Ability.Wisdom);
                }
            }
            else if (Program.Rng.DieRoll(2) == 1)
            {
                if (!SaveGame.Player.HasSustainIntelligence)
                {
                    SaveGame.Player.TryDecreasingAbilityScore(Ability.Intelligence);
                }
            }
            else
            {
                if (!SaveGame.Player.HasSustainWisdom)
                {
                    SaveGame.Player.TryDecreasingAbilityScore(Ability.Wisdom);
                }
            }
        }
    }
    public override void ProcessWorld()
    {
        if (TurnsRemaining != 0)
        {
            int adjust = SaveGame.Player.AbilityScores[Ability.Constitution].ConRecoverySpeed + 1;
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
        SaveGame.UpdateBonusesFlaggedAction.Set();
        SaveGame.RedrawStunFlaggedAction.Set();
        base.Noticed();
    }
}
