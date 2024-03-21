// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class SummonKinMonsterSpell : SummonMonsterSpell
{
    private SummonKinMonsterSpell(SaveGame saveGame) : base(saveGame) { }
    /// <summary>
    /// Returns an empty string because all messages are overridden.
    /// </summary>
    protected override string SummonName(Monster monster)
    {
        string monsterPossessive = monster.PossessiveName;
        string kin = monster.Race.Unique ? "minions" : "kin";
        return $"{monsterPossessive} {kin}";
    }

    /// <summary>
    /// Returns a kin monster selector with the character of the original monster for summoning.
    /// </summary>
    /// <param name="monster"></param>
    /// <returns></returns>
    protected override IMonsterFilter? MonsterSelector(Monster monster) => new KinDynamicMonsterFilter(SaveGame, monster.Race.Symbol.Character);
}
