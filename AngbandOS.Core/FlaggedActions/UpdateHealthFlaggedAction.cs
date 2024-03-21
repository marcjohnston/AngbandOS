// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class UpdateHealthFlaggedAction : FlaggedAction
{
    private UpdateHealthFlaggedAction(Game game) : base(game) { }
    protected override void Execute()
    {
        int bonus = Game.AbilityScores[Ability.Constitution].ConHealthBonus;
        int mhp = Game.PlayerHp[Game.ExperienceLevel.Value - 1] + (bonus * Game.ExperienceLevel.Value / 2);
        if (mhp < Game.ExperienceLevel.Value + 1)
        {
            mhp = Game.ExperienceLevel.Value + 1;
        }
        if (Game.HeroismTimer.Value != 0)
        {
            mhp += 10;
        }
        if (Game.SuperheroismTimer.Value != 0)
        {
            mhp += 30;
        }
        var mult = Game.SingletonRepository.Gods.Get(nameof(NathHorthahGod)).AdjustedFavour + 10;
        mhp *= mult;
        mhp /= 10;
        if (Game.MaxHealth.Value != mhp)
        {
            if (Game.Health.Value >= mhp)
            {
                Game.Health.Value = mhp;
                Game.FractionalHealth = 0;
            }
            Game.MaxHealth.Value = mhp;
        }
    }
}
