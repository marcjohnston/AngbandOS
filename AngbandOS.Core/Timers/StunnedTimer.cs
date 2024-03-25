// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Timers;

[Serializable]
internal class StunnedTimer : Timer
{
    private StunnedTimer(Game game) : base(game) { } // This object is a singleton.
    protected override void EffectStopped()
    {
        Game.MsgPrint("You are no longer stunned.");
    }
    protected override void OnRateIncreased(int newRate, int currentRate) 
    {
        switch (newRate)
        {
            case 1:
                Game.MsgPrint("You have been stunned.");
                break;

            case 2:
                Game.MsgPrint("You have been heavily stunned.");
                break;

            case 3:
                Game.MsgPrint("You have been knocked out.");
                break;
        }
        if (Game.DieRoll(1000) < newRate || Game.DieRoll(16) == 1)
        {
            Game.MsgPrint("A vicious Attack hits your head.");
            if (Game.DieRoll(3) == 1)
            {
                if (!Game.HasSustainIntelligence)
                {
                    Game.TryDecreasingAbilityScore(Ability.Intelligence);
                }
                if (!Game.HasSustainWisdom)
                {
                    Game.TryDecreasingAbilityScore(Ability.Wisdom);
                }
            }
            else if (Game.DieRoll(2) == 1)
            {
                if (!Game.HasSustainIntelligence)
                {
                    Game.TryDecreasingAbilityScore(Ability.Intelligence);
                }
            }
            else
            {
                if (!Game.HasSustainWisdom)
                {
                    Game.TryDecreasingAbilityScore(Ability.Wisdom);
                }
            }
        }
    }
    public override void ProcessWorld()
    {
        if (Value != 0)
        {
            int adjust = Game.AbilityScores[Ability.Constitution].ConRecoverySpeed + 1;
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
        Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
        base.Noticed();
    }
}
