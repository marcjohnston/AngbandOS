// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class SummonMonstersMonsterSpell : SummonMonsterSpell
{
    private SummonMonstersMonsterSpell(SaveGame saveGame) : base(saveGame) { }
    protected override string SummonName(Monster monster) => "monsters";

    /// <summary>
    /// Returns 8, to summon upto 8 monsters.
    /// </summary>
    protected override int MaximumSummonCount(SaveGame saveGame) => 8;

    /// <summary>
    /// Returns null, for any monster to be summoned.
    /// </summary>
    protected override MonsterFilter? MonsterSelector(Monster monster) => null;

    protected override MonsterFilter? FriendlyMonsterSelector(Monster monster) => SaveGame.SingletonRepository.MonsterFilters.Get(nameof(NoUniquesMonsterFilter));
}
