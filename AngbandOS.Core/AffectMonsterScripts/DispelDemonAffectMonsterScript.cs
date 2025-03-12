// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.AffectMonsterScripts;

[Serializable]
internal class DispelDemonAffectMonsterScript : AffectMonsterScript
{
    private DispelDemonAffectMonsterScript(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns the <see cref="DemonMonsterFilter"/> because demon pets will become unfriendly when hit with this projectile.
    /// </summary>
    protected override string? UnfriendPetMonsterFilterBindingKey => nameof(DemonMonsterFilter);

    protected override bool Apply(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        string noteDies = " dissolves!";
        string? note = null;
        if (rPtr.Demon)
        {
            if (seen)
            {
                rPtr.Knowledge.Characteristics.Demon = true;
                obvious = true;
            }
            note = " shudders.";
        }
        else
        {
            return false;
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, noteDies, 0);
        return obvious;
    }
}
