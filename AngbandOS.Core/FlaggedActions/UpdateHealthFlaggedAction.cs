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
    public UpdateHealthFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        int bonus = SaveGame.AbilityScores[Ability.Constitution].ConHealthBonus;
        int mhp = SaveGame.PlayerHp[SaveGame.ExperienceLevel - 1] + (bonus * SaveGame.ExperienceLevel / 2);
        if (mhp < SaveGame.ExperienceLevel + 1)
        {
            mhp = SaveGame.ExperienceLevel + 1;
        }
        if (SaveGame.TimedHeroism.TurnsRemaining != 0)
        {
            mhp += 10;
        }
        if (SaveGame.TimedSuperheroism.TurnsRemaining != 0)
        {
            mhp += 30;
        }
        var mult = SaveGame.Religion.GetNamedDeity(Pantheon.GodName.Nath_Horthah).AdjustedFavour + 10;
        mhp *= mult;
        mhp /= 10;
        if (SaveGame.MaxHealth != mhp)
        {
            if (SaveGame.Health >= mhp)
            {
                SaveGame.Health = mhp;
                SaveGame.FractionalHealth = 0;
            }
            SaveGame.MaxHealth = mhp;
            SaveGame.RedrawHpFlaggedAction.Set();
        }
    }
}
