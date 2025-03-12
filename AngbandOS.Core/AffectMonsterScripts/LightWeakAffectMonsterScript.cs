// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.AffectMonsterScripts;

[Serializable]
internal class LightWeakAffectMonsterScript : AffectMonsterScript
{
    private LightWeakAffectMonsterScript(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns the <see cref="HurtByLightMonsterFilter"/> because pets that are hurt by light will become unfriendly when hit with this projectile.
    /// </summary>
    protected override string? UnfriendPetMonsterFilterBindingKey => nameof(HurtByLightMonsterFilter);

    protected override bool Apply(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        string? note = null;
        string? noteDies = null;
        if (rPtr.HurtByLight)
        {
            if (seen)
            {
                obvious = true;
            }
            if (seen)
            {
                rPtr.Knowledge.Characteristics.HurtByLight = true;
            }
            note = " cringes from the light!";
            noteDies = " shrivels away in the light!";
        }
        else
        {
            dam = 0;
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, noteDies, 0);
        return obvious;
    }
}
