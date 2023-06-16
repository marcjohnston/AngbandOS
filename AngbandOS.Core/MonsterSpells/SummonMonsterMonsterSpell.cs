// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class SummonMonsterMonsterSpell : SummonMonsterSpell
{
    protected override string SummonName(Monster monster) => "help";

    /// <summary>
    /// Returns null, to summon any monster.
    /// </summary>
    protected override MonsterSelector? MonsterSelector(Monster monster) => null;

    /// <summary>
    /// Returns 1, to summon a single monster.
    /// </summary>
    protected override int MaximumSummonCount(SaveGame saveGame) => 1;
}
