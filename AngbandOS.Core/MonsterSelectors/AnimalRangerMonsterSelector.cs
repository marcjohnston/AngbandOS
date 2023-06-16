namespace AngbandOS.Core.MonsterSelectors;

[Serializable]
internal class AnimalRangerMonsterSelector : MonsterSelector
{
    public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
    {
        return rPtr.Animal &&
                "abcflqrwBCIJKMRS".Contains(rPtr.Character.ToString()) &&
                !rPtr.Dragon &&
                !rPtr.Evil &&
                !rPtr.Undead &&
                !rPtr.Demon &&
                !rPtr.Cthuloid &&
                !rPtr.Unique &&
                rPtr.Spells.Count == 0;
    }
}
