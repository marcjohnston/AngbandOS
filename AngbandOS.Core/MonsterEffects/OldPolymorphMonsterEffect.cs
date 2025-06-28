// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterEffects;

[Serializable]
internal class OldPolymorphMonsterEffect : MonsterEffect
{
    private OldPolymorphMonsterEffect(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns the <see cref="Any1In8MonsterFilter"/> because all pets will become unfriendly 1 time in 8 when hit with this projectile.
    /// </summary>
    protected override string? UnfriendPetMonsterFilterBindingKey => nameof(Any1In8MonsterFilter);

    protected override IdentifiedResultEnum Apply(int who, Monster mPtr, int dam, int r)
    {
        GridTile cPtr = Game.Map.Grid[mPtr.MapY][mPtr.MapX];
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        string? note = null;
        if (seen)
        {
            obvious = true;
        }
        bool doPoly = true;
        if (rPtr.Unique || rPtr.Level > Game.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 10)
        {
            note = " is unaffected!";
            doPoly = false;
            obvious = false;
        }
        dam = 0;
        if (rPtr.Unique)
        {
            doPoly = false;
        }
        if (rPtr.Guardian)
        {
            doPoly = false;
        }
        if (doPoly && Game.DieRoll(90) > rPtr.Level)
        {
            note = " is unaffected!";
            bool charm = mPtr.IsPet;
            int tmp = Game.PolymorphMonsterRace(mPtr.Race);
            if (tmp != mPtr.Race.Index)
            {
                note = " changes!";
                dam = 0;
                Game.DeleteMonsterByIndex(cPtr.MonsterIndex, true);
                MonsterRace race = Game.SingletonRepository.Get<MonsterRace>(tmp);
                Game.PlaceMonsterAux(mPtr.MapY, mPtr.MapX, race, false, false, charm);
                mPtr = Game.Monsters[cPtr.MonsterIndex];
            }
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, null, 0);
        return obvious ? IdentifiedResultEnum.True : IdentifiedResultEnum.False;
    }
}
