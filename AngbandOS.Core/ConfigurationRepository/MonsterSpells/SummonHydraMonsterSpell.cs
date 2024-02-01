// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class SummonHydraMonsterSpell : SummonMonsterSpell
{
    private SummonHydraMonsterSpell(SaveGame saveGame) : base(saveGame) { }
    protected override string SummonName(Monster monster) => "hydras";

    protected override MonsterFilter? MonsterSelector(Monster monster) => SaveGame.SingletonRepository.MonsterFilters.Get(nameof(HydraMonsterFilter));
}
