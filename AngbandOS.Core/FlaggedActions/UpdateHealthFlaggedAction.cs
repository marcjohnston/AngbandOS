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
        int bonus = SaveGame.Player.AbilityScores[Ability.Constitution].ConHealthBonus;
        int mhp = SaveGame.Player.PlayerHp[SaveGame.Player.Level - 1] + (bonus * SaveGame.Player.Level / 2);
        if (mhp < SaveGame.Player.Level + 1)
        {
            mhp = SaveGame.Player.Level + 1;
        }
        if (SaveGame.Player.TimedHeroism.TurnsRemaining != 0)
        {
            mhp += 10;
        }
        if (SaveGame.Player.TimedSuperheroism.TurnsRemaining != 0)
        {
            mhp += 30;
        }
        var mult = SaveGame.Player.Religion.GetNamedDeity(Pantheon.GodName.Nath_Horthah).AdjustedFavour + 10;
        mhp *= mult;
        mhp /= 10;
        if (SaveGame.Player.MaxHealth != mhp)
        {
            if (SaveGame.Player.Health >= mhp)
            {
                SaveGame.Player.Health = mhp;
                SaveGame.Player.FractionalHealth = 0;
            }
            SaveGame.Player.MaxHealth = mhp;
            SaveGame.RedrawHpFlaggedAction.Set();
        }
    }
}
