// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class SummonCthuloidMonsterSpell : SummonMonsterSpell
{
    private SummonCthuloidMonsterSpell(SaveGame saveGame) : base(saveGame) { }
    protected override string SummonName(Monster monster) => "a Cthuloid entity";

    protected override int MaximumSummonCount(SaveGame saveGame) => 1;

    protected override MonsterSelector? MonsterSelector(Monster monster) => new CthuloidMonsterSelector();
}
