// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class SummonReaverMonsterSpell : SummonMonsterSpell
{
    private SummonReaverMonsterSpell(SaveGame saveGame) : base(saveGame) { }
    protected override string SummonName(Monster monster) => "Black Reavers";

    protected override int MaximumSummonCount(SaveGame saveGame) => (saveGame.Difficulty / 50) + Program.Rng.DieRoll(6);

    protected override int SummonLevel(Monster monster) => 100;

    /// <summary>
    /// Returns null, because the Execute methods are overridden because Reavers can only be summoned via the SummonReaver method.
    /// </summary>
    /// <param name="monster"></param>
    /// <returns></returns>
    protected override MonsterSelector? MonsterSelector(Monster monster) => new ReaverMonsterSelector();
}
