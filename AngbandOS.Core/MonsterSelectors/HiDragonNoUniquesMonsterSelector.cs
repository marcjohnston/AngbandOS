namespace AngbandOS.Core.MonsterSelectors;

[Serializable]
internal class HiDragonNoUniquesMonsterSelector : MonsterSelector
{
    public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
    {
        return rPtr.Character == 'D' && !rPtr.Unique;
    }
}
