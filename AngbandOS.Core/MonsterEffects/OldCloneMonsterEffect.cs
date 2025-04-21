// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterEffects;

[Serializable]
internal class OldCloneMonsterEffect : MonsterEffect
{
    private OldCloneMonsterEffect(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns the <see cref="Any1In8MonsterFilter"/> because all pets will become unfriendly 1 time in 8 when hit with this projectile.
    /// </summary>
    protected override string? UnfriendPetMonsterFilterBindingKey => nameof(Any1In8MonsterFilter);

    protected override bool Apply(int who, Monster mPtr, int dam, int r)
    {
        GridTile cPtr = Game.Map.Grid[mPtr.MapY][mPtr.MapX];
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        string? note = null;
        bool isFriend = false;
        if (seen)
        {
            obvious = true;
        }
        if (mPtr.IsPet && Game.DieRoll(3) != 1)
        {
            isFriend = true;
        }
        mPtr.Health = mPtr.MaxHealth;
        if (mPtr.Speed < 150)
        {
            mPtr.Speed += 10;
        }
        Monster targetMonster = Game.Monsters[cPtr.MonsterIndex];
        if (Game.MultiplyMonster(targetMonster, isFriend, true))
        {
            note = " spawns!";
        }
        dam = 0;
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, null, 0);
        return obvious;
    }
}
