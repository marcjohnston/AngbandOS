// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterEffects;

[Serializable]
internal class OldHealMonsterEffect : AffectMonsterScript
{
    private OldHealMonsterEffect(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns the null because pets do not become unfriendly when hit with this projectile.
    /// </summary>
    protected override string? UnfriendPetMonsterFilterBindingKey => null;

    protected override bool Apply(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        if (seen)
        {
            obvious = true;
        }
        mPtr.SleepLevel = 0;
        mPtr.Health += dam;
        if (mPtr.Health > mPtr.MaxHealth)
        {
            mPtr.Health = mPtr.MaxHealth;
        }
        string? note = " looks healthier.";
        dam = 0;
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, null, 0);
        return obvious;
    }
}
