namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class SummonKinMonsterSpell : SummonMonsterSpell
{
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
    protected override MonsterSelector? MonsterSelector(Monster monster) => new KinMonsterSelector(monster.Race.Character);
}
